using System;
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

        protected void radLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the scanner id
            HiddenField myGUID = (HiddenField)Page.Master.FindControl("hfSCannerID");
            string myLanguage = radLanguage.SelectedValue;

            string myjson = "{\"scannerID\":\"" + myGUID.Value + "\",\"LanguageCode\":\"" + myLanguage + "\"}";

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