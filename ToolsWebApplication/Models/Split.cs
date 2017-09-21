using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToolsWebApplication.Models
{
    /// <summary>
    /// csv分割したデータのモデル
    /// </summary>
    public class Split
    {
        // longのIdがモデルには絶対に必要だとかカエルに教わった気がする
        // public long Id { get; set; }

        // 本体 
        // 名前はなんて付けていいかわからんかった
        [Required]
        public IEnumerable<string> Text { get; set; }
    }
}