using Hotel.ATR.Portal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Hotel.ATR.Portal.Controllers
{
    public class RoomController : Controller
    {
        private IWebHostEnvironment hostEnv;
        public RoomController(IWebHostEnvironment hostEnv)
        {
            this.hostEnv = hostEnv;
        }
        public IActionResult Index(string email)
        {
            ViewBag.CurrentTime = DateTime.Now.ToString();
            TempData["CurrentTimeTD"] = DateTime.Now.ToString();
            return View((object) email);
        }

        public ContentResult IndexText()
        {
            string message = "some text";
            return Content(message, "text/plain", Encoding.Default);
        }

        //public ContentResult IndexBeep()
        //{
        //    string message = "some text";
        //    return Json(message, JsonRequestBehavior.AllowGet);
        //}

        public FileResult GetFile()
        {
            string path = Path.Combine(hostEnv.WebRootPath, "кот.jpg");

            return File("", "", "");
        }
        public IActionResult RoomList() {
            return View();
        }
        public IActionResult RoomDetails()
        {
            return View();
            //return View("Index");
        }

        [HttpPost]
        public async Task < IActionResult> CreateSubscribe(IFormFile photo, User user)
        {
            string path = Path.Combine(hostEnv.WebRootPath, photo.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }

            // var form = Request.Form;

            //return View("~/Views/Home/Privacy/cshtml");

            //return RedirectToAction("Index", "Room", new { email = user.email });

            return View("~/Views/Home/Privacy/cshtml");

            //return View("Index", new { email = user.email });
        }

    }
}
