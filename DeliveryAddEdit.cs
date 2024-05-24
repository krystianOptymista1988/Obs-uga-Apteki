using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Modele;
using Obsługa_Apteki.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Obsługa_Apteki
{
    public partial class DeliveryAddEdit : Form
    {
        private AptekaTestDbContext _context = new AptekaTestDbContext();
        private DbActions _action = new DbActions();
        private List<Stock> _stockList = new List<Stock>();
        private List<Medicine> _medicine = new List<Medicine>();
        private List<Pharmaceut> _pharmaceuts = new List<Pharmaceut>();  
        private Stock stockItem = new Stock();
        
        public DeliveryAddEdit()
        {
            InitializeComponent();
            ComboboxDataLoad();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboboxDataLoad()
        {
            _medicine = _action.GetMedicines();
            cbMedicines.DataSource = _medicine;
            cbMedicines.DisplayMember = "Name";
            cbMedicines.ValueMember = "MedicineId";
          

            _pharmaceuts = _action.GetPharmaceuts();
            cbPharmaceut.DataSource = _pharmaceuts;
            cbPharmaceut.DisplayMember = "FullName";
            cbPharmaceut.ValueMember = "PharmaceutId";
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            stockItem.Quantity = int.Parse(numericUpDown1.Value.ToString());
            stockItem.MedicineId = int.Parse(cbMedicines.SelectedValue.ToString());
            _stockList.Add(stockItem);
            DGVRefresh();
        }

        private void DGVRefresh()
        {
            
          dataGridView1.DataSource = null;

            dataGridView1.DataSource = _stockList;
        }
    }
}
