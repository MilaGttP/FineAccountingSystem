
namespace FineAccountingSystem
{
    public class LegalEntityFine : IFine, ILegalEntityFine
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfPayment { get; set; }
        public UInt32 Price { get; set; }
        public string LegalEntityReceiver { get; set; }

        public void AddLegalEntityFine()
        {
            try
            {
                Console.Write("Enter a legal entity`s full name -> "); LegalEntityReceiver = Console.ReadLine();
                if (LegalEntityReceiver.Any(char.IsDigit)) throw new Exception("Name contains digits!");
                Console.Write("Enter a name of fine -> "); Name = Console.ReadLine();
                Console.Write("Enter a category of fine -> "); Category = Console.ReadLine();
                DateOfIssue = DateTime.Now;
                Console.Write("Enter a date of payment -> "); DateOfPayment = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter a price -> "); Price = Convert.ToUInt32(Console.ReadLine());
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            FileData.Serialize(this, "LegalEntityFines.xml");
        }

        public void PayLegalEntityFine()
        {
            try
            {
                Console.Write("Enter your full name -> "); LegalEntityReceiver = Console.ReadLine();
                if (LegalEntityReceiver.Any(char.IsDigit)) throw new Exception("Name contains digits!");
                LegalEntityFine legalEntityFine = new LegalEntityFine();
                legalEntityFine = FileData.Deserialize<LegalEntityFine>("LegalEntityFines.xml");
                if (legalEntityFine.LegalEntityReceiver == LegalEntityReceiver)
                {
                    Console.WriteLine($"Fine`s price is: {legalEntityFine.Price}");
                    Console.WriteLine("Enter an amount of money to pay -> "); UInt32 amountOfMoney = Convert.ToUInt32(Console.ReadLine());
                    if (amountOfMoney < legalEntityFine.Price) throw new Exception("Enter a large amount!");
                    else
                    {
                        File.WriteAllText("LegalEntityFines.xml", "");
                        Console.WriteLine("Paid!");
                    }
                }
                else Console.WriteLine("You haven`t any fines!");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public override string ToString()
        {
            return $"Legal entity fine information: \n Receiver: {LegalEntityReceiver}\n Fine`s name: {Name}\n" +
                $" Category: {Category}\n Date of issue: {DateOfIssue}\n Date of payment: {DateOfPayment}\n Price: {Price}\n";
        }
    }
}
