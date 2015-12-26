using System;
using System.Windows.Forms;

namespace Games.Concrete.TicTacToe
{
    public partial class Player1 : Form
    {
        private readonly TicTacToeGame _game;

        public Player1(TicTacToeGame game)
        {
            InitializeComponent();

            _game = game;
        }

        public Button[] Buttons { get; private set; }

        private void btn_Click(object sender, EventArgs e)
        {
            Player1Move(sender);
            Buttons = new[] { btn_1, btn_2, btn_3, btn_4, btn_5, btn_6, btn_7, btn_8, btn_9 };
            _game.CheckResult(Buttons, 1);
        }

        private void Player1Move(object sender)
        {
            var button = (Button)sender;
            button.Text = @"X";
            button.Enabled = false;
        }
    }
}
