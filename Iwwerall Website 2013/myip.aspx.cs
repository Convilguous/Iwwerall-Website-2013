using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Iwwerall_Website_2013
{
    public partial class myip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Response.ContentType = "text/plain";
            Page.Response.Write(Request.UserHostAddress);
        }
    }
}