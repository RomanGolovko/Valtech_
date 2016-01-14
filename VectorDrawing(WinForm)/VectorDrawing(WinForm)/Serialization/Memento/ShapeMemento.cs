using System;
using System.Drawing;
using System.Runtime.Serialization;
using VectorDrawing_WinForm_.Util;

namespace VectorDrawing_WinForm_.Serialization.Memento
{
    [Serializable]
    [DataContract]                          // for json serialization
    public class ShapeMemento
    {
        [DataMember]                        // for json serialization
        public int X { get; set; }

        [DataMember]                        // for json serialization
        public int Y { get; set; }

        [DataMember]                        // for json serialization
        public int Width { get; set; }

        [DataMember]                        // for json serialization
        public int Height { get; set; }

        [DataMember]                        // for json serialization
        public Color Color { get; set; }

        [DataMember]                        // for json serialization
        public string Type { get; set; }

        [DataMember]                        // for json serialization
        public int LineWidth { get; set; }

        public void SetMemento(XData data)
        {
            X = data.X;
            Y = data.Y;
            Width = data.Width;
            Height = data.Height;
            Color = data.Color;
            LineWidth = data.LineWidth;
            Type = data.Type;
        }

        public ShapeMemento GetMemento()
        {
            return this;
        }
    }
}
