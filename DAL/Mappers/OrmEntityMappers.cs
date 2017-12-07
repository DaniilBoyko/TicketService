using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;
using DAL.Interfaces.DTO;

namespace DAL.Mappers
{
    public static class OrmEntityMappers
    {
        public static OrmTicket ToOrmTicket(this DalTicket dalTicket)
        {
            return new OrmTicket()
            {
                Id = dalTicket.Id,
                FioDoctor = dalTicket.FioDoctor,
                FioPatient = dalTicket.FioPatient,
                Cabinet = dalTicket.Cabinet,
                TicketTime = dalTicket.TicketTime,
            };
        }

        public static DalTicket ToDalTicket(this OrmTicket ormTicket)
        {
            return new DalTicket()
            {
                Id = ormTicket.Id,
                FioDoctor = ormTicket.FioDoctor,
                FioPatient = ormTicket.FioPatient,
                TicketTime = ormTicket.TicketTime,
                Cabinet = ormTicket.Cabinet,
            };
        }
    }
}
