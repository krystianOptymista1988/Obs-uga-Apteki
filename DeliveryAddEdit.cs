using Obsługa_Apteki.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Obsługa_Apteki
{
    public partial class DeliveryAddEdit : Form
    {
        private AptekaTestDbContext _context = new AptekaTestDbContext();
        private DbActions _action = new DbActions();
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
            List<Medicine> medicines = new List<Medicine>();
            List<string> list = new List<string>();
            string FullName;
            cbMedicines.Items.Clear();
            medicines = _action.GetMedicines();
            foreach (Medicine me in medicines) 
            {
                FullName = me.Name + me.Producent + me.Price;
                list.Add(FullName);
            }
            cbMedicines.DataSource = list;

            List<Pharmaceut> pharmaceuts = new List<Pharmaceut>();
            List<string> values = new List<string>();
            cbPharmaceut.Items.Clear();
            pharmaceuts = _action.GetPharmaceuts();
            foreach (Pharmaceut pharmaceut in pharmaceuts)
            {
                values.Add(pharmaceut.FullName);
            }
            cbPharmaceut.DataSource = values;
        }
    }
}
