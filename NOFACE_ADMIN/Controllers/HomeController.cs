using System.Web.Mvc;

namespace NOFACE_ADMIN.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
    }
}