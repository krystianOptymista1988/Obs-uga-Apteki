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
    public partial class PatientShow : Form
    {
        public PatientShow()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var addEditPatient = new PatientAddEdit();
            addEditPatient.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var addEditPatient = new PatientAddEdit();
            addEditPatient.ShowDialog();
        }
    }
}
