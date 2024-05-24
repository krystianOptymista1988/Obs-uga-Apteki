using Obsługa_Apteki.Entities;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using static Obsługa_Apteki.Modele.ExpiredMedicines;

namespace Obsługa_Apteki
{
    public partial class Utilization : Form
    {
        public Utilization()
        {
            InitializeComponent();
            LoadExpiredMedicines();
            ConfigureDataGridView();
        }

        private void LoadExpiredMedicines()
        {
               DbActions dbActions = new DbActions();
    List<ExpiredMedicineInfo> expiredMedicines = dbActions.GetExpiredMedicinesWithQuantities();
    dataGridView1.DataSource = expiredMedicines;
        }

        private void ConfigureDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MedicineId",
                HeaderText = "ID",
                Name = "MedicineId"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Nazwa",
                Name = "Name"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Category",
                HeaderText = "Kategoria",
                Name = "Category"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DateOfExpire",
                HeaderText = "Termin Ważności",
                Name = "DateOfExpire"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ExpiredQuantity",
                HeaderText = "Opakowania Ilość",
                Name = "ExpiredQuantity"
            });
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one row to delete.");
                return;
            }

            using (var context = new AptekaTestDbContext())
            {
                foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                {
                    int medicineId = Convert.ToInt32(selectedRow.Cells["MedicineId"].Value);

                    var quantitiesOnMagazine = context.QuantitiesOnMagazine
                        .Include(q => q.Medicine.ExpiredDates)
                        .Where(q => q.MedicineId == medicineId && q.Medicine.ExpiredDates.Any(ed => ed.DateofExpire < DateTime.Now))
                        .ToList();

                    if (quantitiesOnMagazine.Any())
                    {
                        context.QuantitiesOnMagazine.RemoveRange(quantitiesOnMagazine);
                        context.SaveChanges();
                    }
                }
            }


        }
    }
}
