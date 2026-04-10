using RevString;
namespace BLReverse
{
    public class BLString
    {
        public string BLRevString()
        {
            DALReverse d = new DALReverse();
            string beforeReverse = d.ReverseDAL();
            string afterReverse = new string(beforeReverse.Reverse().ToArray());
            return afterReverse;
        }

    }
}
