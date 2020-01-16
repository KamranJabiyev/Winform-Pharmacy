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
    public partial class DeleteType : Form
    {
        private PharmacyEntities _db;
        private ComboBox _cmb;
        public DeleteType(ComboBox cmb)
        {
            _cmb = cmb;
            _db = new PharmacyEntities();
            InitializeComponent();
        }

        private void DeleteType_Load(object sender, EventArgs e)
        {
            FillCmb(cmbDeleteType);
        }

        private async void btnDeleteType_Click(object sender, EventArgs e)
        {
            int id = ((CB_DrugType)cmbDeleteType.SelectedItem).Id;
            DrugType type = _db.DrugTypes.First(t => t.Id == id);
            type.Deleted = false;
            //_db.DrugTypes.Remove(type);
            await _db.SaveChangesAsync();

            MessageBox.Show("Successfully deleted");
            FillCmb(cmbDeleteType);
            FillCmb(_cmb);
        }

        private void FillCmb(ComboBox cmb)
        {
            cmb.Text = "";
            cmb.Items.Clear();
            cmb.Items.AddRange(_db.DrugTypes.Where(t => t.Deleted == true).Select(t => new CB_DrugType
            {
                Id = t.Id,
                Name = t.Name
            }).ToArray());
        }
    }
}
