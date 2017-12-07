using BLL.Interfaces.Entities;
using DAL.Interfaces.DTO;

namespace BLL.Mappers
{
    public static class BllTicketMappers
    {
        public static Ticket ToBllTicket(this DalTicket dalTicket)
        {
            return new Ticket()
            {
                Id = dalTicket.Id,
                FioDoctor = dalTicket.FioDoctor,
                FioPatient = dalTicket.FioPatient,
                TicketTime = dalTicket.TicketTime,
                Cabinet = dalTicket.Cabinet,
            };
        }

        public static DalTicket ToDalTicket(this Ticket ticket)
        {
            return new DalTicket()
            {
                Id = ticket.Id,
                FioDoctor = ticket.FioDoctor,
                FioPatient = ticket.FioPatient,
                TicketTime = ticket.TicketTime,
                Cabinet = ticket.Cabinet,
            };
        }
    }
}
