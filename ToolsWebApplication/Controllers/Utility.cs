using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToolsWebApplication.Models;
using System.IO;

namespace ToolsWebApplication
{
    public static class Utility
    {
        /// <summary>
        /// ファイルを書くだしますよ
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="file"></param>
        public static void WriteFile<T>(T file)
        {
            //string filepath = Server.MapPath("~/App_Data/hoge.txt");
            //using (var fout = new StreamWriter(filepath, false))
            //{
            //    fout.WriteLine(file);
            //}
        }
    }
}
