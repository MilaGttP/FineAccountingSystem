
using System.Text.RegularExpressions;

namespace FineAccountingSystem
{
    public class CitizenAccount : IAccount
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string ITN { get; set; }
        public string Address { get; set; }
        public string CityName { get; set; }
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
                Console.Write("Enter your age -> "); Age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter your identification code -> "); ITN = Console.ReadLine();
                Console.Write("Enter your address -> "); Address = Console.ReadLine();
                Console.Write("Enter your city name -> "); CityName = Console.ReadLine();
                if (CityName.Any(char.IsDigit)) throw new Exception("Your city name contains digits!");
                AccountForm();
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            FileData.Serialize(this, "CitizenAccs.xml");
        }
        public bool SignIn()
        {
            try
            {
                CitizenAccount acc = new CitizenAccount();
                acc = FileData.Deserialize<CitizenAccount>("CitizenAccs.xml");
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
            return $"Citizen information: \n Full name: {FullName}\n Age: {Age}, ITN: {ITN}\n" +
                $" Adress: {Address}\n City name: {CityName}\n Phone: {Phone}\n Email: {Email}";
        }
    }
}
