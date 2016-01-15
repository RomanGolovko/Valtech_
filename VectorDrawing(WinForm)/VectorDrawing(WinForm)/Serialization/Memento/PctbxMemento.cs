using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Forms;
using VectorDrawing_WinForm_.Factories;
using VectorDrawing_WinForm_.Shapes.Abstract;
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
                    LineWidth = shape.LineWidth,
                    Type = shape.Type
                };

                Shapes.Add(shapeMemento);
            }
        }

        public static IEnumerable<AShape> RestoreState(int ext, Form main, string format)
        {
            var shapesMemento = SwitchFactory.SelectSerializationFormat(ext).Load(format);
            var shapes = new List<AShape>();

            foreach (var shapeMemento in shapesMemento)
            {
                var data = new XData();
                data.SetData(shapeMemento.X, shapeMemento.Y, shapeMemento.Width, shapeMemento.Height,
                    shapeMemento.Color, shapeMemento.LineWidth, shapeMemento.Type);

                var shape = ShapeFactory.GetShape(main, data);
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
