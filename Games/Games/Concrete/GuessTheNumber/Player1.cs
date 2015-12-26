using System;
using System.Windows.Forms;

namespace Games.Concrete.GuessTheNumber
{
    public partial class Player1 : Form
    {
        private readonly GuessTheNumber _game;
        public Player1(GuessTheNumber game)
        {
            InitializeComponent();
            _game = game;
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            int num;
            int.TryParse(txbx_estimatedNumber.Text, out num);
            if (num > 0)
            {
                lbl_message.Text = _game.CheckResult(num);
                txbx_estimatedNumber.Text = "";
            }
            else
            {
                MessageBox.Show(@"Wrong value!!!", @"Guess The Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
