using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Modele;
using Obsługa_Apteki.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Obsługa_Apteki
{
    public partial class MedicineCard : Form
    {
        private int medicineId = 0;
        private DbActions _dbAction = new DbActions();
        private Medicine medicine = new Medicine();
        private AptekaTestDbContext _context = new AptekaTestDbContext();
        private bool isAntibiotique;
        private bool isOnReciept;
        private bool isRefunded;

        public MedicineCard()
        {
            InitializeComponent();

        }

        public MedicineCard(int MediniceId, AptekaTestDbContext context)
        {
            InitializeComponent();
            _context = context;
            medicineId = MediniceId;
            GetMedicineData();
        }

        private void GetMedicineData()
        {
            if (_context == null) 
            _context = _dbAction.GetContext();
            if (medicineId != 0)
            {
                Text = "Edytowanie danych Pacjenta";
                medicine = _context.Medicines.FirstOrDefault(x => x.MedicineId == medicineId);

                if (medicine == null)
                {
                    throw new Exception("Brak użytkownika o podanym Id");
                }

                FillTextBoxes(medicine);
            }
            else
            {
                MessageBox.Show("Błąd przekazania");
            }
        }

        private void FillTextBoxes(Medicine medicine)
        {
            tbName.Text = medicine.Name;
            tbId.Text = medicine.MedicineId.ToString() ;
            tbCategory.Text = medicine.Category;
            tbActiveSubstance.Text = medicine.ActiveSubstance;
            tbMargePrice.Text = medicine.PriceMarge.ToString();
            tbPrice.Text = medicine.Price.ToString();   
            tbPriceOfBuy.Text = medicine.PriceOfBuy.ToString(); 
            tbProducent.Text = medicine.Producent.ToString();
            tbQuantityInPackage.Text = medicine.QuantityInPackage.ToString();
            tbRefundedPrice.Text = medicine.PriceAfterRefunding.ToString();
            if (medicine.IsOnReciept)
            {
                cbIsOnReciept.CheckState = CheckState.Checked;
            }
            if (medicine.IsRefunded)
            {
                cbIsRefunded.CheckState = CheckState.Checked;
            }
            if (medicine.IsAntibiotique)
            {
                cbIsAntibiotique.CheckState = CheckState.Checked;   
            }    
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            try
            {
                using (_context)
                {

                    if (!string.IsNullOrEmpty(tbId.Text))
                    {
                        // Aktualizowanie istniejącego farmaceuty
                        int id = int.Parse(tbId.Text);
                        medicine = _context.Medicines.SingleOrDefault(p => p.MedicineId == id);
                        if (medicine != null)
                        {
                            medicine = CreateMedicine();
                            _context.Entry(medicine).State = EntityState.Modified;
                            MessageBox.Show("Aktualizowano dane Leku");
                        }
                        else
                        {
                            MessageBox.Show("Nie znaleziono Leku o podanym ID");
                            return;
                        }
                    }
                    else
                    {
                        // Dodawanie nowego farmaceuty
                        medicine = new Medicine();
                        medicine = CreateMedicine();
                        _context.Medicines.Add(medicine);
                        MessageBox.Show($"Dodano nowy Lek: ID {medicine.MedicineId}, Name {medicine.Name}");
                    }
                    _context.SaveChanges();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zapisywania danych: " + ex.Message);
            }
        }
    

        private Medicine CreateMedicine()
        {
            Medicine medicine = new Medicine();
            medicine.Name = tbName.Text;

            if (!double.TryParse(tbPrice.Text, out double price))
            {
              //  MessageBox.Show("Nieprawidłowy format ceny. Ustawiono wartość domyślną 0.");
                price = 0;
            }
            medicine.Price = price;

            if (!double.TryParse(cbPercentageOfRefunde.Text, out double percentageOfRefunding))
            {
              //  MessageBox.Show("Nieprawidłowy format procentu refundacji. Ustawiono wartość domyślną 0.");
                percentageOfRefunding = 0;
            }
            medicine.PercentageOfRefunding = percentageOfRefunding;

            if (!double.TryParse(tbPriceOfBuy.Text, out double priceOfBuy))
            {
               // MessageBox.Show("Nieprawidłowy format ceny zakupu. Ustawiono wartość domyślną 0.");
                priceOfBuy = 0;
            }
            medicine.PriceOfBuy = priceOfBuy;

            medicine.ActiveSubstance = tbActiveSubstance.Text;
            medicine.Producent = tbProducent.Text;
            medicine.Category = tbCategory.Text;

            if (!double.TryParse(tbMargePrice.Text, out double priceMarge))
            {
                //MessageBox.Show("Nieprawidłowy format marży ceny. Ustawiono wartość domyślną 0.");
                priceMarge = 0;
            }
            medicine.PriceMarge = priceMarge;

            if (!int.TryParse(tbQuantityInPackage.Text, out int quantityInPackage))
            {
                //MessageBox.Show("Nieprawidłowy format ilości w opakowaniu. Ustawiono wartość domyślną 0.");
                quantityInPackage = 0;
            }
            medicine.QuantityInPackage = quantityInPackage;

            if (!double.TryParse(tbPrice.Text, out double priceAfterRefunding))
            {
               // MessageBox.Show("Nieprawidłowy format ceny po refundacji. Ustawiono wartość domyślną 0.");
                priceAfterRefunding = 0;
            }
            medicine.PriceAfterRefunding = priceAfterRefunding;

            medicine.IsAntibiotique = isAntibiotique;
            medicine.IsOnReciept = isOnReciept;
            medicine.IsRefunded = isRefunded;

            return medicine;
        }
        private void cbIsOnReciept_CheckedChanged(object sender, EventArgs e)
        {   if (cbIsOnReciept.Checked == true)
            isOnReciept = true;
        else { isOnReciept = false; }
        }

        private void cbIsRefunded_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsRefunded.Checked == true)
            {
                isRefunded = true;
                cbPercentageOfRefunde.ReadOnly = false;
            }
            else
            { 
                isRefunded = false;
                cbPercentageOfRefunde.ReadOnly = true;

            }
            
        }

        private void cbPercentageOfRefunde_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void tbPrice_TextChanged(object sender, EventArgs e)
        {
       
        }

        private double NullCheck(string price)
        {
            if (price == null)
                return 0;
            else    return double.Parse(price);
        }

        private void tbMargePrice_TextChanged(object sender, EventArgs e)
        {
            string priceS = tbMargePrice.Text;
            double marge = NullCheck(priceS);
            double price;

            if (cbIsRefunded.Checked == true)
            {
                priceS = tbPriceOfBuy.Text;
                double priceOfBuy = NullCheck(priceS);
                price = priceOfBuy + marge;
                priceS = cbPercentageOfRefunde.Text;
                double percentage = NullCheck(priceS);
                priceS = cbPercentageOfRefunde.Text;
                double price2 = price - (priceOfBuy * percentage / 100);
                tbMargePrice.Text = price2.ToString();
            }
            else
            {
                priceS = tbPriceOfBuy.Text; 
                double priceOfBuy = NullCheck(priceS);
                price = priceOfBuy + marge;
                tbPrice.Text = price.ToString();
            }
        }

        private void cbIsAntibiotique_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsAntibiotique.Checked == true)
                isAntibiotique = true;
            else { isAntibiotique = false; }
        }


    }
}

