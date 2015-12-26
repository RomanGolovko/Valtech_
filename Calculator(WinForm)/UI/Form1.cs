using System;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class Main : Form
    {
        private readonly Calculator _calc = new Calculator();
        private int Num1 { get; set; }
        private int Num2 { get; set; }
        private string Action { get; set; }

        public Main()
        {
            InitializeComponent();
        }

        private void btn_Number_Click(object sender, EventArgs e)
        {
            txtbxResult.Text = ((Button)sender).Text;
        }

        private void btn_Action_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).Text)
            {
                case "=":
                    {
                        Num2 = int.Parse(txtbxResult.Text);
                        try
                        {
                            txtbxResult.Text = _calc.Calculate(Num1, Num2, char.Parse(Action)).ToString();
                        }
                        catch (DivideByZeroException)
                        {
                            MessageBox.Show("You can't devide by zero!!!", "Calculator",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtbxResult.Text = "";
                        }
                    }
                    break;
                case "C":
                    txtbxResult.Text = "";
                    break;
                default:
                    {
                        Num1 = int.Parse(txtbxResult.Text);
                        Action = ((Button)sender).Text;
                        txtbxResult.Text = "";
                     }
                    break;
            }
        }
    }
}
