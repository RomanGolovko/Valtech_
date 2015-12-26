namespace Games
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
            this.cmb_games = new System.Windows.Forms.ComboBox();
            this.btn_select = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmb_games
            // 
            this.cmb_games.FormattingEnabled = true;
            this.cmb_games.Location = new System.Drawing.Point(12, 34);
            this.cmb_games.Name = "cmb_games";
            this.cmb_games.Size = new System.Drawing.Size(258, 24);
            this.cmb_games.TabIndex = 0;
            // 
            // btn_select
            // 
            this.btn_select.Location = new System.Drawing.Point(12, 149);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(258, 23);
            this.btn_select.TabIndex = 1;
            this.btn_select.Text = "Select";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.btn_select);
            this.Controls.Add(this.cmb_games);
            this.Name = "Main";
            this.Text = "Games";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_games;
        private System.Windows.Forms.Button btn_select;
    }
}

