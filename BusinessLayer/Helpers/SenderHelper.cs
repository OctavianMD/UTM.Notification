using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Mapper;
using BusinessLayer.Validators;
using CommonLayer.ApiModels;
using CommonLayer.ViewModels;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BusinessLayer.Helpers
{
    public sealed class SenderHelper
    {
        private readonly IGenericRepository<Sender> _senderRepository;

        public SenderHelper(IGenericRepository<Sender> senderRepository)
        {
            _senderRepository = senderRepository;
        }

        public async Task<SenderViewModel> Get(int id)
        {
            var senders = await _senderRepository.Get(x => x.Id == id);
            return senders?.ToViewModel();
        }

        public async Task<List<SenderViewModel>> GetAll()
        {
            var senders = await _senderRepository.GetAll(x=>true);
            return senders.ToViewModel();
        }

        public async Task<SenderViewModel> Create(SenderViewModel model)
        {
            if (model.IsValid())
            {
                var sender =  await _senderRepository.Add(model.ToEntity());
                return sender.ToViewModel();
            }
            return null;
        }

        public async Task Update(SenderViewModel model)
        {
            if (model.IsValid())
            {
                await _senderRepository.Update(model.ToEntity());
            }
            throw new ArgumentOutOfRangeException("SenderViewModel", model, "Model is not valid");
        }

        public async Task Remove(SenderViewModel model)
        {
            await _senderRepository.Remove(model.ToEntity());
        }

        public async Task<int> ProcessFetchedData(string result)
        {
            if (string.IsNullOrWhiteSpace(result))
                return 0;

            var senders = JsonConvert.DeserializeObject<List<SenderApi>>(result);

            if (senders == null)
                return 0;
            var counter = 0;
            foreach (var sender in senders)
            {
                if (sender.IsValid() || await _senderRepository.Any(x =>
                        x.Name == sender.Name && x.Service == sender.Service))
                    continue;
                await _senderRepository.Add(sender.ToEntity());
                counter++;
            }
            return counter;
        }
    }
}
