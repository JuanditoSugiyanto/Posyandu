using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Posyandu.Register_and_Login
{
    public partial class RegisterKader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            string nama = TxtName.Text;
            string tanggalLahir = HiddenFieldDatePicker.Value;
            string password = TxtPasswordReg.Text;
            string nik = TxtNikReg.Text;
            string peran = "kader";

            DateTime tanggalLahirParsed;

            if(!DateTime.TryParse(tanggalLahir, out tanggalLahirParsed))
            {
                ErorMsg1.Text = "Format tanggal lahir salah, harap jangan di ubah";
                return;
            }

            petuga p = new petuga();
            p.namaPetugas = nama;
            p.tanggalLahirKader = tanggalLahirParsed;
            p.NIK = nik;
            

            userAccount a = new userAccount();
            a.kataSandi = password;
             a.peran = peran;
            a.NIK = nik;
            
            if (IsNIKExists(nik))
            {
                ErorMsg1.Text = "NIK sudah ada harap cek kembali";
                return;
            }
            DatabasePsoyanduEntities db = new DatabasePsoyanduEntities();         
            db.userAccounts.Add(a);
            db.petugas.Add(p);
            db.SaveChanges();

            Response.Redirect("Login.aspx");

        }
        private bool IsNIKExists(string nik)
        {
            using (DatabasePsoyanduEntities db = new DatabasePsoyanduEntities())
            {
                return db.userAccounts.Any(u => u.NIK == nik);
            }
        }
    }
}