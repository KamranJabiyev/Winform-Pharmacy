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
    public partial class Form1 : Form
    {
        private PharmacyEntities _db;
        private Form _login;
        private int _userId;
        public Form1(Form form,int userId)
        {
            _userId = userId;
            _login = form;
            _db = new PharmacyEntities();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgv.DataSource = _db.Drugs.Select(d => new
            {
                d.Id,
                d.Name,
                d.Price,
                d.DrugCount,
                Type = d.DrugType.Name
            }).ToList();

            cmbDrugType.Items.AddRange(_db.DrugTypes.Where(t=>t.Deleted==true).Select(t=>new CB_DrugType { 
                Id=t.Id,
                Name=t.Name
            }).ToArray());

            cmbDrug.Items.AddRange(_db.Drugs.Where(d => d.Deleted == true)
                .Select(d => new CB_Drug
                {
                    Id = d.Id,
                    Name = d.Name,
                    Price = d.Price,
                    Count = d.DrugCount
                }).ToArray());
        }

        private void cmbDrugType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id =((CB_DrugType) cmbDrugType.SelectedItem).Id;
            dgv.DataSource = _db.Drugs.Where(d => d.TypeId == id).Select(d => new
            {
                d.Id,
                d.Name,
                d.Price,
                d.DrugCount,
                Type = d.DrugType.Name
            }).ToList();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateType type = new CreateType(cmbDrugType);
            type.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteType delete = new DeleteType(cmbDrugType);
            delete.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Close();
        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            CB_Drug selected_drug =(CB_Drug) cmbDrug.SelectedItem;
            int count = int.Parse(numDrug.Value.ToString());
            if (selected_drug.Count < count)
            {
                MessageBox.Show($"{selected_drug.Name} count - {selected_drug.Count}");
                return;
            }
            selected_drug.Count -= count;
            AddSaleList(selected_drug, count);



            decimal? total = decimal.Parse(lbTotal.Text.Trim());
            total += count * selected_drug.Price;
            lbTotal.Text = total.ToString();

            cmbDrug.Text = "";
            numDrug.Value = 0;

            
        }

        private void AddSaleList(CB_Drug selected_drug,int count)
        {
            bool exist = true;
            foreach (LS_Drug item in lsbDrugList.Items)
            {
                if (selected_drug.Id == item.Id)
                {
                    LS_Drug lsdrug = item;
                    lsbDrugList.Items.Remove(item);
                    lsdrug.Count += count;
                    lsbDrugList.Items.Add(lsdrug);
                    exist = false;
                    break;
                }
            }
            if (exist)
            {
                lsbDrugList.Items.Add(new LS_Drug
                {
                    Id = selected_drug.Id,
                    Name = selected_drug.Name,
                    Price = selected_drug.Price,
                    Count = count
                }).ToString();
            }
        }

        private async void btnSale_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Today;
            decimal total = decimal.Parse(lbTotal.Text);

            Sale sale = new Sale()
            {
                Time = date,
                Total = total,
                EmployeeId = _userId
            };

            foreach (LS_Drug item in lsbDrugList.Items)
            {
                sale.SellDrugs.Add(new SellDrug
                {
                    SaleId=sale.Id,
                    DrugId=item.Id,
                    DrugCount=item.Count
                });
            }
            _db.Sales.Add(sale);
            await _db.SaveChangesAsync();
            DecreaseDrugCount();
            MessageBox.Show("Kef ele");

        }

        private async void DecreaseDrugCount()
        {
            foreach (LS_Drug item in lsbDrugList.Items)
            {
                Drug drug=_db.Drugs.First(d => d.Id == item.Id);
                drug.DrugCount -= item.Count;
                await _db.SaveChangesAsync();
            }
        }
    }
}
