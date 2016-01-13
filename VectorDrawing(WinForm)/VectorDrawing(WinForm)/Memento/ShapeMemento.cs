using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace VectorDrawing_WinForm_.Memento
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
    }
}
