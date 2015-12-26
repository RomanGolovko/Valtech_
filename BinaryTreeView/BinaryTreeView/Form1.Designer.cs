namespace BinaryTreeView
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
            this.btn_draw = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_draw
            // 
            this.btn_draw.Location = new System.Drawing.Point(306, 473);
            this.btn_draw.Name = "btn_draw";
            this.btn_draw.Size = new System.Drawing.Size(262, 115);
            this.btn_draw.TabIndex = 0;
            this.btn_draw.Text = "Draw image";
            this.btn_draw.UseVisualStyleBackColor = true;
            this.btn_draw.Click += new System.EventHandler(this.btn_draw_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 653);
            this.Controls.Add(this.btn_draw);
            this.Name = "Main";
            this.Text = "Binary Tree View";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_draw;
    }
}

