using System;
using System.Web;
using Newtonsoft.Json.Linq;


namespace ScannerApp
{
    public partial class Physical : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScanValue.Focus();

        }

        protected void ScanValue_TextChanged(object sender, EventArgs e)
        {
            // get the scanner id
            HttpCookie ScannerID = Request.Cookies["ScannerID"];
            string myScan = ScanValue.Text;

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\"}";

            var url = "https://them.solutioncreators.com/api/api/Inventory";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            try
            {
                JObject result = JObject.Parse(PostJSONMessage);
                string myResponse = (string)result["messageOut"];
                string myButtons = (string)result["useButtons"];
                string myNextStep = (string)result["nextSteps"];

                lblResponseMessage.Text = myResponse;
                lblScanDirection.Text = myNextStep;
                ScanValue.Text = "";

            }
            catch
            {
                lblResponseMessage.Text = PostJSONMessage;
                lblScanDirection.Text = "";
            }
        }
    }
}