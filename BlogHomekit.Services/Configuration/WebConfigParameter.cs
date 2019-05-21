using System.Configuration;

namespace BlogHomekit.Services.Configuration
{
   public static class WebConfigParameter
    {
        public static string StorageConnectionString => ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString;

        public static string BlobAzureContainerName => ConfigurationManager.AppSettings["BlobAzureContainerName"];
        public static string UrlPathImages => ConfigurationManager.AppSettings["UrlPathImages"];
    }
}
