using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToolsWebApplication.Models;
using System.Text;
using System.IO;

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

            var lst = new List<string>();
            ViewBag.List = lst;

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
            if (droppable == null)
            {
                ViewData["Message"] = "csvが無いかcsvの中身が空ですよ";
                return View("SplitApp");
            }
            else
            {
                IEnumerable<string> data = droppable.Split(',');

                var header = data
                            .Divide(3)
                            .Take(1);

                var ret = data.Divide(3)
                            .Skip(1)
                            .Divide(2)
                            .SelectMany(x => new[] { header.Concat(x) })
                            .Divide(3)
                            .Select(x => x);

                var lst = new List<string>();
                foreach (var a in ret.SelectMany(x => x.SelectMany(y => y)))
                {
                    foreach (var b in a)
                        lst.Add(b);
                }
                ViewBag.List = lst;

                return View("SplitApp");

                // モデルに詰めてみる
                //Split split = new Split();
                //foreach (var a in ret.SelectMany(x => x.SelectMany(y => y)))
                //{
                //    split.Text = a.ToArray();
                //}



                //Dictionary<long, string[]> datas = new Dictionary<long, string[]>();
                //int i = 1;
                //foreach (var a in retret.SelectMany(x => x.SelectMany(y => y)))
                //{
                //    datas.Add(i, a.ToArray());
                //    i++;
                //}


                //int c = 0;
                //foreach (var a in retret.SelectMany(x => x.SelectMany(y => y)))
                //    System.IO.File.WriteAllLines(path: $"data /{c++}.txt", contents: a, encoding: Encoding.Default);

                //---R.I.P---
                //foreach(var a in retret)
                //    foreach(var s in a)
                //        foreach (var ss in s)
                //            System.IO.File.WriteAllLines(path: $"data /{c++}.txt", contents: ss, encoding: Encoding.Default);
            }
        }

        //[HttpPost]
        //public ActionResult SplitCSV(Split<long, string[]>Split)
        //{
        //    return View(Split);
        //}

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
