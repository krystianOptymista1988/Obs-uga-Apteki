using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Obsługa_Apteki
{
    public partial class LoginPanel : Form
    {
        private AptekaTestDbContext _context = new AptekaTestDbContext();
        private DbActions _dbAction = new DbActions();
        private List<Pharmaceut> _logins = new List<Pharmaceut>();
        private string password;
        


        public LoginPanel()
        {
            InitializeComponent();
            ComboboxLoad();
        }

        private void ComboboxLoad()
        {
           _logins = _dbAction.GetPharmaceuts();
            cbxUser.DataSource = _logins;
            cbxUser.DisplayMember = "FullName";
            cbxUser.ValueMember = "PharmaceutId";

        }

        private void CheckPassword()
        {

            int userID = int.Parse(cbxUser.SelectedValue.ToString());
            password = tbPassword.Text;
            foreach (Pharmaceut login in _logins)
            {
                if (userID == login.PharmaceutId)
                {
                    if(login.password == password)
                    {
                        
                        this.Hide();
                        var main = new Main();
                        main.LogOn = true;
                        main.Show();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Błąd logowania, wprowadź prawidłowe hasło");
                    }

                }
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            CheckPassword();
        }
    }
}
