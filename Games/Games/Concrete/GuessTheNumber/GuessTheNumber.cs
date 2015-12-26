using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Games.Abstract;

namespace Games.Concrete.GuessTheNumber
{
    public partial class GuessTheNumber : Form, IGame
    {
        private Player1 _player1;
        private Player2 _player2;
        private int _currentNum;
        private int _tries = 3;

        public GuessTheNumber()
        {
            InitializeComponent();

            cmb_players.DataSource = new List<string> { "Player vs Player", "Player vs CPU" };
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            _player1 = new Player1(this);
            _player1.Show();
            _player2 = new Player2(cmb_players.Text, this);
            _player2.Show();
        }

        public void SetCurrent(int num)
        {
            _currentNum = num;
        }

        public string CheckResult(int num)
        {
            if (num == _currentNum)
            {
                MessageBox.Show(@"You Win!!!", @"Guess The Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }
            else
            {
                --_tries;
                if (_tries > 0) return $"You have left {_tries} tries";
                MessageBox.Show(@"You Loose!!!", @"Guess The Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }

            return $"You have left {_tries} tries";
        }
    }
}
