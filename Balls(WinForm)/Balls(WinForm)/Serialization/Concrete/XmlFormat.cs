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
        private readonly XmlSerializer _formatter = new XmlSerializer(typeof(List<Ball>));

        public void Save(List<Ball> state)
        {
            using (var fs = new FileStream(@"C:\balls(XML).xml", FileMode.OpenOrCreate))
            {
                _formatter.Serialize(fs, state);
                MessageBox.Show(@"Balls state saved", @"Balls", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public List<Ball> Load()
        {
            using (var fs = new FileStream(@"C:\balls(XML).xml", FileMode.OpenOrCreate))
            {
                try
                {
                    return (List<Ball>)_formatter.Deserialize(fs);
                }
                catch (Exception)
                {
                    throw new SerializationException();
                }
            }
        }
    }
}
