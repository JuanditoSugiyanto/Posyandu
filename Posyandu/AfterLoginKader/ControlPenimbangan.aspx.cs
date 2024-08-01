using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Posyandu.AfterLoginKader
{
    public partial class ControlPenimbangan : System.Web.UI.Page
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

        protected void BtnAddData_Click(object sender, EventArgs e)
        {

            string nik = ViewState["NIK"] as string;
            if (string.IsNullOrEmpty(nik))
            {
                // Handle the case where NIK is not available
                Response.Redirect("WebForm1Kader.aspx");
                return;
            }

            DateTime tanggalPemeriksaan = DateTime.Today;
            double tinggiBadan = double.Parse(TxtTinggiBadan.Text); 
            int beratBadan = int.Parse(TextBox2.Text); 

            // Save data to the database
            DatabasePsoyanduEntities db = new DatabasePsoyanduEntities();
            var anak = db.balitas.FirstOrDefault(b => b.NIK == nik);
            if (anak != null)
            {
                anak.beratBadan = beratBadan;
                anak.tinggiBadan = tinggiBadan;
                var existingRecord = db.RecordTimbangPersonals.FirstOrDefault(r => r.NIK == nik && DbFunctions.TruncateTime(r.Tanggal_Timbang) == tanggalPemeriksaan.Date);


                if (existingRecord != null)
                {
                    // Update existing record
                    existingRecord.Berat_Badan = beratBadan;
                    existingRecord.Tinggi_Badan = tinggiBadan;
                    existingRecord.Status_Gizi = "placeholder";
                }
                else
                {
                    // Create new record
                    RecordTimbangPersonal r = new RecordTimbangPersonal();
                    r.NIK = nik;
                    r.Tanggal_Timbang = tanggalPemeriksaan;
                    r.Berat_Badan = beratBadan;
                    r.Tinggi_Badan = tinggiBadan;
                    r.namaAnak = anak.namaAnak;
                    r.Status_Gizi = "placeholder";

                    db.RecordTimbangPersonals.Add(r);
                }


            }


            db.SaveChanges();

            // Optionally, redirect to another page after saving
            Response.Redirect("ControlGigi.aspx?NIK=" + nik);
        }

    }
}