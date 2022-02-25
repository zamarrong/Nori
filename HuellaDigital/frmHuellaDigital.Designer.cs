namespace Nori.HuellaDigital
{
    partial class frmHuellaDigital
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
            System.Windows.Forms.Label StatusLabel;
            System.Windows.Forms.Label PromptLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHuellaDigital));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StatusLine = new System.Windows.Forms.Label();
            this.StatusText = new System.Windows.Forms.TextBox();
            this.Prompt = new System.Windows.Forms.TextBox();
            this.Picture = new System.Windows.Forms.PictureBox();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            StatusLabel = new System.Windows.Forms.Label();
            PromptLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new System.Drawing.Point(208, 41);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new System.Drawing.Size(44, 13);
            StatusLabel.TabIndex = 10;
            StatusLabel.Text = "Estado:";
            // 
            // PromptLabel
            // 
            PromptLabel.AutoSize = true;
            PromptLabel.Location = new System.Drawing.Point(208, 4);
            PromptLabel.Name = "PromptLabel";
            PromptLabel.Size = new System.Drawing.Size(39, 13);
            PromptLabel.TabIndex = 8;
            PromptLabel.Text = "Salida:";
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
            this.ribbonControl1.Size = new System.Drawing.Size(571, 54);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.panel1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 54);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(571, 287);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.StatusLine);
            this.panel1.Controls.Add(this.StatusText);
            this.panel1.Controls.Add(StatusLabel);
            this.panel1.Controls.Add(this.Prompt);
            this.panel1.Controls.Add(PromptLabel);
            this.panel1.Controls.Add(this.Picture);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 263);
            this.panel1.TabIndex = 4;
            // 
            // StatusLine
            // 
            this.StatusLine.AutoSize = true;
            this.StatusLine.Location = new System.Drawing.Point(11, 243);
            this.StatusLine.Name = "StatusLine";
            this.StatusLine.Size = new System.Drawing.Size(11, 13);
            this.StatusLine.TabIndex = 12;
            this.StatusLine.Text = "-";
            // 
            // StatusText
            // 
            this.StatusText.BackColor = System.Drawing.SystemColors.Window;
            this.StatusText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StatusText.Location = new System.Drawing.Point(211, 57);
            this.StatusText.Multiline = true;
            this.StatusText.Name = "StatusText";
            this.StatusText.ReadOnly = true;
            this.StatusText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.StatusText.Size = new System.Drawing.Size(326, 199);
            this.StatusText.TabIndex = 11;
            // 
            // Prompt
            // 
            this.Prompt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Prompt.Location = new System.Drawing.Point(211, 23);
            this.Prompt.Name = "Prompt";
            this.Prompt.ReadOnly = true;
            this.Prompt.Size = new System.Drawing.Size(326, 14);
            this.Prompt.TabIndex = 9;
            // 
            // Picture
            // 
            this.Picture.BackColor = System.Drawing.SystemColors.Window;
            this.Picture.Location = new System.Drawing.Point(14, 4);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(181, 235);
            this.Picture.TabIndex = 7;
            this.Picture.TabStop = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(571, 287);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.panel1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(551, 267);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frmHuellaDigital
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 341);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHuellaDigital";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Huella digital";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmHuellaDigital_FormClosed);
            this.Load += new System.EventHandler(this.frmHuellaDigital_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.Label StatusLine;
        private System.Windows.Forms.TextBox StatusText;
        private System.Windows.Forms.TextBox Prompt;
        private System.Windows.Forms.PictureBox Picture;
    }
}