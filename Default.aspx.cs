using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                        JObject result = JObject.Parse(PostJSONMessage);
                        string myResponse = (string)result["messageOut"];
                        lblResponseMessage.Text = myResponse;
                        string useButtons = (string)result["useButtons"];
                        JObject myButtons = JObject.Parse(useButtons);
                        hypMove.Text = (string)myButtons["Move_Button"];
                        hypProd.Text = (string)myButtons["BOM_Button"];
                        hypReturn.Text = (string)myButtons["Return_Button"];
                        hypShip.Text = (string)myButtons["Shipping_Button"];
                        hypPhysical.Text = (string)myButtons["Inventory_Button"];
                        hypLanguage.Text = (string)myButtons["ScannerLang_Button"];
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