using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using filmapp.business.Abstract;
using filmapp.entity;
using filmapp.webui.Identity;
using filmapp.webui.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace filmapp.webui.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        private IMovieService _movieService;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;

        public AdminController(IMovieService movieService,RoleManager<IdentityRole> roleManager,UserManager<User> userManager)
        {
            this._movieService=movieService;
            this._roleManager=roleManager;
            this._userManager=userManager;
        }
        public async Task<IActionResult> UserEdit(string id)
        {
            var user= await _userManager.FindByIdAsync(id);
            if(user!=null)
            {
                var selectedroles= await _userManager.GetRolesAsync(user);
                var roles = _roleManager.Roles.Select(i=>i.Name);

                ViewBag.Roles=roles;
                return View(new UserDetailModel(){
                    UserId=user.Id,
                    UserName=user.UserName,
                    FirstName=user.FirstName,
                    LastName=user.LastName,
                    Email=user.Email,
                    EmailConfirmed=user.EmailConfirmed,
                    SelectedRoles=selectedroles
                });
            }    
            return Redirect("~/Admin/UserList");    
        }
        [HttpPost]
        public async Task<IActionResult> UserEdit(UserDetailModel model,string[] selectedRoles)
        {
            if(ModelState.IsValid)
            {
                var user=await _userManager.FindByIdAsync(model.UserId);
                if(user!=null)
                {
                    user.FirstName=model.FirstName;
                    user.LastName=model.LastName;
                    user.Email=model.Email;
                    user.UserName=model.UserName;
                    user.EmailConfirmed=model.EmailConfirmed;
                    
                    var result=await _userManager.UpdateAsync(user);

                    if(result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        selectedRoles=selectedRoles??new string[]{};
                        await _userManager.AddToRolesAsync(user,selectedRoles.Except(userRoles).ToArray<string>());
                        await _userManager.RemoveFromRolesAsync(user,userRoles.Except(selectedRoles).ToArray<string>());
                        Console.WriteLine(model.EmailConfirmed);
                        TempData["message"]=$"{model.UserName} başarıyla güncellendi.";
                        return Redirect("/Admin/UserList");
                    }
                }
                return Redirect("/Admin/UserList");
            }
            return View(model);
        }
        public IActionResult UserList()
        {
            return View(_userManager.Users);    
        }
        public async Task<IActionResult> RoleEdit(string id)
        {
            var role=await _roleManager.FindByIdAsync(id);
            var members= new List<User>();
            var nonmembers= new List<User>();
            foreach(var user in _userManager.Users)
            {
                var list=await _userManager.IsInRoleAsync(user,role.Name)?members:nonmembers;
                list.Add(user);
            }
            var model=new RoleDetails(){
                Role=role,
                Members=members,
                NonMembers=nonmembers
            };

            return View(model);
            
        }
        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleEditModel model)
        {
            if(ModelState.IsValid){
                foreach(var userId in model.IdsToAdd ??new string[]{})
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if(user!=null)
                    {
                        var result=await _userManager.AddToRoleAsync(user,model.RoleName);
                        if(result.Succeeded)
                        {
                            foreach(var error in result.Errors)
                            {
                                ModelState.AddModelError("",error.Description);
                            }
                        }
                    }
                }
                foreach(var userId in model.IdsToDelete ??new string[]{})
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if(user!=null)
                    {
                        var result=await _userManager.RemoveFromRoleAsync(user,model.RoleName);
                        if(result.Succeeded)
                        {
                            foreach(var error in result.Errors)
                            {
                                ModelState.AddModelError("",error.Description);
                            }
                        }
                    }
                }
            }
            return Redirect("/Admin/RoleEdit/"+model.RoleId);
        }
        public IActionResult RoleList()
        {
            return View(_roleManager.Roles);
        }
        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleModel model)
        {
            if(ModelState.IsValid)
            {
                var result= await _roleManager.CreateAsync(new IdentityRole(model.Name));
                if(result.Succeeded)
                {
                    TempData["message"]=$"{model.Name} başarıyla eklendi.";
                    return RedirectToAction("RoleList");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("",error.Description);
                    }
                }
            }
            return View(model);
        }

        public IActionResult MovieList()
        {
            Console.WriteLine();
            var movies =_movieService.GetAll();
            return View(movies);
        }
        public IActionResult createMovie(){
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> createMovie(MovieModel movie,IFormFile file){
            if(ModelState.IsValid)
            {
                var entity=new Movie(){
                    Name=movie.Name,
                    Category=movie.Category,
                    Review=movie.Review,
                    Stars=movie.Stars,
                    Year=movie.Year,
                    Director=movie.Director
                };
                if(file!=null)
                {
                    entity.ImageUrl = file.FileName;
                    var path= Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\images",file.FileName);
                    var path2= Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\images","1-"+file.FileName);
                    using(var stream= new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream);  
                    }
                    using(var stream= new FileStream(path2,FileMode.Create))
                    {
                        await file.CopyToAsync(stream);  
                    }
                }

                _movieService.Create(entity);

                TempData["message"]=$"{entity.Name} başarıyla eklendi.";
                
                return RedirectToAction("MovieList");
            }
            return View(movie);
        }
        public IActionResult Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var entity = _movieService.GetById((int)id);

            if(entity==null)
            {
                return NotFound();
            }
            var model = new MovieModel(){
                MovieId=entity.MovieId,
                Name=entity.Name,
                Category=entity.Category,
                Review=entity.Review,
                Year=entity.Year,
                Stars=entity.Stars,
                Director=entity.Director,
                ImageUrl=entity.ImageUrl
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MovieModel model,IFormFile file)
        {    
            if(ModelState.IsValid)
            {
                var entity = _movieService.GetById(model.MovieId);
                if(entity==null)
                {
                    return NotFound();
                }
                entity.Name=model.Name;
                entity.Category=model.Category;
                entity.Director=model.Director;
                entity.Stars=model.Stars;
                entity.Year=model.Year;
                entity.Review=model.Review;

                if(file!=null)
                {
                    entity.ImageUrl = file.FileName;
                    var path= Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\images",file.FileName);
                    var path2= Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\images","1-"+file.FileName);
                    using(var stream= new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream);  
                    }
                    using(var stream= new FileStream(path2,FileMode.Create))
                    {
                        await file.CopyToAsync(stream);  
                    }
                }

                _movieService.Update(entity);

                TempData["message"]=$"{entity.Name} başarıyla güncellendi.";
                return RedirectToAction("MovieList");
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(int movieId)
        {
            var entity = _movieService.GetById(movieId);
            if(entity!=null)
            {
                _movieService.Delete(entity);
            }
            TempData["message"]=$"{entity.Name} başarıyla silindi.";
            return RedirectToAction("MovieList");
        }
    }
}