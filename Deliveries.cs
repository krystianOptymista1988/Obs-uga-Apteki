using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Obsługa_Apteki
{
    public partial class Deliveries : Form
    {
        private DbActions _dbAction = new DbActions();
        private List<Delivery> deliveries;

        public Deliveries()
        {
            InitializeComponent();
            DataLoad();
            DGVHeadersSet();
        }

        private void DataLoad()
        {
            _dbAction = new DbActions();
            deliveries = _dbAction.GetDeliveries();

            if (deliveries == null || deliveries.Count == 0)
            {
                var columnNames = _dbAction.GetColumnNames<Delivery>();
                var dataTable = new DataTable();
                foreach (var columnName in columnNames)
                {
                    dataTable.Columns.Add(columnName);
                }
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                dataGridView1.DataSource = deliveries;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var value = dataGridView1.CurrentRow.Cells["DeliveryId"].Value;
                    if (value != null && int.TryParse(value.ToString(), out int deliveryId))
                    {
                        using (var context = new AptekaTestDbContext())
                        {
                            DeliveryAddEdit editForm = new DeliveryAddEdit(deliveryId, context);
                            if (editForm.ShowDialog() == DialogResult.OK)
                            {
                                DataLoad();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nieprawidłowy format ID zamówienia.");
                    }
                }
                else
                {
                    MessageBox.Show("Wybierz zamówienie do edycji.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas edycji zamówienia: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var DeliveryAddEdit = new DeliveryAddEdit();

            DeliveryAddEdit.ShowDialog();
            DataLoad();
        }

        private void DGVHeadersSet()
        {
            if (deliveries != null)
            {
                dataGridView1.Columns[nameof(Delivery.DeliveryId)].HeaderText = "ID";
                dataGridView1.Columns[nameof(Delivery.DeliveryId)].DisplayIndex = 0;
                dataGridView1.Columns[nameof(Delivery.DateOfCreate)].HeaderText = "Data zamówienia";
                dataGridView1.Columns[nameof(Delivery.DateOfCreate)].DisplayIndex = 1;
                dataGridView1.Columns[nameof(Delivery.DateOfDelivery)].HeaderText = "Termin Realizacji";
                dataGridView1.Columns[nameof(Delivery.DateOfDelivery)].DisplayIndex = 2;
                dataGridView1.Columns[nameof(Delivery.Value)].HeaderText = "Wartość";
                dataGridView1.Columns[nameof(Delivery.Value)].DisplayIndex = 3;
                dataGridView1.Columns[nameof(Delivery.ExpiredDates)].Visible = false;
                dataGridView1.Columns[nameof(Delivery.OrderedMedicines)].Visible = false;
                dataGridView1.Columns[nameof(Delivery.MedicineDeliveries)].Visible = false;
                dataGridView1.Columns[nameof(Delivery.PharmaceutOrdering)].HeaderText = "Zamawiający";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int deleteId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["DeliveryId"].Value);
                Delivery itemToRemove = deliveries.SingleOrDefault(d => d.DeliveryId == deleteId);
                if (itemToRemove != null)
                {
                    _dbAction.RemoveDelivery(itemToRemove);
                    deliveries.Remove(itemToRemove);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = deliveries;
                    DGVHeadersSet();
                }
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć dostawę do usunięcia.");
            }
        }
    }
}
