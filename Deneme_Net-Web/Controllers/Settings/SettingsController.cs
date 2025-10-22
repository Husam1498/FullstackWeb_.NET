using Microsoft.AspNetCore.Mvc;

namespace Deneme_Net_Web.Controllers.Settings
{
    public class SettingsController : Controller
    {
        public IActionResult SettingsIndex()
        {
            return PartialView("_SettingsIndex");
        }
    }
}
