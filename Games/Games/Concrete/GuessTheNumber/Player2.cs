using System;
using System.Windows.Forms;

namespace Games.Concrete.GuessTheNumber
{
    public partial class Player2 : Form
    {
        private readonly GuessTheNumber _game;

        public Player2(string option, GuessTheNumber game)
        {
            InitializeComponent();

            _game = game;

            if (option == "Player vs CPU")
            {
                CPUGuess();
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            int num;
            int.TryParse(txbx_estimatedNumber.Text, out num);
            if (num > 0)
            {
                _game.SetCurrent(num);
                Close();
            }
            else
            {
                MessageBox.Show(@"Wrong value!!!", @"Guess The Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CPUGuess()
        {
            var random = new Random();
            var num = random.Next(1, 11);
            txbx_estimatedNumber.Text = num.ToString();
            btn_send.PerformClick();
        }
    }
}
