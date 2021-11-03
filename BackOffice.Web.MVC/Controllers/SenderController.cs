using System.Threading.Tasks;
using BusinessLayer.Helpers;
using Microsoft.AspNetCore.Mvc;


namespace BackOffice.Web.MVC.Controllers
{
    public class SenderController : Controller
    {
        private readonly SenderHelper _senderHelper;

        public SenderController(SenderHelper senderHelper)
        {
            _senderHelper = senderHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _senderHelper.GetAll());
        }
    }
}
