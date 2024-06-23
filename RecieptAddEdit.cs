
using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Modele;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using System.Xml.Linq;
//using Medicine = Obsługa_Apteki.Modele.Medicine;

namespace Obsługa_Apteki
{
    public partial class RecieptAddEdit : Form
    {
        private DbActions _dbAction = new DbActions();
        private AptekaTestDbContext _context = new AptekaTestDbContext();
        private Reciept _reciept = new Reciept();
        List<Medicine> _medicines;
        List<Patient> _patients;
        MedicineReciept stockItem;
        private List<MedicineReciept> _stockList = new List<MedicineReciept>();

        public RecieptAddEdit()
        {
            InitializeComponent();
            LoadMedicinesData();
            LoadPatientsData();
            DGVColumnSet();
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
            try
            {
                _reciept.DateOfRegistry = DateTime.Now;

              

               DateTime dateOfExpire = DateTime.Parse(dtpDateOfExpire.Value.ToString());

                _reciept.DateOfExpire = dateOfExpire;

                if (!int.TryParse(cbPatients.SelectedValue.ToString(), out int patientId))
                {
                    MessageBox.Show("Proszę wybrać pacjenta.");
                    return;
                }

                _reciept.PatientId = patientId;

                var selectedPatient = cbPatients.SelectedItem as Patient;
                if (selectedPatient != null)
                {
                    _reciept.PatientFullName = selectedPatient.FullName;
                }
                else
                {
                    MessageBox.Show("Proszę wybrać pacjenta.");
                    return;
                }

                _reciept.DoctorFullName = tbDoctor.Text;

                _dbAction.AddRecieptWithMedicines(_reciept, _stockList);

                Close();
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show("Błąd podczas zapisywania danych: " + innerException);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zapisywania danych: " + ex.Message);
            }
        }

            private void btnAddToList_Click(object sender, EventArgs e)
        {
            stockItem = new MedicineReciept();
            stockItem.Quantity = int.Parse(nudQuantity.Value.ToString());
            stockItem.MedicineId = int.Parse(cbMedicines.SelectedValue.ToString());
            stockItem.MedicineName = cbMedicines.Text;
            
            bool found = false;
            foreach (MedicineReciept item in _stockList)
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
            DGVColumnSet();
            
        }

        private void btnDeleteFromList_Click(object sender, EventArgs e)
        {


            if (dataGridView1.SelectedRows.Count > 0)
            {
                int deleteId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MedicineId"].Value);
                foreach (MedicineReciept item in _stockList.ToList())
                {
                    if (item.MedicineId == deleteId)
                    {
                        _stockList.Remove(item);
                    }

                };

                dataGridView1.DataSource = null;
                if (_stockList.Count == 0)
                {
                    dataGridView1.ColumnHeadersVisible = false;
                }
                else
                {
                    dataGridView1.DataSource = _stockList;
                    DGVColumnSet();
                }

            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć Lek do usunięcia.");
            }
        }

        private void DGVColumnSet()
        {


            if (_stockList != null && _stockList.Count > 0)
            {

                dataGridView1.Columns[nameof(MedicineReciept.MedicineId)].HeaderText = "Id Leku";
                dataGridView1.Columns[nameof(MedicineReciept.MedicineId)].DisplayIndex = 0;
                dataGridView1.Columns[nameof(MedicineReciept.MedicineName)].HeaderText = "Nazwa leku";
                dataGridView1.Columns[nameof(MedicineReciept.MedicineName)].DisplayIndex = 1;
                dataGridView1.Columns[nameof(MedicineReciept.Quantity)].HeaderText = "Ilość";
                dataGridView1.Columns[nameof(MedicineReciept.Quantity)].DisplayIndex = 2;
                dataGridView1.Columns[nameof(MedicineReciept.Reciept)].Visible = false;
                dataGridView1.Columns[nameof(MedicineReciept.RecieptId)].Visible = false;
                dataGridView1.Columns[nameof(MedicineReciept.DoctorFullName)].Visible = false;
                dataGridView1.Columns[nameof(MedicineReciept.MedicineRecieptId)].Visible = false;
                dataGridView1.Columns[nameof(MedicineReciept.Medicine)].Visible = false;
            }

        }

    }

}
