using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GameProcess;
using Games.Abstract;

namespace Games.Concrete.TicTacToe
{
    public partial class TicTacToeGame : Form, IGame
    {
        private readonly TicTacToeRules _game;
        private Player1 _player1Field;
        private Player2 _player2Field;

        public TicTacToeGame()
        {
            InitializeComponent();

            _game = new TicTacToeRules();
            cmb_players.DataSource = new List<string> { "Player vs Player", "Player vs CPU" };
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            _player2Field = new Player2(this);
            _player2Field.Show();
            _player1Field = new Player1(this);
            _player1Field.Show();
            ChooseMove(2);
        }

        private void ChooseMove(int playerNumber)
        {
            switch (playerNumber)
            {
                case 1:
                    _player1Field.Enabled = false;
                    _player2Field.Enabled = true;

                    if (cmb_players.Text == @"Player vs CPU")
                    {
                        _player2Field.CPUMove();
                    }
                    break;
                case 2:
                    _player1Field.Enabled = true;
                    _player2Field.Enabled = false;
                    break;
            }
        }

        public void CheckResult(Button[] buttons, int playerNumber)
        {
            var strButtons = new[] { buttons[0].Text, buttons[1].Text, buttons[2].Text, buttons[3].Text,
                buttons[4].Text, buttons[5].Text, buttons[6].Text, buttons[7].Text, buttons[8].Text };
            var result = _game.Win(strButtons);

            if (result != string.Empty)
            {
                MessageBox.Show(result, @"TicTacToe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }

            _player2Field.Buttons = _player1Field.Buttons;

            for (var i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Text != "")
                {
                    _player1Field.Buttons[i].Text = buttons[i].Text;
                    _player1Field.Buttons[i].Enabled = buttons[i].Enabled;
                    _player2Field.Buttons[i].Text = _player1Field.Buttons[i].Text;
                    _player2Field.Buttons[i].Enabled = _player1Field.Buttons[i].Enabled;
                }
            }

            ChooseMove(playerNumber);
        }
    }
}
