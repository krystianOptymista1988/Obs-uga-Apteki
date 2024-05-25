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
        private Stock _addStock;
        public DeliveryToStock()
        {
            InitializeComponent();
            LoadDGVDeliveries();
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
    }
}
