using System;
using System.Web.Helpers;
using System.Web;
using BlogHomekit.Services.Configuration;

namespace BlogHomekit.Services
{
    public static class ImageHelper
    {
        public static bool TerminaConUnaExtensionDeImagenValida(this string fileName)
        {
            return fileName.EndsWith(".jpg", StringComparison.CurrentCultureIgnoreCase) ||
                   fileName.EndsWith(".gif", StringComparison.CurrentCultureIgnoreCase) ||
                   fileName.EndsWith(".png", StringComparison.CurrentCultureIgnoreCase) ||
                   fileName.EndsWith(".JPG", StringComparison.CurrentCultureIgnoreCase) ||
                   fileName.EndsWith(".GIF", StringComparison.CurrentCultureIgnoreCase) ||
                   fileName.EndsWith(".PNG", StringComparison.CurrentCultureIgnoreCase);
        }

        public static WebImage ToWebImage(this HttpPostedFileBase postedFile)
        {
            if (postedFile == null) return null;

            var image = new WebImage(postedFile.InputStream)
            {
                FileName = postedFile.FileName
            };
            return image;
        }

        public static string GenerateImageUrl(this string relativeFilePath)
        {
            return string.Format("{0}/{1}",
               WebConfigParameter.UrlPathImages,
               relativeFilePath);
        }

    }
}
