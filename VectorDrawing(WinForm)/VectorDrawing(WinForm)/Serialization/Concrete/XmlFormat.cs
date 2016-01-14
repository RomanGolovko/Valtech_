using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;
using VectorDrawing_WinForm_.Serialization.Abstract;
using VectorDrawing_WinForm_.Serialization.Memento;

namespace VectorDrawing_WinForm_.Serialization.Concrete
{
    public class XmlFormat : IFormat
    {
        private readonly XmlSerializer _formatter = new XmlSerializer(typeof(List<ShapeMemento>));

        public void Save(string path, List<ShapeMemento> state)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                _formatter.Serialize(fs, state);
                MessageBox.Show(@"Balls state saved", @"Balls", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public IEnumerable<ShapeMemento> Load(string path)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                try
                {
                    return (List<ShapeMemento>)_formatter.Deserialize(fs);
                }
                catch (Exception)
                {
                    throw new SerializationException();
                }
            }
        }
    }
}
