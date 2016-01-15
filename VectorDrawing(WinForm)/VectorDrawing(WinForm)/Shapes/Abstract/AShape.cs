using System.Drawing;
using System.Windows.Forms;
using VectorDrawing_WinForm_.Util;

namespace VectorDrawing_WinForm_.Shapes.Abstract
{
    public abstract class AShape : Control
    {
        public XData Data { get; set; }
        public Form Main { get; set; }
        public Color Color { get; set; }
        public int LineWidth { get; set; }
        public bool IsPresed { get; set; }

        public abstract void RedrawShape(XData data);

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Left)
            {
                Focus();
                Data.GetData(Main);
            }
            else if (e.Button == MouseButtons.Right)
            {
                var cms_shapeMenu = new ContextMenuStrip();
                ToolStripMenuItem some = new ToolStripMenuItem("Hello");
                cms_shapeMenu.Items.Add(some);
                this.ContextMenuStrip = cms_shapeMenu;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            IsPresed = true;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            IsPresed = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (IsPresed)
            {
                Top = e.X - Top;
                Left = e.Y - Left;
            }
            
        }
    }
}
