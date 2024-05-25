using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Modele;
using Obsługa_Apteki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Obsługa_Apteki
{
    public partial class DeliveryAddEdit : Form
    {
        private AptekaTestDbContext _context = new AptekaTestDbContext();
        private DbActions _dbAction = new DbActions();
        private List<MedicineDelivery> _deliveryList = new List<MedicineDelivery>();
        private List<Medicine> _medicines = new List<Medicine>();
        private List<Pharmaceut> _pharmaceuts = new List<Pharmaceut>();  
        private Delivery _delivery = new Delivery();
        private double deliveryCost;
        
        public DeliveryAddEdit()
        {
            InitializeComponent();
            ComboboxDataLoad();
            LoadComboboxData();
           //DGVColumSet();    Coś mi się tu krzaczyło :(
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboboxDataLoad()
        {
            _medicines = _dbAction.GetMedicines();
            cbMedicines.DataSource = _medicines;
            cbMedicines.DisplayMember = "Name";
            cbMedicines.ValueMember = "MedicineId";
          

            _pharmaceuts = _dbAction.GetPharmaceuts();
            cbPharmaceut.DataSource = _pharmaceuts;
            cbPharmaceut.DisplayMember = "FullName";
            cbPharmaceut.ValueMember = "PharmaceutId";
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MedicineDelivery  stockItem = new MedicineDelivery();
            stockItem.Quantity = int.Parse(numericUpDown1.Value.ToString());
            stockItem.MedicineId = int.Parse(cbMedicines.SelectedValue.ToString());

            bool found = false;
            foreach (MedicineDelivery item in _deliveryList)
            {
                if (item.MedicineId == stockItem.MedicineId)
                {
                    item.Quantity += stockItem.Quantity;
                    found = true;
                    break;
                }
            }

           if (!found)
          {
                _deliveryList.Add(stockItem); 

          }

            dgvMedicinesDelivery.DataSource = null;
            dgvMedicinesDelivery.DataSource = _deliveryList;
            DGVComunSet();
            CountCostDelivery();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgvMedicinesDelivery.SelectedRows.Count > 0)
            {
                int deleteId = Convert.ToInt32(dgvMedicinesDelivery.SelectedRows[0].Cells["MedicineId"].Value);
                List<MedicineDelivery> stockList = _deliveryList;
                _deliveryList = new List<MedicineDelivery>();
                foreach (MedicineDelivery item in stockList)
                {
                    if (item.MedicineId != deleteId)
                    {
                        _deliveryList.Add(item);
                        
                    }
                };
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć Lek do usunięcia.");
            }
            dgvMedicinesDelivery.DataSource = null;
            dgvMedicinesDelivery.DataSource = _deliveryList;
            CountCostDelivery();
        }

        private void DGVComunSet()
        {
            if(_deliveryList != null && _deliveryList.Count > 0)
            {

            dgvMedicinesDelivery.Columns[nameof(MedicineDelivery.Delivery)].Visible = false;
            dgvMedicinesDelivery.Columns[nameof(MedicineDelivery.Medicine)].HeaderText= "Nazwa Leku";
            dgvMedicinesDelivery.Columns[nameof(MedicineDelivery.Quantity)].HeaderText = "Opakowania";
            dgvMedicinesDelivery.Columns[nameof(MedicineDelivery.DeliveryId)].Visible = false;
            dgvMedicinesDelivery.Columns[nameof(MedicineDelivery.MedicineId)].HeaderText = "ID Leku";
            }
        }

        private void CountCostDelivery()
        {
            double cost = 0;
            double cost2 = 0;
            deliveryCost = 0;

            List<Medicine> medicines = new List<Medicine>();
            medicines = _context.Medicines.ToList();
            foreach (MedicineDelivery medicine in _deliveryList) 
            {
                foreach (var item in medicines)
                {
                    if (item.MedicineId == medicine.MedicineId)
                    {
                        cost2 = item.PriceOfBuy;
                        break;
                    }
                }
                cost = (medicine.Quantity * cost2);
                deliveryCost += cost;
            }

            lbDeliveryCost.Text = deliveryCost.ToString();
        }

        private void LoadComboboxData()
        {
            _pharmaceuts = _dbAction.GetPharmaceuts();
            cbPharmaceut.DataSource = _pharmaceuts;
            cbPharmaceut.DisplayMember = "FullName";
            cbPharmaceut.ValueMember = "PharmaceutId";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _delivery.Value = double.Parse(lbDeliveryCost.Text);
            _delivery.DateOfCreate = DateTime.Now;
            _delivery.DateOfDelivery = DateTime.Parse(dateTimePicker1.Value.ToString());
            _delivery.PharmaceutOrdering = int.Parse(cbPharmaceut.SelectedValue.ToString());

            _dbAction.AddDeliveryWithMedicines(_delivery, _deliveryList);

            Close();
        }
    }
    
}
