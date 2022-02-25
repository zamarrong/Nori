namespace Nori.Restaurante
{
    partial class frmRestaurante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRestaurante));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiNuevo = new DevExpress.XtraBars.BarButtonItem();
            this.bbiGuardar = new DevExpress.XtraBars.BarButtonItem();
            this.lblEstacion = new DevExpress.XtraBars.BarStaticItem();
            this.lblUsuario = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPageMesas = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupMesasArchivo = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.panelMesas = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonText = "SALIR";
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bbiNuevo,
            this.bbiGuardar,
            this.lblEstacion,
            this.lblUsuario});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 5;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageMesas});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbon.Size = new System.Drawing.Size(829, 83);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // bbiNuevo
            // 
            this.bbiNuevo.Caption = "Nuevo";
            this.bbiNuevo.Id = 1;
            this.bbiNuevo.ImageUri.Uri = "Add";
            this.bbiNuevo.Name = "bbiNuevo";
            this.bbiNuevo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNuevo_ItemClick);
            // 
            // bbiGuardar
            // 
            this.bbiGuardar.Caption = "Guardar";
            this.bbiGuardar.Id = 2;
            this.bbiGuardar.ImageUri.Uri = "Save";
            this.bbiGuardar.Name = "bbiGuardar";
            this.bbiGuardar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiGuardar_ItemClick);
            // 
            // lblEstacion
            // 
            this.lblEstacion.Caption = "Estación";
            this.lblEstacion.Id = 3;
            this.lblEstacion.Name = "lblEstacion";
            this.lblEstacion.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Caption = "Usuario";
            this.lblUsuario.Id = 4;
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ribbonPageMesas
            // 
            this.ribbonPageMesas.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupMesasArchivo});
            this.ribbonPageMesas.Name = "ribbonPageMesas";
            this.ribbonPageMesas.Text = "MESAS";
            // 
            // ribbonPageGroupMesasArchivo
            // 
            this.ribbonPageGroupMesasArchivo.ItemLinks.Add(this.bbiNuevo);
            this.ribbonPageGroupMesasArchivo.ItemLinks.Add(this.bbiGuardar);
            this.ribbonPageGroupMesasArchivo.Name = "ribbonPageGroupMesasArchivo";
            this.ribbonPageGroupMesasArchivo.Text = "Archivo";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.lblEstacion);
            this.ribbonStatusBar.ItemLinks.Add(this.lblUsuario, true);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 504);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(829, 21);
            // 
            // panelMesas
            // 
            this.panelMesas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMesas.Location = new System.Drawing.Point(0, 83);
            this.panelMesas.Name = "panelMesas";
            this.panelMesas.Size = new System.Drawing.Size(829, 421);
            this.panelMesas.TabIndex = 2;
            // 
            // frmRestaurante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 525);
            this.Controls.Add(this.panelMesas);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRestaurante";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Restaurante";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageMesas;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupMesasArchivo;
        private DevExpress.XtraBars.BarButtonItem bbiNuevo;
        private DevExpress.XtraBars.BarButtonItem bbiGuardar;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private System.Windows.Forms.Panel panelMesas;
        private DevExpress.XtraBars.BarStaticItem lblEstacion;
        private DevExpress.XtraBars.BarStaticItem lblUsuario;
    }
}