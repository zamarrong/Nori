namespace Nori
{
    partial class frmAutorizacion
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutorizacion));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblComentario = new System.Windows.Forms.Label();
            this.txtComentario = new DevExpress.XtraEditors.MemoEdit();
            this.btnDenegar = new System.Windows.Forms.Button();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.btnAutorizar = new System.Windows.Forms.Button();
            this.lblAutorizacion = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtComentario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 1;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.Size = new System.Drawing.Size(492, 49);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.panelControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 49);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(492, 240);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.lblComentario);
            this.panelControl1.Controls.Add(this.txtComentario);
            this.panelControl1.Controls.Add(this.btnDenegar);
            this.panelControl1.Controls.Add(this.lblReferencia);
            this.panelControl1.Controls.Add(this.btnAutorizar);
            this.panelControl1.Controls.Add(this.lblAutorizacion);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(468, 216);
            this.panelControl1.TabIndex = 4;
            // 
            // lblComentario
            // 
            this.lblComentario.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblComentario.Location = new System.Drawing.Point(14, 81);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(438, 39);
            this.lblComentario.TabIndex = 20;
            this.lblComentario.Text = "Sin comentario";
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(17, 128);
            this.txtComentario.MenuManager = this.ribbonControl1;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtComentario.Size = new System.Drawing.Size(435, 35);
            this.txtComentario.TabIndex = 1;
            // 
            // btnDenegar
            // 
            this.btnDenegar.BackColor = System.Drawing.Color.Firebrick;
            this.btnDenegar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDenegar.FlatAppearance.BorderColor = System.Drawing.Color.Brown;
            this.btnDenegar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDenegar.ForeColor = System.Drawing.Color.White;
            this.btnDenegar.Location = new System.Drawing.Point(230, 172);
            this.btnDenegar.Name = "btnDenegar";
            this.btnDenegar.Size = new System.Drawing.Size(108, 27);
            this.btnDenegar.TabIndex = 0;
            this.btnDenegar.TabStop = false;
            this.btnDenegar.Text = "Denegar";
            this.btnDenegar.UseVisualStyleBackColor = false;
            this.btnDenegar.Click += new System.EventHandler(this.btnDenegar_Click);
            // 
            // lblReferencia
            // 
            this.lblReferencia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblReferencia.Location = new System.Drawing.Point(14, 32);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(438, 41);
            this.lblReferencia.TabIndex = 16;
            this.lblReferencia.Text = "Referencia";
            // 
            // btnAutorizar
            // 
            this.btnAutorizar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAutorizar.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnAutorizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutorizar.ForeColor = System.Drawing.Color.White;
            this.btnAutorizar.Location = new System.Drawing.Point(344, 172);
            this.btnAutorizar.Name = "btnAutorizar";
            this.btnAutorizar.Size = new System.Drawing.Size(108, 27);
            this.btnAutorizar.TabIndex = 0;
            this.btnAutorizar.TabStop = false;
            this.btnAutorizar.Text = "Autorizar";
            this.btnAutorizar.UseVisualStyleBackColor = false;
            this.btnAutorizar.Click += new System.EventHandler(this.btnAutorizar_Click);
            // 
            // lblAutorizacion
            // 
            this.lblAutorizacion.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutorizacion.Location = new System.Drawing.Point(17, 5);
            this.lblAutorizacion.Name = "lblAutorizacion";
            this.lblAutorizacion.Size = new System.Drawing.Size(103, 19);
            this.lblAutorizacion.TabIndex = 10;
            this.lblAutorizacion.Text = "Autorización";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(492, 240);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.panelControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(472, 220);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 5000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmAutorizacion
            // 
            this.AcceptButton = this.btnAutorizar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDenegar;
            this.ClientSize = new System.Drawing.Size(492, 289);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.DoubleBuffered = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAutorizacion";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autorización";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtComentario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.Button btnAutorizar;
        private DevExpress.XtraEditors.LabelControl lblAutorizacion;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.Button btnDenegar;
        private DevExpress.XtraEditors.MemoEdit txtComentario;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblComentario;
    }
}