namespace TicketServiceWCF
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AccountModel : DbContext
    {
        public AccountModel()
            : base("name=AccountModel")
        {
        }


        public virtual DbSet<MyEntity> Accounts { get; set; }
    }

    public class MyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}