using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Modele;
using Obsługa_Apteki.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Obsługa_Apteki
{
    public partial class RecieptAddEdit : Form
    {
        private DbActions _dbAction = new DbActions();
        private AptekaTestDbContext _context = new AptekaTestDbContext();
        private Reciept reciept = new Reciept();
        List<Medicine> _medicines;
        List<Patient> _patients;
        private List<Reciept> reciepts;

        private List<Stock> _stockList = new List<Stock>();
        public RecieptAddEdit()
        {
            InitializeComponent();
            LoadMedicinesData();
            LoadPatientsData();            
        }


        private Reciept CreateReciept()
        {
            reciept.Quantity = int.Parse(nudQuantity.Value.ToString());
            reciept.DateOfRegistry = DateTime.Parse(dtpDateOfRegistry.Value.ToString());
            reciept.DateOfExpire = DateTime.Parse(dtpDateOfExpire.Value.ToString());
            reciept.Doctor.FullName = tbDoctor.Text;
            //// pharmaceut.Patients = new List<Patient>();
            
            return reciept;
        }

        private Reciept CreateReciept(Reciept reciept)
        {
            int recieptID = int.Parse(tbId.Text);

            reciept.Quantity = int.Parse(nudQuantity.Value.ToString());
            reciept.DateOfRegistry = DateTime.Parse(dtpDateOfRegistry.Value.ToString());
            reciept.DateOfExpire = DateTime.Parse(dtpDateOfExpire.Value.ToString());
            reciept.Doctor.FullName = tbDoctor.Text;

            return reciept;
        }


        private void LoadMedicinesData()
        {
            _medicines = _dbAction.GetMedicines();
            cbMedicines.DataSource = _medicines;
            cbMedicines.DisplayMember = "Name";
            cbMedicines.ValueMember = "MedicineId";
        }


        private void LoadPatientsData()
        {
            _patients = _dbAction.GetPatients();
            cbPatients.DataSource = _patients;
            cbPatients.DisplayMember = "FullName";
            cbPatients.ValueMember = "PatientId";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAccept_Click_1(object sender, EventArgs e)
        {
            //try
            //{
            //    using (_context)
            //    {

            //        if (!string.IsNullOrEmpty(tbId.Text))
            //        {
            //            // Aktualizowanie istniejącej recepty
            //            int id = int.Parse(tbId.Text);
            //            reciept = _context.Reciepts.SingleOrDefault(p => p.RecieptId == id);
            //            if (reciept != null)
            //            {
            //                reciept = CreateReciept();
            //                _context.Entry(reciept).State = EntityState.Modified;
            //                MessageBox.Show("Aktualizowano dane Recepty");
            //            }
            //            else
            //            {
            //                MessageBox.Show("Nie znaleziono Recepty o podanym ID");
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            // Dodawanie nowej recepty
            //            reciept = new Reciept();
            //            reciept = CreateReciept(reciept);
            //            _context.Reciepts.Add(reciept);
            //            MessageBox.Show($"Dodano nową receptę: ID {reciept.RecieptId}");
            //        }
            //        _context.SaveChanges();
            //    }
            //    this.DialogResult = DialogResult.OK;
            //    this.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Błąd podczas zapisywania danych: " + ex.Message);
            //}

            reciept.DateOfRegistry = DateTime.Now;
            reciept.DateOfExpire = DateTime.Parse(dtpDateOfExpire.Value.ToString());
            reciept.PatientId = int.Parse(cbPatients.SelectedValue.ToString());

            _dbAction.AddRecieptWithMedicines(reciept, _stockList);

            Close();
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            Stock stockItem = new Stock();
            stockItem.Quantity = int.Parse(nudQuantity.Value.ToString());
            stockItem.MedicineId = int.Parse(cbMedicines.SelectedValue.ToString());
            bool found = false;
            foreach (Stock item in _stockList)
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
                _stockList.Add(stockItem);

            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _stockList;
        }

        private void btnDeleteFromList_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int deleteId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MedicineId"].Value);
                foreach (Stock item in _stockList.ToList())
                {
                    if (item.MedicineId == deleteId)
                    {
                        _stockList.Remove(item);
                    }
                };
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć Lek do usunięcia.");
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _stockList;

        }
    }

}
