using System;
using System.Web.UI.WebControls;

namespace ScannerApp
{
    public partial class Move : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ScanValue_TextChanged(object sender, EventArgs e)
        {
            // get the scanner id
            HiddenField myGUID = (HiddenField)Page.Master.FindControl("hfSCannerID");
            string myScan = ScanValue.Text;

            string json = "{\"HeaderStatus\": \"ADD\", \"OrderDate\": \"01/04/2024\", \"NSOrderNumber\": \"SO9999\", \"DueDate\": \"01/08/2024\", \"DMTrucker\": 1009, \"Status\": \"NEW\", \"CustomerID\": 3044, \"PurchaseOrder\": \"262644\", \"SpecialInstructions\": \"\", \"ShippingDate\": \"01/05/2024\", \"ItemCount\": 45, \"OrderSubTotal\": 1652.5, \"Dscount\": 0, \"TotalPallets\": 24, \"OrderTotal\": 1652.5, \"ShipDateOrig\": \"01/05/2024\",";
            json += "\"OrderDetails\": [{ \"DetailStatus\": \"ADD\", \"NSDetailKey\": \"7933581\", \"ProductID\": 10800, \"Description\": \"DARK PINK ICING  20 LBS\", \"Quantity\": 1, \"Amount\": 37.6, \"CreateDate\": \"2024-01-04T21:43:13.164Z\" }]}";


            json = "{\"scanValue\":\"" + myScan + "\",\"scannerID\":\"" + myGUID.Value + "\"}";

            


            var url = "https://them.solutioncreators.com/api/api/Move";
            //var url = "https://solutioncreators.com/TestDutchMaid/DutchMaid/DM_Orders";

            string PostJSONMessage = ScannerApp.App_Code.PublicFunctions.PostRequest(url, json);
            lblResponseMessage.Text = PostJSONMessage;
        }
        
    }

}

