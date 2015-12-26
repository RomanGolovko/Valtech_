namespace Games.Concrete.TicTacToe
{
    partial class TicTacToeGame
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
            this.btn_play = new System.Windows.Forms.Button();
            this.cmb_players = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_play
            // 
            this.btn_play.Location = new System.Drawing.Point(12, 143);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(378, 23);
            this.btn_play.TabIndex = 3;
            this.btn_play.Text = "Play";
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // cmb_players
            // 
            this.cmb_players.FormattingEnabled = true;
            this.cmb_players.Location = new System.Drawing.Point(12, 12);
            this.cmb_players.Name = "cmb_players";
            this.cmb_players.Size = new System.Drawing.Size(378, 24);
            this.cmb_players.TabIndex = 2;
            // 
            // TicTacToeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 191);
            this.Controls.Add(this.btn_play);
            this.Controls.Add(this.cmb_players);
            this.Name = "TicTacToeGame";
            this.Text = "TicTacToeGame";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.ComboBox cmb_players;
    }
}