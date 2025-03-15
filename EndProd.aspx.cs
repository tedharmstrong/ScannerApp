using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScannerApp
{
    public partial class EndProd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                // get the inital value for lblScanDirection
                // get the scanner id
                HttpCookie ScannerID = Request.Cookies["ScannerID"];
                string myScan = ScanValue.Text;

                string myjson = "{\"scannerID\":\"" + ScannerID.Value + "\",\"pageName\":\"ActivateProduction\"}";


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


            var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "ActivateProd";

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

                string activeWorkOrderList = (string)result["activeWorkOrderList"];

                if (activeWorkOrderList != null)
                {

                    dynamic myMOH = JsonConvert.DeserializeObject(activeWorkOrderList);
                    foreach (var data in myMOH)
                    {
                        // skip entries that already exist
                        string myMohName = data;
                        myMohName = myMohName.Replace("{", "").Replace("}", "");
                        if (ddlMoh.Items.FindByText(myMohName) == null)
                        {
                            ddlMoh.Items.Insert(0, new ListItem() { Text = myMohName, Value = myMohName });
                        }
                    }
                    ddlMoh.Visible = true;
                }

                string activeShiftList = (string)result["activeShiftList"];

                if (activeShiftList != null)
                {

                    dynamic myShifts = JsonConvert.DeserializeObject(activeShiftList);
                    foreach (var data in myShifts)
                    {
                        // skip entries that already exist
                        string myShiftName = data;
                        myShiftName = myShiftName.Replace("{", "").Replace("}", "");
                        if (ddlShift.Items.FindByText(myShiftName) == null)
                        {
                            ddlShift.Items.Insert(0, new ListItem() { Text = myShiftName, Value = myShiftName });
                        }
                    }
                    ddlShift.Visible = true;
                }

                string activeDateList = (string)result["activeDateList"];

                if (activeDateList != null)
                {
                    dynamic myDates = JsonConvert.DeserializeObject(activeDateList);
                    foreach (var data in myDates)
                    {
                        // skip entries that already exist
                        string myDateName = data;
                        myDateName = myDateName.Replace("{", "").Replace("}", "");
                        if (ddlActiveDate.Items.FindByText(myDateName) == null)
                        {
                            ddlActiveDate.Items.Insert(0, new ListItem() { Text = myDateName, Value = myDateName });
                        }
                    }
                    ddlActiveDate.Visible = true;
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
            if (ddlMoh.SelectedValue == "" || ddlShift.SelectedValue == "" || ddlActiveDate.SelectedValue == "")
            {
                return;
            }

            // get the scanner id
            HttpCookie ScannerID = Request.Cookies["ScannerID"];
            string myScan = ScanValue.Text;

            string myjson = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + ScannerID.Value + "\",\"activeMO\":\"" + ddlMoh.SelectedValue + "\",\"activeShift\":\"" + ddlShift.SelectedValue + "\",\"activeDate\":\"" + ddlActiveDate.SelectedValue + "\"}";

            var url = System.Configuration.ConfigurationManager.AppSettings["APIURL"] + "ActivateProd";

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
                ScanValue.Visible = false;
                ddlMoh.SelectedValue = "";
                ddlMoh.Visible = false;
                ddlShift.SelectedValue = "";
                ddlShift.Visible = false;
                ddlActiveDate.SelectedValue = "";
                ddlActiveDate.Visible = false;
                btn1.Visible = false;

            }
            catch (Exception ex)
            {
                lblResponseMessage.Text = ex.Message;
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
    }
}