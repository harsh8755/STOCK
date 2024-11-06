using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Drawing;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for IMAGE
/// </summary>
/// namespace CYS
namespace CYS
{

  public class ImageConverter1
  {
    public static byte[] ConvertImageToBytes(string imagePath)
    {
      try
      {
        // Read the image file into a byte array
        byte[] imageData = File.ReadAllBytes(imagePath);

        return imageData;
      }
      catch (Exception ex)
      {
        Console.WriteLine("An error occurred while converting the image to bytes: " + ex.Message);
        return null;
      }
    }
    public static System.Drawing.Image ConvertBytesToImage(byte[] imageData)
    {
      try
      {
        using (MemoryStream ms = new MemoryStream(imageData))
        {
          System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
          return image;
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("An error occurred while converting bytes to image: " + ex.Message);
        return null;
      }
    }
    public byte[] ConvertFileUploaderToByteArray(FileUpload fileUploader)
    {
      if (fileUploader.HasFile)
      {
        using (MemoryStream ms = new MemoryStream())
        {
          fileUploader.PostedFile.InputStream.CopyTo(ms);
          return ms.ToArray();
        }
      }

      return null; // or throw an exception, depending on your requirements
    }
        public byte[] ConvertFileUploaderToByteArray1(string imagePath)
        {
            byte[] imageData = File.ReadAllBytes(imagePath);


            return imageData; // or throw an exception, depending on your requirements
        }
    }

}
