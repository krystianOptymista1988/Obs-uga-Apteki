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
        private List<Medicine> _medicinesShow = new List<Medicine>();
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

        private void DGVDetailsHS()
        {
            dgvDeliveryDetails.Columns[nameof(Medicine.MedicineId)].Visible = false;
            dgvDeliveryDetails.Columns[nameof(Medicine.Name)].HeaderText = "Nazwa";
            dgvDeliveryDetails.Columns[nameof(Medicine.Name)].DisplayIndex = 0;
            dgvDeliveryDetails.Columns[nameof(Medicine.Category)].Visible = false;
            dgvDeliveryDetails.Columns[nameof(Medicine.ExpiredDates)].Visible = false;
            dgvDeliveryDetails.Columns[nameof(Medicine.IsRefunded)].Visible = false;
            dgvDeliveryDetails.Columns[nameof(Medicine.IsOnReciept)].Visible = false;
            dgvDeliveryDetails.Columns[nameof(Medicine.ActiveSubstance)].Visible = false;
            dgvDeliveryDetails.Columns[nameof(Medicine.Deliveries)].Visible = false;
            dgvDeliveryDetails.Columns[nameof(Medicine.ExpiredDates)].Visible = false;
            dgvDeliveryDetails.Columns[nameof(Medicine.Price)].Visible = false;
            dgvDeliveryDetails.Columns[nameof(Medicine.Producent)].HeaderText = "Producent";
            dgvDeliveryDetails.Columns[nameof(Medicine.Producent)].DisplayIndex = 4;
            dgvDeliveryDetails.Columns[nameof(Medicine.PercentageOfRefunding)].Visible = false;
            dgvDeliveryDetails.Columns[nameof(Medicine.PriceAfterRefunding)].Visible = false;
            dgvDeliveryDetails.Columns[nameof(Medicine.QuantityInPackage)].HeaderText = "Ilość w Op";
            dgvDeliveryDetails.Columns[nameof(Medicine.QuantityOnMagazines)].Visible = false;
            dgvDeliveryDetails.Columns[nameof(Medicine.IsAntibiotique)].Visible = false;
            dgvDeliveryDetails.Columns[nameof(Medicine.Reciepts)].Visible = false;
            dgvDeliveryDetails.Columns[nameof(Medicine.PriceOfBuy)].HeaderText = "Cena zakupu";
            dgvDeliveryDetails.Columns[nameof(Medicine.PriceMarge)].Visible = false;

            dgvDeliveryDetails.Columns[nameof(Medicine.Quantity)].HeaderText = "ilośc zamówiona";

        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            _medicinesShow = new List<Medicine>();
            _context = new AptekaTestDbContext();
            List<Medicine> list = new List<Medicine>();
            list = _dbAction.GetMedicines().ToList();

            if (dgvDeliveryStock.SelectedRows.Count > 0)
            {
                int deliveryId = Convert.ToInt32(dgvDeliveryStock.SelectedRows[0].Cells["DeliveryId"].Value);
                _medicineDelivery = _dbAction.GetMedicineDeliveries();
                List<MedicineDelivery> medicines = new List<MedicineDelivery>();
                foreach (MedicineDelivery medicinesIn in _medicineDelivery)
                {
                   if(medicinesIn.DeliveryId == deliveryId)
                    {
                        medicines.Add(medicinesIn);
                    }
                }
                
                foreach(MedicineDelivery med in medicines)
                {
                    foreach (Medicine medicineShow in list)
                    if(med.MedicineId == medicineShow.MedicineId)
                        {
                            medicineShow.Quantity = med.Quantity;
                            _medicinesShow.Add(medicineShow);
                        }
                }
                dgvDeliveryDetails.DataSource = _medicinesShow;
                DGVDetailsHS();
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć dostawę do wyświetlenia.");
            }
        }

        private void btnShowOrdered_Click(object sender, EventArgs e)
        {
            _medicinesShow = new List<Medicine>();
            _context = new AptekaTestDbContext();
            List<Medicine> list = new List<Medicine>();
            list = _dbAction.GetMedicines().ToList();
            Medicine medd = new Medicine();

            if (dgvDelivryInFuture.SelectedRows.Count > 0)
            {
                int deliveryId = Convert.ToInt32(dgvDelivryInFuture.SelectedRows[0].Cells["DeliveryId"].Value);
                _medicineDelivery = _dbAction.GetMedicineDeliveries();
                List<MedicineDelivery> medicines = new List<MedicineDelivery>();
                foreach (MedicineDelivery medicinesIn in _medicineDelivery)
                {
                    if (medicinesIn.DeliveryId == deliveryId)
                    {
                         
                        medicines.Add(medicinesIn);
                    }
                }

                foreach (MedicineDelivery med in medicines)
                {
                    foreach (Medicine medicineShow in list)
                        if (med.MedicineId == medicineShow.MedicineId)
                        {
                            medicineShow.Quantity = med.Quantity;
                            _medicinesShow.Add(medicineShow);
                        }
                }
                dgvDeliveryDetails.DataSource = _medicinesShow;
                DGVDetailsHS();
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć dostawę do wyświetlenia.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             var DialogResult = MessageBox.Show("Czy jesteś pewien że chcesz przyjąć dostawę ?","Uwaga",MessageBoxButtons.YesNoCancel);
            if(DialogResult == DialogResult.Yes) 
            {
                if (dgvDeliveryStock.SelectedRows.Count > 0)
                {
                    int deliveryId = Convert.ToInt32(dgvDeliveryStock.SelectedRows[0].Cells["DeliveryId"].Value);
                    List<Delivery> _deliveryContext = _dbAction.GetDeliveries();
                    foreach (Delivery delivery in _deliveryContext)
                    {
                        if (delivery.DeliveryId == deliveryId)
                        {

                            _dbAction.AddToStock(delivery);
                            _dbAction.RemoveDelivery(delivery);
                            LoadDGVDeliveries();
                        }
                        else
                        { 
                                MessageBox.Show("Dostawa nie została znaleziona.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nie zaznaczono żadnej dostawy.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }
    }
}
