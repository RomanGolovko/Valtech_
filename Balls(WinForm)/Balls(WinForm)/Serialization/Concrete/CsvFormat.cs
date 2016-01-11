using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Balls_WinForm_.Serialization.Abstract;

namespace Balls_WinForm_.Serialization.Concrete
{
    public class CsvFormat : IFormat
    {
        public void Save(string path, List<BallMemento> state)
        {
            using (var sw = new StreamWriter(path, false, Encoding.Default))
            {
                foreach (var str in state.Select(ball => $"{ball.x},{ball.y},{ball.increaseX},{ball.increaseY}"))
                {
                    sw.WriteLine(str);
                }

                MessageBox.Show(@"Balls state saved", @"Balls", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public List<BallMemento> Load(string path)
        {
            var balls = new List<BallMemento>();

            using (var sr = new StreamReader(path, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var ball = new BallMemento();

                    var readLine = sr.ReadLine();
                    if (readLine != null)
                    {
                        var values = readLine.Split(',');
                        ball.x = int.Parse(values[0]);
                        ball.y = int.Parse(values[1]);
                        ball.increaseX = bool.Parse(values[2]);
                        ball.increaseY = bool.Parse(values[3]);
                    }

                    balls.Add(ball);
                }
            }

            return balls;
        }
    }
}
