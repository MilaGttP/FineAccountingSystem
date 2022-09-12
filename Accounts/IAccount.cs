
namespace FineAccountingSystem
{
    public interface IAccount
    {
        string FullName { get; }
        string ITN { get; }
        string Phone { get; }
        string Email { get; }
        string Password { get; }
        void AccountForm();
        void Registration();
        bool SignIn();
    }
}
