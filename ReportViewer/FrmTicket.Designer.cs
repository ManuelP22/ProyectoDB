
namespace ProyectoDB.ReportViewer
{
    partial class FrmTicket
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CReportTicket = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CReportViajes1 = new ProyectoDB.ReportViewer.CReportViajes();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(800, 450);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // CReportTicket
            // 
            this.CReportTicket.ActiveViewIndex = 0;
            this.CReportTicket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CReportTicket.Cursor = System.Windows.Forms.Cursors.Default;
            this.CReportTicket.DisplayStatusBar = false;
            this.CReportTicket.DisplayToolbar = false;
            this.CReportTicket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CReportTicket.Location = new System.Drawing.Point(0, 0);
            this.CReportTicket.Name = "CReportTicket";
            this.CReportTicket.ReportSource = this.CReportViajes1;
            this.CReportTicket.Size = new System.Drawing.Size(800, 450);
            this.CReportTicket.TabIndex = 1;
            // 
            // FrmTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CReportTicket);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "FrmTicket";
            this.Text = "FrmTicket";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CReportViajes CReportViajes1;
        public CrystalDecisions.Windows.Forms.CrystalReportViewer CReportTicket;
    }
}