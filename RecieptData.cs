using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Modele;
using Obsługa_Apteki.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Obsługa_Apteki
{
    public partial class RecieptData : Form
    {
        private DbActions _dbAction = new DbActions();
        private Reciept _reciept = new Reciept();
        private List<MedicineReciept> _medicines;

        public RecieptData()
        {
            InitializeComponent();
            DGVColumnSet();
        }

        public RecieptData(Reciept reciept)
        {
            InitializeComponent();
            _reciept = reciept;
            LoadRecieptData();

        }

        public void LoadRecieptData()
        {

            if (_reciept != null)
            {

                tbDoctor.Text = _reciept.DoctorFullName;
                tbPatient.Text = _reciept.PatientFullName;
                tbDateOfExpire.Text = _reciept.DateOfExpire.ToString();
                LoadMedicinesFromReciept(_reciept.RecieptId);
            }
        }

        //Metoda do wyświetlenia leków z wybranej recepty
        private void LoadMedicinesFromReciept(int recieptId)
        {
            _medicines = _dbAction.GetMedicinesFromReciept(recieptId);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _medicines;
            DGVColumnSet();
        }

        private void DGVColumnSet()
        {
            if (_medicines != null && _medicines.Count > 0)
            {

                dataGridView1.Columns[nameof(MedicineReciept.MedicineId)].Visible = false;
                dataGridView1.Columns[nameof(MedicineReciept.MedicineName)].HeaderText = "Nazwa leku";
                dataGridView1.Columns[nameof(MedicineReciept.MedicineName)].DisplayIndex = 0;
                dataGridView1.Columns[nameof(MedicineReciept.Quantity)].HeaderText = "Ilość";
                dataGridView1.Columns[nameof(MedicineReciept.Quantity)].DisplayIndex = 1;
                dataGridView1.Columns[nameof(MedicineReciept.Reciept)].Visible = false;
                dataGridView1.Columns[nameof(MedicineReciept.RecieptId)].Visible = false;
                dataGridView1.Columns[nameof(MedicineReciept.DoctorFullName)].Visible = false;
                dataGridView1.Columns[nameof(MedicineReciept.MedicineRecieptId)].Visible = false;
                dataGridView1.Columns[nameof(MedicineReciept.Medicine)].Visible = false;
            }
        }
    }
}
