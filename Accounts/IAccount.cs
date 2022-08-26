
namespace FineAccountingSystem
{
    public interface IAccount
    {
        string Name { get; }
        string Phone { get; }
        string Email { get; }
        string Password { get; }
        void Registration();
        void SignIn();
    }
}
