
namespace FineAccountingSystem
{
    public class PoliceOfficeID
    {
        private static UInt32 id = 0;
        public static UInt32 GetPoliceOfficeID() { return id++; }
    }
}