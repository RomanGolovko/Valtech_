using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using VectorDrawing_WinForm_.Factories;
using VectorDrawing_WinForm_.Shapes.Abstract;
using VectorDrawing_WinForm_.Shapes.Concrete;
using VectorDrawing_WinForm_.Util;

namespace VectorDrawing_WinForm_.Serialization.Memento
{
    [Serializable]
    [DataContract]                                      // for json serialization
    public class PctbxMemento
    {
        [DataMember]                                    // for json serialization
        public List<ShapeMemento> Shapes { get; set; }  // public for xml serialization

        public PctbxMemento() { }                       // for xml serialization

        public PctbxMemento(IEnumerable<AShape> shapes)
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

        public static IEnumerable<AShape> RestoreState(int ext, string format)
        {
            var shapesMemento = SwitchFactory.SelectSerializationFormat(ext).Load(format);
            var shapes = new List<AShape>();

            foreach (var shapeMemento in shapesMemento)
            {
                var data = new XData();
                data.SetData(shapeMemento.X, shapeMemento.Y, shapeMemento.Width, shapeMemento.Height,
                    shapeMemento.Color, shapeMemento.LineWidth, shapeMemento.Type);

                var shape = ShapeFactory.GetShape(shapeMemento.Type, null, null, data);
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
