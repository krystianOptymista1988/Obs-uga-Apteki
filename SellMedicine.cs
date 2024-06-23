using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Modele;
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
        private List<BillQuantity> _billQuantities = new List<BillQuantity>();

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

        private void LoadMedicinesFromReciept(int recieptId)
        {
            _medicines = _dbAction.GetMedicinesFromReciept(recieptId);

            dgvBillMedicines.DataSource = null;
            dgvBillMedicines.DataSource = _medicines;
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
                dgvMedicinesOnStock.DataSource = dataTable;
            }
            else
            {
                dgvMedicinesOnStock.DataSource = medicines;
            }
        }

        public void DGVHeadersFill()
        {
            dgvMedicinesOnStock.Columns[nameof(Medicine.MedicineId)].Visible = false;
            dgvMedicinesOnStock.Columns[nameof(Medicine.Name)].HeaderText = "Nazwa";
            dgvMedicinesOnStock.Columns[nameof(Medicine.Name)].DisplayIndex = 0;
            dgvMedicinesOnStock.Columns[nameof(Medicine.Category)].Visible = false;

            dgvMedicinesOnStock.Columns[nameof(Medicine.IsRefunded)].Visible = false;
            dgvMedicinesOnStock.Columns[nameof(Medicine.IsOnReciept)].Visible = false;
            dgvMedicinesOnStock.Columns[nameof(Medicine.ActiveSubstance)].Visible = false;
            dgvMedicinesOnStock.Columns[nameof(Medicine.Price)].HeaderText = "Cena";
            dgvMedicinesOnStock.Columns[nameof(Medicine.Producent)].HeaderText = "Producent";
            dgvMedicinesOnStock.Columns[nameof(Medicine.Producent)].DisplayIndex = 2;
            dgvMedicinesOnStock.Columns[nameof(Medicine.PriceAfterRefunding)].Visible = false;
            dgvMedicinesOnStock.Columns[nameof(Medicine.QuantityInPackage)].Visible = false;
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
            if (dgvMedicinesOnStock.CurrentRow != null && !string.IsNullOrEmpty(tbQuantity.Text) && int.TryParse(tbQuantity.Text, out int quantity))
            {
                var selectedMedicineId = Convert.ToInt32(dgvMedicinesOnStock.CurrentRow.Cells["MedicineId"].Value);
                var selectedMedicine = _context.Medicines.FirstOrDefault(m => m.MedicineId == selectedMedicineId);

                if (selectedMedicine != null && selectedMedicine.Quantity >= quantity)
                {
                    var existingBillQuantity = _billQuantities.FirstOrDefault(bq => bq.QuantityOnMagazineId == selectedMedicineId);

                    if (existingBillQuantity != null)
                    {
                        existingBillQuantity.Quantity += quantity;
                    }
                    else
                    {
                        _billQuantities.Add(new BillQuantity
                        {
                            QuantityOnMagazineId = selectedMedicineId,
                            Quantity = quantity
                        });
                    }

                    dgvBillMedicines.DataSource = null;
                    dgvBillMedicines.DataSource = _billQuantities;
                    DGVRecieptFill();
                }
                else
                {
                    MessageBox.Show("Niewystarczająca ilość leku na magazynie.");
                }
            }
            else
            {
                MessageBox.Show("Wybierz lek i podaj prawidłową ilość.");
            }
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            try
            {
                var bill = new Bill
                {
                    DateOfBill = DateTime.Now,
                    BillPrice = _billQuantities.Sum(bq => bq.Quantity * _context.Medicines.FirstOrDefault(m => m.MedicineId == bq.QuantityOnMagazineId).Price)
                };

                foreach (var billQuantity in _billQuantities)
                {
                    var medicine = _context.Medicines.FirstOrDefault(m => m.MedicineId == billQuantity.QuantityOnMagazineId);
                    if (medicine != null)
                    {
                        medicine.Quantity -= billQuantity.Quantity;

                        bill.BillQuantities.Add(new BillQuantity
                        {
                            QuantityOnMagazineId = billQuantity.QuantityOnMagazineId,
                            Quantity = billQuantity.Quantity
                        });
                    }
                }

                _context.Bills.Add(bill);
                _context.SaveChanges();

                MessageBox.Show("Wydrukowano paragon.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas drukowania paragonu: " + ex.Message);
            }
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                var bill = new Bill
                {
                    DateOfBill = DateTime.Now,
                    BillPrice = _billQuantities.Sum(bq => bq.Quantity * _context.Medicines.FirstOrDefault(m => m.MedicineId == bq.QuantityOnMagazineId).Price)
                };

                foreach (var billQuantity in _billQuantities)
                {
                    var medicine = _context.Medicines.FirstOrDefault(m => m.MedicineId == billQuantity.QuantityOnMagazineId);
                    if (medicine != null)
                    {
                        medicine.Quantity -= billQuantity.Quantity;

                        bill.BillQuantities.Add(new BillQuantity
                        {
                            QuantityOnMagazineId = billQuantity.QuantityOnMagazineId,
                            Quantity = billQuantity.Quantity
                        });
                    }
                }

                _context.Bills.Add(bill);
                _context.SaveChanges();

                MessageBox.Show("Wydrukowano fakturę.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas drukowania faktury: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBillMedicines.CurrentRow != null)
            {
                var selectedMedicineId = Convert.ToInt32(dgvBillMedicines.CurrentRow.Cells["QuantityOnMagazineId"].Value);
                var billQuantity = _billQuantities.FirstOrDefault(bq => bq.QuantityOnMagazineId == selectedMedicineId);

                if (billQuantity != null)
                {
                    _billQuantities.Remove(billQuantity);

                    dgvBillMedicines.DataSource = null;
                    dgvBillMedicines.DataSource = _billQuantities;
                    DGVRecieptFill();
                }
            }
            else
            {
                MessageBox.Show("Wybierz lek do usunięcia.");
            }
        }
    }
}
