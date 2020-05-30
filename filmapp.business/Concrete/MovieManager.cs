using System.Collections.Generic;
using filmapp.business.Abstract;
using filmapp.data.Abstract;
using filmapp.data.Concrete.EfCore;
using filmapp.entity;

namespace filmapp.business.Concrete
{
    public class MovieManager : IMovieService
    {
        private IMovie _movieRepo;
        public MovieManager(IMovie movieRepo)
        {
            _movieRepo=movieRepo;
        }
        
        public void Create(Movie entity)
        {
            _movieRepo.Create(entity);
        }

        public void Delete(Movie entity)
        {
            _movieRepo.Delete(entity);
        }

        public List<Movie> GetAll()
        {
            return _movieRepo.GetAll();
        }

        public Movie GetById(int id)
        {
            return _movieRepo.GetById(id);
        }

        public void Update(Movie entity)
        {
            _movieRepo.Update(entity);
        }
    }
}