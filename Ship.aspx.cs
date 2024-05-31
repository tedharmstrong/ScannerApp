using System;
using System.Web;
using Newtonsoft.Json.Linq;

namespace ScannerApp
{
    public partial class Ship : System.Web.UI.Page
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

                string myjson = "{\"scannerID\":\"" + ScannerID.Value + "\",\"pageName\":\"Shipping\"}";


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
                        string mySendButton = (string)myButtons["SendButton"];
                        string mytblocation = (string)myButtons["tbLocation"];
                        string mytbWorkOrder = (string)myButtons["tbWorkOrderNumber"];
                        ScanValue.Visible = false;
                        btn1.Visible = false;
                        btn2.Visible = false;

                        if (myButton1 != null)
                        {
                            hypHome.Text = myButton1;
                        }
                        if (mySendButton != null)
                        {
                            btnSubmit.Visible = true;
                            btnSubmit.Text = mySendButton;
                        }
                        if (mytblocation != null)
                        {
                            txtLocation.Visible = true;
                            txtLocation.Attributes.Add("placeholder", mytblocation);
                            txtLocation.Focus();
                        }
                        if (mytbWorkOrder != null)
                        {
                            txtWorkOrder.Visible = true;
                            txtWorkOrder.Attributes.Add("placeholder", mytbWorkOrder);
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

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\",\"workOrderNumber\":\"" + txtWorkOrder.Text + "\",\"completeShipment\":\"\",\"cancelScan\":\"\"}";

            var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "Shipping";

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
                    string myHomeButton = (string)myButtons["Home_Button"];
                    string myButton1 = (string)myButtons["button1"];
                    ScanValue.Visible = false;
                    btn1.Visible = false;
                    btn2.Visible = false;

                    if (myHomeButton != null)
                    {
                        hypHome.Text = myHomeButton;
                    }
                    if (myButton1 != null)
                    {
                        btn1.Visible = true;
                        btn1.Text = myButton1;
                    }
                }

                string myNextStep = (string)result["nextSteps"];

                lblResponseMessage.Text = myResponse;
                lblScanDirection.Text = myNextStep;

                ScanValue.Visible = true;
                txtLocation.Visible = false;
                txtWorkOrder.Visible = false;
                btn2.Visible = false;
                btnSubmit.Visible = false;

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
            string myScan = "";

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\",\"workOrderNumber\":\"" + txtWorkOrder.Text + "\",\"completeShipment\":\"" + btn1.Text + "\",\"cancelScan\":\"" + btn2.Text + "\"}";

            var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "Shipping";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            try
            {
                JObject result = JObject.Parse(PostJSONMessage);
                string myResponse = (string)result["messageOut"];
                string useButtons = (string)result["useButtons"];
                if (useButtons != null)
                {
                    JObject myButtons = JObject.Parse(useButtons);
                    string myButton1 = (string)myButtons["Home_Button"];
                    string mySendButton = (string)myButtons["SendButton"];
                    string mytblocation = (string)myButtons["tbLocation"];
                    string mytbWorkOrder = (string)myButtons["tbWorkOrderNumber"];

                    if (myButton1 != null)
                    {
                        hypHome.Text = myButton1;
                    }
                    if (mySendButton != null)
                    {
                        btnSubmit.Visible = true;
                        btnSubmit.Text = mySendButton;
                    }
                    if (mytblocation != null)
                    {
                        txtLocation.Visible = true;
                        txtLocation.Attributes.Add("placeholder", mytblocation);
                        txtLocation.Focus();
                    }
                    if (mytbWorkOrder != null)
                    {
                        txtWorkOrder.Visible = true;
                        txtWorkOrder.Attributes.Add("placeholder", mytbWorkOrder);
                    }
                }
                btn1.Text = "";
                btn1.Visible = false;
                btn2.Text = "";
                btn2.Visible = false;
                btnSubmit.Visible = true;
                ScanValue.Visible = false;
                txtLocation.Visible = true;
                txtLocation.Text = "";
                txtWorkOrder.Visible = true;
                txtWorkOrder.Text = "";

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

            btn1.Text = "";
            btn1.Visible = false;
            btn2.Text = "";
            btn2.Visible = false;
            ScanValue.Text = "";
            lblResponseMessage.Text = "";

            string myjson = "{\"scanValue\":\"" + ScanValue.Text + "\",\"scannerID\":\"" + ScannerID.Value + "\",\"workOrderNumber\":\"" + txtWorkOrder.Text + "\",\"completeShipment\":\"" + btn1.Text + "\",\"cancelScan\":\"" + btn2.Text + "\"}";

            var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "Shipping";

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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // get the scanner id
            HttpCookie ScannerID = Request.Cookies["ScannerID"];
            string myScan = txtLocation.Text;

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\",\"workOrderNumber\":\"" + txtWorkOrder.Text + "\",\"completeShipment\":\"" + btn1.Text + "\",\"cancelScan\":\"" + btn2.Text + "\"}";

            var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "Shipping";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            try
            {
                JObject result = JObject.Parse(PostJSONMessage);
                lblTitle.Text = (string)result["pageTitle"];
                lblScanDirection.Text = (string)result["pageInstruction"];
                string myResponse = (string)result["messageOut"];
                string useButtons = (string)result["useButtons"];
                if (useButtons != null)
                {
                    JObject myButtons = JObject.Parse(useButtons);
                    string myButton1 = (string)myButtons["button1"];
                    if (myButton1 != null)
                    {
                        btn1.Visible = true;
                        btn1.Text = myButton1;
                    }
                }
                
                btn2.Text = "";
                btn2.Visible = false;
                btnSubmit.Visible = false;
                txtLocation.Visible = false;
                txtWorkOrder.Visible = false;
                ScanValue.Visible = true;
                string myNextStep = (string)result["nextSteps"];

                lblResponseMessage.Text = myResponse;
                lblScanDirection.Text = myNextStep;
                ScanValue.Text = "";
                ScanValue.Focus();

            }
            catch
            {
                lblResponseMessage.Text = PostJSONMessage;
                lblScanDirection.Text = "";
            }
        }
    }
}