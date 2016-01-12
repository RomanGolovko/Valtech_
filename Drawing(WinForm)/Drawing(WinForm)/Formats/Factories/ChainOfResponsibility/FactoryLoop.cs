using Drawing_WinForm_.Formats.Abstract;
using System.Collections.Generic;

namespace Drawing_WinForm_.Formats.Factories.ChainOfResponsibility
{
    public class FactoryLoop
    {
        private readonly List<IHandler> _handlerList;

        public FactoryLoop()
        {
            _handlerList = new List<IHandler>
            {
                new BaseHandler(),
                new XpsHandler(),
                new PdfHandler(),
                new PsdHandler()
            };
        }

        public List<IFormat> GetValidFormats(int ext)
        {
            var formats = new List<IFormat>();

            foreach (var item in _handlerList)
            {
                if (item.IsMine(ext))
                {
                    formats.Add(item.GetFormat());
                }
            }

            return formats;
        }
    }
}
