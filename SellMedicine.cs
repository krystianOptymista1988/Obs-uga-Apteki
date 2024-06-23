using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Modele;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
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

        public SellMedicine(Modele.Reciept _reciept)
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

        public SellMedicine()
        {
            InitializeComponent();
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
            using (var context = new AptekaTestDbContext())
            {
                _medicines = context.MedicineReciepts
                                    .Where(mr => mr.RecieptId == recieptId)
                                    .Include(mr => mr.Medicine)
                                    .ToList();

                dgvBillMedicines.DataSource = null;
                dgvBillMedicines.DataSource = _medicines;
                DGVRecieptFill();
            }
        }

        public void DataLoad()
        {
            using (var context = new AptekaTestDbContext())
            {
                medicines = context.Medicines
                                   .Include(m => m.Reciepts)
                                   .Include(m => m.MedicineDeliveries)
                                   .ToList();

                _medicinedelivery = context.MedicineDeliveries.ToList();

                if (medicines == null || medicines.Count == 0)
                {
                    var columnNames = _dbAction.GetColumnNames<Medicine>();
                    var dataTable = new DataTable();
                    foreach (var columnName in columnNames)
                    {
                        dataTable.Columns.Add(columnName);
                    }
                    dgvMedicinesOnStock.DataSource = dataTable;
                }
                else
                {
                    dgvMedicinesOnStock.DataSource = medicines;
                }
            }
        }

        public void DGVHeadersFill()
        {
            dgvMedicinesOnStock.Columns[nameof(Medicine.MedicineId)].Visible = false;
            dgvMedicinesOnStock.Columns[nameof(Medicine.MedicineId)].DisplayIndex = 0;
            dgvMedicinesOnStock.Columns[nameof(Medicine.Name)].HeaderText = "Nazwa";
            dgvMedicinesOnStock.Columns[nameof(Medicine.Name)].DisplayIndex = 1;
            dgvMedicinesOnStock.Columns[nameof(Medicine.Category)].HeaderText = "Kategoria";
            dgvMedicinesOnStock.Columns[nameof(Medicine.Category)].DisplayIndex = 2;
            dgvMedicinesOnStock.Columns[nameof(Medicine.ExpiredDates)].HeaderText = "Uwagi";
            dgvMedicinesOnStock.Columns[nameof(Medicine.ExpiredDates)].DisplayIndex = 3;
            dgvMedicinesOnStock.Columns[nameof(Medicine.IsRefunded)].HeaderText = "Refundacja";
            dgvMedicinesOnStock.Columns[nameof(Medicine.IsOnReciept)].Visible = false;
            dgvMedicinesOnStock.Columns[nameof(Medicine.ActiveSubstance)].HeaderText = "Substancja Aktywna";
            dgvMedicinesOnStock.Columns[nameof(Medicine.Deliveries)].Visible = false;
            dgvMedicinesOnStock.Columns[nameof(Medicine.ExpiredDates)].Visible = false;
            dgvMedicinesOnStock.Columns[nameof(Medicine.Price)].HeaderText = "Cena";
            dgvMedicinesOnStock.Columns[nameof(Medicine.Producent)].Visible = false;
            dgvMedicinesOnStock.Columns[nameof(Medicine.Producent)].DisplayIndex = 4;
            dgvMedicinesOnStock.Columns[nameof(Medicine.PercentageOfRefunding)].Visible = false;
            dgvMedicinesOnStock.Columns[nameof(Medicine.PriceAfterRefunding)].HeaderText = "Cena NFZ";
            dgvMedicinesOnStock.Columns[nameof(Medicine.QuantityInPackage)].HeaderText = "Ilość w Op";
            dgvMedicinesOnStock.Columns[nameof(Medicine.QuantityOnMagazines)].Visible = false;
            dgvMedicinesOnStock.Columns[nameof(Medicine.IsAntibiotique)].Visible = false;
            dgvMedicinesOnStock.Columns[nameof(Medicine.Reciepts)].Visible = false;
            dgvMedicinesOnStock.Columns[nameof(Medicine.PriceOfBuy)].Visible = false;
            dgvMedicinesOnStock.Columns[nameof(Medicine.PriceMarge)].Visible = false;
            dgvMedicinesOnStock.Columns[nameof(Medicine.Quantity)].HeaderText = "Na Magazynie";
        }

        public void DGVRecieptFill()
        {
            if (_medicines != null && _medicines.Count > 0)
            {
                dgvBillMedicines.Columns[nameof(MedicineReciept.MedicineId)].Visible = false;
                dgvBillMedicines.Columns[nameof(MedicineReciept.MedicineName)].HeaderText = "Nazwa leku";
                dgvBillMedicines.Columns[nameof(MedicineReciept.MedicineName)].DisplayIndex = 0;
                dgvBillMedicines.Columns[nameof(MedicineReciept.Quantity)].HeaderText = "Ilość";
                dgvBillMedicines.Columns[nameof(MedicineReciept.Quantity)].DisplayIndex = 1;
                dgvBillMedicines.Columns[nameof(MedicineReciept.Reciept)].Visible = false;
                dgvBillMedicines.Columns[nameof(MedicineReciept.RecieptId)].Visible = false;
                dgvBillMedicines.Columns[nameof(MedicineReciept.DoctorFullName)].Visible = false;
                dgvBillMedicines.Columns[nameof(MedicineReciept.MedicineRecieptId)].Visible = false;
                dgvBillMedicines.Columns[nameof(MedicineReciept.Medicine)].Visible = false;
            }
        }

        private void btnAddToBill_Click(object sender, EventArgs e)
        {
            if (dgvMedicinesOnStock.CurrentRow != null)
            {
                int medicineId = (int)dgvMedicinesOnStock.CurrentRow.Cells[nameof(Medicine.MedicineId)].Value;
                int quantity = int.Parse(tbQuantity.Text);

                var selectedMedicine = medicines.FirstOrDefault(m => m.MedicineId == medicineId);
                if (selectedMedicine != null)
                {
                    MedicineReciept medicineReciept = new MedicineReciept
                    {
                        MedicineId = selectedMedicine.MedicineId,
                        MedicineName = selectedMedicine.Name,
                        Quantity = quantity,
                        RecieptId = _reciept.RecieptId
                    };

                    _medicines.Add(medicineReciept);
                    dgvBillMedicines.DataSource = null;
                    dgvBillMedicines.DataSource = _medicines;
                    DGVRecieptFill();
                }
            }
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wydrukowano paragon.");
           // SaveBill();
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wydrukowano fakturę.");
           // SaveBill();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBillMedicines.CurrentRow != null)
            {
                int medicineId = (int)dgvBillMedicines.CurrentRow.Cells[nameof(MedicineReciept.MedicineId)].Value;
                var selectedMedicine = _medicines.FirstOrDefault(m => m.MedicineId == medicineId);
                if (selectedMedicine != null)
                {
                    _medicines.Remove(selectedMedicine);
                    dgvBillMedicines.DataSource = null;
                    dgvBillMedicines.DataSource = _medicines;
                    DGVRecieptFill();
                }
            }
        }


            private void SaveBill()
            {
                try
                {
                    var bill = new Bill
                    {
                        DateOfBill = DateTime.Now,
                        BillPrice = _medicines.Sum(m => m.Quantity * medicines.FirstOrDefault(x => x.MedicineId == m.MedicineId).Price),
                        Medicines = _medicines.Select(mr => medicines.FirstOrDefault(x => x.MedicineId == mr.MedicineId)).ToList(),
                        BillQuantities = new List<BillQuantity>()
                    };

                    foreach (var mr in _medicines)
                    {
                        var medicine = medicines.FirstOrDefault(m => m.MedicineId == mr.MedicineId);
                        if (medicine != null)
                        {
                            medicine.Quantity -= mr.Quantity;
                            var quantityOnMagazine = _context.QuantitiesOnMagazine.FirstOrDefault(q => q.MedicineId == mr.MedicineId);
                            if (quantityOnMagazine != null)
                            {
                                quantityOnMagazine.Quantities -= mr.Quantity;
                                _context.Entry(quantityOnMagazine).State = EntityState.Modified;

                                bill.BillQuantities.Add(new BillQuantity
                                {
                                    Quantity = mr.Quantity,
                                    QuantityOnMagazineId = quantityOnMagazine.QuantityOnMagazineId,
                                    Bill = bill
                                });
                            }
                            else
                            {
                                MessageBox.Show($"Brak odpowiedniego stanu magazynowego dla leku: {medicine.Name}", "Błąd podczas zapisywania danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            _context.Entry(medicine).State = EntityState.Modified;
                        }
                    }

                    _context.Bills.Add(bill);
                    _context.SaveChanges();
                    MessageBox.Show("Paragon zapisany pomyślnie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (DbUpdateException ex)
                {
                    var innerException = ex.InnerException?.InnerException as SqlException;
                    if (innerException != null)
                    {
                        MessageBox.Show($"SQL Error: {innerException.Message}", "Błąd podczas zapisywania danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Błąd podczas zapisywania danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        } }
        
