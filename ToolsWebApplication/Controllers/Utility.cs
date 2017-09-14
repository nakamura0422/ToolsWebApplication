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
        /// ファイルに書く
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

        /// <summary>   
        /// 対象のシーケンスを分割、余りは切り捨て
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="datas"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Divide<T>(this IEnumerable<T> datas, int value)
        {
            if (datas == null)
                // そもそも分割するdatasが無いのはおかしくね? 
                // Exceptionを出して、使った人に告知してあげようかな
                throw new ArgumentNullException();

            // 要素が無いとbreak
            if (!datas.Any())
                yield break;

            // value分だけをyield return
            yield return datas.Take(value);

            // 上の処理でTakeした分だけSkipしたものから再帰して自分REST@RT
            foreach (var s in datas.Skip(value).Divide(value))
                // きちんと分割できるか判定
                if (value == s.Count())
                    // 分割したものを各自yield return
                    yield return s;
        }

        /// <summary>
        /// 縦列でもってくる
        /// 
        /// ---input
        /// id
        /// name
        /// 1
        /// A
        /// 2
        /// B
        /// 
        /// ---output
        /// id,1,2
        /// name,A,B
        /// 
        /// にしたい
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="datas"></param>
        /// <param name="columnCount"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Column<T>(this IEnumerable<T> datas , int columnCount)
        {
            // データが無いとき
            if (datas == null)
                throw new ArgumentNullException();

            // 探索する列が無い時
            if (columnCount == 0)
                yield break;

            while (datas.Any())
            {
                yield return datas.Take(1);
                columnCount--;
                datas = datas.Skip(columnCount);
            }
            Column(datas, columnCount);
        } 
    }
}
