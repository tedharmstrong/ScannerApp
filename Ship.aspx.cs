using System;
using System.Web;
using Newtonsoft.Json.Linq;

namespace ScannerApp
{
    public partial class Ship : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ScanValue.Visible = false;
            btnRemoveYes.Visible = false;
            btnRemoveNo.Visible = false;
            btnAddYes.Visible = false;
            btnAddNo.Visible = false;
            btnComplete.Visible = false;

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
                        string btn1 = (string)myButtons["Home_Button"];
                        string mySendButton = (string)myButtons["SendButton"];
                        string myCompleteButton = (string)myButtons["btnComplete"];
                        string mytblocation = (string)myButtons["tbLocation"];
                        string mytbWorkOrder = (string)myButtons["tbWorkOrderNumber"];
 
                        if (btn1 != null)
                        {
                            hypHome.Text = btn1;
                        }
                        if (mySendButton != null)
                        {
                            btnSubmit.Visible = true;
                            btnSubmit.Text = mySendButton;
                        }
                        if (myCompleteButton != null)
                        {
                            btnComplete.Visible = true;
                            btnComplete.Text = myCompleteButton;
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

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\",\"workOrderNumber\":\"" + txtWorkOrder.Text + "\",\"completeShipment\":\"\",\"cancelScan\":\"\"}";

            var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "Shipping";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            

            try
            {
                ProcessResponse(PostJSONMessage);
            }
            catch
            {
                lblResponseMessage.Text = PostJSONMessage;
                lblScanDirection.Text = "";
            }
        }

        protected void btnRemoveYes_Click(object sender, EventArgs e)
        {
            // get the scanner id
            HttpCookie ScannerID = Request.Cookies["ScannerID"];
            string myScan = ScanValue.Text;

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\",\"workOrderNumber\":\"" + txtWorkOrder.Text + "\",\"removeFromShipment\":\"Yes\"}";

            var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "Shipping";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            try
            {
                ProcessResponse(PostJSONMessage);
            }
            catch
            {
                lblResponseMessage.Text = PostJSONMessage;
                lblScanDirection.Text = "";
            }
        }

        protected void btnRemoveNo_Click(object sender, EventArgs e)
        {
            // get the scanner id
            HttpCookie ScannerID = Request.Cookies["ScannerID"];
            string myScan = ScanValue.Text;

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\",\"workOrderNumber\":\"" + txtWorkOrder.Text + "\",\"removeFromShipment\":\"No\"}";

            var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "Shipping";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            try
            {
                ProcessResponse(PostJSONMessage);
            }
            catch
            {
                lblResponseMessage.Text = PostJSONMessage;
                lblScanDirection.Text = "";
            }
        }

        protected void btnAddYes_Click(object sender, EventArgs e)
        {
            // get the scanner id
            HttpCookie ScannerID = Request.Cookies["ScannerID"];
            string myScan = ScanValue.Text;

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\",\"workOrderNumber\":\"" + txtWorkOrder.Text + "\",\"addToShipment\":\"Yes\"}";

            var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "Shipping";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            try
            {
                ProcessResponse(PostJSONMessage);
            }
            catch
            {
                lblResponseMessage.Text = PostJSONMessage;
                lblScanDirection.Text = "";
            }
        }

        protected void btnAddNo_Click(object sender, EventArgs e)
        {
            // get the scanner id
            HttpCookie ScannerID = Request.Cookies["ScannerID"];
            string myScan = ScanValue.Text;

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\",\"workOrderNumber\":\"" + txtWorkOrder.Text + "\",\"addToShipment\":\"No\"}";

            var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "Shipping";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            try
            {
                ProcessResponse(PostJSONMessage);
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

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\",\"workOrderNumber\":\"" + txtWorkOrder.Text + "\",\"completeShipment\":\"\"}";

            var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "Shipping";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            try
            {
                ProcessResponse(PostJSONMessage);
            }
            catch
            {
                lblResponseMessage.Text = PostJSONMessage;
                lblScanDirection.Text = "";
            }
        }

        protected void btnComplete_Click(object sender, EventArgs e)
        {
            // get the scanner id
            HttpCookie ScannerID = Request.Cookies["ScannerID"];
            string myScan = txtLocation.Text;

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\",\"workOrderNumber\":\"" + txtWorkOrder.Text + "\",\"completeShipment\":\"Yes\"}";

            var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "Shipping";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            try
            {
                ProcessResponse(PostJSONMessage);
            }
            catch
            {
                lblResponseMessage.Text = PostJSONMessage;
                lblScanDirection.Text = "";
            }
        }

        protected void ProcessResponse(string PostJSONMessage)
        {
            try
            {
                Boolean blnClear = true;

                JObject result = JObject.Parse(PostJSONMessage);
                string myResponse = (string)result["messageOut"];
                string useButtons = (string)result["useButtons"];
                string myMessageColor = (string)result["messageColor"];
                string myNextColor = (string)result["nextColor"];

                if (useButtons != null)
                {
                    JObject myButtons = JObject.Parse(useButtons);
                    string myHomeButton = (string)myButtons["Home_Button"];
                    string btnRemove1 = (string)myButtons["btnRemoveYes"];
                    string btnRemove2 = (string)myButtons["btnRemoveNo"];
                    string btnAdd1 = (string)myButtons["btnAddYes"];
                    string btnAdd2 = (string)myButtons["btnAddNo"];
                    string strComplete = (string)myButtons["btnComplete"];
                    

                    if (myHomeButton != null)
                    {
                        hypHome.Text = myHomeButton;
                    }
                    if (btnRemove1 != null)
                    {
                        btnRemoveYes.Visible = true;
                        btnRemoveYes.Text = btnRemove1;
                        blnClear = false;
                    }
                    if (btnRemove2 != null)
                    {
                        btnRemoveNo.Visible = true;
                        btnRemoveNo.Text = btnRemove2;
                    }
                    if (btnAdd1 != null)
                    {
                        btnAddYes.Visible = true;
                        btnAddYes.Text = btnAdd1;
                        blnClear = false;
                    }
                    if (btnAdd2 != null)
                    {
                        btnAddNo.Visible = true;
                        btnAddNo.Text = btnAdd2;
                    }

                    if (strComplete != null)
                    {
                        btnComplete.Visible = true;
                        btnComplete.Text = strComplete;
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

                ScanValue.Visible = true;
                txtLocation.Visible = false;
                txtWorkOrder.Visible = false;
                btnSubmit.Visible = false;

                if (blnClear)
                {
                    ScanValue.Text = "";
                }
            }
            catch
            {
                lblResponseMessage.Text = PostJSONMessage;
                lblScanDirection.Text = "";
            }
        }
    }
}