using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using VectorDrawing_WinForm_.Memento;
using VectorDrawing_WinForm_.Serialization.Abstract;

namespace VectorDrawing_WinForm_.Serialization.Concrete
{
    public class BinaryFormat : IFormat
    {
        private readonly BinaryFormatter _formatter = new BinaryFormatter();

        public void Save(string path, List<ShapeMemento> state)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                _formatter.Serialize(fs, state);
                MessageBox.Show(@"Balls state saved", @"Balls", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public List<ShapeMemento> Load(string path)
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
