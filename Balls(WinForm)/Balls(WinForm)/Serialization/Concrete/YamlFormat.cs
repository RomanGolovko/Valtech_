using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Yaml.Serialization;
using Balls_WinForm_.Serialization.Abstract;

namespace Balls_WinForm_.Serialization.Concrete
{
    public class YamlFormat : IFormat
    {
        private readonly YamlSerializer _formatter = new YamlSerializer();

        public void Save(List<Ball> state)
        {
            using (var fs = new FileStream(@"C:\balls(YAML).yaml", FileMode.OpenOrCreate))
            {
                _formatter.Serialize(fs, state);
                MessageBox.Show(@"Balls state saved", @"Balls", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public List<Ball> Load()
        {
            using (var fs = new FileStream(@"C:\balls(YAML).yaml", FileMode.OpenOrCreate))
            {
                try
                {
                    return (List<Ball>)_formatter.Deserialize(fs)[0];
                }
                catch (Exception)
                {
                    throw new SerializationException();
                }
            }
        }
    }
}
