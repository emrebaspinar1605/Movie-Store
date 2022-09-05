using System.Linq;
using AutoMapper;
using WebApi.Application.ActorMoviesOperation.Command;
using WebApi.Application.ActorMoviesOperation.Queries;
using WebApi.Application.ActorOperations.Command;
using WebApi.Application.ActorOperations.Queries;
using WebApi.Application.CustomerOperations.Command;
using WebApi.Application.CustomerOperations.Queries;
using WebApi.Application.DirectorMoviesOperations.Command;
using WebApi.Application.DirectorMoviesOperations.Queries;
using WebApi.Application.DirectorOperations.Command;
using WebApi.Application.DirectorOperations.Queries;
using WebApi.Application.FavoritesGenreOperations.Command;
using WebApi.Application.FavoritesGenreOperations.Queries;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.MovieOperations.Command;
using WebApi.Application.MovieOperations.Queries;
using WebApi.Application.PurchasedMoviesOperations.Command;
using WebApi.Application.PurchasedMoviesOperations.Command.Validators;
using WebApi.Entities;

namespace WebApi.Common.Mapper
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      //movie mapper
      CreateMap<Movie, MovieQueryViewModel>()
          .ForMember(dest => dest.Actors, opt => opt.MapFrom(m => m.ActorMovies.Select(s => s.Actor.Name + " " + s.Actor.SurName)))
          .ForMember(dest=> dest.Director, opt=> opt.MapFrom(m=> m.DirectorMovies.Select(s => s.Director.Name + " " + s.Director.SurName)))
          .ForMember(dest=> dest.Genre, opt=> opt.MapFrom(m=> (Genre)m.Genre));
      CreateMap<CreateMovieModel, Movie>();

      //actor mapper
      CreateMap<Actor, GetActorsQueryViewModel>();
      CreateMap<CreateActorModel, Actor>();
      CreateMap<Actor, GetActorMovieViewModel>()
          .ForMember(dest => dest.NameSurName, opt => opt.MapFrom(m => m.Name + " " + m.SurName))
          .ForMember(dest => dest.Movies, opt => opt.MapFrom(m => m.ActorMovies.Select(s => s.Movie.Name)));

      //actor movie mapper
      CreateMap<CreateActorMovieModel, ActorMovie>();           

      //director mapper    
      CreateMap<Director, DirectorQueryViewModel>()
          .ForMember(dest => dest.NameSurname, opt => opt.MapFrom(m => m.Name + " " + m.SurName));
          //.ForMember(dest => dest.Movies, opt => opt.MapFrom(m => m.ActorMovies.Select(s => s.Movie.Name))); 
      CreateMap<DirectorModel, Director>();

      //director movie mapper
      CreateMap<Director, GetDirectorMovieViewModel>()
          .ForMember(dest => dest.NameSurName, opt => opt.MapFrom(m => m.Name + " " + m.SurName))
          .ForMember(dest => dest.Movies, opt => opt.MapFrom(m => m.DirectorMovies.Select(s => s.Movie.Name)));
      CreateMap<DirectorMovieModel, DirectorMovie>();

      //customer mapper
      CreateMap<Customer, CustomerQueryViewModel>();
      CreateMap<CustomerModel, Customer>();

      //purchased movies mapper
      CreateMap<PurchasedMoviesModel, PurchasedMovie>();
      CreateMap<Customer, PurchasedMoviesViewModel>()
          .ForMember(dest => dest.NameSurname , opt => opt.MapFrom(m => m.Name + " " + m.SurName))
          .ForMember(dest => dest.Movies, opt => opt.MapFrom(m => m.PurchasedMovies.Select(s => s.Movie.Name)))
          .ForMember(dest => dest.Price, opt => opt.MapFrom(m => m.PurchasedMovies.Select(s => s.Movie.Price)))
          .ForMember(dest => dest.PurchasedDate, opt => opt.MapFrom(m => m.PurchasedMovies.Select(s => s.purchasedTime)));
          

      //favorites genre mapper
       CreateMap<Customer, FavoritesGenreQueryViewModel>()
          .ForMember(dest => dest.NameSurname , opt => opt.MapFrom(m => m.Name + " " + m.SurName))
          .ForMember(dest => dest.Genres, opt => opt.MapFrom(m => m.FavoritesGenres.Select(s => (Genre)s.Genre)));
      CreateMap<FavoriteGenresModel, FavoritesGenre>();

      //Genres mapper
      CreateMap<Genre,GenresViewModel>();
      CreateMap<Genre,GenreViewModel>();

    }
  }
}