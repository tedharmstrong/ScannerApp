using System;
using System.Web;
using Newtonsoft.Json.Linq;

namespace ScannerApp
{
    public partial class Logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScanValue.Focus();

            if (!IsPostBack)
            {

                // get the inital value for lblScanDirection
                // get the scanner id
                HttpCookie ScannerID = Request.Cookies["ScannerID"];
                string myScan = ScanValue.Text;

                string myjson = "{\"scannerID\":\"" + ScannerID.Value + "\",\"pageName\":\"Logon\"}";


                var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "PageText";

                //string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

                //try
                //{
                //    JObject result = JObject.Parse(PostJSONMessage);
                //    lblTitle.Text = (string)result["pageTitle"];
                //    lblScanDirection.Text = (string)result["pageInstruction"];
                    
                //}
                //catch
                //{
                //    lblResponseMessage.Text = PostJSONMessage;
                //    lblScanDirection.Text = "";
                //}

            }

        }

        protected void ScanValue_TextChanged(object sender, EventArgs e)
        {
            // get the scanner id
            HttpCookie ScannerID = Request.Cookies["ScannerID"];
            string myScan = ScanValue.Text;

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\",\"cancelScan\":\"\"}";


            var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "Logon";

            //string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            //try
            //{
            //    // clear out the value of the scan
            //    ScanValue.Text = "";

            //    JObject result = JObject.Parse(PostJSONMessage);
            //    string myResponse = (string)result["messageOut"];
            //    string myNextStep = (string)result["nextSteps"];

            //    // testing
            //    myResponse = "Active";

            //    if (myResponse == "Active")
            //    {
            //        Response.Redirect("Default");
            //    }

            //}
            //catch
            //{
            //    lblResponseMessage.Text = PostJSONMessage;
            //    lblScanDirection.Text = "";
            //}
            Response.Redirect("Default");
        }

    }
}