using System;
using System.Windows.Forms;

namespace Obsługa_Apteki
{
    public partial class Deliveries : Form
    {
        public Deliveries()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var DeliveryAddEdit = new DeliveryAddEdit();

            DeliveryAddEdit.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var DeliveryAddEdit = new DeliveryAddEdit();

            DeliveryAddEdit.ShowDialog();
        }
    }
}
