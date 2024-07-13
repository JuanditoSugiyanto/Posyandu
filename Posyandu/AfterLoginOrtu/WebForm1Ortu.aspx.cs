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
                var balitas = from b in db.balitas where b.NIK_OrangTua == nikOrangTua
                              select new
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
                                  b.statusGizi,
                                  b.NIK_OrangTua
                              };

                GridView1.DataSource = balitas.ToList();
                GridView1.DataBind();
            }
        }


    }
}