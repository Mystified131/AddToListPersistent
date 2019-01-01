using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.ViewModels
{
    public class EditItemViewModel
    {
        [Required]
        public string NewElement2 { get; set; }
        public List<string> TheList { get; set; }
    }
}
