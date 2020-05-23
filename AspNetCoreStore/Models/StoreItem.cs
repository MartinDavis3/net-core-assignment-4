﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreStore.Models
{
    public class StoreItem
    {
        public Guid Id { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public bool InCart { get; set; }
        public int Quantity { get; set; }
    }
}
