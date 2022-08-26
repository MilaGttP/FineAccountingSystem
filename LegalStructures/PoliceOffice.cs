
namespace FineAccountingSystem
{
    public class PoliceOffice
    {
        public UInt32 id = PoliceOfficeID.GetPoliceOfficeID();
        public int PeopleQuantity { get; set; }
        public City City { get; set; }
    }
}
