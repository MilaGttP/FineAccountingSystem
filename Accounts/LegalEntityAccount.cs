
using System.Net;
using System.Text.RegularExpressions;

namespace FineAccountingSystem
{
    public class LegalEntityAccount : IAccount
    {
        public string FullName { get; set; }
        public string EDPNOU { get; set; }
        public string ITN { get; set; }
        public string BankName { get; set; }
        public string BankAccount { get; set; }
        public string LegalAddress { get; set; }
        public string PhysicalAddress { get; set; }
        public string Director { get; set; }
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
            try {
                Console.Write("Enter your full name -> "); FullName = Console.ReadLine();
                if (FullName.Any(char.IsDigit)) throw new Exception("Your name contains digits!");
                Console.Write("Enter your EDPNOU -> "); EDPNOU = Console.ReadLine();
                Console.Write("Enter your identification code -> "); ITN = Console.ReadLine();
                Console.Write("Enter your bank name -> "); BankName = Console.ReadLine();
                if (BankName.Any(char.IsDigit)) throw new Exception("Your bank name contains digits!");
                Console.Write("Enter your bank account -> "); BankAccount = Console.ReadLine();
                Console.Write("Enter legal address -> "); LegalAddress = Console.ReadLine();
                Console.Write("Enter physical address -> "); PhysicalAddress = Console.ReadLine();
                Console.Write("Enter director name -> "); Director = Console.ReadLine();
                if (Director.Any(char.IsDigit)) throw new Exception("Your director name contains digits!");
                AccountForm();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            FileData.Serialize(this, "LegalEntityAccs.xml");
        }
        public bool SignIn()
        {
            try
            {
                LegalEntityAccount acc = new LegalEntityAccount();
                acc = FileData.Deserialize<LegalEntityAccount>("LegalEntityAccs.xml");
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
        public override string ToString()
        {
            return $"Legal entity information: \n Full name: {FullName}\n EDPNOU: {EDPNOU}, ITN: {ITN}\n" +
                $" Bank name: {BankName}\n Bank account: {BankAccount}\n Legal address: {LegalAddress}\n" +
                $" Physical address: {PhysicalAddress}\n Director: {Director}\n Phone: {Phone}\n Email: {Email}";
        }
    }
}
