using Drawing_WinForm_.Formats.Abstract;
using System;
using System.Drawing;

namespace Drawing_WinForm_.Formats.Concrete
{
    public class XpsFormat : IFormat
    {
        public void Save(string path, Image image)
        {
            throw new NotImplementedException();
        }

        public Image Load(string path)
        {
            throw new NotImplementedException();
        }
    }
}
