using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackOffice.Web.Pages
{
    public class FetchDataModel : PageModel
    {
        private readonly ILogger<FetchDataModel> _logger;

        public FetchDataModel(ILogger<FetchDataModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
