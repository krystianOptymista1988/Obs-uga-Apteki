﻿using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Models;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Obsługa_Apteki
{
    public partial class MedicineWarehouse : Form
    {
        private DbActions _dbAction = new DbActions();
        private AptekaTestDbContext _context = new AptekaTestDbContext();
        private List<Medicine> medicines;

        public MedicineWarehouse()
        {
            InitializeComponent();
            RefreshData();
            DGVHeadersFill();
            LoadComboboxData();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void Warehouse_Load(object sender, EventArgs e)
        {

        }

        public void DGVHeadersFill() 
        {
            dataGridView1.Columns[nameof(Medicine.MedicineId)].HeaderText = "ID";
            dataGridView1.Columns[nameof(Medicine.MedicineId)].DisplayIndex = 0;
            dataGridView1.Columns[nameof(Medicine.Name)].HeaderText = "Nazwa";
            dataGridView1.Columns[nameof(Medicine.Name)].DisplayIndex = 1;
            dataGridView1.Columns[nameof(Medicine.Category)].HeaderText = "Kategoria";
            dataGridView1.Columns[nameof(Medicine.Category)].DisplayIndex = 2;
            dataGridView1.Columns[nameof(Medicine.ExpiredDates)].HeaderText = "Uwagi";
            dataGridView1.Columns[nameof(Medicine.ExpiredDates)].DisplayIndex = 3;
            dataGridView1.Columns[nameof(Medicine.IsRefunded)].HeaderText = "Refundacja";
            dataGridView1.Columns[nameof(Medicine.IsOnReciept)].Visible = false;
            dataGridView1.Columns[nameof(Medicine.ActiveSubstance)].HeaderText = "Substancja Aktywna";
            dataGridView1.Columns[nameof(Medicine.Deliveries)].Visible = false;
            dataGridView1.Columns[nameof(Medicine.Doctor)].Visible = false;
            dataGridView1.Columns[nameof(Medicine.ExpiredDates)].Visible = false;
            dataGridView1.Columns[nameof(Medicine.Price)].HeaderText = "Cena";
            dataGridView1.Columns[nameof(Medicine.Producent)].HeaderText = "Producent";
            dataGridView1.Columns[nameof(Medicine.Producent)].DisplayIndex = 4;
            dataGridView1.Columns[nameof(Medicine.PercentageOfRefunding)].Visible = false;
            dataGridView1.Columns[nameof(Medicine.PriceAfterRefunding)].HeaderText = "Cena NFZ";
            dataGridView1.Columns[nameof(Medicine.QuantityInPackage)].HeaderText = "Ilość w Op";
            dataGridView1.Columns[nameof(Medicine.QuantityOnMagazines)].HeaderText = "Na Magazynie";
            dataGridView1.Columns[nameof(Medicine.IsAntibiotique)].Visible = false;
            dataGridView1.Columns[nameof(Medicine.Reciepts)].Visible = false;



        }

        public void RefreshData()
        {
            dataGridView1.Rows.Clear();
            
            medicines = _dbAction.GetMedicines();
            dataGridView1.DataSource = medicines;  
        }

        private void LoadComboboxData()
        {
            comboBox1.Items.Clear();

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                comboBox1.Items.Add(column.HeaderText);
            }

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var medicineCard = new MedicineCard();
            medicineCard.ShowDialog();
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    int MedicineId = (int)dataGridView1.CurrentRow.Cells["ID"].Value;
                    using (var _context = _dbAction.GetContext())
                    {
                        MedicineCard editForm = new MedicineCard(MedicineId, _context);
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            DataLoad();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Wybierz Asortyment do edycji.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas edycji Asortymentu: " + ex.Message);
            }
        }

        private void btnAddDelivery_Click(object sender, EventArgs e)
        {
            var DeliveryToStock = new DeliveryToStock();
            DeliveryToStock.ShowDialog();
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void DataLoad()
        {
            medicines = _dbAction.GetMedicines();

            if (medicines == null || medicines.Count == 0)
            {
                var columnNames = _dbAction.GetColumnNames<Medicine>();
                var dataTable = new DataTable();
                foreach (var columnName in columnNames)
                {
                    dataTable.Columns.Add(columnName);
                }
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                dataGridView1.DataSource = medicines;
            }
        }
    }
}
