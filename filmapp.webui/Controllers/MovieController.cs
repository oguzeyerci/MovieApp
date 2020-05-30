using System;
using System.Collections.Generic;
using System.Linq;
using filmapp.business.Abstract;
using filmapp.entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace filmapp.webui.Controllers
{
    [Authorize]
    public class MovieController:Controller
    {
        
       
       private IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            this._movieService=movieService;
        }
       public IActionResult Details(int? id){
           if(id==null)
           {
               return NotFound();
           }
           var abc = _movieService.GetById((int)id);
           return View(abc);
       }
       
       public IActionResult list(string id,string q,int page=1){

            var movies =_movieService.GetAll();
            int a=movies.Count();
            if (!string.IsNullOrEmpty(id))
            {
                movies = movies.Where(p => p.Category.Contains(id)).ToList();
                a=movies.Count();
                ViewBag.CurrentCategory=id;
            }
            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(p => p.Name.ToLower().Contains(q.ToLower()) || p.Stars.ToLower().Contains(q.ToLower()) || p.Director.ToLower().Contains(q.ToLower()) ).ToList();
                a=movies.Count();
            }
            ViewBag.CurrentPage=page;
            ViewBag.Pages=((int)Math.Ceiling((decimal)a/6)); //HER SAYFADA MAX 6 FİLM ŞUAN
            var siralimovies = movies.OrderBy(x=>x.Name);
            return View(siralimovies.Skip((page-1)*6).Take(6).ToList());
       }

       
     
    }
}