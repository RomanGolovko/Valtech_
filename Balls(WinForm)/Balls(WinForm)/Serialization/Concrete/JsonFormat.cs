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
        private readonly DataContractJsonSerializer _formatter = new DataContractJsonSerializer(typeof(List<BallMemento>));

        public void Save(string path, List<BallMemento> state)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                _formatter.WriteObject(fs, state);
                MessageBox.Show(@"Balls state saved", @"Balls", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public List<BallMemento> Load(string path)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                try
                {
                    return (List<BallMemento>)_formatter.ReadObject(fs);
                }
                catch (Exception)
                {
                    throw new SerializationException();
                }
            }
        }
    }
}
