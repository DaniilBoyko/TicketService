﻿using BLL.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TicketService;

namespace TicketServiceWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITicketService" in both code and config file together.
    [ServiceContract]
    public interface ITicketService
    {
        [OperationContract]
        string GetHelloWorld();

        [OperationContract]
        List<Ticket> GetAllTickets(CheckInfo checkInfo);

        [OperationContract]
        void DeleteTicket(string id, CheckInfo checkInfo);

        [OperationContract]
        void UpdateTicket(Ticket ticket, CheckInfo checkInfo);

        [OperationContract]
        void AddTicket(string id, string fioDoctor, string fioPatient, DateTime ticketTime, int cabinet, CheckInfo checkInfo);

        [OperationContract]
        Ticket GetTicketById(string id, CheckInfo checkInfo);

        [OperationContract]
        List<string> GetNameColumns(CheckInfo checkInfo);
    }
}
