using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Posyandu.AfterLoginKader
{
    public partial class ControlCacing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string nik = Request.QueryString["NIK"];
                if (string.IsNullOrEmpty(nik))
                {
                    // Handle the case where NIK is not provided
                    Response.Redirect("WebForm1Kader.aspx");
                    return;
                }

                ViewState["NIK"] = nik; // Store NIK in ViewState for use later
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string nik = ViewState["NIK"] as string;
            if (string.IsNullOrEmpty(nik))
            {
                // Handle the case where NIK is not available
                Response.Redirect("WebForm1Kader.aspx");
                return;
            }

            bool ObatCacingBox = CheckBoxYaCacing.Checked;

            DatabasePsoyanduEntities db = new DatabasePsoyanduEntities();
            var anak = db.balitas.FirstOrDefault(b => b.NIK == nik);

            if (anak != null)
            {
                var existingData = db.penerimaObatCacings.FirstOrDefault(g => g.NIK == nik);
                if (existingData != null)
                {
                    // Update existing data
                    existingData.pemberianAbendazole = ObatCacingBox;
                }
                else
                {
                    penerimaObatCacing c = new penerimaObatCacing();
                    c.NIK = nik;
                    c.namaAnak = anak.namaAnak;
                    c.pemberianAbendazole = ObatCacingBox;
                    db.penerimaObatCacings.Add(c);
                }              
            }

            db.SaveChanges();


        }
    }
}