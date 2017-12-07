using System;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using DependencyResolver;
using Ninject;

namespace ConsolePL.Tests
{
    public class Program
    {
        private static readonly IKernel Resolver;

        static Program()
        {
            Resolver = new StandardKernel();
            Resolver.ConfigurateResolverWeb();
        }

        static void Main(string[] args)
        {
            var ticketsService = Resolver.Get<ITicketsService>();

            try
            {
               /* ticketsService.AddTicket(new Ticket()
                {
                    Id = "4",
                    FioDoctor = "Pavel Pupkov",
                    FioPatient = "Fiedor Mixhalkov",
                    TicketTime = new DateTime(2000, 9, 1),
                    Cabinet = 234,
                });
                */
                ticketsService.AddTicket(new Ticket()
                {
                    Id = "12",
                    FioDoctor = "Piter Culacov",
                    FioPatient = "Fiedor Mixhalkov",
                    TicketTime = new DateTime(2000, 9, 1),
                    Cabinet = 234,
                });

                foreach (Ticket ticket in ticketsService.GetAllTickets())
                {
                    string info = string.Empty;
                    info += $"Id = {ticket.Id}\n";
                    info += $"FIO Doctor = {ticket.FioDoctor}\n";
                    info += $"FIO Patient = {ticket.FioPatient}\n";
                    info += $"Ticket time = {ticket.TicketTime}\n";
                    info += $"Cabinet = {ticket.Cabinet}\n";

                    Console.WriteLine(info);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
