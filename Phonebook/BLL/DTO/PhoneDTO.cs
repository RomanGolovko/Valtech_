namespace BLL.DTO
{
    public class PhoneDTO
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public int PersonId { get; set; }
        public int AddressId { get; set; }
    }
}
