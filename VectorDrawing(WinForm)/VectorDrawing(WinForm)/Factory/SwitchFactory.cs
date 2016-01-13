using VectorDrawing_WinForm_.Serialization.Abstract;
using VectorDrawing_WinForm_.Serialization.Concrete;

namespace VectorDrawing_WinForm_.Factory
{
    public static class SwitchFactory
    {
        public static IFormat SelectSerializationFormat(int ext)
        {
            IFormat format = null;

            switch (ext)
            {
                case 0: format = new BinaryFormat(); break;
                case 1: format = new XmlFormat(); break;
                case 2: format = new JsonFormat(); break;
                case 3: format = new YamlFormat(); break;
                default:
                    break;
            }

            return format;
        }
    }
}
