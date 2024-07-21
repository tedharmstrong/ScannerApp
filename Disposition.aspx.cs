using System;
using System.Web;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ScannerApp
{
    public partial class Disposition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                // get the inital value for lblScanDirection
                // get the scanner id
                HttpCookie ScannerID = Request.Cookies["ScannerID"];
                string myScan = ScanValue.Text;

                string myjson = "{\"scannerID\":\"" + ScannerID.Value + "\",\"pageName\":\"Disposition\"}";


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

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\",\"dispositionID\":\"0\"}";


            var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "Disposition";

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

                string dispositionList = (string)result["dispositionList"];

                if (dispositionList != null)
                {

                    dynamic myDisp = JsonConvert.DeserializeObject(dispositionList);
                    foreach (var data in myDisp)
                    {
                        // skip entries that already exist
                        string myDispName = data.DispositionName;
                        myDispName = myDispName.Replace("{", "").Replace("}", "");
                        if (ddlDisposition.Items.FindByText(myDispName) == null)
                        {
                            ddlDisposition.Items.Insert(0, new ListItem() { Text = data.DispositionName, Value = data.DispositionID });
                        }
                    }
                    ddlDisposition.Visible = true;
                }
                else 
                {
                    ScanValue.Text = "";
                }

                string myNextStep = (string)result["nextSteps"];

                lblResponseMessage.Text = myResponse;
                lblScanDirection.Text = myNextStep;

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

        protected void ddlDisposition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDisposition.SelectedValue == "0")
            {
                return;
            }

            // get the scanner id
            HttpCookie ScannerID = Request.Cookies["ScannerID"];
            string myScan = ScanValue.Text;

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\",\"dispositionID\":\"" + ddlDisposition.SelectedValue + "\"}";

            var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "Disposition";

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
                lblScanDirection.Text = myNextStep;
                ScanValue.Text = "";
                ddlDisposition.SelectedValue = "0";
                ddlDisposition.Visible = false;

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