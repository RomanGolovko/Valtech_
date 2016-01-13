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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ttcmbx_color = new System.Windows.Forms.ToolStripComboBox();
            this.widthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ttcmbx_width = new System.Windows.Forms.ToolStripComboBox();
            this.ttcmbx_type = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox3 = new System.Windows.Forms.ToolStripComboBox();
            this.tabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ttcmbx_tabs = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lbl_color = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lbl_width = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lbl_type = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lbl_tabs = new System.Windows.Forms.ToolStripLabel();
            this.tbcntrl_canvas = new System.Windows.Forms.TabControl();
            this.tbpg_1 = new System.Windows.Forms.TabPage();
            this.tbpg_2 = new System.Windows.Forms.TabPage();
            this.grbx_color = new System.Windows.Forms.GroupBox();
            this.cmbx_color = new System.Windows.Forms.ComboBox();
            this.grbx_width = new System.Windows.Forms.GroupBox();
            this.nmr_width = new System.Windows.Forms.NumericUpDown();
            this.grbx_type = new System.Windows.Forms.GroupBox();
            this.cmbx_type = new System.Windows.Forms.ComboBox();
            this.grbx_coord = new System.Windows.Forms.GroupBox();
            this.pctbx_canvas1 = new System.Windows.Forms.PictureBox();
            this.pctbx_canvas2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tbcntrl_canvas.SuspendLayout();
            this.tbpg_1.SuspendLayout();
            this.tbpg_2.SuspendLayout();
            this.grbx_color.SuspendLayout();
            this.grbx_width.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_width)).BeginInit();
            this.grbx_type.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbx_canvas1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbx_canvas2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.colorToolStripMenuItem,
            this.widthToolStripMenuItem,
            this.ttcmbx_type,
            this.tabsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(721, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttcmbx_color});
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.colorToolStripMenuItem.Text = "Color";
            // 
            // ttcmbx_color
            // 
            this.ttcmbx_color.Name = "ttcmbx_color";
            this.ttcmbx_color.Size = new System.Drawing.Size(121, 28);
            // 
            // widthToolStripMenuItem
            // 
            this.widthToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttcmbx_width});
            this.widthToolStripMenuItem.Name = "widthToolStripMenuItem";
            this.widthToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.widthToolStripMenuItem.Text = "Width";
            // 
            // ttcmbx_width
            // 
            this.ttcmbx_width.Name = "ttcmbx_width";
            this.ttcmbx_width.Size = new System.Drawing.Size(121, 28);
            // 
            // ttcmbx_type
            // 
            this.ttcmbx_type.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox3});
            this.ttcmbx_type.Name = "ttcmbx_type";
            this.ttcmbx_type.Size = new System.Drawing.Size(53, 24);
            this.ttcmbx_type.Text = "Type";
            // 
            // toolStripComboBox3
            // 
            this.toolStripComboBox3.Name = "toolStripComboBox3";
            this.toolStripComboBox3.Size = new System.Drawing.Size(121, 28);
            // 
            // tabsToolStripMenuItem
            // 
            this.tabsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttcmbx_tabs});
            this.tabsToolStripMenuItem.Name = "tabsToolStripMenuItem";
            this.tabsToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.tabsToolStripMenuItem.Text = "Tabs";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // ttcmbx_tabs
            // 
            this.ttcmbx_tabs.Name = "ttcmbx_tabs";
            this.ttcmbx_tabs.Size = new System.Drawing.Size(121, 28);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_color,
            this.toolStripSeparator2,
            this.lbl_width,
            this.toolStripSeparator3,
            this.lbl_type,
            this.toolStripSeparator4,
            this.lbl_tabs});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(721, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lbl_color
            // 
            this.lbl_color.Name = "lbl_color";
            this.lbl_color.Size = new System.Drawing.Size(45, 22);
            this.lbl_color.Text = "Color";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // lbl_width
            // 
            this.lbl_width.Name = "lbl_width";
            this.lbl_width.Size = new System.Drawing.Size(49, 22);
            this.lbl_width.Text = "Width";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // lbl_type
            // 
            this.lbl_type.Name = "lbl_type";
            this.lbl_type.Size = new System.Drawing.Size(41, 22);
            this.lbl_type.Text = "Type";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // lbl_tabs
            // 
            this.lbl_tabs.Name = "lbl_tabs";
            this.lbl_tabs.Size = new System.Drawing.Size(40, 22);
            this.lbl_tabs.Text = "Tabs";
            // 
            // tbcntrl_canvas
            // 
            this.tbcntrl_canvas.Controls.Add(this.tbpg_1);
            this.tbcntrl_canvas.Controls.Add(this.tbpg_2);
            this.tbcntrl_canvas.Location = new System.Drawing.Point(149, 57);
            this.tbcntrl_canvas.Name = "tbcntrl_canvas";
            this.tbcntrl_canvas.SelectedIndex = 0;
            this.tbcntrl_canvas.Size = new System.Drawing.Size(560, 443);
            this.tbcntrl_canvas.TabIndex = 2;
            this.tbcntrl_canvas.SelectedIndexChanged += new System.EventHandler(this.tbcntrl_canvas_SelectedIndexChanged);
            // 
            // tbpg_1
            // 
            this.tbpg_1.Controls.Add(this.pctbx_canvas1);
            this.tbpg_1.Location = new System.Drawing.Point(4, 25);
            this.tbpg_1.Name = "tbpg_1";
            this.tbpg_1.Padding = new System.Windows.Forms.Padding(3);
            this.tbpg_1.Size = new System.Drawing.Size(552, 414);
            this.tbpg_1.TabIndex = 0;
            this.tbpg_1.Text = "Canvas 1";
            this.tbpg_1.UseVisualStyleBackColor = true;
            // 
            // tbpg_2
            // 
            this.tbpg_2.Controls.Add(this.pctbx_canvas2);
            this.tbpg_2.Location = new System.Drawing.Point(4, 25);
            this.tbpg_2.Name = "tbpg_2";
            this.tbpg_2.Padding = new System.Windows.Forms.Padding(3);
            this.tbpg_2.Size = new System.Drawing.Size(552, 414);
            this.tbpg_2.TabIndex = 1;
            this.tbpg_2.Text = "Canvas 2";
            this.tbpg_2.UseVisualStyleBackColor = true;
            // 
            // grbx_color
            // 
            this.grbx_color.Controls.Add(this.cmbx_color);
            this.grbx_color.Location = new System.Drawing.Point(13, 82);
            this.grbx_color.Name = "grbx_color";
            this.grbx_color.Size = new System.Drawing.Size(134, 100);
            this.grbx_color.TabIndex = 3;
            this.grbx_color.TabStop = false;
            this.grbx_color.Text = "Color";
            // 
            // cmbx_color
            // 
            this.cmbx_color.FormattingEnabled = true;
            this.cmbx_color.Location = new System.Drawing.Point(7, 39);
            this.cmbx_color.Name = "cmbx_color";
            this.cmbx_color.Size = new System.Drawing.Size(121, 24);
            this.cmbx_color.TabIndex = 0;
            // 
            // grbx_width
            // 
            this.grbx_width.Controls.Add(this.nmr_width);
            this.grbx_width.Location = new System.Drawing.Point(13, 188);
            this.grbx_width.Name = "grbx_width";
            this.grbx_width.Size = new System.Drawing.Size(134, 100);
            this.grbx_width.TabIndex = 4;
            this.grbx_width.TabStop = false;
            this.grbx_width.Text = "Width";
            // 
            // nmr_width
            // 
            this.nmr_width.Location = new System.Drawing.Point(7, 40);
            this.nmr_width.Name = "nmr_width";
            this.nmr_width.Size = new System.Drawing.Size(120, 22);
            this.nmr_width.TabIndex = 0;
            this.nmr_width.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // grbx_type
            // 
            this.grbx_type.Controls.Add(this.cmbx_type);
            this.grbx_type.Location = new System.Drawing.Point(13, 294);
            this.grbx_type.Name = "grbx_type";
            this.grbx_type.Size = new System.Drawing.Size(134, 100);
            this.grbx_type.TabIndex = 4;
            this.grbx_type.TabStop = false;
            this.grbx_type.Text = "Type";
            // 
            // cmbx_type
            // 
            this.cmbx_type.FormattingEnabled = true;
            this.cmbx_type.Location = new System.Drawing.Point(7, 39);
            this.cmbx_type.Name = "cmbx_type";
            this.cmbx_type.Size = new System.Drawing.Size(121, 24);
            this.cmbx_type.TabIndex = 0;
            // 
            // grbx_coord
            // 
            this.grbx_coord.Location = new System.Drawing.Point(13, 400);
            this.grbx_coord.Name = "grbx_coord";
            this.grbx_coord.Size = new System.Drawing.Size(134, 100);
            this.grbx_coord.TabIndex = 5;
            this.grbx_coord.TabStop = false;
            this.grbx_coord.Text = "Coordinates";
            // 
            // pctbx_canvas1
            // 
            this.pctbx_canvas1.Location = new System.Drawing.Point(7, 7);
            this.pctbx_canvas1.Name = "pctbx_canvas1";
            this.pctbx_canvas1.Size = new System.Drawing.Size(539, 401);
            this.pctbx_canvas1.TabIndex = 0;
            this.pctbx_canvas1.TabStop = false;
            // 
            // pctbx_canvas2
            // 
            this.pctbx_canvas2.Location = new System.Drawing.Point(7, 7);
            this.pctbx_canvas2.Name = "pctbx_canvas2";
            this.pctbx_canvas2.Size = new System.Drawing.Size(539, 401);
            this.pctbx_canvas2.TabIndex = 0;
            this.pctbx_canvas2.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 514);
            this.Controls.Add(this.grbx_coord);
            this.Controls.Add(this.grbx_type);
            this.Controls.Add(this.grbx_width);
            this.Controls.Add(this.grbx_color);
            this.Controls.Add(this.tbcntrl_canvas);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Drawing";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tbcntrl_canvas.ResumeLayout(false);
            this.tbpg_1.ResumeLayout(false);
            this.tbpg_2.ResumeLayout(false);
            this.grbx_color.ResumeLayout(false);
            this.grbx_width.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmr_width)).EndInit();
            this.grbx_type.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctbx_canvas1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbx_canvas2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox ttcmbx_color;
        private System.Windows.Forms.ToolStripMenuItem widthToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox ttcmbx_width;
        private System.Windows.Forms.ToolStripMenuItem ttcmbx_type;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox3;
        private System.Windows.Forms.ToolStripMenuItem tabsToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox ttcmbx_tabs;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
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

