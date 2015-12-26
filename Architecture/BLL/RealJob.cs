using DAL;

namespace BLL
{
    public class RealJob
    {
        private readonly DataBase _db = new DataBase();
        public string GetRealJob()
        {
            return "Hello from RealJob";
        }

        public string GetFromDAL()
        {
            return _db.GetDB();
        }
    }
}
