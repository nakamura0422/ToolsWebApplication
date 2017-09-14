using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToolsWebApplication.Models;
using System.Text;

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

        /// <summary>
        /// dragoverない
        /// 分割してなんかにつめてリダイレクトするんかね？
        /// </summary>
        /// <param name="csvData"></param>
        /// <returns></returns>
        public ActionResult SplitCSV(string droppable)
        {
            if(droppable == null)
            {
                ViewData["Message"] = "csvが無いかcsvの中身が空ですよ";
                return View("SplitApp");
            }
            else
            {
                IEnumerable<string> data = droppable
                        .Split(",");

                var a = data.Column(3);

                ViewData["csvData"] = a;
                return View("SplitApp");
            }
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
