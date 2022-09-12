
using static System.Console;

namespace FineAccountingSystem
{
    public class AccountFacade
    {
        public static int ShowMainAccMenu()
        {
            CitizenAccount CitizenAccount = new CitizenAccount();
            LegalEntityAccount LegalEntityAccount = new LegalEntityAccount();
            PolicemanAccount PolicemanAccount = new PolicemanAccount();
            Write("Greetings!\n 1 - Registration \n 2 - Sign in \n Enter -> "); int choiceRegOrSignIn = Convert.ToInt32(ReadLine());
            Write("\n 1 - Citizen \n 2 - Legal entity \n 3 - Policeman \n Enter -> "); int choiceAcc = Convert.ToInt32(ReadLine());
            switch (choiceRegOrSignIn)
            {
                case 1:
                    {
                        switch(choiceAcc)
                        {
                            case 1: CitizenAccount.Registration(); return 1;
                            break;
                            case 2: LegalEntityAccount.Registration(); return 0;
                            break;
                            case 3: PolicemanAccount.Registration(); return -1;
                            break;
                        }
                    }
                    break;
                case 2:
                    switch (choiceAcc)
                    {
                        case 1: CitizenAccount.SignIn(); return 1;
                        break;
                        case 2: LegalEntityAccount.SignIn(); return 0;
                        break;
                        case 3: PolicemanAccount.SignIn(); return -1;
                        break;
                    }
                    break;
            }
            return 10;
        }
    }
}
