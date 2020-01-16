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
    public partial class CreateType : Form
    {
        private PharmacyEntities _db;
        private ComboBox _cmb;
        public CreateType(ComboBox cmb)
        {
            _cmb = cmb;
            _db = new PharmacyEntities();
            InitializeComponent();
        }

        private async void btnCreateType_Click(object sender, EventArgs e)
        {
            string name = txtCreateTypeName.Text.Trim();
            if (name == "")
            {
                MessageBox.Show("Fill all input", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_db.DrugTypes.Any(t => t.Name.ToLower() == name.ToLower()))
            {
                MessageBox.Show($"{name} already exist", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DrugType type = new DrugType() { Name = name };
            _db.DrugTypes.Add(type);
            await _db.SaveChangesAsync();

            MessageBox.Show($"Succussfully added", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtCreateTypeName.Text = "";

            _cmb.Items.Clear();
            _cmb.Items.AddRange(_db.DrugTypes.Select(t => new CB_DrugType
            {
                Id = t.Id,
                Name = t.Name
            }).ToArray());
        }
    }
}
