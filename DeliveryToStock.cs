using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Modele;
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
    public partial class DeliveryToStock : Form
    { 
        private DbActions _dbAction = new DbActions();
        private AptekaTestDbContext _context = new AptekaTestDbContext();
        private List<Delivery> _deliveries;
        private List<MedicineDelivery> _medicineDelivery;
        //private Stock _addStock;
        public DeliveryToStock()
        {
            InitializeComponent();
            LoadDGVDeliveries();
            DGVHeadersSet();
        }

        private void LoadDGVDeliveries()
        {
            _deliveries = _context.Deliveries.ToList();
            List<Delivery> deliveriesInMagazine = new List<Delivery>();
            List<Delivery> deliveryInFuture = new List<Delivery>();

            foreach (Delivery delivery in _deliveries) 
            {
                if(delivery.DateOfDelivery > DateTime.Now)
                {
                    deliveryInFuture.Add(delivery);
                }
                else
                {
                    deliveriesInMagazine.Add(delivery);
                }
            }

            dgvDeliveryStock.DataSource = deliveriesInMagazine;
            dgvDelivryInFuture.DataSource = deliveryInFuture;
        }

        private void DGVHeadersSet()
        {
            dgvDeliveryStock.Columns[nameof(Delivery.DeliveryId)].HeaderText = "ID";
            dgvDeliveryStock.Columns[nameof(Delivery.DeliveryId)].DisplayIndex = 0;
            dgvDeliveryStock.Columns[nameof(Delivery.DateOfCreate)].DisplayIndex = 1;
            dgvDeliveryStock.Columns[nameof(Delivery.DateOfCreate)].HeaderText = "Data zamówienia";
            dgvDeliveryStock.Columns[nameof(Delivery.DateOfDelivery)].DisplayIndex = 2;
            dgvDeliveryStock.Columns[nameof(Delivery.DateOfDelivery)].HeaderText = "Data Dostawy";
            dgvDeliveryStock.Columns[nameof(Delivery.Value)].HeaderText = "Wartość";
            dgvDeliveryStock.Columns[nameof(Delivery.PharmaceutOrdering)].HeaderText = "Zamawiający";
            dgvDeliveryStock.Columns[nameof(Delivery.ExpiredDates)].Visible = false;
            dgvDeliveryStock.Columns[nameof(Delivery.MedicineDeliveries)].Visible = false;
            dgvDeliveryStock.Columns[nameof(Delivery.OrderedMedicines)].Visible = false;

            dgvDelivryInFuture.Columns[nameof(Delivery.DeliveryId)].HeaderText = "ID";
            dgvDelivryInFuture.Columns[nameof(Delivery.DeliveryId)].DisplayIndex = 0;
            dgvDelivryInFuture.Columns[nameof(Delivery.DateOfCreate)].DisplayIndex = 1;
            dgvDelivryInFuture.Columns[nameof(Delivery.DateOfCreate)].HeaderText = "Data zamówienia";
            dgvDelivryInFuture.Columns[nameof(Delivery.DateOfDelivery)].DisplayIndex = 2;
            dgvDelivryInFuture.Columns[nameof(Delivery.DateOfDelivery)].HeaderText = "Data Dostawy";
            dgvDelivryInFuture.Columns[nameof(Delivery.Value)].HeaderText = "Wartość";
            dgvDelivryInFuture.Columns[nameof(Delivery.PharmaceutOrdering)].HeaderText = "Zamawiający";
            dgvDelivryInFuture.Columns[nameof(Delivery.ExpiredDates)].Visible = false;
            dgvDelivryInFuture.Columns[nameof(Delivery.MedicineDeliveries)].Visible = false;
            dgvDelivryInFuture.Columns[nameof(Delivery.OrderedMedicines)].Visible = false;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (dgvDeliveryStock.SelectedRows.Count > 0)
            {
                int deliveryId = Convert.ToInt32(dgvDeliveryStock.SelectedRows[0].Cells["DeliveryId"].Value);
                _medicineDelivery = _dbAction.GetMedicineDeliveries();
                List<MedicineDelivery> medicines = new List<MedicineDelivery>();
                foreach (MedicineDelivery medicinesIn in medicines)
                {
                   // if(medi)
                }
                
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć dostawę do wyświetlenia.");
            }
        }
    }
}
