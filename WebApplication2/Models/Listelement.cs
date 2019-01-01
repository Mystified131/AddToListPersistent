using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Listelement
    {
        public int ID { get; set; }
        public string Element { get; set; }


        public Listelement(string element)
        {
            Element = element;
        }
    }
}
