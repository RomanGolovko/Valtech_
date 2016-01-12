using Drawing_WinForm_.Formats.Abstract;

namespace Drawing_WinForm_.Formats.Factories.ChainOfResponsibility
{
    public interface IHandler
    {
        IHandler Successor { get; set; }
        IFormat HandleRequest(int format);

        bool IsMine(int format);
        IFormat GetFormat();
    }
}
