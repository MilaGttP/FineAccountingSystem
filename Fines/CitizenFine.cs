
namespace FineAccountingSystem
{
    public class CitizenFine : IFine, ICitizenFine
    {
        public string Name { get; }
        public string Category { get; }
        public DateTime DateOfIssue { get; }
        public DateTime DateOfPayment { get; }
        public UInt32 Price { get; }
        public Citizen CitizenReceiver { get; }
    }
}
