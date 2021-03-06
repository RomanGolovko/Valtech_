﻿using System.Drawing;

namespace VectorDrawing_WinForm_.Shapes
{
    public class XData
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Color Color { get; set; }
        public string Type { get; set; }
        public int LineWidth { get; set; }
        public int TabIndex { get; set; }

        public XData SetData(int x, int y, int width, int height,
            Color color, int lineWidth, string type, int tabIndex)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Color = color;
            LineWidth = lineWidth;
            Type = type;
            TabIndex = tabIndex;

            return this;
        }
    }
}
