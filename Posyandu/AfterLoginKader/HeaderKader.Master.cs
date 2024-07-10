using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Posyandu.AfterLoginKader
{
    public partial class HeaderKader : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string nama = Session["UserName"] as string;

                if (!string.IsNullOrEmpty(nama))
                {
                    LabelName.Text = nama;
                }
                else
                {
                    LabelName.Text = "Guest";
                    if (Session["UserName"] == null)
                    {
                        LabelName.Text += " (Session is null)";
                    }
                }
            }
        }
    }
}