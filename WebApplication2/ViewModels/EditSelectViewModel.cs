﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class EditSelectViewModel
    {
        [Required]
        public int NewElement1 { get; set; }
        public List<Listelement> TheList { get; set; }
    }
}
