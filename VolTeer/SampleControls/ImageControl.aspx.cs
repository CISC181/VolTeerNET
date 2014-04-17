using System;
using System.Linq;
using System.IO;
using Telerik.Web.UI;
using Telerik.Web.UI.ImageEditor;

namespace VolTeer.SampleControls
{
    public partial class ImageControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

     protected void AsyncUpload1_FileUploaded(object sender, FileUploadedEventArgs e)

     {
        //Clear changes and remove uploaded image from Cache
        RadImageEditor1.ResetChanges();
        Context.Cache.Remove(Session.SessionID + "UploadedFile");
        using (Stream stream = e.File.InputStream)
           {
           byte[] imgData = new byte[stream.Length];
           stream.Read(imgData, 0, imgData.Length);
           MemoryStream ms = new MemoryStream();
           ms.Write(imgData, 0, imgData.Length);
 
           Context.Cache.Insert(Session.SessionID + "UploadedFile", ms, null, DateTime.Now.AddMinutes(20), TimeSpan.Zero);
           }
     }


     protected void RadImageEditor1_ImageLoading(object sender, ImageEditorLoadingEventArgs args)
     {
         //Handle Uploaded images
         if (!Object.Equals(Context.Cache.Get(Session.SessionID + "UploadedFile"), null))
         {
             using (EditableImage image = new EditableImage((MemoryStream)Context.Cache.Get(Session.SessionID + "UploadedFile")))
             {
                 args.Image = image.Clone();
                 args.Cancel = true;
             }
         }
     }
    }
}