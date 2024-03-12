using System;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;

namespace ScannerApp
{
    public partial class Move : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScanValue.Focus();

            if (!IsPostBack)
            {
                lblScanDirection.Text = "Scan Location or Item";
            }
        }

        protected void ScanValue_TextChanged(object sender, EventArgs e)
        {
            // get the scanner id
            HiddenField myGUID = (HiddenField)Page.Master.FindControl("hfSCannerID");
            string myScan = ScanValue.Text;

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + myGUID.Value + "\"}";

            var url = "https://them.solutioncreators.com/api/api/Move";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            try
            {


                JObject result = JObject.Parse(PostJSONMessage);
                string myResponse = (string)result["messageOut"];
                string myButtons = (string)result["useButtons"];

                lblResponseMessage.Text = myResponse;

                ScanValue.Text = "";

                // give them the next direction
                switch (myResponse)
                {
                    case "Raw Material Scan Received.":
                        lblScanDirection.Text = "Scan Location";
                        break;
                    case "Location Scan Received.":
                        lblScanDirection.Text = "Scan Item";
                        break;
                    case "Raw Material Not Expected. Cancel previous scan?":
                        lblScanDirection.Text = "Scan Location";
                        break;
                    case "Location Not Expected. Cancel previous scan?":
                        lblScanDirection.Text = "Scan Item";
                        break;
                    case "Barcode Already Scanned!":
                        lblScanDirection.Text = "Scan Location";
                        break;
                    case "Location Already Scanned!":
                        lblScanDirection.Text = "Scan Item";
                        break;
                    default:
                        lblScanDirection.Text = "Scan Location or Item";
                        break;
                }
            }
            catch
            {
                lblResponseMessage.Text = PostJSONMessage;
            }
        }
        
    }

}

