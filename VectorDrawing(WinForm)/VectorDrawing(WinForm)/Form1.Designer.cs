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
            this.tsmi_file = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_open = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_save = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_color = new System.Windows.Forms.ToolStripMenuItem();
            this.ttcmbx_color = new System.Windows.Forms.ToolStripComboBox();
            this.tsmi_lineWidth = new System.Windows.Forms.ToolStripMenuItem();
            this.ttcmbx_width = new System.Windows.Forms.ToolStripComboBox();
            this.tsmi_type = new System.Windows.Forms.ToolStripMenuItem();
            this.ttcmd_type = new System.Windows.Forms.ToolStripComboBox();
            this.tsmi_tabs = new System.Windows.Forms.ToolStripMenuItem();
            this.ttcmbx_tabs = new System.Windows.Forms.ToolStripComboBox();
            this.tsmi_settings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_lang = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_language = new System.Windows.Forms.ToolStripComboBox();
            this.tsmi_style = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_theme = new System.Windows.Forms.ToolStripComboBox();
            this.tsmi_about = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tsmi_file,
            this.tsmi_color,
            this.tsmi_lineWidth,
            this.tsmi_type,
            this.tsmi_tabs,
            this.tsmi_settings,
            this.tsmi_about});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // tsmi_file
            // 
            this.tsmi_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_open,
            this.tsmi_save,
            this.toolStripSeparator1,
            this.tsmi_exit});
            this.tsmi_file.Name = "tsmi_file";
            resources.ApplyResources(this.tsmi_file, "tsmi_file");
            // 
            // tsmi_open
            // 
            this.tsmi_open.Name = "tsmi_open";
            resources.ApplyResources(this.tsmi_open, "tsmi_open");
            this.tsmi_open.Click += new System.EventHandler(this.tsmi_open_Click);
            // 
            // tsmi_save
            // 
            this.tsmi_save.Name = "tsmi_save";
            resources.ApplyResources(this.tsmi_save, "tsmi_save");
            this.tsmi_save.Click += new System.EventHandler(this.tsmi_save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // tsmi_exit
            // 
            this.tsmi_exit.Name = "tsmi_exit";
            resources.ApplyResources(this.tsmi_exit, "tsmi_exit");
            this.tsmi_exit.Click += new System.EventHandler(this.tsmi_exit_Click);
            // 
            // tsmi_color
            // 
            this.tsmi_color.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttcmbx_color});
            this.tsmi_color.Name = "tsmi_color";
            resources.ApplyResources(this.tsmi_color, "tsmi_color");
            // 
            // ttcmbx_color
            // 
            this.ttcmbx_color.Name = "ttcmbx_color";
            resources.ApplyResources(this.ttcmbx_color, "ttcmbx_color");
            this.ttcmbx_color.SelectedIndexChanged += new System.EventHandler(this.cmbx_SelectedIndexChanged);
            // 
            // tsmi_lineWidth
            // 
            this.tsmi_lineWidth.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttcmbx_width});
            this.tsmi_lineWidth.Name = "tsmi_lineWidth";
            resources.ApplyResources(this.tsmi_lineWidth, "tsmi_lineWidth");
            // 
            // ttcmbx_width
            // 
            this.ttcmbx_width.Name = "ttcmbx_width";
            resources.ApplyResources(this.ttcmbx_width, "ttcmbx_width");
            this.ttcmbx_width.SelectedIndexChanged += new System.EventHandler(this.cmbx_SelectedIndexChanged);
            // 
            // tsmi_type
            // 
            this.tsmi_type.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttcmd_type});
            this.tsmi_type.Name = "tsmi_type";
            resources.ApplyResources(this.tsmi_type, "tsmi_type");
            // 
            // ttcmd_type
            // 
            this.ttcmd_type.Name = "ttcmd_type";
            resources.ApplyResources(this.ttcmd_type, "ttcmd_type");
            this.ttcmd_type.SelectedIndexChanged += new System.EventHandler(this.cmbx_SelectedIndexChanged);
            // 
            // tsmi_tabs
            // 
            this.tsmi_tabs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttcmbx_tabs});
            this.tsmi_tabs.Name = "tsmi_tabs";
            resources.ApplyResources(this.tsmi_tabs, "tsmi_tabs");
            // 
            // ttcmbx_tabs
            // 
            this.ttcmbx_tabs.Name = "ttcmbx_tabs";
            resources.ApplyResources(this.ttcmbx_tabs, "ttcmbx_tabs");
            this.ttcmbx_tabs.SelectedIndexChanged += new System.EventHandler(this.cmbx_SelectedIndexChanged);
            // 
            // tsmi_settings
            // 
            this.tsmi_settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_lang,
            this.tsmi_style});
            this.tsmi_settings.Name = "tsmi_settings";
            resources.ApplyResources(this.tsmi_settings, "tsmi_settings");
            // 
            // tsmi_lang
            // 
            this.tsmi_lang.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_language});
            this.tsmi_lang.Name = "tsmi_lang";
            resources.ApplyResources(this.tsmi_lang, "tsmi_lang");
            // 
            // tsmi_language
            // 
            this.tsmi_language.Name = "tsmi_language";
            resources.ApplyResources(this.tsmi_language, "tsmi_language");
            this.tsmi_language.SelectedIndexChanged += new System.EventHandler(this.tsmi_language_SelectedIndexChanged);
            // 
            // tsmi_style
            // 
            this.tsmi_style.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_theme});
            this.tsmi_style.Name = "tsmi_style";
            resources.ApplyResources(this.tsmi_style, "tsmi_style");
            // 
            // tsmi_theme
            // 
            this.tsmi_theme.Name = "tsmi_theme";
            resources.ApplyResources(this.tsmi_theme, "tsmi_theme");
            this.tsmi_theme.SelectedIndexChanged += new System.EventHandler(this.tsmi_theme_SelectedIndexChanged);
            // 
            // tsmi_about
            // 
            this.tsmi_about.Name = "tsmi_about";
            resources.ApplyResources(this.tsmi_about, "tsmi_about");
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
        private System.Windows.Forms.ToolStripMenuItem tsmi_file;
        private System.Windows.Forms.ToolStripMenuItem tsmi_open;
        private System.Windows.Forms.ToolStripMenuItem tsmi_save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_exit;
        private System.Windows.Forms.ToolStripMenuItem tsmi_color;
        private System.Windows.Forms.ToolStripComboBox ttcmbx_color;
        private System.Windows.Forms.ToolStripMenuItem tsmi_lineWidth;
        private System.Windows.Forms.ToolStripComboBox ttcmbx_width;
        private System.Windows.Forms.ToolStripMenuItem tsmi_type;
        private System.Windows.Forms.ToolStripComboBox ttcmd_type;
        private System.Windows.Forms.ToolStripMenuItem tsmi_tabs;
        private System.Windows.Forms.ToolStripComboBox ttcmbx_tabs;
        private System.Windows.Forms.ToolStripMenuItem tsmi_about;
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
        private System.Windows.Forms.ToolStripMenuItem tsmi_settings;
        private System.Windows.Forms.ToolStripMenuItem tsmi_lang;
        private System.Windows.Forms.ToolStripComboBox tsmi_language;
        private System.Windows.Forms.ToolStripMenuItem tsmi_style;
        private System.Windows.Forms.ToolStripComboBox tsmi_theme;
    }
}

