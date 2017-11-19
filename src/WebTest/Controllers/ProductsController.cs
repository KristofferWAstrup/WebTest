using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTest.Infrastructure.Data;
using WebTest.Infrastructure.Data.Models;
using WebTest.Models;
using WebTest.Models.Products;

namespace WebTest.Controllers
{
    public class ProductsController : Controller
    {
        
        public ActionResult Index(string id)
        {
            var model = new ProductIndexModel();

            using (var repos = new ProductRepository())
            {
                model.Products = id == null || id.Length > 2? repos.GetAll() : repos.GetAll(Convert.ToInt32(id.Substring(0,2)), Convert.ToInt32(id.Substring(2, id.Length-2)));
            }

            return View(model);
        }

        public ActionResult Inspect(Guid id)
        {
            using (var repos = new ProductRepository())
            {
                var product = repos.Get(id);

                var model = new ProductInspectModel
                {
                    Product = product
                };

                return View(model);
            }
           
        }

        public ActionResult ImgToFile(Image img)
        {
            using (var strm = new MemoryStream())
            {
                img.Save(strm, ImageFormat.Png);
                return File(strm, "image/png");
            }
        }

    }
}