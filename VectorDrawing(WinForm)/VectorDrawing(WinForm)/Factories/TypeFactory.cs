namespace VectorDrawing_WinForm_.Factories
{
    public static class TypeFactory
    {
        public static int GetNumShapeType(string type)
        {
            var numType = 0;

            switch (type)
            {
                case "Rectangle": numType = 0; break;
                case "Ellipse": numType = 1; break;
                case "Line": numType = 2; break;
                default:
                    break;
            }

            return numType;
        }

        public static string GetStrShapeType(int typeNum)
        {
            var type = "";

            switch (typeNum)
            {
                case 0: type = "Rectangle"; break;
                case 1: type = "Ellipse"; break;
                case 2: type = "Line"; break;
                default:
                    break;
            }

            return type;
        }
    }
}
