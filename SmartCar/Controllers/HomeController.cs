using Business.Concrete;
using Business.ValidationRules;
using Core.Entities.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Dto;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartCar.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginDto login)
        {
            var user = userManager.UserExist(login);
            if(user!=null)
            {
                return RedirectToAction("ListofCarParks");
            }
            return View();
        }
        
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
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
            reservation.userId = 1;
            reservation.date = DateTime.Now;
            reservationManager.TAdd(reservation);
            spotManager.UpdateFulById(reservation.spotId);
            return RedirectToAction("ListofCarParks");
        }
    }
}
