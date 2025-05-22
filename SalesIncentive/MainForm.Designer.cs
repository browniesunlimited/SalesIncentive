
namespace SalesIncentive
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSCRF = new System.Windows.Forms.Button();
            this.btnEncodeVariance = new System.Windows.Forms.Button();
            this.btnIncentive = new System.Windows.Forms.Button();
            this.btnQualifiedOutlet = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OrangeRed;
            this.panel1.Controls.Add(this.btnSCRF);
            this.panel1.Controls.Add(this.btnEncodeVariance);
            this.panel1.Controls.Add(this.btnIncentive);
            this.panel1.Controls.Add(this.btnQualifiedOutlet);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 775);
            this.panel1.TabIndex = 0;
            // 
            // btnSCRF
            // 
            this.btnSCRF.BackColor = System.Drawing.Color.White;
            this.btnSCRF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSCRF.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSCRF.Location = new System.Drawing.Point(9, 88);
            this.btnSCRF.Margin = new System.Windows.Forms.Padding(2);
            this.btnSCRF.Name = "btnSCRF";
            this.btnSCRF.Size = new System.Drawing.Size(186, 49);
            this.btnSCRF.TabIndex = 4;
            this.btnSCRF.Text = "SCRF";
            this.btnSCRF.UseVisualStyleBackColor = false;
            this.btnSCRF.Click += new System.EventHandler(this.btnSCRF_Click);
            // 
            // btnEncodeVariance
            // 
            this.btnEncodeVariance.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.btnEncodeVariance.BackColor = System.Drawing.Color.White;
            this.btnEncodeVariance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncodeVariance.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncodeVariance.Location = new System.Drawing.Point(9, 10);
            this.btnEncodeVariance.Margin = new System.Windows.Forms.Padding(2);
            this.btnEncodeVariance.Name = "btnEncodeVariance";
            this.btnEncodeVariance.Size = new System.Drawing.Size(186, 70);
            this.btnEncodeVariance.TabIndex = 3;
            this.btnEncodeVariance.Text = "Encode Variance && Spoilage";
            this.btnEncodeVariance.UseVisualStyleBackColor = false;
            this.btnEncodeVariance.Click += new System.EventHandler(this.btnEncodeVariance_Click);
            // 
            // btnIncentive
            // 
            this.btnIncentive.BackColor = System.Drawing.Color.White;
            this.btnIncentive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncentive.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncentive.Location = new System.Drawing.Point(9, 195);
            this.btnIncentive.Margin = new System.Windows.Forms.Padding(2);
            this.btnIncentive.Name = "btnIncentive";
            this.btnIncentive.Size = new System.Drawing.Size(186, 49);
            this.btnIncentive.TabIndex = 2;
            this.btnIncentive.Text = "Incentive";
            this.btnIncentive.UseVisualStyleBackColor = false;
            this.btnIncentive.Click += new System.EventHandler(this.btnIncentive_Click);
            // 
            // btnQualifiedOutlet
            // 
            this.btnQualifiedOutlet.BackColor = System.Drawing.Color.White;
            this.btnQualifiedOutlet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQualifiedOutlet.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQualifiedOutlet.Location = new System.Drawing.Point(9, 141);
            this.btnQualifiedOutlet.Margin = new System.Windows.Forms.Padding(2);
            this.btnQualifiedOutlet.Name = "btnQualifiedOutlet";
            this.btnQualifiedOutlet.Size = new System.Drawing.Size(186, 49);
            this.btnQualifiedOutlet.TabIndex = 1;
            this.btnQualifiedOutlet.Text = "Qualified Outlet";
            this.btnQualifiedOutlet.UseVisualStyleBackColor = false;
            this.btnQualifiedOutlet.Click += new System.EventHandler(this.btnQualifiedOutlet_Click);
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(206, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(2);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(908, 775);
            this.panelMain.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 775);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Incentive by Brownies Unlimited";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panelMain;
        public System.Windows.Forms.Button btnIncentive;
        public System.Windows.Forms.Button btnQualifiedOutlet;
        public System.Windows.Forms.Button btnEncodeVariance;
        public System.Windows.Forms.Button btnSCRF;
    }
}