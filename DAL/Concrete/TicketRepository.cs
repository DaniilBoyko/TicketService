using DAL.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces.DTO;
using DAL.Mappers;
using ORM;

namespace DAL.Concrete
{
    public class TicketRepository : ITicketRepository
    {
        private readonly DbContext _context;

        public TicketRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(DalTicket dalTicket)
        {
            var ormTicket = dalTicket.ToOrmTicket();
            _context.Set<OrmTicket>().Add(ormTicket);
        }

        public void Delete(DalTicket dalTicket)
        {
            var ormTicket = dalTicket.ToOrmTicket();
            ormTicket = _context.Set<OrmTicket>().Single(acc => acc.Id == ormTicket.Id);
            _context.Set<OrmTicket>().Remove(ormTicket);
        }

        public IEnumerable<DalTicket> GetAll()
        {
            return _context.Set<OrmTicket>().ToList().Select(ormTicket => ormTicket.ToDalTicket());
        }

        public DalTicket GetById(string id)
        {
            var ormTicket = _context.Set<OrmTicket>().FirstOrDefault(ticket => ticket.Id == id);
            return ormTicket?.ToDalTicket();
        }

        public DalTicket GetByPredicate(Predicate<DalTicket> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(DalTicket dalTicket)
        {
            Delete(dalTicket);
            Create(dalTicket);
        }
    }
}
