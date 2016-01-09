using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;
using Balls_WinForm_.Serialization.Abstract;

namespace Balls_WinForm_.Serialization.Concrete
{
    public class JsonFormat : IFormat
    {
        private readonly DataContractJsonSerializer _formatter = new DataContractJsonSerializer(typeof(List<Ball>));

        public void Save(List<Ball> state)
        {
            using (var fs = new FileStream(@"C:\balls(JSON).json", FileMode.OpenOrCreate))
            {
                _formatter.WriteObject(fs, state);
                MessageBox.Show(@"Balls state saved", @"Balls", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public List<Ball> Load()
        {
            using (var fs = new FileStream(@"C:\balls(JSON).json", FileMode.OpenOrCreate))
            {
                try
                {
                    return (List<Ball>)_formatter.ReadObject(fs);
                }
                catch (Exception)
                {
                    throw new SerializationException();
                }
            }
        }
    }
}
