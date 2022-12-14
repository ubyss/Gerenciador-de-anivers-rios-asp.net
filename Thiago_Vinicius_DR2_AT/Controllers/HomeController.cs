using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Thiago_Vinicius_DR2_AT.Models;

namespace Thiago_Vinicius_DR2_AT.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}