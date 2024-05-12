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
