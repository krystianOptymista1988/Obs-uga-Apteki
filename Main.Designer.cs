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
            this.btnPharmaceuts = new System.Windows.Forms.Button();
            this.btnSupport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMedicines
            // 
            this.btnMedicines.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMedicines.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMedicines.ForeColor = System.Drawing.Color.Tomato;
            this.btnMedicines.Image = ((System.Drawing.Image)(resources.GetObject("btnMedicines.Image")));
            this.btnMedicines.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMedicines.Location = new System.Drawing.Point(134, 108);
            this.btnMedicines.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMedicines.Name = "btnMedicines";
            this.btnMedicines.Size = new System.Drawing.Size(250, 289);
            this.btnMedicines.TabIndex = 0;
            this.btnMedicines.Text = "Baza Leków";
            this.btnMedicines.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMedicines.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnMedicines.UseVisualStyleBackColor = true;
            this.btnMedicines.Click += new System.EventHandler(this.btnMedicines_Click);
            // 
            // btnDelivery
            // 
            this.btnDelivery.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDelivery.ForeColor = System.Drawing.Color.Tomato;
            this.btnDelivery.Image = ((System.Drawing.Image)(resources.GetObject("btnDelivery.Image")));
            this.btnDelivery.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelivery.Location = new System.Drawing.Point(148, 476);
            this.btnDelivery.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelivery.Name = "btnDelivery";
            this.btnDelivery.Size = new System.Drawing.Size(250, 289);
            this.btnDelivery.TabIndex = 6;
            this.btnDelivery.Text = "Zamówienia";
            this.btnDelivery.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelivery.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnDelivery.UseVisualStyleBackColor = true;
            this.btnDelivery.Click += new System.EventHandler(this.btnDelivery_Click);
            // 
            // btnRecipe
            // 
            this.btnRecipe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRecipe.ForeColor = System.Drawing.Color.Tomato;
            this.btnRecipe.Image = ((System.Drawing.Image)(resources.GetObject("btnRecipe.Image")));
            this.btnRecipe.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRecipe.Location = new System.Drawing.Point(502, 108);
            this.btnRecipe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRecipe.Name = "btnRecipe";
            this.btnRecipe.Size = new System.Drawing.Size(250, 289);
            this.btnRecipe.TabIndex = 7;
            this.btnRecipe.Text = "Recepty";
            this.btnRecipe.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecipe.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnRecipe.UseVisualStyleBackColor = true;
            this.btnRecipe.Click += new System.EventHandler(this.btnRecipe_Click);
            // 
            // btnPatient
            // 
            this.btnPatient.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPatient.ForeColor = System.Drawing.Color.Tomato;
            this.btnPatient.Image = ((System.Drawing.Image)(resources.GetObject("btnPatient.Image")));
            this.btnPatient.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPatient.Location = new System.Drawing.Point(851, 108);
            this.btnPatient.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPatient.Name = "btnPatient";
            this.btnPatient.Size = new System.Drawing.Size(250, 289);
            this.btnPatient.TabIndex = 8;
            this.btnPatient.Text = "Pacjenci";
            this.btnPatient.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPatient.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnPatient.UseVisualStyleBackColor = true;
            this.btnPatient.Click += new System.EventHandler(this.btnPatient_Click);
            // 
            // btnSell
            // 
            this.btnSell.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSell.ForeColor = System.Drawing.Color.Tomato;
            this.btnSell.Image = ((System.Drawing.Image)(resources.GetObject("btnSell.Image")));
            this.btnSell.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSell.Location = new System.Drawing.Point(851, 476);
            this.btnSell.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(250, 289);
            this.btnSell.TabIndex = 9;
            this.btnSell.Text = "Sprzedaż";
            this.btnSell.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSell.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // btnUtilization
            // 
            this.btnUtilization.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUtilization.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUtilization.ForeColor = System.Drawing.Color.Tomato;
            this.btnUtilization.Image = ((System.Drawing.Image)(resources.GetObject("btnUtilization.Image")));
            this.btnUtilization.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUtilization.Location = new System.Drawing.Point(502, 476);
            this.btnUtilization.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUtilization.Name = "btnUtilization";
            this.btnUtilization.Size = new System.Drawing.Size(250, 289);
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
            // btnPharmaceuts
            // 
            this.btnPharmaceuts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPharmaceuts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPharmaceuts.ForeColor = System.Drawing.Color.Tomato;
            this.btnPharmaceuts.Image = ((System.Drawing.Image)(resources.GetObject("btnPharmaceuts.Image")));
            this.btnPharmaceuts.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPharmaceuts.Location = new System.Drawing.Point(1202, 108);
            this.btnPharmaceuts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPharmaceuts.Name = "btnPharmaceuts";
            this.btnPharmaceuts.Size = new System.Drawing.Size(250, 289);
            this.btnPharmaceuts.TabIndex = 11;
            this.btnPharmaceuts.Text = "Farmaceuci";
            this.btnPharmaceuts.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPharmaceuts.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnPharmaceuts.UseVisualStyleBackColor = true;
            this.btnPharmaceuts.Click += new System.EventHandler(this.btnPharmaceuts_Click);
            // 
            // btnSupport
            // 
            this.btnSupport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSupport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSupport.ForeColor = System.Drawing.Color.Tomato;
            this.btnSupport.Image = ((System.Drawing.Image)(resources.GetObject("btnSupport.Image")));
            this.btnSupport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSupport.Location = new System.Drawing.Point(1202, 476);
            this.btnSupport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSupport.Name = "btnSupport";
            this.btnSupport.Size = new System.Drawing.Size(250, 289);
            this.btnSupport.TabIndex = 12;
            this.btnSupport.Text = "Support";
            this.btnSupport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSupport.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnSupport.UseVisualStyleBackColor = true;
            this.btnSupport.Click += new System.EventHandler(this.btnSupport_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1651, 953);
            this.Controls.Add(this.btnSupport);
            this.Controls.Add(this.btnPharmaceuts);
            this.Controls.Add(this.btnUtilization);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.btnPatient);
            this.Controls.Add(this.btnRecipe);
            this.Controls.Add(this.btnDelivery);
            this.Controls.Add(this.btnMedicines);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Main";
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
        private System.Windows.Forms.Button btnPharmaceuts;
        private System.Windows.Forms.Button btnSupport;
    }
}

