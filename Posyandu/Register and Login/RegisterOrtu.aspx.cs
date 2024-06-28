using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Posyandu.Register_and_Login
{
    public partial class RegisterOrtu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateRWDropdown();
            }
        }
        private void PopulateRWDropdown()
        {
            for (int i = 1; i <= 100; i++)
            {
                DropDownList1.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            for (int i = 1; i <= 300; i++)
            {
                DropDownList2.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            string nama = TxtName.Text;
            string nomorTelepon = TxtTelp.Text;
            string tanggalLahir = HiddenFieldDatePicker.Value;
            string password = TxtPasswordReg.Text; 
            string NIK = TxtNikReg.Text;
            string selectedRW = DropDownList1.SelectedValue;
            string selectedRT = DropDownList2.SelectedValue;

            DateTime tanggalLahirParsed;

            if (!DateTime.TryParse(tanggalLahir, out tanggalLahirParsed))
            {
                ErorMsg1.Text = "Format tanggal lahir salah, harap jangan di ubah";
                return;
            }


            orangtua o = new orangtua();
            o.namaOrangtua = nama;
            o.noTelp = nomorTelepon;
            o.RT = selectedRT;
            o.RW = selectedRW;
            o.NIK = NIK;
            o.tanggalLahirorangtua = tanggalLahirParsed;
            userAccount u = new userAccount();
            u.NIK = NIK; 
            u.peran = "orangtua";
            u.kataSandi = password;
            if (IsNIKExists(NIK))
            {
                ErorMsg1.Text = "NIK sudah ada harap cek kembali";
                return;
            }

            DatabasePsoyanduEntities db = new DatabasePsoyanduEntities();
            db.userAccounts.Add(u);
            db.orangtuas.Add(o);
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