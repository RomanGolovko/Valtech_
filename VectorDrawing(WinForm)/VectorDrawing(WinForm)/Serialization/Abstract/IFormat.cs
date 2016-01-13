using System.Collections.Generic;
using VectorDrawing_WinForm_.Memento;

namespace VectorDrawing_WinForm_.Serialization.Abstract
{
    public interface IFormat
    {
        void Save(string path, List<ShapeMemento> state);
        List<ShapeMemento> Load(string path);
    }
}
