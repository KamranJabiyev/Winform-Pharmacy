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
    public partial class Register : Form
    {
        private Form _login;
        private PharmacyEntities _db;
        public Register(Form form)
        {
            _db = new PharmacyEntities();
            _login = form;
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Show();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtRegisterName.Text.Trim();
            string email = txtRegisterEmail.Text.Trim();
            string password = txtRegisterPass.Text.Trim();

            if (name == "" || email == "" || password == "")
            {
                MessageBox.Show("Please fill all input!!!");
                return;
            }

            if (!email.IsEmail())
            {
                MessageBox.Show("Email is not valid!!!");
                return;
            }

            if (_db.Employees.Any(em => em.Email == email))
            {
                MessageBox.Show("Email allready exist!!!");
                return;
            }

            string hashPassword = password.PassHash();
            Employee employee = new Employee
            {
                Name=name,
                Email=email,
                Password=hashPassword
            };
            _db.Employees.Add(employee);
            await _db.SaveChangesAsync();
            MessageBox.Show("Success");
            this.Close();
        }
    }
}
