using System;
using System.Windows.Forms;

namespace Obsługa_Apteki
{
    public partial class RecieptsShow : Form
    {
        public RecieptsShow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var RecieptAddEdit = new RecieptAddEdit();
            RecieptAddEdit.ShowDialog();
        }
    }
}
