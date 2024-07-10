using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Posyandu.Register_and_Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string nik = TxtNikLogin.Text;
            string password = TxtPasswordReg.Text;

            DatabasePsoyanduEntities db = new DatabasePsoyanduEntities();

            userAccount u = (from y in db.userAccounts where y.NIK.Equals(nik) && y.kataSandi.Equals(password) select y).FirstOrDefault();

            if (u == null)
            {
                ErrorMsg1.Text = "User is Empty";
            }
            else
            {
                string peran = u.peran;

                string userName = "";
                if (peran == "kader")
                {
                    petuga k = (from n in db.petugas where n.NIK.Equals(nik) select n).FirstOrDefault();
                    userName = k?.namaPetugas;
                }
                else if (peran == "orangtua")
                {
                    orangtua o = (from k in db.orangtuas
                                  where k.NIK.Equals(nik)
                                  select k).FirstOrDefault();
                    userName = o?.namaOrangtua;
                    

                    
                }

                Session["UserName"] = userName;
                if (Session["UserName"] == null)
                {
                    ErrorMsg1.Text = "Session not set";
                    return;
                }

                if (peran == "kader")
                {

                    Response.Redirect("../AfterLoginKader/WebForm1Kader.aspx");
                }else if(peran == "orangtua")
                {             
                    Response.Redirect("../AfterLoginOrtu/WebForm1Ortu.aspx");
                }

                if (Session["UserName"] == null)
                {
                    ErrorMsg1.Text = "Session not set";
                }
            }
        }
    }
}