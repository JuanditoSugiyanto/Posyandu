using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Posyandu.AfterLoginOrtu
{
    public partial class TambahAnak : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnTambah_Click(object sender, EventArgs e)
        {
            string nik = TxtNIK.Text;
            string namaAnak = TxtNamaAnak.Text;
            string TanggalLahir = HiddenFieldDatePicker.Value;
            string Alamat = TxtAlamatAnak.Text;
            string kelamin = TxtKelamin.Text;  
            string nikOrangTua = Session["UserNIK"] as string;
            string namaOrangTUa = Session["UserName"] as string;
            DateTime tanggalLahirParsed;

            if (!DateTime.TryParse(TanggalLahir, out tanggalLahirParsed))
            {
                ErorMsg1.Text = "Format tanggal lahir salah, harap jangan di ubah";
                return;
            }
            if(nikOrangTua == null)
            {
                ErorMsg1.Text = "Session has expired. Please log in again.";
                return;
            }
            int ageInMonths = CalculateAgeInMonths(tanggalLahirParsed);
            balita b = new balita();
            b.namaAnak = namaAnak;
            b.NIK = nik;
            b.alamat = Alamat;
            b.tanggalLahir = tanggalLahirParsed;
            b.jenisKelamin = kelamin;
            b.umur = ageInMonths;
            b.NIK_OrangTua = nikOrangTua;
            b.namaOrangtua = namaOrangTUa;
            if (IsNIKExists(nik))
            {
                ErorMsg1.Text = "NIK sudah ada harap cek kembali";
                return;
            }
            

            DatabasePsoyanduEntities db = new DatabasePsoyanduEntities();
            db.balitas.Add(b);
            db.SaveChanges();

            Response.Redirect("WebForm1Ortu.aspx");

        }
        private bool IsNIKExists(string nik)
        {
            using (DatabasePsoyanduEntities db = new DatabasePsoyanduEntities())
            {
                return db.balitas.Any(u => u.NIK == nik);
            }
        }

        private int CalculateAgeInMonths(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int months = (today.Year - birthDate.Year) * 12 + today.Month - birthDate.Month;

            // If the birth date has not occurred yet this month, subtract one month
            if (birthDate.Day > today.Day)
            {
                months--;
            }

            return months;
        }
    }
}