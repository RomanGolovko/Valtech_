namespace GameProcess
{
    public class TicTacToeRules
    {
        public string Win(string[] buttons)
        {
            var result = string.Empty;

            if ((buttons[0] == "X" && buttons[1] == "X" && buttons[2] == "X") ||
                (buttons[3] == "X" && buttons[4] == "X" && buttons[5] == "X") ||
                (buttons[6] == "X" && buttons[7] == "X" && buttons[8] == "X") ||
                (buttons[0] == "X" && buttons[3] == "X" && buttons[6] == "X") ||
                (buttons[1] == "X" && buttons[4] == "X" && buttons[7] == "X") ||
                (buttons[2] == "X" && buttons[5] == "X" && buttons[8] == "X") ||
                (buttons[0] == "X" && buttons[4] == "X" && buttons[8] == "X") ||
                (buttons[2] == "X" && buttons[4] == "X" && buttons[6] == "X"))
            {
                result = "X Win!!!";
            }
            else if ((buttons[0] == "O" && buttons[1] == "O" && buttons[2] == "O") ||
                     (buttons[3] == "O" && buttons[4] == "O" && buttons[5] == "O") ||
                     (buttons[6] == "O" && buttons[7] == "O" && buttons[8] == "O") ||
                     (buttons[0] == "O" && buttons[3] == "O" && buttons[6] == "O") ||
                     (buttons[1] == "O" && buttons[4] == "O" && buttons[7] == "O") ||
                     (buttons[2] == "O" && buttons[5] == "O" && buttons[8] == "O") ||
                     (buttons[0] == "O" && buttons[4] == "O" && buttons[8] == "O") ||
                     (buttons[2] == "O" && buttons[4] == "O" && buttons[6] == "O"))
            {
                result = "O Win!!!";
            }
            else if ((buttons[0] != "" && buttons[1] != "" && buttons[2] != "" &&
                      buttons[3] != "" && buttons[4] != "" && buttons[5] != "" &&
                      buttons[6] != "" && buttons[7] != "" && buttons[8] != ""))
            {
                result = "Draw!!!";
            }

            return result;
        }
    }
}
