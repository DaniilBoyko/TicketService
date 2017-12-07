using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Entities
{
    public class Ticket
    {
        public string Id { get; set; }

        public string FioDoctor { get; set; }

        public string FioPatient { get; set; }

        public DateTime TicketTime { get; set; }

        public int Cabinet { get; set; }
    }
}
