namespace Project_4___Cafe
{
    partial class OrderWindow
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
            this.OrderBtn = new System.Windows.Forms.Button();
            this.ReserveBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ORPanelMain = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // OrderBtn
            // 
            this.OrderBtn.BackColor = System.Drawing.Color.IndianRed;
            this.OrderBtn.FlatAppearance.BorderSize = 0;
            this.OrderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OrderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderBtn.Location = new System.Drawing.Point(12, 12);
            this.OrderBtn.Name = "OrderBtn";
            this.OrderBtn.Size = new System.Drawing.Size(87, 46);
            this.OrderBtn.TabIndex = 0;
            this.OrderBtn.Text = "Order";
            this.OrderBtn.UseVisualStyleBackColor = false;
            this.OrderBtn.Click += new System.EventHandler(this.OrderBtn_Click);
            // 
            // ReserveBtn
            // 
            this.ReserveBtn.BackColor = System.Drawing.Color.DarkOrange;
            this.ReserveBtn.FlatAppearance.BorderSize = 0;
            this.ReserveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReserveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReserveBtn.Location = new System.Drawing.Point(12, 64);
            this.ReserveBtn.Name = "ReserveBtn";
            this.ReserveBtn.Size = new System.Drawing.Size(87, 46);
            this.ReserveBtn.TabIndex = 1;
            this.ReserveBtn.Text = "Reserve";
            this.ReserveBtn.UseVisualStyleBackColor = false;
            this.ReserveBtn.Click += new System.EventHandler(this.ReserveBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(791, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ORPanelMain
            // 
            this.ORPanelMain.Location = new System.Drawing.Point(105, 12);
            this.ORPanelMain.Name = "ORPanelMain";
            this.ORPanelMain.Size = new System.Drawing.Size(680, 321);
            this.ORPanelMain.TabIndex = 3;
            // 
            // OrderWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 345);
            this.Controls.Add(this.ORPanelMain);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ReserveBtn);
            this.Controls.Add(this.OrderBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OrderWindow";
            this.Text = "OrderWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OrderBtn;
        private System.Windows.Forms.Button ReserveBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel ORPanelMain;
    }
}