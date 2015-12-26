namespace Games.Concrete.GuessTheNumber
{
    partial class Player1
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_send = new System.Windows.Forms.Button();
            this.txbx_estimatedNumber = new System.Windows.Forms.TextBox();
            this.lbl_message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Type estimated number from 1 to 10\r\n";
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(12, 178);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(237, 23);
            this.btn_send.TabIndex = 4;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // txbx_estimatedNumber
            // 
            this.txbx_estimatedNumber.Location = new System.Drawing.Point(12, 126);
            this.txbx_estimatedNumber.Name = "txbx_estimatedNumber";
            this.txbx_estimatedNumber.Size = new System.Drawing.Size(237, 22);
            this.txbx_estimatedNumber.TabIndex = 3;
            // 
            // lbl_message
            // 
            this.lbl_message.AutoSize = true;
            this.lbl_message.Location = new System.Drawing.Point(12, 63);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(0, 17);
            this.lbl_message.TabIndex = 6;
            // 
            // Player1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 224);
            this.Controls.Add(this.lbl_message);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.txbx_estimatedNumber);
            this.Name = "Player1";
            this.Text = "Player1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox txbx_estimatedNumber;
        private System.Windows.Forms.Label lbl_message;
    }
}