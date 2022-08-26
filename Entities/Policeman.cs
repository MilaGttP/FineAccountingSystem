
namespace FineAccountingSystem
{
    public class Policeman
    {
        public string FullName { get; set; }
        public string ITN { get; set; }
        public string Rank { get; set; }
        public PoliceOffice PoliceOffice { get; set; }
        public DateOnly DateOfEmployment { get; set; }
    }
}
