using System.Collections.Generic;
using filmapp.data.Abstract;
using filmapp.entity;

namespace filmapp.data.Concrete.EfCore
{
    public class EfCoreMovieRepo : EfCoreGenericRepo<Movie, FilmSiteContext>, IMovie
    {
       
    }
}