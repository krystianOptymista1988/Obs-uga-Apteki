namespace Obsługa_Apteki
{
    partial class RecieptData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecieptData));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tbPatient = new System.Windows.Forms.TextBox();
            this.tbDateOfExpire = new System.Windows.Forms.TextBox();
            this.lblPatient = new System.Windows.Forms.Label();
            this.lblDateOfExpire = new System.Windows.Forms.Label();
            this.tbDoctor = new System.Windows.Forms.TextBox();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.btnImplement = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(245, 242);
            this.dataGridView1.TabIndex = 0;
            // 
            // tbPatient
            // 
            this.tbPatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPatient.Location = new System.Drawing.Point(51, 260);
            this.tbPatient.Name = "tbPatient";
            this.tbPatient.Size = new System.Drawing.Size(189, 20);
            this.tbPatient.TabIndex = 1;
            // 
            // tbDateOfExpire
            // 
            this.tbDateOfExpire.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDateOfExpire.Location = new System.Drawing.Point(51, 299);
            this.tbDateOfExpire.Name = "tbDateOfExpire";
            this.tbDateOfExpire.Size = new System.Drawing.Size(189, 20);
            this.tbDateOfExpire.TabIndex = 2;
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Location = new System.Drawing.Point(120, 283);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(43, 13);
            this.lblPatient.TabIndex = 3;
            this.lblPatient.Text = "Pacjent";
            // 
            // lblDateOfExpire
            // 
            this.lblDateOfExpire.AutoSize = true;
            this.lblDateOfExpire.Location = new System.Drawing.Point(103, 322);
            this.lblDateOfExpire.Name = "lblDateOfExpire";
            this.lblDateOfExpire.Size = new System.Drawing.Size(77, 13);
            this.lblDateOfExpire.TabIndex = 4;
            this.lblDateOfExpire.Text = "Data ważności";
            // 
            // tbDoctor
            // 
            this.tbDoctor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDoctor.Location = new System.Drawing.Point(51, 338);
            this.tbDoctor.Name = "tbDoctor";
            this.tbDoctor.Size = new System.Drawing.Size(189, 20);
            this.tbDoctor.TabIndex = 5;
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Location = new System.Drawing.Point(90, 361);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(104, 13);
            this.lblDoctor.TabIndex = 6;
            this.lblDoctor.Text = "Lekarz wystawiający";
            // 
            // btnImplement
            // 
            this.btnImplement.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnImplement.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnImplement.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnImplement.Image = ((System.Drawing.Image)(resources.GetObject("btnImplement.Image")));
            this.btnImplement.Location = new System.Drawing.Point(83, 406);
            this.btnImplement.Name = "btnImplement";
            this.btnImplement.Size = new System.Drawing.Size(127, 32);
            this.btnImplement.TabIndex = 10;
            this.btnImplement.Text = "Zrealizuj";
            this.btnImplement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImplement.UseVisualStyleBackColor = false;
            this.btnImplement.Click += new System.EventHandler(this.btnImplement_Click);
            // 
            // RecieptData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 450);
            this.Controls.Add(this.btnImplement);
            this.Controls.Add(this.lblDoctor);
            this.Controls.Add(this.tbDoctor);
            this.Controls.Add(this.lblDateOfExpire);
            this.Controls.Add(this.lblPatient);
            this.Controls.Add(this.tbDateOfExpire);
            this.Controls.Add(this.tbPatient);
            this.Controls.Add(this.dataGridView1);
            this.Name = "RecieptData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recepta";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tbPatient;
        private System.Windows.Forms.TextBox tbDateOfExpire;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Label lblDateOfExpire;
        private System.Windows.Forms.TextBox tbDoctor;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.Button btnImplement;
    }
}