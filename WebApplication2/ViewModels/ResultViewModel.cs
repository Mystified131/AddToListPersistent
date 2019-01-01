using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class ResultViewModel
    {
        [Required]
        public String NewElement { get; set; }
        public List<Listelement> TheList { get; set; }
    }
}
