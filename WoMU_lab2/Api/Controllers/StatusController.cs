namespace Api.Controllers {

using System.Web.Mvc;

public class StatusController : Controller {
    public ActionResult Index() {
        ViewBag.Title = "Controller Unit for New Tasks (C.U.N.T)";

        var db = new Database1Entities();
        return View(db);
    }
}

}
