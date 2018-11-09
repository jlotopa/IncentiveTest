using System.Web.Mvc;

using IncentiveTest.Methods;

namespace IncentiveTest.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            string url = "http://www.incentive.cl:8004/Api/Clientes";
            var a = WebResponse.GetAllClients(url);
            return View(a);
        }

        public ActionResult Details(int id)
        {
            string url = "http://www.incentive.cl:8004/Api/Clientes?id=" + id;
            var model = WebResponse.GetCliente(url);
            return View(model);
        }
    }
}