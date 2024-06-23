using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Modele;
using Obsługa_Apteki.Models;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Medicine = Obsługa_Apteki.Modele.Medicine;

namespace Obsługa_Apteki
{
    public partial class MedicineWarehouse : Form
    {
        private DbActions _dbAction = new DbActions();
        private AptekaTestDbContext _context = new AptekaTestDbContext();
        private List<Medicine> medicines;
        private List<MedicineDelivery> _medicinedelivery;
        public int medicineId;
        public MedicineWarehouse()
        {
            _context = new AptekaTestDbContext();
            InitializeComponent();
            RefreshData();
            DGVHeadersFill();
           
           // dataGridView1.DataError += new DataGridViewDataErrorEventHandler(dataGridView1_DataError);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void Warehouse_Load(object sender, EventArgs e)
        {

        }

        public void DGVHeadersFill() 
        {
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["MedicineId"].HeaderText = "ID";
                dataGridView1.Columns["MedicineId"].DisplayIndex = 0;
                dataGridView1.Columns["Name"].HeaderText = "Nazwa";
                dataGridView1.Columns["Name"].DisplayIndex = 1;
                dataGridView1.Columns["Category"].HeaderText = "Kategoria";
                dataGridView1.Columns["Category"].DisplayIndex = 2;
                dataGridView1.Columns["ExpiredDates"].HeaderText = "Uwagi";
                dataGridView1.Columns["ExpiredDates"].DisplayIndex = 3;
                dataGridView1.Columns["IsRefunded"].HeaderText = "Refundacja";
                dataGridView1.Columns["IsOnReciept"].Visible = false;
                dataGridView1.Columns["ActiveSubstance"].HeaderText = "Substancja Aktywna";
                dataGridView1.Columns["Deliveries"].Visible = false;
                dataGridView1.Columns["ExpiredDates"].Visible = false;
                dataGridView1.Columns["Price"].HeaderText = "Cena";
                dataGridView1.Columns["Producent"].HeaderText = "Producent";
                dataGridView1.Columns["Producent"].DisplayIndex = 4;
                dataGridView1.Columns["PercentageOfRefunding"].Visible = false;
                dataGridView1.Columns["PriceAfterRefunding"].HeaderText = "Cena NFZ";
                dataGridView1.Columns["QuantityInPackage"].HeaderText = "Ilość w Op";
                dataGridView1.Columns["QuantityOnMagazines"].Visible = false;
                dataGridView1.Columns["IsAntibiotique"].Visible = false;
                dataGridView1.Columns["Reciepts"].Visible = false;
                dataGridView1.Columns["PriceOfBuy"].Visible = false;
                dataGridView1.Columns["PriceMarge"].Visible = false;
                dataGridView1.Columns["Quantity"].HeaderText = "Na Magazynie";
            }
        }
        
        public void RefreshData()
        {
            try
            {
                using (var context = new AptekaTestDbContext())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    // Ładowanie danych z bazy danych, w tym powiązanych danych
                    medicines = context.Medicines
                        .Include("MedicineReciepts.Reciept")
                        .Include("MedicineDeliveries.Delivery")
                        .ToList();

                    var medicineData = medicines.Select(m => new
                    {
                        m.MedicineId,
                        m.Name,
                        m.Category,
                        m.ExpiredDates,
                        m.IsRefunded,
                        m.IsOnReciept,
                        m.ActiveSubstance,
                        m.Price,
                        m.Producent,
                        m.PercentageOfRefunding,
                        m.PriceAfterRefunding,
                        m.QuantityInPackage,
                        m.IsAntibiotique,
                        m.Quantity
                    }).ToList();
                    // Ustawienie danych źródłowych dla DataGridView
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = medicines;

                    // Ustawienie nagłówków kolumn
                    DGVHeadersFill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas odświeżania danych: " + ex.Message);
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
                    var value = dataGridView1.CurrentRow.Cells["MedicineId"].Value;
                    if (value != null && int.TryParse(value.ToString(), out medicineId))
                    {
                        using (var context = new AptekaTestDbContext())
                        {
                            MedicineCard editForm = new MedicineCard(medicineId, context);
                            if (editForm.ShowDialog() == DialogResult.OK)
                            {
                                RefreshData();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nieprawidłowy format ID leku.");
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
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int deleteId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MedicineId"].Value);
                Medicine itemToRemove = medicines.SingleOrDefault(m => m.MedicineId == deleteId);
                if (itemToRemove != null)
                {
                    _dbAction.RemoveMedicine(itemToRemove);
                    medicines.Remove(itemToRemove);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = medicines;
                    DGVHeadersFill();
                }

            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć receptę do usunięcia.");
            }
        }


        public void DataLoad()
        {
            using (var context = new AptekaTestDbContext())
            {
                medicines = context.Medicines.Include("MedicineReciepts").ToList();
                _medicinedelivery = context.MedicineDeliveries.ToList();

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Wystąpił błąd podczas ładowania danych. Szczegóły: " + e.Exception.Message);
            e.ThrowException = false;
        }
    }
}
