using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using VectorDrawing_WinForm_.Factory;
using VectorDrawing_WinForm_.Shapes.Abstract;
using VectorDrawing_WinForm_.Shapes.Concrete;

namespace VectorDrawing_WinForm_.Memento
{
    [Serializable]
    [DataContract]                                      // for json serialization
    public class PctbxMemento
    {
        [DataMember]                                    // for json serialization
        public List<ShapeMemento> Shapes { get; set; }  // public for xml serialization

        public PctbxMemento() { }                       // for xml serialization

        public PctbxMemento(List<AShape> shapes)
        {
            Shapes = new List<ShapeMemento>();

            foreach (var shape in shapes)
            {
                var shapeMemento = new ShapeMemento
                {
                    X = shape.Top,
                    Y = shape.Left,
                    Width = shape.Width,
                    Height = shape.Height,
                    Color = shape.Color,
                    LineWidth = shape.LineWidth
                };

                if (shape is Rectangle)
                {
                    shapeMemento.Type = "Rectangle";
                }
                else if (shape is Ellipse)
                {
                    shapeMemento.Type = "Ellipse";
                }
                else if (shape is Line)
                {
                    shapeMemento.Type = "Line";
                }

                Shapes.Add(shapeMemento);
            }
        }

        public static List<AShape> RestoreState(int ext, string format)
        {
            var shapesMemento = SwitchFactory.SelectSerializationFormat(ext).Load(format);

            var shapes = new List<AShape>();

            foreach (var shapeMemento in shapesMemento)
            {
                AShape shape = null;
                if (shapeMemento.Type == "Rectangle")
                {
                    shape = new Rectangle(null, null, shapeMemento);
                }
                else if (shapeMemento.Type == "Ellipse")
                {
                    shape = new Ellipse(null, shapeMemento);
                }
                else if (shapeMemento.Type == "Line")
                {
                    shape = new Line(null, shapeMemento);
                }
                shapes.Add(shape);
            }

            return shapes;
        }

        public void SaveState(int ext, string format)
        {
            SwitchFactory.SelectSerializationFormat(ext).Save(format, Shapes);
        }
    }
}
