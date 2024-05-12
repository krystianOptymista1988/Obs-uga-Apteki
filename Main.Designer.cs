namespace Obsługa_Apteki
{
    partial class Main
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnMedicines = new System.Windows.Forms.Button();
            this.btnDelivery = new System.Windows.Forms.Button();
            this.btnRecipe = new System.Windows.Forms.Button();
            this.btnPatient = new System.Windows.Forms.Button();
            this.btnSell = new System.Windows.Forms.Button();
            this.btnUtilization = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnMedicines
            // 
            this.btnMedicines.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMedicines.ForeColor = System.Drawing.Color.Tomato;
            this.btnMedicines.Image = ((System.Drawing.Image)(resources.GetObject("btnMedicines.Image")));
            this.btnMedicines.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMedicines.Location = new System.Drawing.Point(75, 48);
            this.btnMedicines.Name = "btnMedicines";
            this.btnMedicines.Size = new System.Drawing.Size(149, 193);
            this.btnMedicines.TabIndex = 0;
            this.btnMedicines.Text = "Baza Leków";
            this.btnMedicines.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMedicines.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnMedicines.UseVisualStyleBackColor = true;
            // 
            // btnDelivery
            // 
            this.btnDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDelivery.ForeColor = System.Drawing.Color.Tomato;
            this.btnDelivery.Image = ((System.Drawing.Image)(resources.GetObject("btnDelivery.Image")));
            this.btnDelivery.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelivery.Location = new System.Drawing.Point(84, 287);
            this.btnDelivery.Name = "btnDelivery";
            this.btnDelivery.Size = new System.Drawing.Size(149, 193);
            this.btnDelivery.TabIndex = 6;
            this.btnDelivery.Text = "Zamówienia";
            this.btnDelivery.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelivery.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnDelivery.UseVisualStyleBackColor = true;
            // 
            // btnRecipe
            // 
            this.btnRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRecipe.ForeColor = System.Drawing.Color.Tomato;
            this.btnRecipe.Image = ((System.Drawing.Image)(resources.GetObject("btnRecipe.Image")));
            this.btnRecipe.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRecipe.Location = new System.Drawing.Point(344, 48);
            this.btnRecipe.Name = "btnRecipe";
            this.btnRecipe.Size = new System.Drawing.Size(149, 193);
            this.btnRecipe.TabIndex = 7;
            this.btnRecipe.Text = "Recepty";
            this.btnRecipe.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecipe.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnRecipe.UseVisualStyleBackColor = true;
            // 
            // btnPatient
            // 
            this.btnPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPatient.ForeColor = System.Drawing.Color.Tomato;
            this.btnPatient.Image = ((System.Drawing.Image)(resources.GetObject("btnPatient.Image")));
            this.btnPatient.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPatient.Location = new System.Drawing.Point(344, 287);
            this.btnPatient.Name = "btnPatient";
            this.btnPatient.Size = new System.Drawing.Size(149, 193);
            this.btnPatient.TabIndex = 8;
            this.btnPatient.Text = "Pacjenci";
            this.btnPatient.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPatient.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnPatient.UseVisualStyleBackColor = true;
            this.btnPatient.Click += new System.EventHandler(this.btnPatient_Click);
            // 
            // btnSell
            // 
            this.btnSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSell.ForeColor = System.Drawing.Color.Tomato;
            this.btnSell.Image = ((System.Drawing.Image)(resources.GetObject("btnSell.Image")));
            this.btnSell.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSell.Location = new System.Drawing.Point(628, 48);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(149, 193);
            this.btnSell.TabIndex = 9;
            this.btnSell.Text = "Sprzedaż";
            this.btnSell.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSell.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnSell.UseVisualStyleBackColor = true;
            // 
            // btnUtilization
            // 
            this.btnUtilization.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUtilization.ForeColor = System.Drawing.Color.Tomato;
            this.btnUtilization.Image = ((System.Drawing.Image)(resources.GetObject("btnUtilization.Image")));
            this.btnUtilization.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUtilization.Location = new System.Drawing.Point(628, 287);
            this.btnUtilization.Name = "btnUtilization";
            this.btnUtilization.Size = new System.Drawing.Size(149, 193);
            this.btnUtilization.TabIndex = 10;
            this.btnUtilization.Text = "Utylizacja";
            this.btnUtilization.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUtilization.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnUtilization.UseVisualStyleBackColor = true;
            this.btnUtilization.Click += new System.EventHandler(this.button5_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 562);
            this.Controls.Add(this.btnUtilization);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.btnPatient);
            this.Controls.Add(this.btnRecipe);
            this.Controls.Add(this.btnDelivery);
            this.Controls.Add(this.btnMedicines);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Pharm Assistant - Twoja apteka";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMedicines;
        private System.Windows.Forms.Button btnDelivery;
        private System.Windows.Forms.Button btnRecipe;
        private System.Windows.Forms.Button btnPatient;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Button btnUtilization;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

