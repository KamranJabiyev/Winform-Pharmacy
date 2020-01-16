using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy
{
    public partial class Login : Form
    {
        private PharmacyEntities _db;
        public Login()
        {
            _db = new PharmacyEntities();
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtLoginEmail.Text.Trim();
            string password = txtLoginPass.Text.Trim().PassHash();

            if (email == "" || password == "")
            {
                MessageBox.Show("Please fill all input!!!");
                return;
            }
            var employee = _db.Employees.FirstOrDefault(em => em.Email == email 
                                                            && em.Password == password);
            if (employee == null)
            {
                MessageBox.Show("Incorrect email or password!!!");
                return;
            }
            if (employee.Deleted)
            {
                MessageBox.Show("This account deleted!!!");
                return;
            }
            if (!employee.Confirmed)
            {
                MessageBox.Show("Please wait confermation!!!");
                return;
            }

            if (employee.IsAdmin)
            {
                Admin admin = new Admin(this);
                this.Hide();
                admin.Show();
            }
            else
            {
                Form1 form = new Form1(this,employee.Id);
                this.Hide();
                form.Show();
            }
        }

        private void btnRegistrPage_Click(object sender, EventArgs e)
        {
            Register register = new Register(this);
            this.Hide();
            register.Show();
        }
    }
}
