using Newtonsoft.Json.Linq;
using System;
using System.Web;

namespace ScannerApp
{
    public partial class Info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // get the inital value for lblScanDirection
                // get the scanner id
                HttpCookie ScannerID = Request.Cookies["ScannerID"];
                string myScan = ScanValue.Text;

                string myjson = "{\"scannerID\":\"" + ScannerID.Value + "\",\"pageName\":\"Info\"}";


                var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "PageText";

                string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

                try
                {
                    JObject result = JObject.Parse(PostJSONMessage);
                    lblTitle.Text = (string)result["pageTitle"];
                    lblScanDirection.Text = (string)result["pageInstruction"];
                    string useButtons = (string)result["useButtons"];
                    if (useButtons != null)
                    {
                        JObject myButtons = JObject.Parse(useButtons);
                        string myButton1 = (string)myButtons["Home_Button"];
                        if (myButton1 != null)
                        {
                            hypHome.Text = myButton1;
                        }
                    }
                }
                catch
                {
                    lblResponseMessage.Text = PostJSONMessage;
                    lblScanDirection.Text = "";
                    ScanValue.Focus();
                }
            }
            ScanValue.Focus();

        }

        protected void ScanValue_TextChanged(object sender, EventArgs e)
        {
            // get the scanner id
            HttpCookie ScannerID = Request.Cookies["ScannerID"];
            string myScan = ScanValue.Text;

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\"}";

            var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "Info";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            try
            {
                // clear out the value of the scan
                ScanValue.Text = "";

                JObject result = JObject.Parse(PostJSONMessage);
                string myResponse = (string)result["messageOut"];
                string useButtons = (string)result["useButtons"];
                string myMessageColor = (string)result["messageColor"];
                string myNextColor = (string)result["nextColor"];

                if (useButtons != null)
                {
                    JObject myButtons = JObject.Parse(useButtons);
                    string myButton1 = (string)myButtons["button1"];
                    string myButton2 = (string)myButtons["button2"];
                    if (myButton1 != null)
                    {
                        btn1.Text = myButton1;
                        btn1.Visible = true;
                    }
                    btn2.Visible = false;
                }

                string myNextStep = (string)result["nextSteps"];

                lblResponseMessage.Text = myResponse;
                if (myMessageColor != null)
                {
                    lblResponseMessage.Attributes.Add("style", "color:" + myMessageColor);
                }
                lblScanDirection.Text = myNextStep;
                if (myNextColor != null)
                {
                    lblScanDirection.Attributes.Add("style", "color:" + myNextColor);
                }


            }
            catch
            {
                lblResponseMessage.Text = PostJSONMessage;
                lblScanDirection.Text = "";
                ScanValue.Focus();
            }
            ScanValue.Focus();
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            // send the same message with the button choice
            // get the scanner id
            HttpCookie ScannerID = Request.Cookies["ScannerID"];

            string myjson = "{\"scanValue\":\"\",\"scannerID\":\"" + ScannerID.Value + "\",\"palletComplete\":\"" + btn1.Text + "\",\"productionComplete\":\"\"}";

            var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "FinishedGood";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            try
            {
                JObject result = JObject.Parse(PostJSONMessage);
                string myResponse = (string)result["messageOut"];
                string useButtons = (string)result["useButtons"];
                string myMessageColor = (string)result["messageColor"];
                string myNextColor = (string)result["nextColor"];
                if (useButtons != null)
                {
                    JObject myButtons = JObject.Parse(useButtons);
                    string myButton1 = (string)myButtons["button1"];
                    string myButton2 = (string)myButtons["button2"];
                    btn1.Visible = false;
                    if (myButton2 != null)
                    {
                        btn2.Text = myButton2;
                        btn2.Visible = true;
                    }
                }
                string myNextStep = (string)result["nextSteps"];

                lblResponseMessage.Text = myResponse;
                if (myMessageColor != null)
                {
                    lblResponseMessage.Attributes.Add("style", "color:" + myMessageColor);
                }
                lblScanDirection.Text = myNextStep;
                if (myNextColor != null)
                {
                    lblScanDirection.Attributes.Add("style", "color:" + myNextColor);
                }
                ScanValue.Text = "";
            }
            catch
            {
                lblResponseMessage.Text = PostJSONMessage;
                lblScanDirection.Text = "";
                ScanValue.Focus();
            }
            ScanValue.Focus();
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            // get the scanner id
            HttpCookie ScannerID = Request.Cookies["ScannerID"];

            btn1.Visible = false;
            btn2.Visible = false;
            ScanValue.Visible = false;
            lblResponseMessage.Text = "";

            string myjson = "{\"scanValue\":\"\",\"scannerID\":\"" + ScannerID.Value + "\",\"palletComplete\":\"\",\"productionComplete\":\"" + btn2.Text + "\"}";

            var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "FinishedGood";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            try
            {
                JObject result = JObject.Parse(PostJSONMessage);
                string myResponse = (string)result["messageOut"];
                string myMessageColor = (string)result["messageColor"];
                string myNextColor = (string)result["nextColor"];
                lblTitle.Text = (string)result["pageTitle"];
                lblScanDirection.Text = (string)result["pageInstruction"];
                lblResponseMessage.Text = myResponse;
                if (myMessageColor != null)
                {
                    lblResponseMessage.Attributes.Add("style", "color:" + myMessageColor);
                }
            }
            catch
            {
                lblResponseMessage.Text = PostJSONMessage;
                lblScanDirection.Text = "";
                ScanValue.Focus();
            }
            ScanValue.Focus();
        }
    }
}