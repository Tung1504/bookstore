using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Services
{

    public class UploadService
    {
        public const string PUBLISHER_AVATAR_PATH = "~/Storage/Publisher";

        public UploadService()
        {

        }

        public static void Upload(HttpPostedFileBase file, string disk)
        {                        
            if (file != null)
            {
                if (!Directory.Exists(HttpContext.Current.Server.MapPath(disk)))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(disk));
                }
                
                string fileName = Path.GetFileName(file.FileName);
                string storagePath = Path.Combine(HttpContext.Current.Server.MapPath(disk), fileName);
                file.SaveAs(storagePath);
            }
            
        }
    }
}