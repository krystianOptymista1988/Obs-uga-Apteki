using MySql.Data.MySqlClient;
using Obsługa_Apteki.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Obsługa_Apteki.Entities.AptekaDbContext;


namespace Obsługa_Apteki
{
    public partial class PatientShow : Form
    {
        private AptekaDbContext context;
        private List<Patient> PatientsList2 = new List<Patient>();
        public PatientShow()
        {
            InitializeComponent();
           
            context = new AptekaDbContext();

            RefreshPatients();
        }

        public void RefreshPatients()
        {
            try
            {
                using (var context = new AptekaDbContext())
                {

                    var patients = context.Patients.ToList();

                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();

                    if (patients.Any())
                    {
                        dataGridView1.DataSource = patients;
                    }
                    else
                    {
                        MessageBox.Show("Brak pacjentów w bazie danych.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas odświeżania listy pacjentów: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshData()
        {
            this.RefreshPatients();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            var addEditPatient = new PatientAddEdit();
            addEditPatient.ShowDialog();
            Close();
        }

        private void btnEditPatient_Click(object sender, EventArgs e)
        {
            var addEditPatient = new PatientAddEdit();
            addEditPatient.ShowDialog();
        }
    }
}
