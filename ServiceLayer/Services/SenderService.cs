using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Helpers;
using CommonLayer.ViewModels;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class SenderService: ISenderService
    {
        private readonly ILogger<SenderService> _logger;
        private readonly SenderHelper _senderHelper;

        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            MaxDepth = 4,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
            
        public SenderService(ILogger<SenderService> logger, SenderHelper senderHelper)
        {
            _logger = logger;
            _senderHelper = senderHelper;
        }

        public async Task<SenderViewModel> Get(int id)
        {
            try
            {
                _logger.LogInformation($"Get Sender by id:{id}");
                var sender = await _senderHelper.Get(id);
                if (sender == null)
                {
                    _logger.LogWarning($"Sender: {id} does not exist.");
                }
                return sender;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting Sender: {id}");
            }
            return new SenderViewModel();
        }

        public async Task<List<SenderViewModel>> GetAll()
        {
            _logger.LogInformation("Getting all Senders");
            return await _senderHelper.GetAll();
        }

        public async Task Create(SenderViewModel model)
        {
            try
            {
                _logger.LogInformation("Add new Sender");
                var sender = await _senderHelper.Create(model);
                if (sender == null)
                {
                    _logger.LogWarning($"Sender is not valid.  Details: { JsonConvert.SerializeObject(model, SerializerSettings)}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,$"Error adding Sender. Details: { JsonConvert.SerializeObject(model, SerializerSettings)}");
            }
        }

        public async Task Update(SenderViewModel model)
        {
            try
            {
                _logger.LogInformation($"Update Sender:{model.Id}");
                await _senderHelper.Update(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error update Sender. Details: { JsonConvert.SerializeObject(model, SerializerSettings)}");
            }
        }

        public async Task Remove(int id)
        {
            try
            {
                _logger.LogInformation($"Remove Sender:{id}");
                var model = await _senderHelper.Get(id);
                await _senderHelper.Remove(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error remove Sender: {id}");
            }
        }
    }
}
