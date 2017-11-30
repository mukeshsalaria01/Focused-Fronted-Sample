using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FocusedFrontendSample.Controllers
{
    public class FileUploadController : ApiController
    {

        [HttpPost]
        public KeyValuePair<bool, string> UploadFile()
        {
            try
            {
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    // Get the uploaded image from the Files collection
                    var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

                    if (httpPostedFile != null)
                    {
                        if (httpPostedFile.ContentType.Contains("image"))
                        {
                            // Get the complete file path
                            var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadedFiles"), httpPostedFile.FileName);

                            // Save the uploaded file to "UploadedFiles" folder
                            httpPostedFile.SaveAs(fileSavePath);

                            return new KeyValuePair<bool, string>(true, "Image uploaded successfully.");
                        }
                        else
                        {
                            return new KeyValuePair<bool, string>(false, "Please select an image.");
                        }
                        // Validate the uploaded image(optional)
                    }

                    return new KeyValuePair<bool, string>(true, "Could not get the uploaded image.");
                }

                return new KeyValuePair<bool, string>(true, "No image found to upload.");
            }
            catch (Exception ex)
            {
                return new KeyValuePair<bool, string>(false, "An error occurred while uploading. Error Message: " + ex.Message);
            }
        }
    }
}
