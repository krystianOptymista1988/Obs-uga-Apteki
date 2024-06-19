namespace Obsługa_Apteki
{
    partial class DeliveryAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryAddEdit));
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvMedicinesDelivery = new System.Windows.Forms.DataGridView();
            this.cbMedicines = new System.Windows.Forms.ComboBox();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblMedicines = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.dtpDateOfDelivery = new System.Windows.Forms.DateTimePicker();
            this.cbPharmaceut = new System.Windows.Forms.ComboBox();
            this.lblDateOfDelivery = new System.Windows.Forms.Label();
            this.lblPharmaceut = new System.Windows.Forms.Label();
            this.btnDeleteFromList = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDeliveryCost = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicinesDelivery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.Location = new System.Drawing.Point(160, 502);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(134, 27);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Wyślij ";
            this.btnSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(439, 502);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(134, 27);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgvMedicinesDelivery
            // 
            this.dgvMedicinesDelivery.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedicinesDelivery.BackgroundColor = System.Drawing.Color.White;
            this.dgvMedicinesDelivery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicinesDelivery.Location = new System.Drawing.Point(26, 116);
            this.dgvMedicinesDelivery.Name = "dgvMedicinesDelivery";
            this.dgvMedicinesDelivery.RowHeadersVisible = false;
            this.dgvMedicinesDelivery.RowHeadersWidth = 62;
            this.dgvMedicinesDelivery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicinesDelivery.Size = new System.Drawing.Size(705, 246);
            this.dgvMedicinesDelivery.TabIndex = 2;
            // 
            // cbMedicines
            // 
            this.cbMedicines.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbMedicines.FormattingEnabled = true;
            this.cbMedicines.Location = new System.Drawing.Point(174, 11);
            this.cbMedicines.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMedicines.Name = "cbMedicines";
            this.cbMedicines.Size = new System.Drawing.Size(185, 24);
            this.cbMedicines.TabIndex = 3;
            // 
            // btnAddToList
            // 
            this.btnAddToList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAddToList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddToList.Image = ((System.Drawing.Image)(resources.GetObject("btnAddToList.Image")));
            this.btnAddToList.Location = new System.Drawing.Point(277, 58);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(207, 35);
            this.btnAddToList.TabIndex = 4;
            this.btnAddToList.Text = "Dodaj do zamówienia";
            this.btnAddToList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddToList.UseVisualStyleBackColor = false;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // nudQuantity
            // 
            this.nudQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nudQuantity.Location = new System.Drawing.Point(535, 13);
            this.nudQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(73, 23);
            this.nudQuantity.TabIndex = 5;
            // 
            // lblMedicines
            // 
            this.lblMedicines.AutoSize = true;
            this.lblMedicines.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMedicines.Location = new System.Drawing.Point(124, 16);
            this.lblMedicines.Name = "lblMedicines";
            this.lblMedicines.Size = new System.Drawing.Size(34, 17);
            this.lblMedicines.TabIndex = 6;
            this.lblMedicines.Text = "Lek";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblQuantity.Location = new System.Drawing.Point(397, 16);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(118, 17);
            this.lblQuantity.TabIndex = 7;
            this.lblQuantity.Text = "ilość opakowań";
            // 
            // dtpDateOfDelivery
            // 
            this.dtpDateOfDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpDateOfDelivery.Location = new System.Drawing.Point(480, 451);
            this.dtpDateOfDelivery.Name = "dtpDateOfDelivery";
            this.dtpDateOfDelivery.Size = new System.Drawing.Size(170, 23);
            this.dtpDateOfDelivery.TabIndex = 8;
            // 
            // cbPharmaceut
            // 
            this.cbPharmaceut.FormattingEnabled = true;
            this.cbPharmaceut.Location = new System.Drawing.Point(220, 453);
            this.cbPharmaceut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbPharmaceut.Name = "cbPharmaceut";
            this.cbPharmaceut.Size = new System.Drawing.Size(127, 21);
            this.cbPharmaceut.TabIndex = 9;
            // 
            // lblDateOfDelivery
            // 
            this.lblDateOfDelivery.AutoSize = true;
            this.lblDateOfDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDateOfDelivery.Location = new System.Drawing.Point(367, 454);
            this.lblDateOfDelivery.Name = "lblDateOfDelivery";
            this.lblDateOfDelivery.Size = new System.Drawing.Size(107, 17);
            this.lblDateOfDelivery.TabIndex = 10;
            this.lblDateOfDelivery.Text = "Data Dostawy";
            // 
            // lblPharmaceut
            // 
            this.lblPharmaceut.AutoSize = true;
            this.lblPharmaceut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPharmaceut.Location = new System.Drawing.Point(113, 454);
            this.lblPharmaceut.Name = "lblPharmaceut";
            this.lblPharmaceut.Size = new System.Drawing.Size(100, 17);
            this.lblPharmaceut.TabIndex = 11;
            this.lblPharmaceut.Text = "Zamawiający";
            // 
            // btnDeleteFromList
            // 
            this.btnDeleteFromList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDeleteFromList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDeleteFromList.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteFromList.Image")));
            this.btnDeleteFromList.Location = new System.Drawing.Point(148, 389);
            this.btnDeleteFromList.Name = "btnDeleteFromList";
            this.btnDeleteFromList.Size = new System.Drawing.Size(187, 36);
            this.btnDeleteFromList.TabIndex = 13;
            this.btnDeleteFromList.Text = "Usuń z zamówienia";
            this.btnDeleteFromList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteFromList.UseVisualStyleBackColor = false;
            this.btnDeleteFromList.Click += new System.EventHandler(this.btnDeleteFromList_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(375, 401);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "wartość zamówienia :";
            // 
            // lblDeliveryCost
            // 
            this.lblDeliveryCost.AutoSize = true;
            this.lblDeliveryCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDeliveryCost.ForeColor = System.Drawing.Color.Firebrick;
            this.lblDeliveryCost.Location = new System.Drawing.Point(525, 399);
            this.lblDeliveryCost.Name = "lblDeliveryCost";
            this.lblDeliveryCost.Size = new System.Drawing.Size(19, 20);
            this.lblDeliveryCost.TabIndex = 15;
            this.lblDeliveryCost.Text = "0";
            // 
            // DeliveryAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(771, 565);
            this.Controls.Add(this.lblDeliveryCost);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDeleteFromList);
            this.Controls.Add(this.lblPharmaceut);
            this.Controls.Add(this.lblDateOfDelivery);
            this.Controls.Add(this.cbPharmaceut);
            this.Controls.Add(this.dtpDateOfDelivery);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblMedicines);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.btnAddToList);
            this.Controls.Add(this.cbMedicines);
            this.Controls.Add(this.dgvMedicinesDelivery);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSend);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(787, 610);
            this.MinimumSize = new System.Drawing.Size(595, 492);
            this.Name = "DeliveryAddEdit";
            this.Text = "Dodaj lub Edytuj Zamówienie";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicinesDelivery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvMedicinesDelivery;
        private System.Windows.Forms.ComboBox cbMedicines;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label lblMedicines;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.DateTimePicker dtpDateOfDelivery;
        private System.Windows.Forms.ComboBox cbPharmaceut;
        private System.Windows.Forms.Label lblDateOfDelivery;
        private System.Windows.Forms.Label lblPharmaceut;
        private System.Windows.Forms.Button btnDeleteFromList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDeliveryCost;
    }
}