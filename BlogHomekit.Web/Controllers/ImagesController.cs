using System;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using BlogHomekit.Services;
using Microsoft.Ajax.Utilities;

namespace BlogHomekit.Web.Controllers
{
   // [Authorize]
    public class ImagesController : Controller
    {
        private readonly UploadImageFileService _imagenServicio;

        public ImagesController()
            : this(new UploadImageFileService())
        {
        }

        public ImagesController(UploadImageFileService imagenServicio)
        {
            _imagenServicio = imagenServicio;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SubirImagen(HttpPostedFileBase upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            if (upload == null)
                return Content("Selecciona una imagen");

            if (!upload.FileName.TerminaConUnaExtensionDeImagenValida())
                return Content("Selecciona una archivo jpg, gif o png");

            WebImage imagen = upload.ToWebImage();

            string filename = _imagenServicio.UploadImage(imagen, dimensionMaxima: 1000);

            string respuestaCkEditor = createResponseForCkEditor(filename, CKEditorFuncNum);

            return Content(respuestaCkEditor);
        }
       
       

        private string createResponseForCkEditor(string fileName, string ckEditorFuncNum)
        {
            if (String.IsNullOrEmpty(fileName))
            {
                return createErrorMessageForCkEditor(ckEditorFuncNum, "Error: No se ha guardado la imagen correctamente.");
            }

            var url = (fileName).GenerateImageUrl();

            return CreateOKMessageforCkEditor(ckEditorFuncNum, url);
        }

        private string createErrorMessageForCkEditor(string ckEditorFuncNum, string message)
        {
            var url = Request.Url.GetLeftPart(UriPartial.Authority);
            return @"<html><body><script>window.parent.CKEDITOR.tools.callFunction(" + ckEditorFuncNum + ", \"" +
                url + "\", \"" + message + "\");</script></body></html>";
        }

        private string CreateOKMessageforCkEditor(string ckEditorFuncNum, string url)
        {
            return @"<html><body><script>window.parent.CKEDITOR.tools.callFunction(" + ckEditorFuncNum +
                        ", \"" + url + "\", function() { " +

           "var element, dialog = this.getDialog();" +
           "if (dialog.getName() == 'image')" +
           "{" +

               "element = dialog.getContentElement('advanced', 'txtGenClass');" +
               "if (element)" +
                   "element.setValue('img-responsive');" +

           "}" +
           "});</script></body></html>";
        }
    }
}