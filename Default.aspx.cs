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

                    var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "RegScanner";

                    
                        string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

                    try
                    {

                        JObject result = JObject.Parse(PostJSONMessage);
                        string myResponse = (string)result["messageOut"];
                        //lblResponseMessage.Text = myResponse;
                        string useButtons = (string)result["useButtons"];
                        JObject myButtons = JObject.Parse(useButtons);

                        // put the privileges in a variable to check against each button
                        string privs = (string)HttpContext.Current.Session["privilegeList"];
                        HttpCookie myPrivs = Request.Cookies["MyPrivs"];
                        privs = myPrivs.Value;

                        hypReceive.Text = (string)myButtons["Receive_Button"];
                        if (privs.IndexOf("Receive_Button") == -1)
                        {
                            hypReceive.Visible = false;
                        }
                        hypMove.Text = (string)myButtons["Move_Button"];
                        if (privs.IndexOf("Move_Button") == -1)
                        {
                            hypMove.Visible = false;
                        }
                        hypProd.Text = (string)myButtons["BOM_Button"];
                        if (privs.IndexOf("BOM_Button") == -1)
                        {
                            hypProd.Visible = false;
                        }
                        //hypReturn.Text = (string)myButtons["Return_Button"];
                        //if (privs.IndexOf("Return_Button") == -1)
                        //{
                        //    hypReturn.Visible = false;
                        //}
                        hypShip.Text = (string)myButtons["Shipping_Button"];
                        if (privs.IndexOf("Shipping_Button") == -1)
                        {
                            hypShip.Visible = false;
                        }
                        hypPhysical.Text = (string)myButtons["Inventory_Button"];
                        if (privs.IndexOf("Inventory_Button") == -1)
                        {
                            hypPhysical.Visible = false;
                        }
                        hypDisposition.Text = (string)myButtons["Disposition_Button"];
                        if (privs.IndexOf("Disposition_Button") == -1)
                        {
                            hypDisposition.Visible = false;
                        }
                        hypLanguage.Text = (string)myButtons["ScannerLang_Button"];
                        hypLogoff.Text = (string)myButtons["LogOff_Button"];

                        // save this as a cookie to be retrieved by other pages
                        string strHomeButton = (string)myButtons["Home_Button"];
                        //Store the Home button text in a cookie
                        HttpCookie HomeButton = new HttpCookie("HomeButton");
                        HomeButton.Value = strHomeButton;
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