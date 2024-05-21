using System;
using System.Web;
using Newtonsoft.Json.Linq;

namespace ScannerApp
{
    public partial class Prod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScanValue.Focus();

            if (!IsPostBack)
            {
                // get the inital value for lblScanDirection
                // get the scanner id
                HttpCookie ScannerID = Request.Cookies["ScannerID"];
                string myScan = ScanValue.Text;

                string myjson = "{\"scannerID\":\"" + ScannerID.Value + "\",\"pageName\":\"FinishGoods\"}";


                var url = "https://them.solutioncreators.com/api/PageText";

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
                }
            }

        }
        
        protected void ScanValue_TextChanged(object sender, EventArgs e)
        {
            // get the scanner id
            HttpCookie ScannerID = Request.Cookies["ScannerID"];
            string myScan = ScanValue.Text;

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\",\"palletComplete\":\"\",\"productionComplete\":\"\"}";

            var url = "https://them.solutioncreators.com/api/FinishedGood";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            try
            {
                // clear out the value of the scan
                ScanValue.Text = "";

                JObject result = JObject.Parse(PostJSONMessage);
                string myResponse = (string)result["messageOut"];
                string useButtons = (string)result["useButtons"];

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
                lblScanDirection.Text = myNextStep;


            }
            catch
            {
                lblResponseMessage.Text = PostJSONMessage;
                lblScanDirection.Text = "";
            }
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            // send the same message with the button choice
            // get the scanner id
            HttpCookie ScannerID = Request.Cookies["ScannerID"];
            
            string myjson = "{\"scanValue\":\"\",\"scannerID\":\"" + ScannerID.Value + "\",\"palletComplete\":\"" + btn1.Text + "\",\"productionComplete\":\"\"}";

            var url = "https://them.solutioncreators.com/api/FinishedGood";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            try
            {
                JObject result = JObject.Parse(PostJSONMessage);
                string myResponse = (string)result["messageOut"];
                string useButtons = (string)result["useButtons"];
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
                lblScanDirection.Text = myNextStep;
                ScanValue.Text = "";
            }
            catch
            {
                lblResponseMessage.Text = PostJSONMessage;
                lblScanDirection.Text = "";
            }
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

            var url = "https://them.solutioncreators.com/api/FinishedGood";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            try
            {
                JObject result = JObject.Parse(PostJSONMessage);
                string myResponse = (string)result["messageOut"];
                lblTitle.Text = (string)result["pageTitle"];
                lblScanDirection.Text = (string)result["pageInstruction"];
                lblResponseMessage.Text = myResponse;
            }
            catch
            {
                lblResponseMessage.Text = PostJSONMessage;
                lblScanDirection.Text = "";
            }
        }
    }
}