namespace Drawing_WinForm_
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
            this.pctbx_canvas = new System.Windows.Forms.PictureBox();
            this.cmbx_color = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nmrc_size = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pctbx_canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrc_size)).BeginInit();
            this.SuspendLayout();
            // 
            // pctbx_canvas
            // 
            this.pctbx_canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctbx_canvas.Location = new System.Drawing.Point(179, 12);
            this.pctbx_canvas.Name = "pctbx_canvas";
            this.pctbx_canvas.Size = new System.Drawing.Size(584, 504);
            this.pctbx_canvas.TabIndex = 0;
            this.pctbx_canvas.TabStop = false;
            this.pctbx_canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pctbx_canvas_MouseDown);
            this.pctbx_canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pctbx_canvas_MouseMove);
            this.pctbx_canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pctbx_canvas_MouseUp);
            // 
            // cmbx_color
            // 
            this.cmbx_color.FormattingEnabled = true;
            this.cmbx_color.Location = new System.Drawing.Point(13, 64);
            this.cmbx_color.Name = "cmbx_color";
            this.cmbx_color.Size = new System.Drawing.Size(121, 24);
            this.cmbx_color.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Color";
            // 
            // nmrc_size
            // 
            this.nmrc_size.Location = new System.Drawing.Point(16, 141);
            this.nmrc_size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrc_size.Name = "nmrc_size";
            this.nmrc_size.Size = new System.Drawing.Size(120, 22);
            this.nmrc_size.TabIndex = 3;
            this.nmrc_size.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Size";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 528);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nmrc_size);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbx_color);
            this.Controls.Add(this.pctbx_canvas);
            this.Name = "Main";
            this.Text = "Drawing";
            ((System.ComponentModel.ISupportInitialize)(this.pctbx_canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrc_size)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctbx_canvas;
        private System.Windows.Forms.ComboBox cmbx_color;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nmrc_size;
        private System.Windows.Forms.Label label2;
    }
}

