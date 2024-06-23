using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Modele;
using Obsługa_Apteki.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Obsługa_Apteki
{
    public partial class DeliveryAddEdit : Form
    {
        private AptekaTestDbContext _context;
        private DbActions _dbAction;
        private List<MedicineDelivery> _deliveryList;
        private List<Modele.Medicine> _medicines;
        private List<Pharmaceut> _pharmaceuts;
        private Delivery _delivery;
        private double deliveryCost;
        private int deliveryID;

        public DeliveryAddEdit()
        {
            InitializeComponent();
            InitializeFields();
            ComboboxDataLoad();
            LoadComboboxData();
            _context = new AptekaTestDbContext();
        }

        public DeliveryAddEdit(int deliveryId, AptekaTestDbContext context)
        {
            InitializeComponent();
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbAction = new DbActions();
            _deliveryList = new List<MedicineDelivery>();
            _medicines = new List<Modele.Medicine>();
            _pharmaceuts = new List<Pharmaceut>();
            _delivery = new Delivery();
            deliveryID = deliveryId;
            ComboboxDataLoad();
            LoadComboboxData();
            GetDeliveryData();
        }

            private void InitializeFields()
        {
            _dbAction = new DbActions();
            _deliveryList = new List<MedicineDelivery>();
            _medicines = new List<Modele.Medicine>();
            _pharmaceuts = new List<Pharmaceut>();
            _delivery = new Delivery();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
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

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (_context == null)
            {
                MessageBox.Show("Kontekst bazy danych jest null.");
                return;
            }

            if (cbMedicines.SelectedValue == null)
            {
                MessageBox.Show("Nie wybrano leku.");
                return;
            }

            MedicineDelivery stockItem = new MedicineDelivery();
            stockItem.Quantity = int.Parse(nudQuantity.Value.ToString());
            stockItem.MedicineId = int.Parse(cbMedicines.SelectedValue.ToString());

            var selectedMedicineId = int.Parse(cbMedicines.SelectedValue.ToString());
            stockItem.Medicine = _context.Medicines.Find(selectedMedicineId);

            if (stockItem.Medicine == null)
            {
                MessageBox.Show("Nie można znaleźć leku o podanym ID.");
                return;
            }

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


        private void btnDeleteFromList_Click(object sender, EventArgs e)
        {
            if (dgvMedicinesDelivery.SelectedRows.Count > 0)
            {
                int deleteId = Convert.ToInt32(dgvMedicinesDelivery.SelectedRows[0].Cells["MedicineId"].Value);
                _deliveryList = _deliveryList.Where(item => item.MedicineId != deleteId).ToList();
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
            if (_deliveryList != null && _deliveryList.Count > 0 && dgvMedicinesDelivery != null)
            {
                dgvMedicinesDelivery.Columns[nameof(MedicineDelivery.Delivery)].Visible = false;
                dgvMedicinesDelivery.Columns[nameof(MedicineDelivery.MedicineName)].HeaderText = "Nazwa Leku";
                dgvMedicinesDelivery.Columns[nameof(MedicineDelivery.Quantity)].HeaderText = "Opakowania";
                dgvMedicinesDelivery.Columns[nameof(MedicineDelivery.MedicineId)].HeaderText = "ID Leku";
                dgvMedicinesDelivery.Columns[nameof(MedicineDelivery.QuantityInPackage)].Visible = false;
                dgvMedicinesDelivery.Columns[nameof(MedicineDelivery.MedicineDeliveryId)].Visible = false;
                dgvMedicinesDelivery.Columns[nameof(MedicineDelivery.DeliveryId)].HeaderText = "ID Dostawy";
                dgvMedicinesDelivery.Columns[nameof(MedicineDelivery.Medicine)].Visible = false;
            }
        }

        private void CountCostDelivery()
        {
            double cost = 0;
            double cost2 = 0;
            deliveryCost = 0;

            List<Modele.Medicine> medicines = new List<Modele.Medicine>();
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

            lblDeliveryCost.Text = deliveryCost.ToString();
        }

        private void LoadComboboxData()
        {
            _pharmaceuts = _dbAction.GetPharmaceuts();
            cbPharmaceut.DataSource = _pharmaceuts;
            cbPharmaceut.DisplayMember = "FullName";
            cbPharmaceut.ValueMember = "PharmaceutId";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (_delivery == null)
            {
                _delivery = new Delivery();
            }

            _delivery.Value = double.Parse(lblDeliveryCost.Text);
            _delivery.DateOfCreate = DateTime.Now;
            _delivery.DateOfDelivery = DateTime.Parse(dtpDateOfDelivery.Value.ToString());
            _delivery.PharmaceutOrdering = int.Parse(cbPharmaceut.SelectedValue.ToString());

            _dbAction.AddDeliveryWithMedicines(_delivery, _deliveryList);

            Close();
        }

        private void GetDeliveryData()
        {
            int deliveryID2 = deliveryID;
            if (deliveryID2 != 0)
            {
                Text = "Edytowanie danych Pacjenta";
                _delivery = _context.Deliveries
                    .Include("MedicineDeliveries.Medicine") // Załaduj powiązane leki
                    .FirstOrDefault(x => x.DeliveryId == deliveryID2);

                if (_delivery == null)
                {
                    throw new Exception("Brak dostawy o podanym Id");
                }

                FillTextBoxes();
                LoadMedicineDeliveries();
            }
        }

        private void FillTextBoxes()
        {
            lblDeliveryCost.Text = _delivery.Value.ToString();
            dtpDateOfDelivery.Value = _delivery.DateOfDelivery;
            cbPharmaceut.SelectedValue = _delivery.PharmaceutOrdering;
        }

        private void LoadMedicineDeliveries()
        {
            _deliveryList = _delivery.MedicineDeliveries.ToList();
            dgvMedicinesDelivery.DataSource = null;
            dgvMedicinesDelivery.DataSource = _deliveryList;
            DGVComunSet();
            CountCostDelivery();
        }
    }
}
