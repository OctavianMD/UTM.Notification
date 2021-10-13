using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
using DataLayer.Enums;
using DataLayer.Repositories.Interfaces;

namespace BackOffice.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IGenericRepository<Receiver> _receiverRepository;

        public IndexModel(ILogger<IndexModel> logger, IGenericRepository<Receiver> receiverRepository)
        {
            _logger = logger;
            _receiverRepository = receiverRepository;
        }

        public async Task OnGet()
        {
            var receiver = await _receiverRepository.Add(new Receiver
            {
                Idnp = "22222",
                Name = "Octavian",
                Surname = "Godonoga",
                PreferredChannels = Channel.Email | Channel.Sms,
                Notifications = new List<Notification>()
            });
        }
    }
}
