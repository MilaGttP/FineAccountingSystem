
namespace FineAccountingSystem
{
    public class Bank
    {
        public UInt32 Id = BankID.GetBankID();
        public string Name { get; set; }
    }
}
