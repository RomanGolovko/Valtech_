using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;
using VectorDrawing_WinForm_.Serialization.Abstract;
using VectorDrawing_WinForm_.Serialization.Memento;

namespace VectorDrawing_WinForm_.Serialization.Concrete
{
    public class JsonFormat : IFormat
    {
        private readonly DataContractJsonSerializer _formatter = new DataContractJsonSerializer(typeof(List<ShapeMemento>));

        public void Save(string path, List<ShapeMemento> state)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                _formatter.WriteObject(fs, state);
                MessageBox.Show(@"Balls state saved", @"Balls", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public IEnumerable<ShapeMemento> Load(string path)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                try
                {
                    return (List<ShapeMemento>)_formatter.ReadObject(fs);
                }
                catch (Exception)
                {
                    throw new SerializationException();
                }
            }
        }
    }
}
