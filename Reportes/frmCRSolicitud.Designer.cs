
namespace RefugioAnimaLove.Reportes
{
    partial class frmCRSolicitud
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
            this.crview = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crview
            // 
            this.crview.ActiveViewIndex = -1;
            this.crview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crview.Cursor = System.Windows.Forms.Cursors.Default;
            this.crview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crview.Location = new System.Drawing.Point(0, 0);
            this.crview.Name = "crview";
            this.crview.Size = new System.Drawing.Size(1197, 687);
            this.crview.TabIndex = 0;
            // 
            // frmCRSolicitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 687);
            this.Controls.Add(this.crview);
            this.Name = "frmCRSolicitud";
            this.Text = "frmCRSolicitud";
            this.Load += new System.EventHandler(this.frmCRSolicitud_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crview;
    }
}