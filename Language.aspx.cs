using System;
using System.Web;
using Newtonsoft.Json.Linq;

namespace ScannerApp
{
    public partial class Language : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // get the Home button text
                HttpCookie HomeButton = Request.Cookies["HomeButton"];
                if (HomeButton.Value != null)
                {
                    hypHome.Text = HomeButton.Value;
                }


                // get the inital value for lblScanDirection
                // get the scanner id
                HttpCookie ScannerID = Request.Cookies["ScannerID"];

                string myjson = "{\"scannerID\":\"" + ScannerID.Value + "\",\"pageName\":\"Language\"}";


                var url = "https://them.solutioncreators.com/api/api/PageText";

                string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

                try
                {
                    JObject result = JObject.Parse(PostJSONMessage);
                    lblTitle.Text = (string)result["pageTitle"];
                }
                catch
                {
                    lblResponseMessage.Text = PostJSONMessage;
                }
            }
        }

        protected void btnEnglish_Click(object sender, EventArgs e)
        {
            // get the scanner id
            HttpCookie ScannerID = Request.Cookies["ScannerID"];

            string myjson = "{\"scannerID\":\"" + ScannerID.Value + "\",\"languageCode\":\"EN\"}";

            var url = "https://them.solutioncreators.com/api/api/ScannerLang";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            try
            {
                JObject result = JObject.Parse(PostJSONMessage);
                string myResponse = (string)result["messageOut"];

                lblResponseMessage.Text = myResponse;
            }
            catch
            {
                lblResponseMessage.Text = PostJSONMessage;
            }
        }

        protected void btnSpanish_Click(object sender, EventArgs e)
        {
            // get the scanner id
            HttpCookie ScannerID = Request.Cookies["ScannerID"];

            string myjson = "{\"scannerID\":\"" + ScannerID.Value + "\",\"languageCode\":\"SP\"}";

            var url = "https://them.solutioncreators.com/api/api/ScannerLang";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            try
            {
                JObject result = JObject.Parse(PostJSONMessage);
                string myResponse = (string)result["messageOut"];

                lblResponseMessage.Text = myResponse;
            }
            catch
            {
                lblResponseMessage.Text = PostJSONMessage;
            }
        }
    }
}