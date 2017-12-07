using System;
using System.Collections.Generic;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Services
{
    public interface ITicketsService
    {
        List<Ticket> GetAllTickets();

        void DeleteTicket(Ticket ticket);

        void UpdateTicket(Ticket ticket);

        void AddTicket(Ticket ticket);

        Ticket GetTicketById(string id);

        Ticket GetTicketByPredicate(Predicate<Ticket> predicate);
    }
}
