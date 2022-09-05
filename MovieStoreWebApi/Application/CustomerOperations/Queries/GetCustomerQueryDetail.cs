using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.CustomerOperations.Queries
{
  public class GetCustomerQueryDetail
  {
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;
    public int Id { get; set; }

    public GetCustomerQueryDetail(IMovieStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public CustomerQueryViewModel Handle()
    {
      var customer = _context.Customers.SingleOrDefault(x => x.Id == Id);
      if (customer is null)
        throw new InvalidOperationException("Müşteri mevcut değil.");
      
      var vm = _mapper.Map<CustomerQueryViewModel>(customer);

      return vm;
    }
  }
}
