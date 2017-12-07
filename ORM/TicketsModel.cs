namespace ORM
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TicketsModel : DbContext
    {
        public TicketsModel()
            : base("name=TicketsModel")
        {
        }

        public virtual DbSet<OrmTicket> Tickets { get; set; }
    }

}