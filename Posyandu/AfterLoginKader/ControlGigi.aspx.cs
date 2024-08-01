using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Posyandu.AfterLoginKader
{
    public partial class ControlGigi : System.Web.UI.Page
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

            bool kebersihanGigi = CheckBoxYaBersih.Checked;
            bool lubangGigi = CheckBoxYaBerlubang.Checked;
            bool kotorGigi = CheckBoxYaKotor.Checked;


            DatabasePsoyanduEntities db = new DatabasePsoyanduEntities();
            var anak = db.balitas.FirstOrDefault(b => b.NIK == nik);
            if (anak != null)
            {

                var existingData = db.kebersihanGigiAnaks.FirstOrDefault(g => g.NIK == nik);

                if (existingData != null)
                {
                    // Update existing data
                    existingData.kebersihanGigi = kebersihanGigi;
                    existingData.karies = lubangGigi; // Assuming lubangGigi represents karies in your context
                    
                }
                else
                {
                    kebersihanGigiAnak g = new kebersihanGigiAnak();
                    g.NIK = nik;
                    g.namaAnak = anak.namaAnak;
                    g.tanggalPeriksa = DateTime.Today;
                    g.jenisKelamin = anak.jenisKelamin;
                    g.kebersihanGigi = kebersihanGigi;
                    g.karies = kebersihanGigi;
                    db.kebersihanGigiAnaks.Add(g);
                }
            }
            db.SaveChanges();

            Response.Redirect("ControlCacing.aspx?NIK=" + nik);
        }
    }
}