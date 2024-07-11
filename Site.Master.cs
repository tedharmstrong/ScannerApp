using System;
using System.Web;
using System.Web.UI;


namespace ScannerApp
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["privilegeList"] == null)
            {
                string pagename = HttpContext.Current.Request.Url.AbsolutePath;
                if (pagename != "/Logon")
                {
                    //Response.Redirect("Logon");
                }

            }
            if (!IsPostBack)
            {
                try
                {
                    // see if the GUID cookie exists.  If not create it
                    HttpCookie ScannerID = Request.Cookies["ScannerID"];
                    if (ScannerID == null)
                    {
                        // no cookie exists, create it
                        ScannerID = new HttpCookie("ScannerID");
                        Guid myGuid = Guid.NewGuid();
                        ScannerID.Value = myGuid.ToString();
                        ScannerID.Expires = DateTime.Now.AddYears(50);
                        Response.Cookies.Add(ScannerID);
                    }

                }
                catch (Exception ex)
                {
                    hfSCannerID.Value = ex.Message;
                }
            }
        }
    }
}