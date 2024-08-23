using Posyandu.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Posyandu.AfterLoginOrtu
{
    public partial class WebForm1Ortu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
                
            }
        }

        protected void BtnTambahAnak_Click(object sender, EventArgs e)
        {
            Response.Redirect("TambahAnak.aspx");
        }

        private void BindGridView()
        {

            string nikOrangTua = Session["UserNIK"] as string;
            if (string.IsNullOrEmpty(nikOrangTua))
            {
                Response.Redirect("../Register and Login/Login.aspx");
            }

            using (DatabasePsoyanduEntities db = new DatabasePsoyanduEntities())
            {
                growthUtility utility = new growthUtility();    
                var balitasQuery = from b in db.balitas
                                   select b;
                var balitasFromDb = balitasQuery.ToList();
                var balitas = db.balitas
                            .Where(b => b.NIK_OrangTua == nikOrangTua)
                            .ToList()
                            .Select(b => new
                            {
                                  b.NIK,
                                  b.namaAnak,
                                   tanggalLahir = b.tanggalLahir.ToString("dd-MM-yyyy"),
                                  b.umur,
                                  b.jenisKelamin,
                                  b.alamat,
                                  b.namaPosyandu,
                                  b.beratBadan,
                                  b.tinggiBadan,
                                  statusGizi = (b.beratBadan == null || b.beratBadan == 0) ? "" :
                                  utility.CalculateZScoreAndClassificationWeight(b.umur, Convert.ToDouble(b.beratBadan), b.jenisKelamin).classification,
                                  zScoreTinggi = (b.tinggiBadan == null || b.tinggiBadan == 0) ? (double?)null :
                                  Math.Round(utility.CalculateZScoreAndClassificationHeight(b.umur, Convert.ToDouble(b.tinggiBadan), b.jenisKelamin).zScore ?? 0, 2),
                                  b.NIK_OrangTua,
                                  zscoreBerat = (b.beratBadan == null || b.beratBadan == 0) ? (double?)null : 
                                  Math.Round(utility.CalculateZScoreAndClassificationWeight(b.umur, Convert.ToDouble(b.beratBadan), b.jenisKelamin).zScore ?? 0, 2)
                                  

                            });

                GridView1.DataSource = balitas.ToList();
                GridView1.DataBind();
            }
        }


    }
}