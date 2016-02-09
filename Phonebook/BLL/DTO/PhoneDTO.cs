namespace BLL.DTO
{
    public class PhoneDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PersonId { get; set; }
        public PersonDTO Person { get; set; }
    }
}
