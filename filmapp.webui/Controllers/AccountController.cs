using System;
using System.Threading.Tasks;
using filmapp.webui.EmailServices;
using filmapp.webui.Identity;
using filmapp.webui.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace filmapp.webui.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _usermanager;
        private SignInManager<User> _signInManager;
        private IEmailSender _emailsender;
        public AccountController(UserManager<User> usermanager, SignInManager<User> signInManager,IEmailSender emailsender)
        {
            _usermanager = usermanager;
            _signInManager = signInManager;
            _emailsender=emailsender;
        }
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginModel()
            {
                ReturnUrl = returnUrl
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //var user=await _usermanager.FindByNameAsync(model.UserName);
            var user = await _usermanager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı Bulunamadı");
                return View(model);
            }
            if(!await _usermanager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Mailinizi Onaylayınız!");
                return View(model);   
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl ?? "~/");
            }
            ModelState.AddModelError("", "Kullanıcı adı veya parola hatalı!");
            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _usermanager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var code= await _usermanager.GenerateEmailConfirmationTokenAsync(user);
                var url = Url.Action("ConfirmEmail","Account",new{
                    userId=user.Id,
                    token=code
                });
                await _emailsender.SendEmailAsync(model.Email,"Hesabınızı Onaylayınız",$"Lütfen email adresinizi doğrulamak için linke <a href='https://localhost:5001{url}'>tıklayınız.</a>");
                //mail yolla
                TempData["message"] = "Mailinizi kontrol ediniz.";
                return RedirectToAction("Login", "Account");
            }
            ModelState.AddModelError("Password", "Bilinmeyen Hata.");
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> ConfirmEmail(string userId,string token)
        {
            if(userId==null || token==null)
            {
                TempData["message"] = "Geçersiz Token.";
                return View();
            }
            var user= await _usermanager.FindByIdAsync(userId);
            if(user!=null)
            {
                var result=await _usermanager.ConfirmEmailAsync(user,token);
                if(result.Succeeded)
                {
                TempData["message"] = "Hesabınız Onaylandı.";
                return View();
                }
            }
            
            TempData["message"] = "Hesabınız Onaylanmadı.";
            return View();
        }
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(string Email)
        {
            if(string.IsNullOrEmpty(Email))
            {
                return View();
            }
            var user = await _usermanager.FindByEmailAsync(Email);
            if(user==null){
                return View();
            }
            var code = await _usermanager.GeneratePasswordResetTokenAsync(user);
            var url = Url.Action("ResetPassword","Account",new{
                userId=user.Id,
                token=code
            });
            await _emailsender.SendEmailAsync(Email,"Parolanızı Sıfırlayın",$"Lütfen parolanızı sıfırlamak için linke <a href='https://localhost:5001{url}'>tıklayınız.</a>");
            TempData["message"] = "Mailinizi kontrol ediniz.";    
            return View();
             
        }
        public IActionResult ResetPassword(string userId,string token)
        {
            if(userId==null || token==null)
            {
            return RedirectToAction("Index", "Home");
            }
            var model = new ResetPasswordModel{
                Token=token
            };
            return View();
        } 
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if(!ModelState.IsValid){
                return View();
            }
            var user = await _usermanager.FindByEmailAsync(model.Email);
            if(user==null){
            return RedirectToAction("Index", "Home");
            }
            var result=await _usermanager.ResetPasswordAsync(user,model.Token,model.Password);
            if(result.Succeeded){
                TempData["message"] = "Parolanız başarıyla sıfırlandı.";
                return RedirectToAction("Login","Account");
            }
            TempData["message"] = "Eski bir sıfırlama linki denediniz."; 
            return View(model);
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
    
}