using System.Collections.Generic;
using CommonLayer.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BackOffice.API.Controllers
{
    [ApiController]
    [Route("api/dataseed")]
    public class DataSeedController : ControllerBase
    {
        private readonly ILogger<DataSeedController> _logger;

        public DataSeedController(ILogger<DataSeedController> logger)
        {
            _logger = logger;
        }

        [HttpGet("senders")]
        public List<SenderApi> Senders()
        {
            _logger.LogInformation("Getting senders");
            return new List<SenderApi>
            {
                new SenderApi
                {
                    Name = "Serviciul fiscal de stat",
                    Service = "SFS01"
                },
                new SenderApi
                {
                    Name = "Serviciul fiscal de stat",
                    Service = "SFS02"
                },
                new SenderApi
                {
                    Name = "Serviciul fiscal de stat",
                    Service = "SFS03"
                }
            };
        }

        [HttpGet("receivers")]
        public List<ReceiverApi> Receivers()
        {
            _logger.LogInformation("Getting receivers");
            return new List<ReceiverApi>
            {
                new ReceiverApi
                {
                    Name = "Octavian",
                    Surname = "Godonoga",
                    Idnp = "1111111111111",
                    Email = "og@gmail.com"
                },
                new ReceiverApi
                {
                    Name = "Valeria",
                    Surname = "Cebotari",
                    Idnp = "2222222221111",
                    Email = "vc@gmail.com"
                },
                new ReceiverApi
                {
                    Name = "Sandu",
                    Surname = "Chiriță",
                    Idnp = "3333333333111",
                    Email = "sc@gmail.com"
                }
            };
        }
    }
}
