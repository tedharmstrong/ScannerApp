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

        }

        protected void ScanValue_TextChanged(object sender, EventArgs e)
        {
            // get the scanner id
            HttpCookie ScannerID = Request.Cookies["ScannerID"];
            string myScan = ScanValue.Text;

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\"}";


            var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "Logon";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            try
            {
                // clear out the value of the scan
                ScanValue.Text = "";

                JObject result = JObject.Parse(PostJSONMessage);
                string myResponse = (string)result["messageOut"];
                string myprivilegeList = (string)result["privilegeList"];

                // testing
                if (myResponse == "Logon Successful")
                {
                    // set a session variable with the privilegeList
                    HttpContext.Current.Session["privilegeList"] = myprivilegeList;

                    // take the user to the main menu
                    Response.Redirect("Default");
                }
                else
                {
                    lblResponseMessage.Text = myResponse;
                }

            }
            catch
            {
                lblResponseMessage.Text = PostJSONMessage;
                lblScanDirection.Text = "";
            }
        }

    }
}