namespace Obsługa_Apteki
{
    partial class MedicineCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MedicineCard));
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCategory = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbProducent = new System.Windows.Forms.TextBox();
            this.tbQuantityInPackage = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.tbPriceOfBuy = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbMargePrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbActiveSubstance = new System.Windows.Forms.TextBox();
            this.cbPercentageOfRefunde = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbRefundedPrice = new System.Windows.Forms.TextBox();
            this.cbIsRefunded = new System.Windows.Forms.CheckBox();
            this.cbIsAntibiotique = new System.Windows.Forms.CheckBox();
            this.cbIsOnReciept = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(395, 520);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(184, 46);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Anuluj";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(108, 520);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(184, 46);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "Akceptuj";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbName.Location = new System.Drawing.Point(150, 91);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(176, 28);
            this.tbName.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(66, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 22);
            this.label1.TabIndex = 23;
            this.label1.Text = "Nazwa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(370, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 22);
            this.label2.TabIndex = 24;
            this.label2.Text = "Kategoria";
            // 
            // tbCategory
            // 
            this.tbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbCategory.Location = new System.Drawing.Point(472, 97);
            this.tbCategory.Name = "tbCategory";
            this.tbCategory.Size = new System.Drawing.Size(176, 28);
            this.tbCategory.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(365, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 22);
            this.label3.TabIndex = 26;
            this.label3.Text = "Producent";
            // 
            // tbProducent
            // 
            this.tbProducent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbProducent.Location = new System.Drawing.Point(472, 153);
            this.tbProducent.Name = "tbProducent";
            this.tbProducent.Size = new System.Drawing.Size(176, 28);
            this.tbProducent.TabIndex = 27;
            // 
            // tbQuantityInPackage
            // 
            this.tbQuantityInPackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbQuantityInPackage.Location = new System.Drawing.Point(150, 150);
            this.tbQuantityInPackage.Name = "tbQuantityInPackage";
            this.tbQuantityInPackage.Size = new System.Drawing.Size(176, 28);
            this.tbQuantityInPackage.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(26, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 22);
            this.label5.TabIndex = 30;
            this.label5.Text = "ilość w Op.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(181, 466);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 22);
            this.label6.TabIndex = 29;
            this.label6.Text = "Cena Sprzedaży";
            // 
            // tbPrice
            // 
            this.tbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbPrice.Location = new System.Drawing.Point(342, 463);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.ReadOnly = true;
            this.tbPrice.Size = new System.Drawing.Size(147, 28);
            this.tbPrice.TabIndex = 28;
            this.tbPrice.TextChanged += new System.EventHandler(this.tbPrice_TextChanged);
            // 
            // tbPriceOfBuy
            // 
            this.tbPriceOfBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbPriceOfBuy.Location = new System.Drawing.Point(147, 331);
            this.tbPriceOfBuy.Name = "tbPriceOfBuy";
            this.tbPriceOfBuy.Size = new System.Drawing.Size(151, 28);
            this.tbPriceOfBuy.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(9, 331);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 22);
            this.label7.TabIndex = 38;
            this.label7.Text = "Cena zakupu";
            // 
            // tbMargePrice
            // 
            this.tbMargePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbMargePrice.Location = new System.Drawing.Point(505, 381);
            this.tbMargePrice.Name = "tbMargePrice";
            this.tbMargePrice.Size = new System.Drawing.Size(143, 28);
            this.tbMargePrice.TabIndex = 37;
            this.tbMargePrice.TextChanged += new System.EventHandler(this.tbMargePrice_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(426, 381);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 22);
            this.label8.TabIndex = 36;
            this.label8.Text = "Marża";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(276, 219);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(190, 22);
            this.label9.TabIndex = 35;
            this.label9.Text = "Substancja Aktywna";
            // 
            // tbActiveSubstance
            // 
            this.tbActiveSubstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbActiveSubstance.Location = new System.Drawing.Point(472, 219);
            this.tbActiveSubstance.Name = "tbActiveSubstance";
            this.tbActiveSubstance.Size = new System.Drawing.Size(176, 28);
            this.tbActiveSubstance.TabIndex = 34;
            // 
            // cbPercentageOfRefunde
            // 
            this.cbPercentageOfRefunde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbPercentageOfRefunde.Location = new System.Drawing.Point(472, 271);
            this.cbPercentageOfRefunde.Name = "cbPercentageOfRefunde";
            this.cbPercentageOfRefunde.ReadOnly = true;
            this.cbPercentageOfRefunde.Size = new System.Drawing.Size(176, 28);
            this.cbPercentageOfRefunde.TabIndex = 45;
            this.cbPercentageOfRefunde.TextChanged += new System.EventHandler(this.cbPercentageOfRefunde_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(338, 271);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 22);
            this.label10.TabIndex = 44;
            this.label10.Text = "% Refundacji";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(304, 334);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(185, 22);
            this.label12.TabIndex = 41;
            this.label12.Text = "Cena Refundowana";
            // 
            // tbRefundedPrice
            // 
            this.tbRefundedPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbRefundedPrice.Location = new System.Drawing.Point(505, 331);
            this.tbRefundedPrice.Name = "tbRefundedPrice";
            this.tbRefundedPrice.ReadOnly = true;
            this.tbRefundedPrice.Size = new System.Drawing.Size(143, 28);
            this.tbRefundedPrice.TabIndex = 40;
            // 
            // cbIsRefunded
            // 
            this.cbIsRefunded.AutoSize = true;
            this.cbIsRefunded.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbIsRefunded.Location = new System.Drawing.Point(46, 274);
            this.cbIsRefunded.Name = "cbIsRefunded";
            this.cbIsRefunded.Size = new System.Drawing.Size(157, 26);
            this.cbIsRefunded.TabIndex = 46;
            this.cbIsRefunded.Text = "Refundowany";
            this.cbIsRefunded.UseVisualStyleBackColor = true;
            this.cbIsRefunded.CheckedChanged += new System.EventHandler(this.cbIsRefunded_CheckedChanged);
            // 
            // cbIsAntibiotique
            // 
            this.cbIsAntibiotique.AutoSize = true;
            this.cbIsAntibiotique.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbIsAntibiotique.Location = new System.Drawing.Point(46, 383);
            this.cbIsAntibiotique.Name = "cbIsAntibiotique";
            this.cbIsAntibiotique.Size = new System.Drawing.Size(129, 26);
            this.cbIsAntibiotique.TabIndex = 47;
            this.cbIsAntibiotique.Text = "Antybiotyk";
            this.cbIsAntibiotique.UseVisualStyleBackColor = true;
            this.cbIsAntibiotique.CheckedChanged += new System.EventHandler(this.cbIsAntibiotique_CheckedChanged);
            // 
            // cbIsOnReciept
            // 
            this.cbIsOnReciept.AutoSize = true;
            this.cbIsOnReciept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbIsOnReciept.Location = new System.Drawing.Point(46, 215);
            this.cbIsOnReciept.Name = "cbIsOnReciept";
            this.cbIsOnReciept.Size = new System.Drawing.Size(134, 26);
            this.cbIsOnReciept.TabIndex = 48;
            this.cbIsOnReciept.Text = "Na receptę";
            this.cbIsOnReciept.UseVisualStyleBackColor = true;
            this.cbIsOnReciept.CheckedChanged += new System.EventHandler(this.cbIsOnReciept_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(89, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 22);
            this.label4.TabIndex = 49;
            this.label4.Text = "ID";
            // 
            // tbId
            // 
            this.tbId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbId.Location = new System.Drawing.Point(133, 30);
            this.tbId.Name = "tbId";
            this.tbId.ReadOnly = true;
            this.tbId.Size = new System.Drawing.Size(70, 28);
            this.tbId.TabIndex = 50;
            // 
            // MedicineCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(686, 596);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbIsOnReciept);
            this.Controls.Add(this.cbIsAntibiotique);
            this.Controls.Add(this.cbIsRefunded);
            this.Controls.Add(this.cbPercentageOfRefunde);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbRefundedPrice);
            this.Controls.Add(this.tbPriceOfBuy);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbMargePrice);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbActiveSubstance);
            this.Controls.Add(this.tbQuantityInPackage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.tbProducent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(708, 652);
            this.Name = "MedicineCard";
            this.Text = "Karta Leku";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbProducent;
        private System.Windows.Forms.TextBox tbQuantityInPackage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.TextBox tbPriceOfBuy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbMargePrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbActiveSubstance;
        private System.Windows.Forms.TextBox cbPercentageOfRefunde;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbRefundedPrice;
        private System.Windows.Forms.CheckBox cbIsRefunded;
        private System.Windows.Forms.CheckBox cbIsAntibiotique;
        private System.Windows.Forms.CheckBox cbIsOnReciept;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbId;
    }
}