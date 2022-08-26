
namespace FineAccountingSystem
{
    public class TaxID
    {
        private static UInt32 id = 0;
        public static UInt32 GetTaxID() { return id++; }
    }
}