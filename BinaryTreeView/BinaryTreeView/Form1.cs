using System;
using System.Drawing;
using System.Windows.Forms;
using BinaryTreeBLL;

namespace BinaryTreeView
{
    public partial class Main : Form
    {
        private readonly Node _current;
        private int _x;
        private int _y;
        private int _lineX;
        private int _lineY;
        public Main()
        {
            InitializeComponent();

            _x = 200;
            _y = 10;
            var tree = new BinaryTree();
            int[] array = { 5, 3, 7, 4, 6, 2, 8, 1 };
            tree.Init(array);
            _current = tree.Head;
        }

        private void btn_draw_Click(object sender, EventArgs e)
        {
            btn_draw.Hide();
            DrawTree();
        }

        private void DrawTree()
        {
            DrawTree(_current);
        }

        private void DrawTree(Node node)
        {
            var pen = new Pen(Color.Black);
            var graphics = CreateGraphics();


            if (node.Left != null)
            {
                _lineX = _x;
                _lineY = _y;

                _x =(node.Value <= 5)? _x / 2: _x / 2 + 30;
                _y += 50;
                DrawTree(node.Left);
                _x = (node.Value <= 5) ? _x*2 : (_x - 30)*2;
                _y -= 50;
            }

            if (node.Value == 5)
            {
                graphics.DrawLine(pen, 300, 60, _x, _y);
            }

            graphics.DrawLine(pen, _lineX, _lineY, _x, _y);
            graphics.DrawEllipse(pen, _x, _y, 15, 15);
            graphics.DrawString(node.Value.ToString(), new Font("Times New Roman", 12, FontStyle.Regular),
                SystemBrushes.ActiveCaptionText, _x, _y);

            if (node.Right != null)
            {
                _lineX = _x;
                _lineY = _y;

                _x += _x/2;
                _y += 50;
                DrawTree(node.Right);
                _x = _x / 3 * 2;
                _y -= 50;
            }
        }
    }
}
