﻿namespace DAL.Entities
{
    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
