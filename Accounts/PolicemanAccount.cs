
using System.Text.RegularExpressions;

namespace FineAccountingSystem
{
    public class PolicemanAccount : IAccount
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string ITN { get; set; }
        public string Rank { get; set; }
        public int PoliceOffice { get; set; }
        public DateOnly DateOfEmployment { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void AccountForm()
        {
            Console.Write("Enter your phone -> "); Phone = Console.ReadLine();
            Regex phoneRegex = new Regex("^\\+?[1-9][0-9]{7,14}$");
            if (!phoneRegex.IsMatch(Phone)) throw new Exception("You entered incorrect phone!");
            Console.Write("Enter your email -> "); Email = Console.ReadLine();
            Regex emailRegex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            if (!emailRegex.IsMatch(Email)) throw new Exception("You entered incorrect email!");
            Console.Write("Enter your password -> "); Password = Console.ReadLine();
            Regex passwordRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            if (!passwordRegex.IsMatch(Password)) throw new Exception("You entered incorrect password!");
        }
        public void Registration()
        {
            try
            {
                Console.Write("Enter your full name -> "); FullName = Console.ReadLine();
                if (FullName.Any(char.IsDigit)) throw new Exception("Your name contains digits!");
                Console.Write("Enter your age -> "); Age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter your identification code -> "); ITN = Console.ReadLine();
                Console.Write("Enter your rank -> "); Rank = Console.ReadLine();
                Console.Write("Enter your police office (number) -> "); PoliceOffice = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter your date of employment -> "); DateOfEmployment = DateOnly.Parse(Console.ReadLine());
                AccountForm();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            FileData.Serialize(this, "PolicemanAccs.xml");
        }
        public bool SignIn()
        {
            try
            {
                PolicemanAccount acc = new PolicemanAccount();
                acc = FileData.Deserialize<PolicemanAccount>("PolicemanAccs.xml");
                AccountForm();
                if (acc.Phone != this.Phone && acc.Email != this.Email && acc.Password != this.Password)
                {
                    throw new Exception("Your data is incorrect!");
                    return false;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return true;
        }
        
        public void CheckFines()
        {
            Console.WriteLine("--- CITIZEN FINES ---");
            CitizenFine citizenFine = new CitizenFine();
            citizenFine = FileData.Deserialize <CitizenFine>("CitizenFines.xml");
            Console.WriteLine(citizenFine.ToString());
            Console.WriteLine("--- LEGAL ENTITY FINES ---");
            LegalEntityAccount legalEntityAcc = new LegalEntityAccount();
            legalEntityAcc = FileData.Deserialize<LegalEntityAccount>("LegalEntityFines.xml");
            Console.WriteLine(legalEntityAcc.ToString());
        }
    }
}
