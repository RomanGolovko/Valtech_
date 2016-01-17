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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(541, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttcmbx_color});
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.colorToolStripMenuItem.Text = "Color";
            // 
            // ttcmbx_color
            // 
            this.ttcmbx_color.Name = "ttcmbx_color";
            this.ttcmbx_color.Size = new System.Drawing.Size(121, 23);
            this.ttcmbx_color.SelectedIndexChanged += new System.EventHandler(this.cmbx_SelectedIndexChanged);
            // 
            // widthToolStripMenuItem
            // 
            this.widthToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttcmbx_width});
            this.widthToolStripMenuItem.Name = "widthToolStripMenuItem";
            this.widthToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.widthToolStripMenuItem.Text = "Width";
            // 
            // ttcmbx_width
            // 
            this.ttcmbx_width.Name = "ttcmbx_width";
            this.ttcmbx_width.Size = new System.Drawing.Size(121, 23);
            this.ttcmbx_width.SelectedIndexChanged += new System.EventHandler(this.cmbx_SelectedIndexChanged);
            // 
            // typeToolStripMenuItem
            // 
            this.typeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttcmd_type});
            this.typeToolStripMenuItem.Name = "typeToolStripMenuItem";
            this.typeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.typeToolStripMenuItem.Text = "Type";
            // 
            // ttcmd_type
            // 
            this.ttcmd_type.Name = "ttcmd_type";
            this.ttcmd_type.Size = new System.Drawing.Size(121, 23);
            this.ttcmd_type.SelectedIndexChanged += new System.EventHandler(this.cmbx_SelectedIndexChanged);
            // 
            // tabsToolStripMenuItem
            // 
            this.tabsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttcmbx_tabs});
            this.tabsToolStripMenuItem.Name = "tabsToolStripMenuItem";
            this.tabsToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.tabsToolStripMenuItem.Text = "Tabs";
            // 
            // ttcmbx_tabs
            // 
            this.ttcmbx_tabs.Name = "ttcmbx_tabs";
            this.ttcmbx_tabs.Size = new System.Drawing.Size(121, 23);
            this.ttcmbx_tabs.SelectedIndexChanged += new System.EventHandler(this.cmbx_SelectedIndexChanged);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
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
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(541, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // lbl_color
            // 
            this.lbl_color.Name = "lbl_color";
            this.lbl_color.Size = new System.Drawing.Size(35, 22);
            this.lbl_color.Text = "Black";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // lbl_width
            // 
            this.lbl_width.Name = "lbl_width";
            this.lbl_width.Size = new System.Drawing.Size(13, 22);
            this.lbl_width.Text = "1";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // lbl_type
            // 
            this.lbl_type.Name = "lbl_type";
            this.lbl_type.Size = new System.Drawing.Size(59, 22);
            this.lbl_type.Text = "Rectangle";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // lbl_tabs
            // 
            this.lbl_tabs.Name = "lbl_tabs";
            this.lbl_tabs.Size = new System.Drawing.Size(31, 22);
            this.lbl_tabs.Text = "Tabs";
            // 
            // tbcntrl_canvas
            // 
            this.tbcntrl_canvas.Controls.Add(this.tbpg_1);
            this.tbcntrl_canvas.Controls.Add(this.tbpg_2);
            this.tbcntrl_canvas.Location = new System.Drawing.Point(112, 46);
            this.tbcntrl_canvas.Margin = new System.Windows.Forms.Padding(2);
            this.tbcntrl_canvas.Name = "tbcntrl_canvas";
            this.tbcntrl_canvas.SelectedIndex = 0;
            this.tbcntrl_canvas.Size = new System.Drawing.Size(420, 360);
            this.tbcntrl_canvas.TabIndex = 2;
            this.tbcntrl_canvas.SelectedIndexChanged += new System.EventHandler(this.tbcntrl_canvas_SelectedIndexChanged);
            // 
            // tbpg_1
            // 
            this.tbpg_1.Controls.Add(this.pctbx_canvas1);
            this.tbpg_1.Location = new System.Drawing.Point(4, 22);
            this.tbpg_1.Margin = new System.Windows.Forms.Padding(2);
            this.tbpg_1.Name = "tbpg_1";
            this.tbpg_1.Padding = new System.Windows.Forms.Padding(2);
            this.tbpg_1.Size = new System.Drawing.Size(412, 334);
            this.tbpg_1.TabIndex = 0;
            this.tbpg_1.Text = "Canvas 1";
            this.tbpg_1.UseVisualStyleBackColor = true;
            // 
            // pctbx_canvas1
            // 
            this.pctbx_canvas1.Location = new System.Drawing.Point(5, 6);
            this.pctbx_canvas1.Margin = new System.Windows.Forms.Padding(2);
            this.pctbx_canvas1.Name = "pctbx_canvas1";
            this.pctbx_canvas1.Size = new System.Drawing.Size(404, 326);
            this.pctbx_canvas1.TabIndex = 0;
            this.pctbx_canvas1.TabStop = false;
            this.pctbx_canvas1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pctbx_canvas_MouseClick);
            // 
            // tbpg_2
            // 
            this.tbpg_2.Controls.Add(this.pctbx_canvas2);
            this.tbpg_2.Location = new System.Drawing.Point(4, 22);
            this.tbpg_2.Margin = new System.Windows.Forms.Padding(2);
            this.tbpg_2.Name = "tbpg_2";
            this.tbpg_2.Padding = new System.Windows.Forms.Padding(2);
            this.tbpg_2.Size = new System.Drawing.Size(412, 334);
            this.tbpg_2.TabIndex = 1;
            this.tbpg_2.Text = "Canvas 2";
            this.tbpg_2.UseVisualStyleBackColor = true;
            // 
            // pctbx_canvas2
            // 
            this.pctbx_canvas2.Location = new System.Drawing.Point(5, 6);
            this.pctbx_canvas2.Margin = new System.Windows.Forms.Padding(2);
            this.pctbx_canvas2.Name = "pctbx_canvas2";
            this.pctbx_canvas2.Size = new System.Drawing.Size(404, 326);
            this.pctbx_canvas2.TabIndex = 0;
            this.pctbx_canvas2.TabStop = false;
            this.pctbx_canvas2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pctbx_canvas_MouseClick);
            // 
            // grbx_color
            // 
            this.grbx_color.Controls.Add(this.cmbx_color);
            this.grbx_color.Location = new System.Drawing.Point(10, 67);
            this.grbx_color.Margin = new System.Windows.Forms.Padding(2);
            this.grbx_color.Name = "grbx_color";
            this.grbx_color.Padding = new System.Windows.Forms.Padding(2);
            this.grbx_color.Size = new System.Drawing.Size(100, 81);
            this.grbx_color.TabIndex = 3;
            this.grbx_color.TabStop = false;
            this.grbx_color.Text = "Color";
            // 
            // cmbx_color
            // 
            this.cmbx_color.FormattingEnabled = true;
            this.cmbx_color.Location = new System.Drawing.Point(5, 32);
            this.cmbx_color.Margin = new System.Windows.Forms.Padding(2);
            this.cmbx_color.Name = "cmbx_color";
            this.cmbx_color.Size = new System.Drawing.Size(92, 21);
            this.cmbx_color.TabIndex = 0;
            // 
            // grbx_width
            // 
            this.grbx_width.Controls.Add(this.nmr_width);
            this.grbx_width.Location = new System.Drawing.Point(10, 153);
            this.grbx_width.Margin = new System.Windows.Forms.Padding(2);
            this.grbx_width.Name = "grbx_width";
            this.grbx_width.Padding = new System.Windows.Forms.Padding(2);
            this.grbx_width.Size = new System.Drawing.Size(100, 81);
            this.grbx_width.TabIndex = 4;
            this.grbx_width.TabStop = false;
            this.grbx_width.Text = "Width";
            // 
            // nmr_width
            // 
            this.nmr_width.Location = new System.Drawing.Point(5, 32);
            this.nmr_width.Margin = new System.Windows.Forms.Padding(2);
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
            this.nmr_width.Size = new System.Drawing.Size(90, 20);
            this.nmr_width.TabIndex = 0;
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
            this.grbx_type.Location = new System.Drawing.Point(10, 239);
            this.grbx_type.Margin = new System.Windows.Forms.Padding(2);
            this.grbx_type.Name = "grbx_type";
            this.grbx_type.Padding = new System.Windows.Forms.Padding(2);
            this.grbx_type.Size = new System.Drawing.Size(100, 81);
            this.grbx_type.TabIndex = 4;
            this.grbx_type.TabStop = false;
            this.grbx_type.Text = "Type";
            // 
            // cmbx_type
            // 
            this.cmbx_type.FormattingEnabled = true;
            this.cmbx_type.Location = new System.Drawing.Point(5, 32);
            this.cmbx_type.Margin = new System.Windows.Forms.Padding(2);
            this.cmbx_type.Name = "cmbx_type";
            this.cmbx_type.Size = new System.Drawing.Size(92, 21);
            this.cmbx_type.TabIndex = 0;
            // 
            // grbx_coord
            // 
            this.grbx_coord.Location = new System.Drawing.Point(10, 325);
            this.grbx_coord.Margin = new System.Windows.Forms.Padding(2);
            this.grbx_coord.Name = "grbx_coord";
            this.grbx_coord.Padding = new System.Windows.Forms.Padding(2);
            this.grbx_coord.Size = new System.Drawing.Size(100, 81);
            this.grbx_coord.TabIndex = 5;
            this.grbx_coord.TabStop = false;
            this.grbx_coord.Text = "Coordinates";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 418);
            this.Controls.Add(this.grbx_coord);
            this.Controls.Add(this.grbx_type);
            this.Controls.Add(this.grbx_width);
            this.Controls.Add(this.grbx_color);
            this.Controls.Add(this.tbcntrl_canvas);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.Text = "Drawing";
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
    }
}

