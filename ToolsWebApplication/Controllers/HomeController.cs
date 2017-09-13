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
        /// 分割してなんかにつめてリダイレクトするんかね？
        /// </summary>
        /// <param name="csvData"></param>
        /// <returns></returns>
        public ActionResult SplitCSV(string[] csvData)
        {
            //ファイルを読み込んで必要な部分のみを取得
            var data = csvData;
            //.Skip(1)
            //.Select(x => x.Split(','));

            ViewData["csvData"] = data;
            //new Split
            //{
               
            //};
            return RedirectToAction("SplitApp");
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
