using System.Threading.Tasks;
using BackOffice.Web.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace BackOffice.Web.MVC.Controllers
{
    public class FetchDataController : Controller
    {
        private readonly IFetchDataService _fetchDataService;

        public FetchDataController(IFetchDataService fetchDataService)
        {
            _fetchDataService = fetchDataService;
        }

        public IActionResult Index()
        {
            return View(new FetchDataModel());
        }

        public async Task<IActionResult> FetchSenders()
        {
            var result = await _fetchDataService.FetchSenders();
            return View("Index", new FetchDataModel
            {
                IsFetched = true,
                Message = $"Successfully fetched {result} senders"
            });
        }

        public async Task<IActionResult> FetchReceivers()
        {
            var result = await _fetchDataService.FetchReceivers();
            return View("Index", new FetchDataModel
            {
                IsFetched = true,
                Message = $"Successfully fetched {result} receivers"
            });
        }
    }
}
