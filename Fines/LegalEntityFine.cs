
namespace FineAccountingSystem
{
    public class LegalEntityFine : IFine, ILegalEntityFine
    {
        public string Name { get; }
        public string Category { get; }
        public DateTime DateOfIssue { get; }
        public DateTime DateOfPayment { get; }
        public UInt32 Price { get; }
        public LegalEntity LegalEntityReceiver { get; }

    }
}
