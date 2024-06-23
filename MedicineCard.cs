using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Modele;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Obsługa_Apteki
{
    public partial class MedicineCard : Form
    {
        private int medicineId = 0;
        private DbActions _dbAction = new DbActions();
        private Modele.Medicine medicine = new Modele.Medicine();
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
                Text = "Edytowanie danych Leka";
                medicine = _context.Medicines.FirstOrDefault(x => x.MedicineId == medicineId);

                if (medicine == null)
                {
                    throw new Exception("Brak leku o podanym Id");
                }

                FillTextBoxes(medicine);
            }
            else
            {
                MessageBox.Show("Błąd przekazania");
            }
        }

        private void FillTextBoxes(Modele.Medicine medicine)
        {
            tbName.Text = medicine.Name;
            tbId.Text = medicine.MedicineId.ToString();
            tbCategory.Text = medicine.Category;
            tbActiveSubstance.Text = medicine.ActiveSubstance;
            tbMargePrice.Text = medicine.PriceMarge.ToString();
            tbPrice.Text = medicine.Price.ToString();
            tbPriceOfBuy.Text = medicine.PriceOfBuy.ToString();
            tbProducent.Text = medicine.Producent.ToString();
            tbQuantityInPackage.Text = medicine.QuantityInPackage.ToString();
            tbRefundedPrice.Text = medicine.PriceAfterRefunding.ToString();
            cbIsOnReciept.Checked = medicine.IsOnReciept;
            cbIsRefunded.Checked = medicine.IsRefunded;
            cbIsAntibiotique.Checked = medicine.IsAntibiotique;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new AptekaTestDbContext())
                {
                    if (!string.IsNullOrEmpty(tbId.Text) && int.TryParse(tbId.Text, out int id))
                    {
                        // Aktualizowanie istniejącego leku
                        var existingMedicine = context.Medicines.SingleOrDefault(p => p.MedicineId == id);
                        if (existingMedicine != null)
                        {
                            UpdateMedicine(existingMedicine);
                            context.Entry(existingMedicine).State = EntityState.Modified;
                            MessageBox.Show("Aktualizowano dane Leka");
                        }
                        else
                        {
                            MessageBox.Show("Nie znaleziono Leka o podanym ID");
                            return;
                        }
                    }
                    else
                    {
                        // Dodawanie nowego leku
                        var newMedicine = new Modele.Medicine();
                        UpdateMedicine(newMedicine);
                        context.Medicines.Add(newMedicine);
                        MessageBox.Show($"Dodano nowy Lek: ID {newMedicine.MedicineId}, Name {newMedicine.Name}");
                    }
                    context.SaveChanges();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zapisywania danych: " + ex.Message);
            }
        }

        private void UpdateMedicine(Modele.Medicine medicine)
        {
            medicine.Name = tbName.Text;
            medicine.Category = tbCategory.Text;
            medicine.ActiveSubstance = tbActiveSubstance.Text;
            medicine.Producent = tbProducent.Text;

            if (double.TryParse(tbMargePrice.Text, out double priceMarge))
            {
                medicine.PriceMarge = priceMarge;
            }

            if (double.TryParse(tbPrice.Text, out double price))
            {
                medicine.Price = price;
            }

            if (double.TryParse(tbPriceOfBuy.Text, out double priceOfBuy))
            {
                medicine.PriceOfBuy = priceOfBuy;
            }

            if (double.TryParse(cbPercentageOfRefunde.Text, out double percentageOfRefunding))
            {
                medicine.PercentageOfRefunding = percentageOfRefunding;
            }

            if (double.TryParse(tbRefundedPrice.Text, out double priceAfterRefunding))
            {
                medicine.PriceAfterRefunding = priceAfterRefunding;
            }

            if (int.TryParse(tbQuantityInPackage.Text, out int quantityInPackage))
            {
                medicine.QuantityInPackage = quantityInPackage;
            }

            medicine.IsOnReciept = cbIsOnReciept.Checked;
            medicine.IsRefunded = cbIsRefunded.Checked;
            medicine.IsAntibiotique = cbIsAntibiotique.Checked;
        }

        private void cbIsOnReciept_CheckedChanged(object sender, EventArgs e)
        {
            isOnReciept = cbIsOnReciept.Checked;
        }

        private void cbIsRefunded_CheckedChanged(object sender, EventArgs e)
        {
            isRefunded = cbIsRefunded.Checked;
            cbPercentageOfRefunde.ReadOnly = !cbIsRefunded.Checked;
        }

        private void cbPercentageOfRefunde_TextChanged(object sender, EventArgs e)
        {
            // Obsługa zmian tekstu w polu cbPercentageOfRefunde
        }

        private void tbPrice_TextChanged(object sender, EventArgs e)
        {
            // Obsługa zmian tekstu w polu tbPrice
        }

        private double NullCheck(string price)
        {
            return double.TryParse(price, out double result) ? result : 0;
        }

        private void tbMargePrice_TextChanged(object sender, EventArgs e)
        {
            double marge = NullCheck(tbMargePrice.Text);
            double price;

            if (cbIsRefunded.Checked)
            {
                double priceOfBuy = NullCheck(tbPriceOfBuy.Text);
                price = priceOfBuy + marge;
                double percentage = NullCheck(cbPercentageOfRefunde.Text);
                double price2 = price - (priceOfBuy * percentage / 100);
                tbRefundedPrice.Text = price2.ToString();
            }
            else
            {
                double priceOfBuy = NullCheck(tbPriceOfBuy.Text);
                price = priceOfBuy + marge;
                tbPrice.Text = price.ToString();
            }
        }

        private void cbIsAntibiotique_CheckedChanged(object sender, EventArgs e)
        {
            isAntibiotique = cbIsAntibiotique.Checked;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
