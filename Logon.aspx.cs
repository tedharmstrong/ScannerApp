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

            // get the scannerid
            HttpCookie ScannerID = Request.Cookies["ScannerID"];
            if (ScannerID != null)
            {
                // call the registration endpoint to be sure the database knows this scanner id
                string myjson = "{\"scannerID\":\"" + ScannerID.Value + "\"}";

                var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "RegScanner";


                string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);
            }
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

                    // set a cookie with the privilegeList
                    HttpCookie myPrivs = new HttpCookie("MyPrivs");
                    myPrivs.Value = myprivilegeList;
                    myPrivs.Expires = DateTime.Now.AddYears(50);
                    Response.Cookies.Add(myPrivs);

                    // report success and enable button to mane
                    lblResponseMessage.Text = myResponse;
                    ScanValue.Visible = false;
                    lblScanDirection.Visible = false;
                    hypMenu.Visible = true;
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