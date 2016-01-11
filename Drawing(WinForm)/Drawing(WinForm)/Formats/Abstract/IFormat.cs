using System.Drawing;

namespace Drawing_WinForm_.Formats.Abstract
{
    public interface IFormat
    {
        void Save(string path, Image image);
        Image Load(string path);
    }
}
