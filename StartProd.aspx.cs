using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.UI.WebControls;

namespace ScannerApp
{
    public partial class StartProd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                // get the inital value for lblScanDirection
                // get the scanner id
                HttpCookie ScannerID = Request.Cookies["ScannerID"];
                string myScan = ScanValue.Text;

                string myjson = "{\"scannerID\":\"" + ScannerID.Value + "\",\"pageName\":\"StartProduction\"}";


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

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\",\"MohID\":\"0\"}";


            var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "StartProduction";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            try
            {
                JObject result = JObject.Parse(PostJSONMessage);
                string myResponse = (string)result["messageOut"];
                string myMessageColor = (string)result["messageColor"];
                string myNextColor = (string)result["nextColor"];
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

                        // put the value back in the ScanValue field
                        ScanValue.Text = myScan;
                    }
                    if (myButton2 != null)
                    {
                        btn2.Text = myButton2;
                        btn2.Visible = true;

                        // put the value back in the ScanValue field
                        ScanValue.Text = myScan;
                    }
                }

                string mohList = (string)result["mohidList"];

                if (mohList != null)
                {

                    dynamic myDisp = JsonConvert.DeserializeObject(mohList);
                    foreach (var data in myDisp)
                    {
                        // skip entries that already exist
                        string myMohName = data.MohNameName;
                        myMohName = myMohName.Replace("{", "").Replace("}", "");
                        if (ddlMoh.Items.FindByText(myMohName) == null)
                        {
                            ddlMoh.Items.Insert(0, new ListItem() { Text = data.MohName, Value = data.MohID });
                        }
                    }
                    ddlMoh.Visible = true;
                }
                else
                {
                    ScanValue.Text = "";
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
            catch (Exception ex)
            {
                lblResponseMessage.Text = ex.Message;
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
            string myScan = ScanValue.Text;

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\",\"cancelScan\":\"" + btn1.Text + "\"}";

            var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "Move";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            try
            {
                JObject result = JObject.Parse(PostJSONMessage);
                string myResponse = (string)result["messageOut"];
                string myMessageColor = (string)result["messageColor"];
                string myNextColor = (string)result["nextColor"];
                btn1.Text = "";
                btn1.Visible = false;
                btn2.Text = "";
                btn2.Visible = false;
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

            btn1.Text = "";
            btn1.Visible = false;
            btn2.Text = "";
            btn2.Visible = false;
            ScanValue.Text = "";
            lblResponseMessage.Text = "";

            string myjson = "{\"scannerID\":\"" + ScannerID.Value + "\",\"pageName\":\"Move\"}";

            var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "PageText";

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
                ScanValue.Focus();
            }
            ScanValue.Focus();
        }

        protected void ddlMoh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMoh.SelectedValue == "0")
            {
                return;
            }

            // get the scanner id
            HttpCookie ScannerID = Request.Cookies["ScannerID"];
            string myScan = ScanValue.Text;

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\",\"MohID\":\"" + ddlMoh.SelectedValue + "\"}";

            var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "StartProduction";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, myjson);

            try
            {
                JObject result = JObject.Parse(PostJSONMessage);
                string myResponse = (string)result["messageOut"];
                string myMessageColor = (string)result["messageColor"];
                string myNextColor = (string)result["nextColor"];
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

                        // put the value back in the ScanValue field
                        ScanValue.Text = myScan;
                    }
                    if (myButton2 != null)
                    {
                        btn2.Text = myButton2;
                        btn2.Visible = true;

                        // put the value back in the ScanValue field
                        ScanValue.Text = myScan;
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
                ddlMoh.SelectedValue = "0";
                ddlMoh.Visible = false;

            }
            catch (Exception ex)
            {
                lblResponseMessage.Text = ex.Message;
                lblScanDirection.Text = "";
                ScanValue.Focus();
            }
            ScanValue.Focus();
        }
    }
}