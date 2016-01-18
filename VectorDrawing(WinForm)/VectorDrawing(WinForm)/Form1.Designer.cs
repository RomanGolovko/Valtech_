namespace VectorDrawing_WinForm_
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_language = new System.Windows.Forms.ToolStripComboBox();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ttcmbx_color = new System.Windows.Forms.ToolStripComboBox();
            this.widthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ttcmbx_width = new System.Windows.Forms.ToolStripComboBox();
            this.typeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ttcmd_type = new System.Windows.Forms.ToolStripComboBox();
            this.tabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ttcmbx_tabs = new System.Windows.Forms.ToolStripComboBox();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.lbl_color = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lbl_width = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lbl_type = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lbl_tabs = new System.Windows.Forms.ToolStripLabel();
            this.tbcntrl_canvas = new System.Windows.Forms.TabControl();
            this.tbpg_1 = new System.Windows.Forms.TabPage();
            this.pctbx_canvas1 = new System.Windows.Forms.PictureBox();
            this.tbpg_2 = new System.Windows.Forms.TabPage();
            this.pctbx_canvas2 = new System.Windows.Forms.PictureBox();
            this.grbx_color = new System.Windows.Forms.GroupBox();
            this.cmbx_color = new System.Windows.Forms.ComboBox();
            this.grbx_width = new System.Windows.Forms.GroupBox();
            this.nmr_width = new System.Windows.Forms.NumericUpDown();
            this.grbx_type = new System.Windows.Forms.GroupBox();
            this.cmbx_type = new System.Windows.Forms.ComboBox();
            this.grbx_coord = new System.Windows.Forms.GroupBox();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.tbcntrl_canvas.SuspendLayout();
            this.tbpg_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbx_canvas1)).BeginInit();
            this.tbpg_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbx_canvas2)).BeginInit();
            this.grbx_color.SuspendLayout();
            this.grbx_width.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_width)).BeginInit();
            this.grbx_type.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.colorToolStripMenuItem,
            this.widthToolStripMenuItem,
            this.typeToolStripMenuItem,
            this.tabsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_language});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // tsmi_language
            // 
            this.tsmi_language.Name = "tsmi_language";
            resources.ApplyResources(this.tsmi_language, "tsmi_language");
            this.tsmi_language.SelectedIndexChanged += new System.EventHandler(this.tsmi_language_SelectedIndexChanged);
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttcmbx_color});
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            resources.ApplyResources(this.colorToolStripMenuItem, "colorToolStripMenuItem");
            // 
            // ttcmbx_color
            // 
            this.ttcmbx_color.Name = "ttcmbx_color";
            resources.ApplyResources(this.ttcmbx_color, "ttcmbx_color");
            this.ttcmbx_color.SelectedIndexChanged += new System.EventHandler(this.cmbx_SelectedIndexChanged);
            // 
            // widthToolStripMenuItem
            // 
            this.widthToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttcmbx_width});
            this.widthToolStripMenuItem.Name = "widthToolStripMenuItem";
            resources.ApplyResources(this.widthToolStripMenuItem, "widthToolStripMenuItem");
            // 
            // ttcmbx_width
            // 
            this.ttcmbx_width.Name = "ttcmbx_width";
            resources.ApplyResources(this.ttcmbx_width, "ttcmbx_width");
            this.ttcmbx_width.SelectedIndexChanged += new System.EventHandler(this.cmbx_SelectedIndexChanged);
            // 
            // typeToolStripMenuItem
            // 
            this.typeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttcmd_type});
            this.typeToolStripMenuItem.Name = "typeToolStripMenuItem";
            resources.ApplyResources(this.typeToolStripMenuItem, "typeToolStripMenuItem");
            // 
            // ttcmd_type
            // 
            this.ttcmd_type.Name = "ttcmd_type";
            resources.ApplyResources(this.ttcmd_type, "ttcmd_type");
            this.ttcmd_type.SelectedIndexChanged += new System.EventHandler(this.cmbx_SelectedIndexChanged);
            // 
            // tabsToolStripMenuItem
            // 
            this.tabsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttcmbx_tabs});
            this.tabsToolStripMenuItem.Name = "tabsToolStripMenuItem";
            resources.ApplyResources(this.tabsToolStripMenuItem, "tabsToolStripMenuItem");
            // 
            // ttcmbx_tabs
            // 
            this.ttcmbx_tabs.Name = "ttcmbx_tabs";
            resources.ApplyResources(this.ttcmbx_tabs, "ttcmbx_tabs");
            this.ttcmbx_tabs.SelectedIndexChanged += new System.EventHandler(this.cmbx_SelectedIndexChanged);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_color,
            this.toolStripSeparator2,
            this.lbl_width,
            this.toolStripSeparator3,
            this.lbl_type,
            this.toolStripSeparator4,
            this.lbl_tabs});
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Name = "toolStrip";
            // 
            // lbl_color
            // 
            this.lbl_color.Name = "lbl_color";
            resources.ApplyResources(this.lbl_color, "lbl_color");
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // lbl_width
            // 
            this.lbl_width.Name = "lbl_width";
            resources.ApplyResources(this.lbl_width, "lbl_width");
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // lbl_type
            // 
            this.lbl_type.Name = "lbl_type";
            resources.ApplyResources(this.lbl_type, "lbl_type");
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // lbl_tabs
            // 
            this.lbl_tabs.Name = "lbl_tabs";
            resources.ApplyResources(this.lbl_tabs, "lbl_tabs");
            // 
            // tbcntrl_canvas
            // 
            this.tbcntrl_canvas.Controls.Add(this.tbpg_1);
            this.tbcntrl_canvas.Controls.Add(this.tbpg_2);
            resources.ApplyResources(this.tbcntrl_canvas, "tbcntrl_canvas");
            this.tbcntrl_canvas.Name = "tbcntrl_canvas";
            this.tbcntrl_canvas.SelectedIndex = 0;
            this.tbcntrl_canvas.SelectedIndexChanged += new System.EventHandler(this.tbcntrl_canvas_SelectedIndexChanged);
            // 
            // tbpg_1
            // 
            this.tbpg_1.Controls.Add(this.pctbx_canvas1);
            resources.ApplyResources(this.tbpg_1, "tbpg_1");
            this.tbpg_1.Name = "tbpg_1";
            this.tbpg_1.UseVisualStyleBackColor = true;
            // 
            // pctbx_canvas1
            // 
            resources.ApplyResources(this.pctbx_canvas1, "pctbx_canvas1");
            this.pctbx_canvas1.Name = "pctbx_canvas1";
            this.pctbx_canvas1.TabStop = false;
            this.pctbx_canvas1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pctbx_canvas_MouseClick);
            // 
            // tbpg_2
            // 
            this.tbpg_2.Controls.Add(this.pctbx_canvas2);
            resources.ApplyResources(this.tbpg_2, "tbpg_2");
            this.tbpg_2.Name = "tbpg_2";
            this.tbpg_2.UseVisualStyleBackColor = true;
            // 
            // pctbx_canvas2
            // 
            resources.ApplyResources(this.pctbx_canvas2, "pctbx_canvas2");
            this.pctbx_canvas2.Name = "pctbx_canvas2";
            this.pctbx_canvas2.TabStop = false;
            this.pctbx_canvas2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pctbx_canvas_MouseClick);
            // 
            // grbx_color
            // 
            this.grbx_color.Controls.Add(this.cmbx_color);
            resources.ApplyResources(this.grbx_color, "grbx_color");
            this.grbx_color.Name = "grbx_color";
            this.grbx_color.TabStop = false;
            // 
            // cmbx_color
            // 
            this.cmbx_color.FormattingEnabled = true;
            resources.ApplyResources(this.cmbx_color, "cmbx_color");
            this.cmbx_color.Name = "cmbx_color";
            // 
            // grbx_width
            // 
            this.grbx_width.Controls.Add(this.nmr_width);
            resources.ApplyResources(this.grbx_width, "grbx_width");
            this.grbx_width.Name = "grbx_width";
            this.grbx_width.TabStop = false;
            // 
            // nmr_width
            // 
            resources.ApplyResources(this.nmr_width, "nmr_width");
            this.nmr_width.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmr_width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmr_width.Name = "nmr_width";
            this.nmr_width.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmr_width.ValueChanged += new System.EventHandler(this.nmr_width_ValueChanged);
            // 
            // grbx_type
            // 
            this.grbx_type.Controls.Add(this.cmbx_type);
            resources.ApplyResources(this.grbx_type, "grbx_type");
            this.grbx_type.Name = "grbx_type";
            this.grbx_type.TabStop = false;
            // 
            // cmbx_type
            // 
            this.cmbx_type.FormattingEnabled = true;
            resources.ApplyResources(this.cmbx_type, "cmbx_type");
            this.cmbx_type.Name = "cmbx_type";
            // 
            // grbx_coord
            // 
            resources.ApplyResources(this.grbx_coord, "grbx_coord");
            this.grbx_coord.Name = "grbx_coord";
            this.grbx_coord.TabStop = false;
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbx_coord);
            this.Controls.Add(this.grbx_type);
            this.Controls.Add(this.grbx_width);
            this.Controls.Add(this.grbx_color);
            this.Controls.Add(this.tbcntrl_canvas);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Main";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tbcntrl_canvas.ResumeLayout(false);
            this.tbpg_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctbx_canvas1)).EndInit();
            this.tbpg_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctbx_canvas2)).EndInit();
            this.grbx_color.ResumeLayout(false);
            this.grbx_width.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmr_width)).EndInit();
            this.grbx_type.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox ttcmbx_color;
        private System.Windows.Forms.ToolStripMenuItem widthToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox ttcmbx_width;
        private System.Windows.Forms.ToolStripMenuItem typeToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox ttcmd_type;
        private System.Windows.Forms.ToolStripMenuItem tabsToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox ttcmbx_tabs;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel lbl_color;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lbl_width;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel lbl_type;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel lbl_tabs;
        private System.Windows.Forms.TabControl tbcntrl_canvas;
        private System.Windows.Forms.TabPage tbpg_1;
        private System.Windows.Forms.TabPage tbpg_2;
        private System.Windows.Forms.GroupBox grbx_color;
        private System.Windows.Forms.ComboBox cmbx_color;
        private System.Windows.Forms.GroupBox grbx_width;
        private System.Windows.Forms.NumericUpDown nmr_width;
        private System.Windows.Forms.GroupBox grbx_type;
        private System.Windows.Forms.ComboBox cmbx_type;
        private System.Windows.Forms.GroupBox grbx_coord;
        private System.Windows.Forms.PictureBox pctbx_canvas1;
        private System.Windows.Forms.PictureBox pctbx_canvas2;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox tsmi_language;
    }
}

