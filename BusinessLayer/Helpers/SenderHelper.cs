using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Mapper;
using BusinessLayer.Validators;
using CommonLayer.ApiModels;
using DataLayer.Entities;
using DataLayer.Enums;
using DataLayer.Repositories.Interfaces;
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
                if(sender.IsValid() || await _senderRepository.Any(x =>
                       x.Name == sender.Name && x.Service == sender.Service))
                    continue;
                await _senderRepository.Add(sender.ToEntity());
                counter++;
            }
            return counter;
        }
    }
}
