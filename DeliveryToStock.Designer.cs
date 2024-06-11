namespace Obsługa_Apteki
{
    partial class DeliveryToStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryToStock));
            this.dgvDeliveryDetails = new System.Windows.Forms.DataGridView();
            this.dgvDeliveryStock = new System.Windows.Forms.DataGridView();
            this.dgvDelivryInFuture = new System.Windows.Forms.DataGridView();
            this.btnShow = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnShowOrdered = new System.Windows.Forms.Button();
            this.lbDeliveryInFuture = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelivryInFuture)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDeliveryDetails
            // 
            this.dgvDeliveryDetails.AllowUserToAddRows = false;
            this.dgvDeliveryDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDeliveryDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDeliveryDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvDeliveryDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeliveryDetails.Location = new System.Drawing.Point(447, 51);
            this.dgvDeliveryDetails.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDeliveryDetails.Name = "dgvDeliveryDetails";
            this.dgvDeliveryDetails.RowHeadersVisible = false;
            this.dgvDeliveryDetails.RowHeadersWidth = 62;
            this.dgvDeliveryDetails.RowTemplate.Height = 28;
            this.dgvDeliveryDetails.Size = new System.Drawing.Size(476, 476);
            this.dgvDeliveryDetails.TabIndex = 0;
            // 
            // dgvDeliveryStock
            // 
            this.dgvDeliveryStock.AllowUserToAddRows = false;
            this.dgvDeliveryStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDeliveryStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDeliveryStock.BackgroundColor = System.Drawing.Color.White;
            this.dgvDeliveryStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeliveryStock.Location = new System.Drawing.Point(23, 51);
            this.dgvDeliveryStock.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDeliveryStock.Name = "dgvDeliveryStock";
            this.dgvDeliveryStock.RowHeadersVisible = false;
            this.dgvDeliveryStock.RowHeadersWidth = 62;
            this.dgvDeliveryStock.RowTemplate.Height = 28;
            this.dgvDeliveryStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeliveryStock.Size = new System.Drawing.Size(399, 130);
            this.dgvDeliveryStock.TabIndex = 1;
            // 
            // dgvDelivryInFuture
            // 
            this.dgvDelivryInFuture.AllowUserToAddRows = false;
            this.dgvDelivryInFuture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDelivryInFuture.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDelivryInFuture.BackgroundColor = System.Drawing.Color.White;
            this.dgvDelivryInFuture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDelivryInFuture.Location = new System.Drawing.Point(23, 302);
            this.dgvDelivryInFuture.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDelivryInFuture.Name = "dgvDelivryInFuture";
            this.dgvDelivryInFuture.RowHeadersVisible = false;
            this.dgvDelivryInFuture.RowHeadersWidth = 62;
            this.dgvDelivryInFuture.RowTemplate.Height = 28;
            this.dgvDelivryInFuture.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDelivryInFuture.Size = new System.Drawing.Size(399, 140);
            this.dgvDelivryInFuture.TabIndex = 2;
            // 
            // btnShow
            // 
            this.btnShow.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnShow.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnShow.Image = ((System.Drawing.Image)(resources.GetObject("btnShow.Image")));
            this.btnShow.Location = new System.Drawing.Point(130, 217);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(127, 32);
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "Pokaż";
            this.btnShow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(295, 217);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 32);
            this.button2.TabIndex = 4;
            this.button2.Text = "Przyjmij";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnShowOrdered
            // 
            this.btnShowOrdered.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnShowOrdered.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnShowOrdered.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnShowOrdered.Image = ((System.Drawing.Image)(resources.GetObject("btnShowOrdered.Image")));
            this.btnShowOrdered.Location = new System.Drawing.Point(209, 464);
            this.btnShowOrdered.Name = "btnShowOrdered";
            this.btnShowOrdered.Size = new System.Drawing.Size(127, 32);
            this.btnShowOrdered.TabIndex = 6;
            this.btnShowOrdered.Text = "Pokaż";
            this.btnShowOrdered.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnShowOrdered.UseVisualStyleBackColor = false;
            this.btnShowOrdered.Click += new System.EventHandler(this.btnShowOrdered_Click);
            // 
            // lbDeliveryInFuture
            // 
            this.lbDeliveryInFuture.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbDeliveryInFuture.AutoSize = true;
            this.lbDeliveryInFuture.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbDeliveryInFuture.ForeColor = System.Drawing.Color.DarkRed;
            this.lbDeliveryInFuture.Location = new System.Drawing.Point(188, 268);
            this.lbDeliveryInFuture.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDeliveryInFuture.Name = "lbDeliveryInFuture";
            this.lbDeliveryInFuture.Size = new System.Drawing.Size(163, 20);
            this.lbDeliveryInFuture.TabIndex = 7;
            this.lbDeliveryInFuture.Text = "Najbliższe Dostawy";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(178, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Dostawy na magazynie";
            // 
            // DeliveryToStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 556);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbDeliveryInFuture);
            this.Controls.Add(this.btnShowOrdered);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dgvDelivryInFuture);
            this.Controls.Add(this.dgvDeliveryStock);
            this.Controls.Add(this.dgvDeliveryDetails);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(950, 595);
            this.MinimumSize = new System.Drawing.Size(950, 595);
            this.Name = "DeliveryToStock";
            this.Text = "DeliveryToStock";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelivryInFuture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDeliveryDetails;
        private System.Windows.Forms.DataGridView dgvDeliveryStock;
        private System.Windows.Forms.DataGridView dgvDelivryInFuture;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnShowOrdered;
        private System.Windows.Forms.Label lbDeliveryInFuture;
        private System.Windows.Forms.Label label1;
    }
}