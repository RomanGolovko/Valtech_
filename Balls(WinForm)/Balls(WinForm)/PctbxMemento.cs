using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Balls_WinForm_.Serialization;

namespace Balls_WinForm_
{
    // Memento
    [Serializable]
    [DataContract]                          // for json serialization
    public class PctbxMemento
    {
        [DataMember]                        // for json serialization
        public readonly List<Ball> balls;   // public for xml serialization

        public PctbxMemento() { }            // for xml serialization

        public PctbxMemento(List<Ball> balls)
        {
            this.balls = balls;
        }

        public static List<Ball> RestoreState(string format)
        {
            return Factory.SelectSerializationFormat(format).Load();
        }

        public void SaveState(string format)
        {
            Factory.SelectSerializationFormat(format).Save(balls);
        }
    }
}
