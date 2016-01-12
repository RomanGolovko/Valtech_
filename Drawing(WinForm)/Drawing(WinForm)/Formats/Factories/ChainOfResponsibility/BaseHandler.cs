using Drawing_WinForm_.Formats.Abstract;
using Drawing_WinForm_.Formats.Concrete;

namespace Drawing_WinForm_.Formats.Factories.ChainOfResponsibility
{
    public class BaseHandler : IHandler
    {
        public IHandler Successor { get; set; }

        public IFormat HandleRequest(int format)
        {
            IFormat extension = null;
            if(format == 0 || format == 1 || format == 2 ||
               format == 3 || format == 4 || format == 5)
            {
                extension = new BaseFormats();
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

            if(format == 0 || format == 1 || format == 2 ||
               format == 3 || format == 4 || format == 5)
            {
                isMine = true;
            }
            return isMine;
        }

        public IFormat GetFormat()
        {
            return new BaseFormats();
        }
    }
}
