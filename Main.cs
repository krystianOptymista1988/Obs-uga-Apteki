﻿using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Obsługa_Apteki
{
    public partial class Main : Form
    {


       // private LoginPanel loginPanel = new LoginPanel();

        public bool LogOn { get; set; } = false;

        public Main()
        {

         

            InitializeComponent();
            InitializeComponents();
            
            this.FormClosed += new FormClosedEventHandler(Main_FormClosed);


        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            Application.Exit();
        }
        private void InitializeComponents()
        {
            toolTip1.SetToolTip(btnDelivery, "Tutaj zamówisz leki na magazyn");
            toolTip1.SetToolTip(btnMedicines, "Sprawdź wszystkie leki w twojej aptece");
            toolTip1.SetToolTip(btnPatient, "Zarządzaj pacjentami apteki w jednym miejscu");
            toolTip1.SetToolTip(btnRecipe, "Moduł do zarządzania receptami");
            toolTip1.SetToolTip(btnSell, "Moduł sprzedaży leków");
            
            toolTip1.SetToolTip(btnPharmaceuts, "Zarządzaj pracownikami Apteki");
            toolTip1.SetToolTip(btnSupport, "Informacje o autorach oraz kontakt");

        }
        private void button1_Click(object sender, EventArgs e)
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

        private void btnMedicines_Click(object sender, EventArgs e)
        {
            var Warehouse = new MedicineWarehouse();

            Warehouse.ShowDialog();
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            var Deliveries = new Deliveries();

            Deliveries.ShowDialog();

        }

        private void btnPharmaceuts_Click(object sender, EventArgs e)
        {
            var Pharmaceuts = new Pharmaceuts();

            Pharmaceuts.ShowDialog();
        }

        private void btnSupport_Click(object sender, EventArgs e)
        {
            var Support = new Support();

            Support.ShowDialog();
        }

        private void btnRecipe_Click(object sender, EventArgs e)
        {
            var RecieptsShow = new RecieptsShow();

            RecieptsShow.ShowDialog();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            var SellMedicine = new SellMedicine();

            SellMedicine.ShowDialog();
        }
    }
}

