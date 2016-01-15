namespace VectorDrawing_WinForm_.Factories
{
    public static class NumTypeFactory
    {
        public static int GetShapeType(string type)
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

    }
}
