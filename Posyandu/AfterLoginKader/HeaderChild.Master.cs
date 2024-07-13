using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Posyandu.AfterLoginKader
{
    public partial class HeaderChild : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string nik = Request.QueryString["NIK"];
            if (!string.IsNullOrEmpty(nik))
            {
                LinkPenimbangan.NavigateUrl = $"ControlPenimbangan.aspx?NIK={nik}";
            }
        }
    }
}