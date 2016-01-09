using Balls_WinForm_.Serialization.Abstract;
using Balls_WinForm_.Serialization.Concrete;

namespace Balls_WinForm_.Serialization
{
    public class Factory
    {
        public static IFormat SelectSerializationFormat(string format)
        {
            switch (format)
            {
                case "Binary": return new BinaryFormat();
                case "CSV": return new CsvFormat();
                case "XML": return new XmlFormat();
                case "JSON": return new JsonFormat();
                case "YAML": return new YamlFormat();
                default: return new BinaryFormat();
            }
        }
    }
}
