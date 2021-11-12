using System.Dynamic;
using System.Threading.Tasks;
using CommonLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;


namespace BackOffice.Web.MVC.Controllers
{
    public class SenderController : Controller
    {
        private readonly ISenderService _senderService;

        public SenderController(ISenderService senderService)
        {
            _senderService = senderService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _senderService.GetAll());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(SenderViewModel model)
        {
            await _senderService.Create(model);
            return View("Index", await _senderService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _senderService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SenderViewModel model)
        {
            await _senderService.Update(model);
            return View("Index", await _senderService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _senderService.Remove(id);
            return View("Index", await _senderService.GetAll());
        }

        [HttpGet]
        public async Task<JsonResult> JsDelete(int id)
        {
            //ToDO bug with id = 0 
            await _senderService.Remove(id);

            dynamic response = new ExpandoObject();
            response.success = true;
            response.id = id;

            return new JsonResult(response);
        }

    }
}
