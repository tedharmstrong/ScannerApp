using System;
using System.Web;
using Newtonsoft.Json.Linq;


namespace ScannerApp
{
    public partial class Physical : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScanValue.Focus();

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

        protected void ScanValue_TextChanged(object sender, EventArgs e)
        {
            // get the scanner id
            HttpCookie ScannerID = Request.Cookies["ScannerID"];
            string myScan = ScanValue.Text;

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\"}";

            var url = "https://them.solutioncreators.com/api/api/Inventory";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            try
            {
                JObject result = JObject.Parse(PostJSONMessage);
                string myResponse = (string)result["messageOut"];
                string myButtons = (string)result["useButtons"];
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
        protected void btn1_Click(object sender, EventArgs e)
        {
            // send the same message with the button choice
            // get the scanner id
            HttpCookie ScannerID = Request.Cookies["ScannerID"];
            string myScan = ScanValue.Text;

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\",\"CancelScan\":\"" + btn1.Text + "\"}";

            var url = "https://them.solutioncreators.com/api/api/Inventory";

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

        protected void btn2_Click(object sender, EventArgs e)
        {
            // send the same message with the button choice
            // get the scanner id
            HttpCookie ScannerID = Request.Cookies["ScannerID"];
            string myScan = ScanValue.Text;

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\",\"CancelScan\":\"" + btn2.Text + "\"}";

            var url = "https://them.solutioncreators.com/api/api/Inventory";

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
    }
}