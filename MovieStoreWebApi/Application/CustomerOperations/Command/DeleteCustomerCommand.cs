using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations.Command
{
   public class DeleteCustomerCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int Id;

        public DeleteCustomerCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == Id);
            if (customer is null)
                throw new InvalidOperationException("Silinmek istenen müşteri bulunamadı.");

            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}