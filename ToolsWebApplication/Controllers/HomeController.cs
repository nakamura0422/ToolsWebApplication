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
        // m付けた方がええか？
        Split split = new Split();
        List<string> lst = new List<string>();


        /// <summary>
        /// ホーム
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// ツールがいっぱいあるとこ
        /// </summary>
        /// <returns></returns>
        [Route("Home/Tools")]
        public IActionResult Tools()
        {
            ViewData["Message"] = "さいきょうつーるしゅう";

            return View();
        }

        /// <summary>
        /// csv分割
        /// </summary>
        /// <returns></returns>
        [Route("Home/SplitApp")]
        public IActionResult SplitApp()
        {
            ViewData["Message"] = "csvファイル分割";

            
            ViewBag.List = lst;

            return View();
        }

        /// <summary>
        /// 分割してなんかにつめてリダイレクトするんかね？
        /// </summary>
        /// <param name="csvData"></param>
        /// <returns></returns>
        public ActionResult SplitCSV(string droppable)
        {
            // そもそもなんか入ってる？
            if (droppable == null)
            {
                ViewData["Message"] = "csvが無いかcsvの中身が空ですよ";
                ViewBag.List = lst;
                return View("SplitApp");
            }
            else
            {
                // ヘッター
                var header = droppable
                                .Split(',')
                                .Divide(3)
                                .Take(1);

                // 3分割した奴にヘッター付けた列挙
                // ヘッター付けるのが遅れたから汚いかも
                var ret = droppable
                                .Split(',')
                                .Divide(3)
                                .Skip(1)
                                .Divide(2)
                                .SelectMany(x => new[] { header.Concat(x) })
                                .Divide(3)
                                .Select(x => x);

                // モデルに詰めてみる
                split.Text = ret.SelectMany(x => x.SelectMany(y => y));


                // ViewBagに詰めてみる
                // ほんとはIEnumerable<IEnumerable<string>>で送りたかった（　＾ω＾）・・・
                foreach (var a in ret.SelectMany(x => x.SelectMany(y => y)))
                    foreach (var b in a)
                        lst.Add(b);
                ViewBag.List = lst;

                return View("SplitApp");

                //---R.I.P---
                //Dictionaryに詰めてみる
                //Dictionary<long, string[]> datas = new Dictionary<long, string[]>();
                //int i = 1;
                //foreach (var a in retret.SelectMany(x => x.SelectMany(y => y)))
                //{
                //    datas.Add(i, a.ToArray());
                //    i++;
                //}

                //---R.I.P---
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

        /// <summary>
        /// /Downloadにアクセスしたときに今のモデルのデータをファイルで吐き出してzipをダウンロードさせる
        /// </summary>
        /// <returns></returns>
        [Route("Home/SplitCSV/Download")]
        public ActionResult Download()
        {
            // モデルからget
            var data = split.Text;

            if (data == null)
            {
                ViewBag.List = lst;
                ViewData["Message"] = "モデルの中になんもないよ";
                  return View("SplitApp");
            }
            else
            {
                ViewBag.List = lst;
                // fileNameの設定
                var fileName = string.Format("{0:yyyyMMdd}", DateTime.Now);

                using (var file = new FileStream($"{fileName}.txt", FileMode.Create))
                using (var writer = new StreamWriter(file, Encoding.UTF8))
                {
                    writer.Write("あいうえお");
                }

                //return File(GetData(), "text/csv", fileName);
                return View("SplitApp");
            }
        }

        /// <summary>
        /// インサート文生成
        /// </summary>
        /// <returns></returns>
        public IActionResult InsertApp()
        {
            ViewData["Message"] = "insert文生成";

            return View();
        }

        /// <summary>
        /// デフォルトでついてきたやつ
        /// </summary>
        /// <returns></returns>
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
