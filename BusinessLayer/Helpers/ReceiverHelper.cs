using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Mapper;
using BusinessLayer.Validators;
using CommonLayer.ApiModels;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using Newtonsoft.Json;

namespace BusinessLayer.Helpers
{
    public sealed class ReceiverHelper
    {
        private readonly IGenericRepository<Receiver> _receiverRepository;

        public ReceiverHelper(IGenericRepository<Receiver> receiverRepository)
        {
            _receiverRepository = receiverRepository;
        }

        public async Task<int> ProcessFetchedData(string result)
        {
            if (string.IsNullOrWhiteSpace(result))
                return 0;
            
            var receivers = JsonConvert.DeserializeObject<List<ReceiverApi>>(result);
            
            if (receivers == null)
                return 0;
            var counter = 0;
            foreach (var receiver in receivers)
            {
                if( !receiver.IsValid() && !await _receiverRepository.Any(x => x.Idnp == receiver.Idnp))
                    continue;
                await _receiverRepository.Add(receiver.ToEntity());
                counter++;
            }
            return counter;
        }
    }
}
