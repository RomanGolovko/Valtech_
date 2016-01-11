using System;
using System.Runtime.Serialization;

namespace Balls_WinForm_
{
    [Serializable]
    [DataContract]                          // for json serialization
    public class BallMemento
    {
        [DataMember]                        // for json serialization
        public int x;

        [DataMember]                        // for json serialization
        public int y;

        [DataMember]                        // for json serialization
        public bool increaseX;

        [DataMember]                        // for json serialization
        public bool increaseY;
    }
}
