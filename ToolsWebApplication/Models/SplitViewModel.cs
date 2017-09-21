using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToolsWebApplication.Models
{
    /// <summary>
    /// Split��VM
    /// </summary>
    public class SplitViewModel
    {
        public IEnumerable<Split> Items { get; set; }
    }
}