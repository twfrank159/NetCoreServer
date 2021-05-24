using System;
using System.Collections.Generic;

#nullable disable

namespace L3_DBEntityFramework.Models
{
    public partial class Cat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public bool? Cute { get; set; }
    }
}
