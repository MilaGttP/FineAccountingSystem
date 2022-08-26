
namespace FineAccountingSystem
{
    public interface IFine
    {
        string Name { get; }
        string Category { get; }
        DateTime DateOfIssue { get; }
        DateTime DateOfPayment { get; }
        UInt32 Price { get; }
    }
}
