using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToolsWebApplication.Models;

namespace ToolsWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Tools()
        {
            ViewData["Message"] = "さいきょうつーるしゅう";

            return View();
        }

        public IActionResult SplitApp()
        {
            ViewData["Message"] = "csvファイル分割";

            return View();
        }

        public IActionResult InsertApp()
        {
            ViewData["Message"] = "insert文生成";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
