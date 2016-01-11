using System.Collections.Generic;

namespace Balls_WinForm_.Serialization.Abstract
{
    public interface IFormat
    {
        void Save(string path, List<BallMemento> state);
        List<BallMemento> Load(string path);
    }
}
