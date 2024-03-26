using System;
using System.Web;
using Newtonsoft.Json.Linq;

namespace ScannerApp
{
    public partial class Return : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScanValue.Focus();

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
                string myScan = ScanValue.Text;

                string myjson = "{\"scannerID\":\"" + ScannerID.Value + "\",\"pageName\":\"MovePartial\"}";


                var url = "https://them.solutioncreators.com/api/api/PageText";

                string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

                try
                {
                    JObject result = JObject.Parse(PostJSONMessage);
                    lblTitle.Text = (string)result["pageTitle"];
                    lblScanDirection.Text = (string)result["pageInstruction"];

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

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\",\"quantity\":0,\"cancelScan\":\"\"}";

            var url = "https://them.solutioncreators.com/api/api/MovePartial";

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
                    if (myButton1 != null)
                    {
                        btn1.Text = myButton1;
                        btn1.Visible = true;
                    }
                    if (myButton2 != null)
                    {
                        btn2.Text = myButton2;
                        btn2.Visible = true;
                    }
                }

                string myNextStep = (string)result["nextSteps"];

                lblResponseMessage.Text = myResponse;
                lblScanDirection.Text = myNextStep;
                Quantity.Visible = true;

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
            string myScan = ScanValue.Text;

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\",\"quantity\":0,\"CancelScan\":\"" + btn1.Text + "\"}";

            var url = "https://them.solutioncreators.com/api/api/MovePartial";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            try
            {
                JObject result = JObject.Parse(PostJSONMessage);
                string myResponse = (string)result["messageOut"];
                btn1.Text = "";
                btn1.Visible = false;
                btn2.Text = "";
                btn2.Visible = false;
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

        
        protected void Quantity_TextChanged(object sender, EventArgs e)
        {
            // get the scanner id
            HttpCookie ScannerID = Request.Cookies["ScannerID"];
            string myScan = ScanValue.Text;
            string myQuantity = Quantity.Text;

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\",\"quantity\":\"" + myQuantity + "\",\"cancelScan\":\"\"}";

            var url = "https://them.solutioncreators.com/api/api/MovePartial";

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
                    if (myButton1 != null)
                    {
                        btn1.Text = myButton1;
                        btn1.Visible = true;
                    }
                    if (myButton2 != null)
                    {
                        btn2.Text = myButton2;
                        btn2.Visible = true;
                    }
                }

                string myNextStep = (string)result["nextSteps"];

                lblResponseMessage.Text = myResponse;
                lblScanDirection.Text = myNextStep;
                Quantity.Visible = false;
                ScanValue.Text = "";

            }
            catch
            {
                lblResponseMessage.Text = PostJSONMessage;
                lblScanDirection.Text = "";
            }
            
        }
    }
}