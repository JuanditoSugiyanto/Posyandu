using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Posyandu.Register_and_Login
{
    public partial class RoleSelector : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnOrangTuaReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterOrtu.aspx");
        }

        protected void BtnKaderReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterKader.aspx");
        }
    }
}