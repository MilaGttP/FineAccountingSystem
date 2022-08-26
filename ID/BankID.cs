
namespace FineAccountingSystem
{
    public class BankID
    {
        private static UInt32 id = 0;
        public static UInt32 GetBankID() { return id++; }
    }
}