using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Helpers;

namespace BlogHomekit.Services
{
    public class UploadImageFileService
    {

        public string UploadImage(WebImage imagen, int dimensionMaxima)
        {
            if (imagen == null || !imagen.FileName.TerminaConUnaExtensionDeImagenValida())
            {
                return string.Empty;
            }

            WebImage imagenRedimensionada = RedimensionarImagen(imagen, dimensionMaxima);

            //string nombreUnico = GenerarUnNombreUnico(imagen.FileName);

            string nombreUnico = GenerarUnNombreUnico(Path.GetFileName(imagen.FileName));

            //GuardarImagenEnAzure(imagenRedimensionada, ImageHelper.DirectorioImagenes, nombreUnico);
            GuardarImagenEnAzure(imagenRedimensionada, nombreUnico);

            return nombreUnico;
        }

        private WebImage RedimensionarImagen(WebImage imagen, int dimensionMaxima)
        {
            bool isWide = imagen.Width > imagen.Height;
            int bigestDimension = isWide ? imagen.Width : imagen.Height;

            if (bigestDimension > dimensionMaxima)
            {
                if (isWide)
                    imagen.Resize(dimensionMaxima, ((dimensionMaxima * imagen.Height) / imagen.Width));
                else
                    imagen.Resize(((dimensionMaxima * imagen.Width) / imagen.Height), dimensionMaxima);
            }

                return imagen;
         }

        private string GenerarUnNombreUnico(string filename)
        {
            Match matchGuid = Regex.Match(filename, @"([a-z0-9]{8}[-][a-z0-9]{4}[-][a-z0-9]{4}[-][a-z0-9]{4}[-][a-z0-9]{12}[_])");

            if (matchGuid.Success)
            {
                filename = filename.Replace(matchGuid.Value, string.Empty);
            }

            return $"{Guid.NewGuid()}_{filename}".ToLower();
        }

        private void GuardarImagenEnAzure(WebImage image,  string fileName)
        {
            //CloudBlobContainer storagecontainer = azurestorageservice.obtenerblobcontainer();
            //string blobname = azurestorageservice.getblobname(Path, fileName);
            //storagecontainer.subirimagen(blobname, image);

            CloudBlobContainer storageContainer = AzureStorageService.GetBlobContainer();
            storageContainer.UploadImage(fileName, image);
        }

        private void GuardarImagenEnServidor(WebImage image, string path, string fileName)
        {
            image.Save(Path.Combine("~" + path + fileName));
            image = null;
        }

    }



}
