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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            toolTip1.SetToolTip(btnDelivery, "Tutaj zamówisz leki na magazyn");
            toolTip1.SetToolTip(btnMedicines, "Sprawdź wszystkie leki w twojej aptece");
            toolTip1.SetToolTip(btnPatient, "Zarządzaj pacjentami apteki w jednym miejscu");
            toolTip1.SetToolTip(btnRecipe, "Moduł do zarządzania receptami");
            toolTip1.SetToolTip(btnSell, "Moduł sprzedaży leków");
            toolTip1.SetToolTip(btnUtilization, "Zgłoś przeterminowane leki do utylizacji");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            var PatientShow = new PatientShow();
           
            PatientShow.ShowDialog();
        }
    }
}
