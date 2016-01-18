using Drawing_WinForm_.Formats.Factories.ChainOfResponsibility;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Drawing_WinForm_
{
    public partial class Main : Form
    {
        private bool _isPresed;
        private int _x;
        private int _y;

        public Main()
        {
            InitializeComponent();
            cmbx_color.DataSource = new List<string> { "black", "green", "red" };
            pctbx_canvas.Image = new Bitmap(pctbx_canvas.Width, pctbx_canvas.Height);
        }

        private void pctbx_canvas_MouseDown(object sender, MouseEventArgs e)
        {
            _isPresed = true;
            _x = e.X;
            _y = e.Y;
        }

        private void pctbx_canvas_MouseUp(object sender, MouseEventArgs e)
        {
            _isPresed = false;
        }

        private void pctbx_canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isPresed) return;
            var color = ChooseColor();
            var size = (int)nmrc_size.Value;

            var graphics = Graphics.FromImage(pctbx_canvas.Image);
            graphics.DrawLine(new Pen(color, size), _x, _y, e.X, e.Y);
            pctbx_canvas.Invalidate();

            _x = e.X;
            _y = e.Y;
        }

        private Color ChooseColor()
        {
            var color = Color.Black;

            switch (cmbx_color.SelectedText)
            {
                case "black": color = Color.Black; break;
                case "green": color = Color.Green; break;
                case "red": color = Color.Red; break;
                default:
                    break;
            }

            return color;
        }

        private void btn_cleare_Click(object sender, System.EventArgs e)
        {
            pctbx_canvas.Image = new Bitmap(pctbx_canvas.Width, pctbx_canvas.Height);
        }

        private void btn_save_Click(object sender, System.EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = @"Bitmap files (*.bmp)|*.bmp|Image files (*.jpg)|*.jpg|PNG files (*.png)|*.png|" +
                         @"ICO files (*.ico)|*.ico|GIF files (*.gif)|*.gif|TIFF files (*.tiff)|*.tiff|" +
                         @"XPS files (*.xps)|*.xps|PDF files (*.pdf)|*.pdf|PSD files (*.psd)|*.psd"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;

            // Switch
            //FactorySwitch.ChooseFormat(saveFileDialog.FilterIndex).Save(saveFileDialog.FileName, pctbx_canvas.Image);

            // LinkedList
            //var factory = new FactoryLinked();
            //factory.GetFormat(saveFileDialog.FilterIndex).Save(saveFileDialog.FileName, pctbx_canvas.Image);

            // Loop
            var factory = new FactoryLoop();
            var formats = factory.GetValidFormats(saveFileDialog.FilterIndex);
            foreach (var item in formats)
            {
                item.Save(saveFileDialog.FileName, pctbx_canvas.Image);
            }
        }

        private void btn_load_Click(object sender, System.EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = @"Bitmap files (*.bmp)|*.bmp|Image files (*.jpg)|*.jpg|PNG files (*.png)|*.png|" +
                         @"ICO files (*.ico)|*.ico|GIF files (*.gif)|*.gif|TIFF files (*.tiff)|*.tiff|" +
                         @"XPS files (*.xps)|*.xps|PDF files (*.pdf)|*.pdf|PSD files (*.psd)|*.psd"
            };
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;

            // Switch
            //pctbx_canvas.Image = FactorySwitch.ChooseFormat(openFileDialog.FilterIndex).Load(openFileDialog.FileName);

            // LinkedList
            //var factory = new FactoryLinked();
            //pctbx_canvas.Image = factory.GetFormat(openFileDialog.FilterIndex).Load(openFileDialog.FileName);

            // Loop
            var factory = new FactoryLoop();
            var formats = factory.GetValidFormats(openFileDialog.FilterIndex);
            foreach (var item in formats)
            {
                pctbx_canvas.Image = item.Load(openFileDialog.FileName);
            }
        }
    }
}

