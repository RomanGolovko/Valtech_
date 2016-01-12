using Drawing_WinForm_.Formats.Abstract;

namespace Drawing_WinForm_.Formats.Factories.ChainOfResponsibility
{
    public interface IHandler
    {
        IHandler Successor { get; set; }    // for Linked
        IFormat HandleRequest(int format);  // for Linked

        bool IsMine(int format);            // for loop
        IFormat GetFormat();                // for loop
    }
}
