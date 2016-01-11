using Drawing_WinForm_.Formats.Abstract;
using Drawing_WinForm_.Formats.Concrete;

namespace Drawing_WinForm_.Formats
{
    public static class Factory
    {
        public static IFormat ChooseFormat(/*string path*/ int index)
        {
            IFormat format = null;
            //var extansion = path.ToLower().Trim().Split('.')[1];

            switch (/*extansion*/ index)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5: format = new BaseFormats(); break;
                default: break;
            }

            return format;
        }
    }
}
