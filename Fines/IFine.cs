
namespace FineAccountingSystem
{
    public interface IFine
    {
        /// <summary>
        /// отримувач може бути як фізична, так і юридична особа - 
        /// проте вони відрізняються лише сумою (як для цієї програми)
        /// тому є можливість слідувати DRY принципу та зробити класи
        /// штрафів опосередкованими для обох категорій отримувачів
        /// </summary>

        Citizen CitizenReceiver { get; } 
        LegalEntity LegalEntityReceiver { get; }

        string Name { get; }
        string Category { get; }
        DateTime DateOfIssue { get; }
        DateTime DateOfPayment { get; }
        UInt32 Price { get; } 
    }
}
