using Newtonsoft.Json.Linq;
using System;
using System.Web;
using System.Web.UI;

namespace ScannerApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // get the scannerid
                HttpCookie ScannerID = Request.Cookies["ScannerID"];
                if (ScannerID != null)
                {
                    // call the registration endpoint to be sure the database knows this scanner id
                    string myjson = "{\"scannerID\":\"" + ScannerID.Value + "\"}";

                    var url = "https://them.solutioncreators.com/api/api/RegScanner";

                    
                    string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

                    try
                    {
                        // set up the encryption class
                        var encryptMe = new ScannerApp.ClassFiles.SHAEncryption();
                        encryptMe.HashKey = "je2Ld'0ld&#2lkd";

                        JObject result = JObject.Parse(PostJSONMessage);
                        string myResponse = (string)result["messageOut"];
                        lblResponseMessage.Text = myResponse;
                        string useButtons = (string)result["useButtons"];
                        JObject myButtons = JObject.Parse(useButtons);
                        hypMove.Text = (string)myButtons["Move_Button"];
                        hypMove.NavigateUrl = "move?t=" + HttpUtility.UrlEncode(encryptMe.EncryptData((string)myButtons["Move_Button"]));
                        hypProd.Text = (string)myButtons["BOM_Button"];
                        hypProd.NavigateUrl = "prod?t=" + HttpUtility.UrlEncode(encryptMe.EncryptData((string)myButtons["BOM_Button"]));
                        hypReturn.Text = (string)myButtons["Return_Button"];
                        hypReturn.NavigateUrl = "return?t=" + HttpUtility.UrlEncode(encryptMe.EncryptData((string)myButtons["Return_Button"]));
                        hypShip.Text = (string)myButtons["Shipping_Button"];
                        hypShip.NavigateUrl = "ship?t=" + HttpUtility.UrlEncode(encryptMe.EncryptData((string)myButtons["Shipping_Button"]));
                        hypPhysical.Text = (string)myButtons["Inventory_Button"];
                        hypPhysical.NavigateUrl = "physical?t=" + HttpUtility.UrlEncode(encryptMe.EncryptData((string)myButtons["Inventory_Button"]));
                        hypLanguage.Text = (string)myButtons["ScannerLang_Button"];
                        hypLanguage.NavigateUrl = "language?t=" + HttpUtility.UrlEncode(encryptMe.EncryptData((string)myButtons["ScannerLang_Button"]));

                        // save this somewhere to be retrieved by other pages
                        string strHomeButton = (string)myButtons["Home_Button"];
                        //Store the Home button text in a cookie
                        HttpCookie HomeButton = new HttpCookie("HomeButton");
                        HomeButton.Value = strHomeButton;
                        // for testing
                        HomeButton.Value = "Casa";
                        Response.Cookies.Add(HomeButton);

                    }
                    catch (Exception ex)
                    {
                        lblResponseMessage.Text = PostJSONMessage;
                    }


                }
            }
        }

    }
}