using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Posyandu.AfterLoginOrtu
{
    public partial class DetaiAnak : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string nik = Request.QueryString["NIK"];
            if (string.IsNullOrEmpty(nik))
            {
                // Handle the case where NIK is not provided
                Response.Redirect("WebForm1Ortu.aspx");
                return;
            }

            using (DatabasePsoyanduEntities db = new DatabasePsoyanduEntities())
            {
                var anak = (from b in db.balitas
                            where b.NIK == nik
                            select b).FirstOrDefault();

                if (anak == null)
                {
                    // Handle the case where the child is not found
                    Response.Redirect("WebForm1Ortu.aspx");
                    return;
                }
                LabelNama.Text = anak.namaAnak;
                LblOrtu.Text = anak.namaOrangtua;



            }
        }
    }
}