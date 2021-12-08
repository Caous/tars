using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TARSTestGustavoNascimento.Infraestructure.Interface;
using TARSTestGustavoNascimento.Models;


namespace TARSTestGustavoNascimento
{

    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signManager;
        public IUserRepository _repository { get; }
        public UserController(ILogger<UserController> logger, UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, IUserRepository repository)

        {
            _repository = repository;
            _logger = logger;
            _userManager = userManager;
            _signManager = signInManager;
            

        }
        public async Task<IActionResult> Index()
        {

            return View(await _repository.GetAllAsync());
        }


        [HttpGet()]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
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
            }

            ModelState.AddModelError("", "Houve um erro");
            return View();
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(string? id)
        {
            RegisterModel user;
            if (id == null)
            {
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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
            ModelState.AddModelError("", "Houve um erro ao localizar o usuário");
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {

            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {

                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return View("Index", await _repository.GetAllAsync());
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string? id)
        {

            if (!String.IsNullOrEmpty(id))
            {
                RegisterModel user;

                var useraux = await _userManager.FindByIdAsync(id);

                if (useraux != null)
                {
                    user = new RegisterModel
                    {
                        Email = useraux.Email,
                        departament = useraux.departament,
                        UserName = useraux.UserName,
                        Password = useraux.PasswordHash,
                        fullname = useraux.fullname,
                        TitlePage = "Detail User"
                    };
                    return View("Register", user);
                }
            }
            ModelState.AddModelError("", "Houve um erro ao localizar o usuário");
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                RegisterModel user;

                var useraux = await _userManager.FindByIdAsync(id);

                if (useraux != null)
                {
                    user = new RegisterModel
                    {
                        Email = useraux.Email,
                        departament = useraux.departament,
                        UserName = useraux.UserName,
                        Password = useraux.PasswordHash,
                        fullname = useraux.fullname,
                        TitlePage = "Detail User"
                    };
                    return View(user);
                }
            }
            ModelState.AddModelError("", "Houve um erro ao localizar o usuário");
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
                    // var checkedPass = await _userManager.CheckPasswordAsync(user, model.Password);
                    // if (checkedPass)
                    // {

                    user.UserName = model.UserName;
                    user.PasswordHash = model.Password;
                    user.Email = model.Email;
                    user.departament = model.departament;
                    user.fullname = model.UserName;
                    // user = new UserModel()
                    // {
                    //     UserName = model.UserName,
                    //     PasswordHash = model.Password,
                    //     Email = model.Email,
                    //     departament = model.departament,
                    //     fullname = model.UserName

                    // };

                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        return View("Index", await _repository.GetAllAsync());
                    }
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View();
                    // }
                    // else
                    // {
                    //     ModelState.AddModelError("", "Senha não confere");
                    //     return View();
                    // }

                }
            }

            ModelState.AddModelError("", "Houve um erro");

            return View("Index", await _repository.GetAllAsync());
        }
        public async Task<IActionResult> Error()
        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}