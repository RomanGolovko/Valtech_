using Drawing_WinForm_.Formats.Abstract;

namespace Drawing_WinForm_.Formats.Factories.ChainOfResponsibility
{
    public class FactoryLinked
    {
        IHandler baseHandler;
        IHandler xps;
        IHandler pdf;
        IHandler psd;

        public FactoryLinked()
        {
            baseHandler = new BaseHandler();
            xps = new XpsHandler();
            pdf = new PdfHandler();
            psd = new PsdHandler();

            baseHandler.Successor = xps;
            xps.Successor = pdf;
            pdf.Successor = psd;
        }

        public IFormat GetFormat(int ext)
        {
            return baseHandler.HandleRequest(ext);
        }
    }
}
