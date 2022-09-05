using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations.Command
{
  public class UpdateCustomerCommand
    {
        private readonly IMovieStoreDbContext _context;
        public CustomerModel Model;
        public int Id;

        public UpdateCustomerCommand(IMovieStoreDbContext context)
        {
            _context = context;            
        }

        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(x=> x.Id == Id);
            if(customer is null)
                throw new InvalidOperationException("Müşteri bulunamadı.");
            
            customer.Name = Model.Name == default ? customer.Name : Model.Name;
            customer.SurName = Model.SurName == default ? customer.SurName : Model.SurName;
            customer.Email = Model.Email == default ? customer.Email : Model.Email;
            customer.Password = Model.Password == default ? customer.Password : Model.Password;

            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
    }
}