using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using DependencyResolver;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Web;
using TicketService;

namespace TicketServiceWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TicketService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TicketService.svc or TicketService.svc.cs at the Solution Explorer and start debugging.
    public class TicketService : ITicketService
    {
        private static readonly ITicketsService TicketsService;

        static TicketService()
        {
            IKernel resolver = new StandardKernel();
            resolver.ConfigurateResolverWeb();
            TicketsService = resolver.Get<ITicketsService>();
        }

        public List<Ticket> GetAllTickets(CheckInfo checkInfo)
        {
            if (CheckClient(checkInfo))
                return TicketsService.GetAllTickets();
            else
                return null;
        }

        public void DeleteTicket(Ticket ticket, CheckInfo checkInfo)
        {
            if (CheckClient(checkInfo))
                TicketsService.DeleteTicket(ticket);
        }

        public void UpdateTicket(Ticket ticket, CheckInfo checkInfo)
        {
            if (CheckClient(checkInfo))
                TicketsService.UpdateTicket(ticket);
        }

        public void AddTicket(Ticket ticket, CheckInfo checkInfo)
        {
            if (CheckClient(checkInfo))
                TicketsService.AddTicket(ticket);
        }

        public Ticket GetTicketById(string id, CheckInfo checkInfo)
        {
            if (CheckClient(checkInfo))
                return TicketsService.GetTicketById(id);
            return null;
        }

        public List<string> GetNameColumns(CheckInfo checkInfo)
        {
            if (CheckClient(checkInfo))
            {
                return (from t in typeof(Ticket).GetProperties()
                        select t.Name).ToList();
            }
            return null;
        }

        private bool CheckClient(CheckInfo checkInfo)
        {
            PaymentService.PaymentService paymentService = new PaymentService.PaymentService();
            String agent = HttpContext.Current.Request.UserAgent;

            string result =
                paymentService.checkPayment(checkInfo.User, checkInfo.Token, GetIP(), agent);
            if (result.Equals(true.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string GetIP()
        {
            OperationContext context = OperationContext.Current;
            MessageProperties prop = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint =
               prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            string ip = endpoint.Address;
            return ip;
        }

        public string GetHelloWorld()
        {
            return "Hello world!";
        }
    }
}
