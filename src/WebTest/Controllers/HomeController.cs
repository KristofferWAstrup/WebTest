using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTest.Infrastructure.Data;
using WebTest.Infrastructure.Data.Models;

namespace WebTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

     
        private void AddStuff()
        {
            using (var repos = new ProductRepository())
            {
                repos.Add(new Product
                {
                    Title = "Silvica Sofabord 50x50",
                    Description = "Flot sofabord i klassisk design udført i egetræ med elegant afrundet bordplade og praktisk hylde. De skrå ben er lavet af massivt egetræ, hvilket sikrer god stabilitet og lang holdbarhed. Giv dit hjem et naturligt og indbydende udtryk med dette tidløse kvalitets sofabord.",
                    Price = 2.199M,
                    ImagePaths = new List<string>
                    {
                        "https://kwastorage.blob.core.windows.net/imagecontainer/explorer_bord_0.jpg",
                        "https://kwastorage.blob.core.windows.net/imagecontainer/explorer_bord_1.jpg"
                    }
                });
            }
        }

    }
}