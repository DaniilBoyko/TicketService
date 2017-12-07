using System;

namespace DAL.Interfaces.DTO
{
    public class DalTicket : IEntity
    {
        public string Id { get; set; }

        public string FioDoctor { get; set; }

        public string FioPatient { get; set; }

        public DateTime TicketTime { get; set; }

        public int Cabinet { get; set; }
    }
}
