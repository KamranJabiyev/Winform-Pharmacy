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
    public partial class Admin : Form
    {
        private Form _login;
        private PharmacyEntities _db;
        public Admin(Form form)
        {
            _login = form;
            _db = new PharmacyEntities();
            InitializeComponent();
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Close();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            FillDgv();
        }

        private void FillDgv()
        {
            dgvAdmin.DataSource = "";
            dgvAdmin.DataSource = _db.Employees.Where(em => em.Confirmed == false
              && em.Deleted == false).Select(em => new
              {
                  em.Id,
                  em.Name,
                  em.Email
              }).ToList();
        }

        private void dgvAdmin_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id=int.Parse(dgvAdmin.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString());
            Employee employee = _db.Employees.First(em => em.Id == id);
            txtAdminMail.Text = employee.Email;
            txtAdminMail.Visible = true;
            btnAdminConfirm.Visible = true;
            btnAdminDelete.Visible = true;
        }

        private async void btnAdminDelete_Click(object sender, EventArgs e)
        {
            string email = txtAdminMail.Text.Trim();
            Employee employee= _db.Employees.First(em => em.Email==email);
            employee.Deleted = true;
            await _db.SaveChangesAsync();
            MessageBox.Show("Employee deleted");
            FillDgv();
            HideInput();
        }

        private async void btnAdminConfirm_Click(object sender, EventArgs e)
        {
            string email = txtAdminMail.Text.Trim();
            Employee employee = _db.Employees.First(em => em.Email == email);
            employee.Confirmed = true;
            await _db.SaveChangesAsync();
            MessageBox.Show("Employee confirmed");
            FillDgv();
            HideInput();
        }

        private void HideInput()
        {
            txtAdminMail.Text = "";
            txtAdminMail.Visible = false;
            btnAdminConfirm.Visible = false;
            btnAdminDelete.Visible = false;
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.ShowDialog();
        }
    }
}
