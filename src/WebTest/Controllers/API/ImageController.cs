using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace WebTest.Controllers.API
{
    public class ImageController : ApiController
    {
       
        [Route("api/image/{id}/appdata")]
        public HttpResponseMessage Get(string id)
        {
            string path = HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data/Images/" + id + ".jpg"); ;
            Image img = Bitmap.FromFile(path);
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new ByteArrayContent(ms.ToArray());
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                return result;
            }
        }

        [Route("api/image/{id}/blob")]
        public HttpResponseMessage GetBlob(string id)
        {
            string path = HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data/Images/" + id + ".jpg"); ;
            Image img = Bitmap.FromFile(path);
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new ByteArrayContent(ms.ToArray());
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                return result;
            }
        }

        /*
        [HttpGet]
        public IActionResult Get()
        {
            
            Byte[] b = System.IO.File.ReadAllBytes(@"E:\\Test.jpg");   // You can use your own method over here.         
            return File(b, "image/jpeg");
        }
        */
    }
}
