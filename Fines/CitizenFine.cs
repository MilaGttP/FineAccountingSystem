
namespace FineAccountingSystem
{
    public class CitizenFine : IFine, ICitizenFine
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfPayment { get; set; }
        public UInt32 Price { get; set; }
        public string CitizenReceiver { get; set; }

        public void AddCitizenFine()
        {
            try {
                Console.Write("Enter a citizen`s full name -> "); CitizenReceiver = Console.ReadLine();
                if (CitizenReceiver.Any(char.IsDigit)) throw new Exception("Name contains digits!");
                Console.Write("Enter a name of fine -> "); Name = Console.ReadLine();
                Console.Write("Enter a category of fine -> "); Category = Console.ReadLine();
                DateOfIssue = DateTime.Now;
                Console.Write("Enter a date of payment -> "); DateOfPayment = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter a price -> "); Price = Convert.ToUInt32(Console.ReadLine());
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            FileData.Serialize(this, "CitizenFines.xml");
        }

        public void PayCitizenFine()
        {
            try
            {
                Console.Write("Enter your full name -> "); CitizenReceiver = Console.ReadLine();
                if (CitizenReceiver.Any(char.IsDigit)) throw new Exception("Name contains digits!");
                CitizenFine citizenFine = new CitizenFine();
                citizenFine = FileData.Deserialize<CitizenFine>("CitizenFines.xml");
                if (citizenFine.CitizenReceiver == CitizenReceiver)
                {
                    Console.WriteLine($"Fine`s price is: {citizenFine.Price}");
                    Console.WriteLine("Enter an amount of money to pay -> "); UInt32 amountOfMoney = Convert.ToUInt32(Console.ReadLine());
                    if (amountOfMoney < citizenFine.Price) throw new Exception("Enter a more amount!");
                    else
                    {
                        File.WriteAllText("CitizenFines.xml", "");
                        Console.WriteLine("Paid!");
                    }
                }
                else Console.WriteLine("You haven`t any fines!");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public override string ToString()
        {
            return $"Citizen fine information: \n Receiver: {CitizenReceiver}\n Fine`s name: {Name}\n" +
                $" Category: {Category}\n Date of issue: {DateOfIssue}\n Date of payment: {DateOfPayment}\n Price: {Price}\n";
        }
    }
}
