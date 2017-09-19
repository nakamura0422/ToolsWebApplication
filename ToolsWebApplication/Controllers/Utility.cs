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
        /// 〇id
        /// name
        /// 〇1
        /// A
        /// 〇2
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
        public static IEnumerable<IEnumerable<T>> OneColumnSerecter<T>(this IEnumerable<T> datas, int columnCount)
        //public static IEnumerable<IEnumerable<T>> Column<T>(this IEnumerable<T> datas, int columnCount, int takeColumn)
        {
            //---R.I.P---
            //// データが無いとき
            //if (datas == null)
            //    throw new ArgumentNullException();

            //// 探索する列が無い時
            //if (columnCount == 0)
            //    yield break;

            //while (datas.Any())
            //{
            //    yield return datas.Take(1);
            //    columnCount--;
            //    datas.Skip(columnCount).Column(columnCount);
            //}
            //Column(datas, columnCount);
            //------
            //---R.I.P--- 一列目の列挙しか生成できない
            if (datas == null)
                throw new ArgumentNullException();

            // 要素が無いとbreak
            if (!datas.Any())
                yield break;

            // value分だけをyield return
            yield return datas.Take(1);

            foreach (var s in datas.Skip(columnCount).OneColumnSerecter(columnCount))
                yield return s;
            //------

            //if (datas == null)
            //    throw new ArgumentNullException();

            //for ()

        }

        /// <summary>
        /// 1列バイバイされた列挙になる
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="datas"></param>
        /// <param name="columnCount"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> OneArrayDeletion<T>(this IEnumerable<T> datas, int columnCount)
        {
            if (datas == null)
                throw new ArgumentNullException();

            datas.Skip(1);
            columnCount--;

            if (datas.Any())
            {
                yield return datas.Take(columnCount);
                datas.Skip(1);
            }
        }
       
    }

}
