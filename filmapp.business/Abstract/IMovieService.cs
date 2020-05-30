using System.Collections.Generic;
using filmapp.entity;

namespace filmapp.business.Abstract
{
    public interface IMovieService
    {
        Movie GetById(int id);
        List<Movie> GetAll();
        void Create(Movie entity);
        void Update(Movie entity);
        void Delete(Movie entity); 
    }
}