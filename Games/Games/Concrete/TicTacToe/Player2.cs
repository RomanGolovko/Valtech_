using System;
using System.Windows.Forms;

namespace Games.Concrete.TicTacToe
{
    public partial class Player2 : Form
    {
        private readonly TicTacToeGame _game;

        public Player2(TicTacToeGame game)
        {
            InitializeComponent();

            _game = game;
            Buttons = new[] { btn_1, btn_2, btn_3, btn_4, btn_5, btn_6, btn_7, btn_8, btn_9 };
        }

        public Button[] Buttons { get; set; }

        public void CPUMove()
        {
            var random = new Random();
            Button button;

            do
            {
                var btn = "btn_" + random.Next(1, 10);
                button = Controls[btn] as Button;
            } while (button.Text != string.Empty);

            button.PerformClick();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Player2Move(sender);
            Buttons = new[] { btn_1, btn_2, btn_3, btn_4, btn_5, btn_6, btn_7, btn_8, btn_9 };
            _game.CheckResult(Buttons, 2);
        }

        private void Player2Move(object sender)
        {
            var button = (Button)sender;
            button.Text = @"O";
            button.Enabled = false;
        }

        private void Player2Field_EnabledChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Buttons.Length; i++)
            {
                if (Buttons[i].Text == "") continue;
                var btn = "";
                btn = "btn_" + (i + 1);
                var button = Controls[btn] as Button;

                button.Text = Buttons[i].Text;
                button.Enabled = Buttons[i].Enabled;
            }
        }
    }
}
