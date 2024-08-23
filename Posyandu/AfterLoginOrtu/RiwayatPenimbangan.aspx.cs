using Posyandu.Utilities;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Posyandu.AfterLoginOrtu
{
    public partial class RiwayatPenimbangan : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            string nikOrangTua = Session["UserNIK"] as string;
            if (string.IsNullOrEmpty(nikOrangTua))
            {
                Response.Redirect("../Register and Login/Login.aspx");
            }

            string nikAnak = Request.QueryString["NIK"];
            if (string.IsNullOrEmpty(nikAnak))
            {
                Response.Redirect("WebForm1Ortu.aspx");
            }

            using (DatabasePsoyanduEntities db = new DatabasePsoyanduEntities())
            {
               
                var anak = db.balitas.FirstOrDefault(b => b.NIK == nikAnak);
                if (anak == null)
                {
                   
                    Response.Redirect("WebForm1Ortu.aspx");
                }

                DateTime tanggalLahir = anak.tanggalLahir;
                growthUtility utility = new growthUtility();

                var penimbanganList = db.RecordTimbangPersonals
                                       .Where(r => r.NIK == nikAnak)
                                       .Select(r => new
                                       {
                                           r.Tanggal_Timbang,
                                           r.Berat_Badan,
                                           r.Tinggi_Badan
                                           
                                       })
                                       .ToList();

              
                var penimbanganListWithAge = penimbanganList
                                            .Select(r => new
                                            {
                                                r.Tanggal_Timbang,
                                                r.Berat_Badan,
                                                r.Tinggi_Badan,
                                     
                                                Umur = CalculateAgeInMonths(tanggalLahir, r.Tanggal_Timbang),
                                                Status_Gizi = (r.Berat_Badan == null || r.Berat_Badan == 0) ? "" :
                                                  utility.CalculateZScoreAndClassificationWeight(CalculateAgeInMonths(tanggalLahir, r.Tanggal_Timbang), Convert.ToDouble(r.Berat_Badan), anak.jenisKelamin).classification
                                            })
                                            .ToList();

                GridView1.DataSource = penimbanganListWithAge;
                GridView1.DataBind();
            }
        }

        private int CalculateAgeInMonths(DateTime tanggalLahir, DateTime tanggalTimbang)
        {
            int years = tanggalTimbang.Year - tanggalLahir.Year;
            int months = tanggalTimbang.Month - tanggalLahir.Month;

            if (months < 0)
            {
                years--;
                months += 12;
            }

            return (years * 12) + months;
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DateTime tanggalTimbang = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "Tanggal_Timbang"));
                e.Row.Cells[0].Text = tanggalTimbang.ToString("dd/MM/yyyy");
            }
        }

    }
}
