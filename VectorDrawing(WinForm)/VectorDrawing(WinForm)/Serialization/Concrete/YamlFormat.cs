using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Yaml.Serialization;
using VectorDrawing_WinForm_.Memento;
using VectorDrawing_WinForm_.Serialization.Abstract;

namespace VectorDrawing_WinForm_.Serialization.Concrete
{
    public class YamlFormat : IFormat
    {
        private readonly YamlSerializer _formatter = new YamlSerializer();

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
                    return (List<ShapeMemento>)_formatter.Deserialize(fs)[0];
                }
                catch (Exception)
                {
                    throw new SerializationException();
                }
            }
        }
    }
}
