using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Posyandu.AfterLoginKader
{
    public partial class ControlVitamin : System.Web.UI.Page
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

            bool merah = CheckBoxMerah.Checked;
            bool biru = CheckBoxBiru.Checked;

            DatabasePsoyanduEntities db = new DatabasePsoyanduEntities();
            var anak = db.balitas.FirstOrDefault(b => b.NIK == nik);

            if(anak != null) 
            {
                var existingData = db.pemberianVitaminAs.FirstOrDefault(g => g.NIK == nik);
                if (existingData != null) {
                    if (merah != false)
                    {
                        existingData.jenisVitaminA = "merah";
                    }
                    else if (biru != false) 
                    {
                        existingData.jenisVitaminA = "Biru";
                    }
                }
                else
                {
                    pemberianVitaminA p = new pemberianVitaminA();
                    p.NIK = nik;
                    if (merah != false)
                    {
                        p.jenisVitaminA = "merah";
                    }
                    else if (biru != false)
                    {
                        p.jenisVitaminA = "biru";
                    }else if(biru != false && merah != false)
                    {
                        LabelError.Text = "Pilih Salah Satu";
                    }
                    else if(biru == false && merah == false)
                    {
                        p.jenisVitaminA = null;
                    }
                    db.pemberianVitaminAs.Add(p);
                    
                }

                try
                {
                    db.SaveChanges();
                    LabelError.Text = "Data berhasil disimpan.";
                    Response.Redirect("WebForm1Kader.aspx");
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            LabelError.Text += "Jika kosong harap lewati halaman ini";
                            Response.Redirect("WebForm1Kader.aspx");
                        }
                    }
                }
            }



        }
    }
}