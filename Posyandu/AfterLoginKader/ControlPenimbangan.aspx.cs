using System;
using System.Data.Entity;
using System.Linq;
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
                LoadRiwayatPenimbangan(); // Load existing records on page load
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
            double beratBadan = double.Parse(TextBox2.Text);

            using (DatabasePsoyanduEntities db = new DatabasePsoyanduEntities())
            {
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
                        existingRecord.Status_Gizi = "placeholder"; // Update with actual logic for status gizi if available
                    }
                    else
                    {
                        // Create new record
                        RecordTimbangPersonal newRecord = new RecordTimbangPersonal
                        {
                            NIK = nik,
                            Tanggal_Timbang = tanggalPemeriksaan,
                            Berat_Badan = beratBadan,
                            Tinggi_Badan = tinggiBadan,
                            namaAnak = anak.namaAnak,
                            Status_Gizi = "placeholder" // Update with actual logic for status gizi if available
                        };

                        db.RecordTimbangPersonals.Add(newRecord);
                    }

                    db.SaveChanges();
                }
            }

            // Refresh GridView
            LoadRiwayatPenimbangan();
        }

        private void LoadRiwayatPenimbangan()
        {
            string nik = ViewState["NIK"] as string;
            if (string.IsNullOrEmpty(nik)) return;

            using (DatabasePsoyanduEntities db = new DatabasePsoyanduEntities())
            {
                var data = db.RecordTimbangPersonals
                    .Where(r => r.NIK == nik)
                    .OrderByDescending(r => r.Tanggal_Timbang)
                    .Select(r => new
                    {
                        Tanggal = DbFunctions.TruncateTime(r.Tanggal_Timbang),
                        TinggiBadan = r.Tinggi_Badan,
                        BeratBadan = r.Berat_Badan,
                        StatusGizi = r.Status_Gizi
                    })
                    .ToList();

                GridViewRiwayatPenimbangan.DataSource = data;
                GridViewRiwayatPenimbangan.DataBind();
            }
        }

        protected void GridViewRiwayatPenimbangan_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string nik = ViewState["NIK"] as string;
            if (string.IsNullOrEmpty(nik))
            {
                Response.Redirect("WebForm1Kader.aspx");
                return;
            }

            // Ambil Tanggal dari baris yang akan dihapus
            DateTime tanggalTimbang = Convert.ToDateTime(GridViewRiwayatPenimbangan.DataKeys[e.RowIndex].Values["Tanggal"]);

            using (DatabasePsoyanduEntities db = new DatabasePsoyanduEntities())
            {
                // Cari record yang sesuai berdasarkan NIK dan Tanggal_Timbang
                var record = db.RecordTimbangPersonals.FirstOrDefault(r => r.NIK == nik && DbFunctions.TruncateTime(r.Tanggal_Timbang) == tanggalTimbang.Date);
                if (record != null)
                {
                    db.RecordTimbangPersonals.Remove(record);
                    db.SaveChanges();
                }
            }

            // Refresh GridView setelah menghapus data
            LoadRiwayatPenimbangan();
        }
    }
}
