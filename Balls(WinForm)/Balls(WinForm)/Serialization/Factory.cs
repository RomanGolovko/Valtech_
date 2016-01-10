using Balls_WinForm_.Serialization.Abstract;
using Balls_WinForm_.Serialization.Concrete;

namespace Balls_WinForm_.Serialization
{
    public class Factory
    {
        public static IFormat SelectSerializationFormat(string format)
        {
            if (format.Contains(".dat"))
            {
                return new BinaryFormat();
            }
            else if (format.Contains(".csv"))
            {
                return new CsvFormat();
            }
            else if (format.Contains(".xml"))
            {
                return new XmlFormat();
            }
            else if (format.Contains(".json"))
            {
                return new JsonFormat();
            }
            else if (format.Contains(".yaml"))
            {
                return new YamlFormat();
            }
            else
            {
                return new BinaryFormat();
            }
        }
    }
}
