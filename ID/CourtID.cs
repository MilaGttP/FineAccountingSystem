
namespace FineAccountingSystem
{
    public class CourtID
    {
        private static UInt32 id = 0;
        public static UInt32 GetCourtID() { return id++; }
    }
}