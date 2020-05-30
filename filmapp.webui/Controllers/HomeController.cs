using System;
using System.Collections.Generic;
using System.Linq;
using filmapp.business.Abstract;
using filmapp.data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace filmapp.webui.Controllers
{
    public class HomeController:Controller
    {
        private IMovieService _movieService;

        public HomeController(IMovieService movieService)
        {
            this._movieService=movieService;
        }
        
        public IActionResult Index(){
            
           var movies =_movieService.GetAll();
           var siralimovies = movies.OrderByDescending(x=>x.MovieId).ToList();
           return View(siralimovies.Take(9).ToList());
       }
        
    }
}