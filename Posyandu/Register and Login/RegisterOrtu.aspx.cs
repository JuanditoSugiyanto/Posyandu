using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Posyandu.Register_and_Login
{
    public partial class RegisterOrtu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateRWDropdown();
            }
        }
        private void PopulateRWDropdown()
        {
            for (int i = 1; i <= 100; i++)
            {
                DropDownList1.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            for (int i = 1; i <= 300; i++)
            {
                DropDownList2.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
    }
}