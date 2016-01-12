using System.Drawing;
using Drawing_WinForm_.Formats.Abstract;

namespace Drawing_WinForm_.Formats.Concrete
{
    public class BaseFormats : IFormat
    {
         public void Save(string path, Image image)
        {
            image.Save(path);
        }

        public Image Load(string path)
        {
            return Image.FromFile(path);
        }
    }
}
