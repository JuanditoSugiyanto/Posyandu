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
                PopulateDropDownList3();
                
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

        private void PopulateDropDownList3()
        {
            
            DropDownList3.Items.Add(new ListItem("Select City", ""));
            DropDownList3.Items.Add(new ListItem("Jakarta Timur", "1"));
            DropDownList3.Items.Add(new ListItem("Jakarta Barat", "2"));
            DropDownList3.Items.Add(new ListItem("Jakarta Selatan", "3"));
            DropDownList3.Items.Add(new ListItem("Jakarta Utara", "4"));
            DropDownList3.Items.Add(new ListItem("Jakarta Pusat", "5"));
           
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCity = DropDownList3.SelectedItem.Text;
            PopulateDropDownList4(selectedCity);
        }

        private void PopulateDropDownList4(string city)
        {
            DropDownList4.Items.Clear();

            List<string> districts = new List<string>();

            switch (city)
            {
                case "Jakarta Timur":
                    districts = new List<string> { "Cakung", "Cipayung", "Ciracas", "Duren Sawit", "Jatinegara", "Kramat Jati", "Makasar", "Matraman", "Pasar Rebo", "Pulogadung" };
                    break;
                case "Jakarta Barat":
                    districts = new List<string> { "Cengkareng", "Grogol Petamburan", "Kalideres", "Kebon Jeruk", "Kembangan", "Palmerah", "Taman Sari", "Tambora" };
                    break;
                case "Jakarta Selatan":
                    districts = new List<string> { "Cilandak", "Jagakarsa", "Kebayoran Baru", "Kebayoran Lama", "Mampang Prapatan", "Pancoran", "Pasar Minggu", "Pesanggrahan", "Setiabudi", "Tebet" };
                    break;
                case "Jakarta Utara":
                    districts = new List<string> { "Cilincing", "Kelapa Gading", "Koja", "Pademangan", "Penjaringan", "Tanjung Priok" };
                    break;
                case "Jakarta Pusat":
                    districts = new List<string> { "Cempaka Putih", "Gambir", "Johar Baru", "Kemayoran", "Menteng", "Sawah Besar", "Senen", "Tanah Abang" };
                    break;
                default:
                    districts.Add("Select District");
                    break;
            }

            foreach (var district in districts)
            {
                DropDownList4.Items.Add(new ListItem(district, district));

            }
        }


        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDistrict = DropDownList4.SelectedItem.Text;
            PopulateDropDownList5(selectedDistrict);
        }

        private void PopulateDropDownList5(string kelurahan)
        {
            DropDownList5.Items.Clear();
            List<string> districts = new List<string>();
            switch (kelurahan)
            {
                case "Kebon Jeruk":
                    districts = new List<string> { "Duri Kepa", "Kedoya Selatan", "Kedoya Utara", "Kebon Jeruk", "Sukabumi Utara", "Kelapa Dua", "Sukabumi Selatan" };
                    break;
                
                default:
                    districts.Add("Pilih Keluarahan");
                    break;
            }
            foreach (var district in districts)
            {
                DropDownList5.Items.Add(new ListItem(district, district));

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