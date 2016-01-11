using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;
using Balls_WinForm_.Serialization.Abstract;

namespace Balls_WinForm_.Serialization.Concrete
{
    public class XmlFormat : IFormat
    {
        private readonly XmlSerializer _formatter = new XmlSerializer(typeof(List<BallMemento>));

        public void Save(string path, List<BallMemento> state)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                _formatter.Serialize(fs, state);
                MessageBox.Show(@"Balls state saved", @"Balls", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public List<BallMemento> Load(string path)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                try
                {
                    return (List<BallMemento>)_formatter.Deserialize(fs);
                }
                catch (Exception)
                {
                    throw new SerializationException();
                }
            }
        }
    }
}
