using Drawing_WinForm_.Formats.Abstract;
using Drawing_WinForm_.Formats.Concrete;

namespace Drawing_WinForm_.Formats.Factories.ChainOfResponsibility
{
    public class XpsHandler : IHandler
    {
        public IHandler Successor { get; set; }

        public IFormat HandleRequest(int format)
        {
            IFormat extension = null;
            if (format == 6)
            {
                extension = new XpsFormat();
            }
            else if (Successor != null)
            {
                Successor.HandleRequest(format);
            }
            return extension;
        }

        public bool IsMine(int format)
        {
            var isMine = false;

            if (format == 7)
            {
                isMine = true;
            }
            return isMine;
        }

        public IFormat GetFormat()
        {
            return new XpsFormat();
        }
    }
}
