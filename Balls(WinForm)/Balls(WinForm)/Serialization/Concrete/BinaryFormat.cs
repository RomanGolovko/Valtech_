using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Balls_WinForm_.Serialization.Abstract;

namespace Balls_WinForm_.Serialization.Concrete
{
    public class BinaryFormat : IFormat
    {
        private readonly BinaryFormatter _formatter = new BinaryFormatter();

        public void Save(List<Ball> state)
        {
            using (var fs = new FileStream(@"C:\balls(Binary).dat", FileMode.OpenOrCreate))
            {
                _formatter.Serialize(fs, state);
                MessageBox.Show(@"Balls state saved", @"Balls", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public List<Ball> Load()
        {
            using (var fs = new FileStream(@"C:\balls(Binary).dat", FileMode.OpenOrCreate))
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
