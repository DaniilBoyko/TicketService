using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using DAL.Interfaces.Repository;
using BLL.Mappers;

namespace BLL.Services
{
    public class TicketService : ITicketsService
    {
        private ITicketRepository TicketRepository { get; }
        private IUnitOfWork UnitOfWork { get; }

        public TicketService(IUnitOfWork unitOfWork, ITicketRepository ticketRepository)
        {
            UnitOfWork = unitOfWork;
            TicketRepository = ticketRepository;
        }

        public List<Ticket> GetAllTickets()
        {
            return TicketRepository.GetAll().Select(tick => tick.ToBllTicket()).ToList();
        }

        public void DeleteTicket(Ticket ticket)
        {
            TicketRepository.Delete(ticket.ToDalTicket());
            UnitOfWork.Commit();
        }

        public void UpdateTicket(Ticket ticket)
        {
            TicketRepository.Update(ticket.ToDalTicket());
            UnitOfWork.Commit();
        }

        public void AddTicket(Ticket ticket)
        {
            TicketRepository.Create(ticket.ToDalTicket());
            UnitOfWork.Commit();
        }

        public Ticket GetTicketById(string id)
        {
            return TicketRepository?.GetById(id)?.ToBllTicket();
        }

        public Ticket GetTicketByPredicate(Predicate<Ticket> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
