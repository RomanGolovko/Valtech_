using Drawing_WinForm_.Formats.Abstract;
using Drawing_WinForm_.Formats.Concrete;

namespace Drawing_WinForm_.Formats
{
    public static class FactorySwitch
    {
        public static IFormat ChooseFormat(int index)
        {
            IFormat format = null;

            switch (index)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5: format = new BaseFormats(); break;
                case 6: format = new XpsFormat(); break;
                case 7: format = new PdfFormat(); break;
                case 8: format = new PsdFormat(); break;
                default: break;
            }

            return format;
        }
    }
}
