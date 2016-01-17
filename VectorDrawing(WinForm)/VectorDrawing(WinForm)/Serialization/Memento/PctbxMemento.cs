using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Forms;
using VectorDrawing_WinForm_.Factories;
using VectorDrawing_WinForm_.Shapes;

namespace VectorDrawing_WinForm_.Serialization.Memento
{
    [Serializable]
    [DataContract]                                      // for json serialization
    public class PctbxMemento
    {
        [DataMember]                                    // for json serialization
        public List<ShapeMemento> Shapes { get; set; }  // public for xml serialization

        public PctbxMemento() { }                       // for xml serialization

        public PctbxMemento(IEnumerable<Shape> shapes)
        {
            Shapes = new List<ShapeMemento>();

            foreach (var shapeMemento in shapes.Select(shape => new ShapeMemento
            {
                X = shape.Left,
                Y = shape.Top,
                Width = shape.Width,
                Height = shape.Height,
                Color = shape.Color,
                LineWidth = shape.LineWidth,
                Type = shape.Type
            }))
            {
                Shapes.Add(shapeMemento);
            }
        }

        public static IEnumerable<Shape> RestoreState(int ext, string format)
        {
            var shapesMemento = FormatFactory.SelectSerializationFormat(ext).Load(format);
            var shapes = new List<Shape>();

            foreach (var shapeMemento in shapesMemento)
            {
                var data = new XData();
                data.SetData(shapeMemento.X, shapeMemento.Y, shapeMemento.Width, shapeMemento.Height,
                    shapeMemento.Color, shapeMemento.LineWidth, shapeMemento.Type);

                var shape = new Shape(data, data.Type);
                shapes.Add(shape);
            }

            return shapes;
        }

        public void SaveState(int ext, string format)
        {
            FormatFactory.SelectSerializationFormat(ext).Save(format, Shapes);
        }
    }
}
