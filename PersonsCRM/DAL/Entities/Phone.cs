namespace DAL.Entities
{
    public class Phone
    {
        public virtual int Id { get; set; }
        public virtual string Number { get; set; }
        public virtual string Type { get; set; }

        public virtual int? PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
