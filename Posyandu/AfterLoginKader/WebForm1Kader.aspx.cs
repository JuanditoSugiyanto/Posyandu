using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Posyandu.Utilities;

namespace Posyandu.AfterLoginKader
{
    public partial class WebForm1Kader : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void BindGridView()
        {
            string nikOrangTua = Session["UserNIK"] as string;
            if (string.IsNullOrEmpty(nikOrangTua))
            {
                Response.Redirect("../Register and Login/Login.aspx");
            }

            string search = TxtSearch.Text.Trim();

            using (DatabasePsoyanduEntities db = new DatabasePsoyanduEntities())
            {
                var balitasQuery = from b in db.balitas
                                   select b;
                if (!string.IsNullOrEmpty(search))
                {
                    balitasQuery = balitasQuery.Where(b => b.namaAnak.Contains(search) || b.NIK.Contains(search));
                }

                var balitasFromDb = balitasQuery.ToList();
                growthUtility utility = new growthUtility();
                // Calculate Z-score and classification in memory
                var balitas = balitasFromDb.Select(b => new
                {
                    b.NIK,
                    b.namaAnak,
                    b.tanggalLahir,
                    b.umur,
                    b.jenisKelamin,
                    b.alamat,
                    b.namaPosyandu,
                    b.beratBadan,
                    b.tinggiBadan,
                    statusGizi = (b.tinggiBadan == null || b.tinggiBadan == 0) ? "" :
                    utility.CalculateZScoreAndClassificationHeight(b.umur, Convert.ToDouble(b.tinggiBadan), b.jenisKelamin).classification,
                    zScore = (b.tinggiBadan == null || b.tinggiBadan == 0) ? (double?)null :
                    Math.Round(utility.CalculateZScoreAndClassificationHeight(b.umur, Convert.ToDouble(b.tinggiBadan), b.jenisKelamin).zScore ?? 0, 2),
                    b.namaOrangtua
                }).ToList();

                GridView1.DataSource = balitas;
                GridView1.DataBind();
            }
        }

        
    }
}
