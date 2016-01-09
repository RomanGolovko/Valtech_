using System.Collections.Generic;

namespace Balls_WinForm_.Serialization.Abstract
{
    public interface IFormat
    {
        void Save(List<Ball> state);
        List<Ball> Load();
    }
}
