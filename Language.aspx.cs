using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;

namespace ScannerApp
{
    public partial class Language : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnglish_Click(object sender, EventArgs e)
        {
            // get the scanner id
            HttpCookie ScannerID = Request.Cookies["ScannerID"];

            string myjson = "{\"scannerID\":\"" + ScannerID.Value + "\",\"LanguageCode\":\"EN\"}";

            var url = "https://them.solutioncreators.com/api/api/Language";

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

            string myjson = "{\"scannerID\":\"" + ScannerID.Value + "\",\"LanguageCode\":\"SP\"}";

            var url = "https://them.solutioncreators.com/api/api/Language";

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