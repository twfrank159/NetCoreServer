using System;
using System.Collections.Generic;

#nullable disable

namespace L5_Swagger.Models
{
    public partial class Cat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public bool? Cute { get; set; }
    }
}
