using Microsoft.AspNetCore.Mvc;
using SPSX.CORE.FMEA.API.Implementation;
using SPSX.CORE.FMEA.API.Interfaces;

namespace SPSX.CORE.FMEA.Controllers.Forms
{
    public class ControlMethodFormController : Controller
    {
        private IControlMethodForm form;

        public ControlMethodFormController(IControlMethodForm _form)
        {
            form = _form;
        }
        public ActionResult Index()
        {
            return View("Index", form.GetMessage());
        }
    }
}