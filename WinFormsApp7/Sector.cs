using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp7
{
    internal class Sector
    {
        public static int StaticId = 1;
        public int Id { get; set; }
        public string? Name { get; set; }

        public Sector() { this.Id = StaticId++; }
    }
}
