using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Games.Abstract;
using Games.Concrete.GuessTheNumber;
using Games.Concrete.TicTacToe;

namespace Games
{
    public partial class Main : Form
    {
        private IGame _game;
        public Main()
        {
            InitializeComponent();
            cmb_games.DataSource = new List<string> { "TicTacToe", "Guess The Number" };
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            
            switch (cmb_games.Text)
            {
                case "TicTacToe":
                    _game = new TicTacToeGame();
                    Run();
                    break;
                case "Guess The Number":
                    _game = new GuessTheNumber();
                    Run();
                    break;
                default:
                    break;
            }
        }

        private void Run()
        {
            _game.ShowDialog();
        }
    }
}
