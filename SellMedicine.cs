using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Modele;
using Obsługa_Apteki.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Obsługa_Apteki
{   
    public partial class SellMedicine : Form
    {
        private AptekaTestDbContext _context = new AptekaTestDbContext();
        private List<Medicine> medicines = new List<Medicine>();
        private List<MedicineDelivery> _medicinedelivery = new List<MedicineDelivery>();
        private DbActions _dbAction = new DbActions();
        private Reciept _reciept = new Reciept();
        private List<MedicineReciept> _medicines = new List<MedicineReciept>();
        public SellMedicine()
        {
            InitializeComponent();
            DataLoad();
            DGVHeadersFill();
        }

        public SellMedicine(Reciept reciept, AptekaTestDbContext context)
        {
            InitializeComponent();
            _context = context;
            _reciept = reciept;
            LoadRecieptData();
            DataLoad();
            DGVHeadersFill();
        }

        private void GetRecieptData()
        {
            var _context = _dbAction.GetContext();
            if (!string.IsNullOrEmpty(_reciept.RecieptId.ToString()))
            {
                int recieptId = _reciept.RecieptId;
                _reciept = _context.Reciepts.FirstOrDefault(x => x.RecieptId == recieptId);

                if (_reciept == null)
                {
                    throw new Exception("Brak recepty o podanym Id");
                }

                //FillTextBoxes(reciept);
            }
        }

        public void LoadRecieptData()
        {

            if (_reciept != null)
            {
                LoadMedicinesFromReciept(_reciept.RecieptId);
            }
        }

        //Metoda do wyświetlenia leków z wybranej recepty
        private void LoadMedicinesFromReciept(int recieptId)
        {
            _medicines = _dbAction.GetMedicinesFromReciept(recieptId);

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = _medicines;
            DGVRecieptFill();       
        }

        public void DataLoad()
        {
            medicines = _dbAction.GetMedicines();
            _medicinedelivery = _dbAction.GetMedicineDeliveries();


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
        public void DGVHeadersFill()
        {
            dataGridView1.Columns[nameof(Medicine.MedicineId)].Visible = false;
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
            dataGridView1.Columns[nameof(Medicine.ExpiredDates)].Visible = false;
            dataGridView1.Columns[nameof(Medicine.Price)].HeaderText = "Cena";
            dataGridView1.Columns[nameof(Medicine.Producent)].Visible = false;
            dataGridView1.Columns[nameof(Medicine.Producent)].DisplayIndex = 4;
            dataGridView1.Columns[nameof(Medicine.PercentageOfRefunding)].Visible = false;
            dataGridView1.Columns[nameof(Medicine.PriceAfterRefunding)].HeaderText = "Cena NFZ";
            dataGridView1.Columns[nameof(Medicine.QuantityInPackage)].HeaderText = "Ilość w Op";
            dataGridView1.Columns[nameof(Medicine.QuantityOnMagazines)].Visible = false;
            dataGridView1.Columns[nameof(Medicine.IsAntibiotique)].Visible = false;
            dataGridView1.Columns[nameof(Medicine.Reciepts)].Visible = false;
            dataGridView1.Columns[nameof(Medicine.PriceOfBuy)].Visible = false;
            dataGridView1.Columns[nameof(Medicine.PriceMarge)].Visible = false;
            dataGridView1.Columns[nameof(Medicine.Quantity)].HeaderText = "Na Magazynie";

        }

        public void DGVRecieptFill()
        {
            if (_medicines != null && _medicines.Count > 0)
            {

                dataGridView2.Columns[nameof(MedicineReciept.MedicineId)].Visible = false;
                dataGridView2.Columns[nameof(MedicineReciept.MedicineName)].HeaderText = "Nazwa leku";
                dataGridView2.Columns[nameof(MedicineReciept.MedicineName)].DisplayIndex = 0;
                dataGridView2.Columns[nameof(MedicineReciept.Quantity)].HeaderText = "Ilość";
                dataGridView2.Columns[nameof(MedicineReciept.Quantity)].DisplayIndex = 1;
                dataGridView2.Columns[nameof(MedicineReciept.Reciept)].Visible = false;
                dataGridView2.Columns[nameof(MedicineReciept.RecieptId)].Visible = false;
                dataGridView2.Columns[nameof(MedicineReciept.DoctorFullName)].Visible = false;
                dataGridView2.Columns[nameof(MedicineReciept.MedicineRecieptId)].Visible = false;
                dataGridView2.Columns[nameof(MedicineReciept.Medicine)].Visible = false;
            }

        }

    }

}
