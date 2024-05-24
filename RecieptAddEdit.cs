using Obsługa_Apteki.Entities;
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
        public RecieptAddEdit()
        {
            InitializeComponent();
            LoadMedicinesData();
            LoadPatientsData();
            DGVHeadersSet();
            DataLoad();
        }

        private void btnAccept_Click(object sender, System.EventArgs e)
        {
            try
            {
                using (_context)
                {

                    if (!string.IsNullOrEmpty(tbId.Text))
                    {
                        // Aktualizowanie istniejącej recepty
                        int id = int.Parse(tbId.Text);
                        reciept = _context.Reciepts.SingleOrDefault(p => p.RecieptId == id);
                        if (reciept != null)
                        {
                            reciept = CreateReciept();
                            _context.Entry(reciept).State = EntityState.Modified;
                            MessageBox.Show("Aktualizowano dane Recepty");
                        }
                        else
                        {
                            MessageBox.Show("Nie znaleziono Recepty o podanym ID");
                            return;
                        }
                    }
                    else
                    {
                        // Dodawanie nowej recepty
                        reciept = new Reciept();
                        reciept = CreateReciept(reciept);
                        _context.Reciepts.Add(reciept);
                        MessageBox.Show($"Dodano nową receptę: ID {reciept.RecieptId}");
                    }
                    _context.SaveChanges();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zapisywania danych: " + ex.Message);
            }
        }

        private Reciept CreateReciept()
        {
            reciept.Quantity = int.Parse(nudQuantity.Text);
            reciept.DateOfRegistry = DateTime.Parse(dtpDateOfRegistry.Value.ToString());
            reciept.DateOfExpire = DateTime.Parse(dtpDateOfExpire.Value.ToString());
            //pharmaceut.Salary = int.Parse(nmSallary.Value.ToString());
            reciept.Doctor.FullName = tbDoctor.Text;
            //// pharmaceut.Patients = new List<Patient>();
            
            return reciept;
        }

        private Reciept CreateReciept(Reciept reciept)
        {
            int recieptID = int.Parse(tbId.Text);

            reciept.Quantity = int.Parse(nudQuantity.Text);
            reciept.Quantity = int.Parse(nudQuantity.Text);
            reciept.DateOfRegistry = DateTime.Parse(dtpDateOfRegistry.Value.ToString());
            reciept.DateOfExpire = DateTime.Parse(dtpDateOfExpire.Value.ToString());
            //pharmaceut.Salary = int.Parse(nmSallary.Value.ToString());
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

        private void DGVHeadersSet()
        {
            //dataGridView1.Columns[nameof(_medicines)].HeaderText = "Lek";
            //dataGridView1.Columns[nameof(_medicines)].DisplayIndex = 0;
            //dataGridView1.Columns[nameof(Reciept.Quantity)].HeaderText = "Ilość";
            //dataGridView1.Columns[nameof(Reciept.Quantity)].DisplayIndex = 1;
            //dataGridView1.Columns[nameof(Reciept.DoctorId)].Visible = false;
            //dataGridView1.Columns[nameof(Reciept.PatientId)].Visible = false;
            //dataGridView1.Columns[nameof(Reciept.DateOfRegistry)].Visible = false;
            //dataGridView1.Columns[nameof(Reciept.DateOfExpire)].Visible = false;
            //dataGridView1.Columns[nameof(Reciept.Doctor)].Visible = false;
        }

        private void DataLoad()
        {
            reciepts = _dbAction.GetReciepts();

            if (reciepts == null || reciepts.Count == 0)
            {
                var columnNames = _dbAction.GetColumnNames<Reciept>();
                var dataTable = new DataTable();
                foreach (var columnName in columnNames)
                {
                    dataTable.Columns.Add(columnName);
                }
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                dataGridView1.DataSource = reciepts;
            }
        }
    }
}
