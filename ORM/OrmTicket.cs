using System;

namespace ORM
{
    public class OrmTicket
    {
        public string Id { get; set; }

        public string FioDoctor { get; set; }

        public string FioPatient { get; set; }

        public DateTime TicketTime { get; set; }

        public int Cabinet { get; set; }

        public OrmTicket()
        {

        }

        public OrmTicket(string id, string fioDoctor, string fioPatient, DateTime time, int cabinet)
        {
            this.Id = id;
            this.FioDoctor = fioDoctor;
            this.FioPatient = fioPatient;
            this.TicketTime = time;
            this.Cabinet = cabinet;
        }

    }


}
