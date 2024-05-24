namespace Obsługa_Apteki
{
    partial class RecieptAddEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecieptAddEdit));
            this.tbId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPatient = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.cbPatients = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblMedicine = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.cbMedicines = new System.Windows.Forms.ComboBox();
            this.dtpDateOfRegistry = new System.Windows.Forms.DateTimePicker();
            this.dtpDateOfExpire = new System.Windows.Forms.DateTimePicker();
            this.lblDateOfRegistry = new System.Windows.Forms.Label();
            this.lblDateOfExpire = new System.Windows.Forms.Label();
            this.tbDoctor = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // tbId
            // 
            this.tbId.Enabled = false;
            this.tbId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbId.Location = new System.Drawing.Point(71, 25);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(57, 21);
            this.tbId.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(47, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 15);
            this.label1.TabIndex = 30;
            this.label1.Text = "ID";
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPatient.Location = new System.Drawing.Point(103, 361);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(50, 13);
            this.lblPatient.TabIndex = 33;
            this.lblPatient.Text = "Pacjent";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(50, 108);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(673, 242);
            this.dataGridView1.TabIndex = 34;
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDoctor.Location = new System.Drawing.Point(27, 391);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(126, 13);
            this.lblDoctor.TabIndex = 35;
            this.lblDoctor.Text = "Lekarz Wystawiający";
            // 
            // cbPatients
            // 
            this.cbPatients.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbPatients.FormattingEnabled = true;
            this.cbPatients.Location = new System.Drawing.Point(172, 356);
            this.cbPatients.Name = "cbPatients";
            this.cbPatients.Size = new System.Drawing.Size(177, 23);
            this.cbPatients.TabIndex = 37;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(411, 428);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(123, 30);
            this.btnCancel.TabIndex = 41;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAccept.Image = ((System.Drawing.Image)(resources.GetObject("btnAccept.Image")));
            this.btnAccept.Location = new System.Drawing.Point(216, 428);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(123, 30);
            this.btnAccept.TabIndex = 40;
            this.btnAccept.Text = "Akceptuj";
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click_1);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblQuantity.Location = new System.Drawing.Point(450, 31);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(106, 15);
            this.lblQuantity.TabIndex = 47;
            this.lblQuantity.Text = "ilość opakowań";
            // 
            // lblMedicine
            // 
            this.lblMedicine.AutoSize = true;
            this.lblMedicine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMedicine.Location = new System.Drawing.Point(169, 28);
            this.lblMedicine.Name = "lblMedicine";
            this.lblMedicine.Size = new System.Drawing.Size(30, 15);
            this.lblMedicine.TabIndex = 46;
            this.lblMedicine.Text = "Lek";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nudQuantity.Location = new System.Drawing.Point(582, 27);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(73, 21);
            this.nudQuantity.TabIndex = 45;
            // 
            // btnAddToList
            // 
            this.btnAddToList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAddToList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddToList.Image = ((System.Drawing.Image)(resources.GetObject("btnAddToList.Image")));
            this.btnAddToList.Location = new System.Drawing.Point(289, 62);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(229, 30);
            this.btnAddToList.TabIndex = 44;
            this.btnAddToList.Text = "Dodaj do Listy";
            this.btnAddToList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddToList.UseVisualStyleBackColor = false;
            // 
            // cbMedicines
            // 
            this.cbMedicines.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbMedicines.FormattingEnabled = true;
            this.cbMedicines.Location = new System.Drawing.Point(216, 25);
            this.cbMedicines.Name = "cbMedicines";
            this.cbMedicines.Size = new System.Drawing.Size(163, 23);
            this.cbMedicines.TabIndex = 43;
            // 
            // dtpDateOfRegistry
            // 
            this.dtpDateOfRegistry.Location = new System.Drawing.Point(523, 359);
            this.dtpDateOfRegistry.Name = "dtpDateOfRegistry";
            this.dtpDateOfRegistry.Size = new System.Drawing.Size(200, 20);
            this.dtpDateOfRegistry.TabIndex = 48;
            // 
            // dtpDateOfExpire
            // 
            this.dtpDateOfExpire.Location = new System.Drawing.Point(523, 385);
            this.dtpDateOfExpire.Name = "dtpDateOfExpire";
            this.dtpDateOfExpire.Size = new System.Drawing.Size(200, 20);
            this.dtpDateOfExpire.TabIndex = 49;
            // 
            // lblDateOfRegistry
            // 
            this.lblDateOfRegistry.AutoSize = true;
            this.lblDateOfRegistry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDateOfRegistry.Location = new System.Drawing.Point(408, 366);
            this.lblDateOfRegistry.Name = "lblDateOfRegistry";
            this.lblDateOfRegistry.Size = new System.Drawing.Size(87, 13);
            this.lblDateOfRegistry.TabIndex = 50;
            this.lblDateOfRegistry.Text = "Data Wydania";
            // 
            // lblDateOfExpire
            // 
            this.lblDateOfExpire.AutoSize = true;
            this.lblDateOfExpire.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDateOfExpire.Location = new System.Drawing.Point(408, 392);
            this.lblDateOfExpire.Name = "lblDateOfExpire";
            this.lblDateOfExpire.Size = new System.Drawing.Size(90, 13);
            this.lblDateOfExpire.TabIndex = 51;
            this.lblDateOfExpire.Text = "Data ważności";
            // 
            // tbDoctor
            // 
            this.tbDoctor.Location = new System.Drawing.Point(172, 391);
            this.tbDoctor.Name = "tbDoctor";
            this.tbDoctor.Size = new System.Drawing.Size(177, 20);
            this.tbDoctor.TabIndex = 52;
            // 
            // RecieptAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.tbDoctor);
            this.Controls.Add(this.lblDateOfExpire);
            this.Controls.Add(this.lblDateOfRegistry);
            this.Controls.Add(this.dtpDateOfExpire);
            this.Controls.Add(this.dtpDateOfRegistry);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblMedicine);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.btnAddToList);
            this.Controls.Add(this.cbMedicines);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.cbPatients);
            this.Controls.Add(this.lblDoctor);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblPatient);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RecieptAddEdit";
            this.Text = "RecieptAddEdit";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.ComboBox cbPatients;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblMedicine;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.ComboBox cbMedicines;
        private System.Windows.Forms.DateTimePicker dtpDateOfRegistry;
        private System.Windows.Forms.DateTimePicker dtpDateOfExpire;
        private System.Windows.Forms.Label lblDateOfRegistry;
        private System.Windows.Forms.Label lblDateOfExpire;
        private System.Windows.Forms.TextBox tbDoctor;
    }
}