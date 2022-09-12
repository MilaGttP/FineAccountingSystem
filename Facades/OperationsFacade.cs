
using static System.Console;

namespace FineAccountingSystem
{
    public class OperationsFacade
    {
        public static void CitizenMenu()
        {
            CitizenFine fine = new CitizenFine();
            WriteLine("Welcome to citizen menu!");
            Write(" 1 - Pay a fine\n 2 - Exit \n Enter -> "); int choice = Convert.ToInt32(ReadLine());
            switch(choice)
            {
                case 1: fine.PayCitizenFine();
                break;
                case 2: Environment.Exit(0);
                break;
            }

        }
        public static void LegalEntityMenu()
        {
            LegalEntityFine fine = new LegalEntityFine();
            WriteLine("Welcome to legal entity menu!");
            Write(" 1 - Pay a fine\n 2 - Exit \n Enter -> "); int choice = Convert.ToInt32(ReadLine());
            switch (choice)
            {
                case 1: fine.AddLegalEntityFine();
                break;
                case 2: Environment.Exit(0);
                break;
            }
        }
        public static void PolicemanMenu()
        {
            CitizenFine citizenFine = new CitizenFine();
            LegalEntityFine legalEntityFine = new LegalEntityFine();
            PolicemanAccount acc = new PolicemanAccount();
            WriteLine("Welcome to policeman menu!");
            Write(" 1 - Check a fine list \n 2 - Add a citizen fine \n 3 - Add a legal entity fine \n 4 - Exit \n Enter -> "); int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1: acc.CheckFines();
                break;
                case 2: citizenFine.AddCitizenFine();
                break;
                case 3: legalEntityFine.AddLegalEntityFine();
                break;
                case 4: Environment.Exit(0);
                break;
            }
        }
        public static void ShowMainOperMenu()
        {
            try
            {
                if (AccountFacade.ShowMainAccMenu() == 1)  CitizenMenu();
                else if (AccountFacade.ShowMainAccMenu() == 0) LegalEntityMenu();
                else if (AccountFacade.ShowMainAccMenu() == -1) PolicemanMenu();
                else throw new Exception("Wrong choice!");
            }
            catch (Exception ex) { WriteLine(ex.Message); }
        }
    }
}
