using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Model.Data
{
    public class Country
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public int Number { get; set; }
        public string City { get; set; }

    }
}
