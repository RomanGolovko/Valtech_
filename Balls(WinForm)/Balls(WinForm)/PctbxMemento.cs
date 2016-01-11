 using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Balls_WinForm_.Serialization;

namespace Balls_WinForm_
{
    // Memento
    [Serializable]
    [DataContract]                                  // for json serialization
    public class PctbxMemento
    {
        [DataMember]                                // for json serialization
        public readonly List<BallMemento> balls;    // public for xml serialization

        public PctbxMemento() { }                   // for xml serialization

        public PctbxMemento(List<Ball> balls)
        {
            this.balls = new List<BallMemento>();

            foreach (var ball in balls)
            {
                var ballMemento = new BallMemento
                {
                    x = ball.X,
                    y = ball.Y,
                    increaseX = ball.IncreaseX,
                    increaseY = ball.IncreaseY
                };

                this.balls.Add(ballMemento);
            }
        }

        public static List<Ball> RestoreState(string format)
        {
            var ballsMemento = Factory.SelectSerializationFormat(format).Load(format);
            var balls = new List<Ball>();

            foreach (var ballMemento in ballsMemento)
            {
                var ball = new Ball
                {
                    X = ballMemento.x,
                    Y = ballMemento.y,
                    IncreaseX = ballMemento.increaseX,
                    IncreaseY = ballMemento.increaseY
                };
                balls.Add(ball);
            }

            return balls;
        }

        public void SaveState(string format)
        {
            Factory.SelectSerializationFormat(format).Save(format, balls);
        }
    }
}
