using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TARSTestGustavoNascimento.Infraestructure.Interface;
using TARSTestGustavoNascimento.Models;


namespace TARSTestGustavoNascimento
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signManager;
        private readonly IConfiguration _config;
        private readonly IUserClaimsPrincipalFactory<UserModel> _userClaimsPrincipalFactory;
        public IUserRepository _repository { get; }
        public IHttpContextAccessor _httpContextAccessor { get; }

        public UserController(IConfiguration config, ILogger<UserController> logger, UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, IUserRepository repository, IUserClaimsPrincipalFactory<UserModel> userClaimsPrincipalFactory, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _repository = repository;
            //_userClaims = userClaims;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _userManager = userManager;
            _signManager = signInManager;


        }
        public async Task<IActionResult> Index()
        {

            return View(await _repository.GetAllAsync());
        }

        [HttpGet()]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost()]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                var resultLogin = await _signManager.CheckPasswordSignInAsync(user, model.Password, false);

                if (resultLogin.Succeeded)
                {
                    var appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == user.UserName.ToUpper());

                    var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

                    await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, principal);

                    return RedirectToAction("Index", "Home");
                }
                else
                {

                    ModelState.AddModelError("", "Password Incorret");
                    return View();
                }
            }
            ModelState.AddModelError("", "Have a probleman with parameters");
            return View();
        }

        [HttpGet()]
        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user == null)
                {

                    user = new UserModel()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = model.UserName,
                        PasswordHash = model.Password,
                        Email = model.Email,
                        departament = model.departament,
                        fullname = model.UserName

                    };

                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {

                        string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies[".AspNetCore.Identity.Application"];

                        if (string.IsNullOrEmpty(cookieValueFromContext))
                        {
                            var appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == user.UserName.ToUpper());

                            var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

                            await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, principal);
                        }
                        ViewBag.Success = "User created with success";
                        return View("Index", await _repository.GetAllAsync());
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User existend");
                    return View();
                }
            }
            ModelState.AddModelError("", "Have a probleman with parameters");
            return View();
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(string? id)
        {
            RegisterModel user;
            if (id != null)
            {
                var useraux = await _userManager.FindByIdAsync(id);

                if (useraux != null)
                {
                    user = new RegisterModel
                    {
                        Email = useraux.Email,
                        departament = useraux.departament,
                        UserName = useraux.UserName,
                        Password = useraux.PasswordHash,
                        fullname = useraux.fullname
                    };
                    return PartialView(user);
                }
            }
            else
            {

                ModelState.AddModelError("", "User not found");
                return View();
            }
            ModelState.AddModelError("", "Have a error in method of delete");
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (id != null)
            {
                var user = await _userManager.FindByIdAsync(id);

                if (user != null)
                {

                    var result = await _userManager.DeleteAsync(user);

                    if (result.Succeeded)
                    {
                        ViewBag.Success = "Deleted with successed";
                        return View("Index", await _repository.GetAllAsync());
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User not localized");
                    return View();
                }
            }
            ModelState.AddModelError("", "Id not localized");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string? id)
        {

            if (!String.IsNullOrEmpty(id))
            {
                RegisterModel user;

                var _user = await _userManager.FindByIdAsync(id);

                if (_user != null)
                {
                    user = new RegisterModel
                    {
                        Email = _user.Email,
                        departament = _user.departament,
                        UserName = _user.UserName,
                        Password = _user.PasswordHash,
                        fullname = _user.fullname,
                        TitlePage = "Detail User"
                    };
                    return View("Register", user);
                }
            }
            else
            {
                ModelState.AddModelError("", "User not found");
                return View();
            }
            ModelState.AddModelError("", "Id not localized");
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                RegisterModel user;

                var _user = await _userManager.FindByIdAsync(id);

                if (_user != null)
                {
                    user = new RegisterModel
                    {
                        Email = _user.Email,
                        departament = _user.departament,
                        UserName = _user.UserName,
                        Password = _user.PasswordHash,
                        fullname = _user.fullname,
                        TitlePage = "Detail User"
                    };
                    return View(user);
                }
                else
                {
                    ModelState.AddModelError("", "User not found");
                    return View();
                }

            }

            ModelState.AddModelError("", "Have a error in method of Edit");
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegisterModel model)
        {

            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {

                    var resultLogin = await _signManager.CheckPasswordSignInAsync(user, model.Password, false);

                    if (resultLogin.Succeeded)
                    {

                        user.UserName = model.UserName;
                        user.Email = model.Email;
                        user.departament = model.departament;
                        user.fullname = model.UserName;


                        var result = await _userManager.UpdateAsync(user);

                        if (result.Succeeded)
                        {
                            ViewBag.Success = "User altered with successed";
                            return View("Index", await _repository.GetAllAsync());
                        }
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                        return View();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Password incorrect");
                        return View();
                    }

                }
            }

            ModelState.AddModelError("", "Have a error in method of Edit");

            return View(await _repository.GetAllAsync());
        }
        public async Task<IActionResult> Error()
        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }

}