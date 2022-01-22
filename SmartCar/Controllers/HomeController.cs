using Business.Concrete;
using Business.ValidationRules;
using Core.Entities.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Dto;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartCar.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartCar.Controllers
{
    public class HomeController : Controller
    {
        ParkManager parkManager = new ParkManager(new EfParkDal());
        ReservationManager reservationManager = new ReservationManager(new EfReservationDal());
        SpotManager spotManager = new SpotManager(new EfSpotDal());
        UserManager userManager = new UserManager(new EfUserDal());


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(LoginDto login)
        {
            var user = userManager.UserExist(login);
            if(user!=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.ID.ToString())
                };
                var userIdentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("ListofCarParks");
            }
            return View();
        }
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult SignUp(SignUpDto signUpDto)
        {
            RegisterValidator registerValidator = new RegisterValidator();
            ValidationResult results = registerValidator.Validate(signUpDto);
            if (results.IsValid)
            {
                User user = new User()
                {
                    FirstName = signUpDto.FirstName,
                    LastName = signUpDto.LastName,
                    Email = signUpDto.Email,
                    Password = signUpDto.Password,
                    Status = true,
                };
                userManager.TAdd(user);
                return RedirectToAction("Index");
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }

        public IActionResult ListofCarParks()
        {
            var parks = parkManager.GetList();
            return View(parks);
        }

        [HttpGet]
        public IActionResult ListOfSpots(int id)
        {
            var values = spotManager.GetListByParkID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult ListOfSpots(Reservation reservation)
        {
            reservation.userId = Convert.ToInt32(User.Identity.Name);
            reservation.date = DateTime.Now;
            reservationManager.TAdd(reservation);
            spotManager.UpdateFulById(reservation.spotId);
            return RedirectToAction("ListofCarParks");
        }

        public IActionResult Profile()
        {
            ProfileD profile = new ProfileD();
            profile.profile = userManager.GetUser(Convert.ToInt32(User.Identity.Name));
            profile.user = userManager.GetByID(Convert.ToInt32(User.Identity.Name));
            return View(profile);
        }
    }
}
