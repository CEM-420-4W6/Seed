﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Cat
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual DemoUser? DemoUser { get; set; }
        [JsonIgnore]
        public virtual List<House> Houses { get; set; } = new List<House>();
    }
}
