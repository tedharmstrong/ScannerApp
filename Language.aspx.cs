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
                // set up the encryption class
                var encryptMe = new ScannerApp.ClassFiles.SHAEncryption();
                encryptMe.HashKey = "je2Ld'0ld&#2lkd";
                lblTitle.Text = encryptMe.DecryptData(Request.QueryString["t"]);

                // get the Home button text
                HttpCookie HomeButton = Request.Cookies["HomeButton"];
                if (HomeButton.Value != null)
                {
                    hypHome.Text = HomeButton.Value;
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