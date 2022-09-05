using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations.Queries
{
  public class GetCustomerQuery
  {
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;

    public GetCustomerQuery(IMovieStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public List<CustomerQueryViewModel> Handle()
    {
      var customers = _context.Customers.OrderBy(x => x.Id).ToList();
      var vm = _mapper.Map<List<CustomerQueryViewModel>>(customers);

      return vm;
    }
  }

  public class CustomerQueryViewModel
  {
    public string Name { get; set; }
    public string SurName { get; set; }
  }
}
