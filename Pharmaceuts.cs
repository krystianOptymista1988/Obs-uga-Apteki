using System;
using System.Windows.Forms;

namespace Obsługa_Apteki
{
    public partial class Pharmaceuts : Form
    {
        public Pharmaceuts()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var PharmaceutAddEdit = new PharmaceutAddEdit();
            PharmaceutAddEdit.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var PharmaceutAddEdit = new PharmaceutAddEdit();
            PharmaceutAddEdit.ShowDialog();
        }
    }
}
