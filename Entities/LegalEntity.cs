
namespace FineAccountingSystem
{
    public class LegalEntity
    {
        public string Name { get; set; }
        public string EDPNOU { get; set; }
        public string ITN { get; set; }
        public Bank Bank { get; set; }
        public string CurrentAccount { get; set; }
        public string LegalAddress { get; set; }
        public string PhysicalAddress { get; set; }
        public Citizen Director { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}
