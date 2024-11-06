using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ZXing;
using System.Web.Services;

public partial class scanner : System.Web.UI.Page
{
    [WebMethod]
    public static string ProcessBarcode(string barcodeValue)
    {
        // Process the barcode (e.g., save it, display on UI, etc.)
        return String.Format("Barcode received: {0}", barcodeValue);
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (fileUpload.HasFile)
        {
            try
            {
                // Convert uploaded file to a Bitmap
                using (var uploadedImage = new Bitmap(fileUpload.PostedFile.InputStream))
                {
                    // Initialize barcode reader
                    var barcodeReader = new BarcodeReader();
                    var result = barcodeReader.Decode(uploadedImage);

                    if (result != null)
                    {
                        // Set the hidden field value to the scanned barcode
                        hfBarcodeResult.Value = result.Text;
                    }
                    else
                    {
                        hfBarcodeResult.Value = "No barcode detected.";
                    }
                }
            }
            catch (Exception ex)
            {
                hfBarcodeResult.Value = "Error reading barcode: " + ex.Message;
            }
        }
    }
}