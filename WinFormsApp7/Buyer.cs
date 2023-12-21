using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WinFormsApp7
{
    internal class Buyer
    {
        public static int StaticId = 1;
        public int Id { get; set; }
        public string? PIB {  get; set; }
        public string? BirthDate { get; set; }
        public string? Sex { get; set; }
        public string? Email { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? SectionsOfInterest { get; set; }
        public Buyer() { this.Id = StaticId++; }
        ~Buyer() { StaticId--; }

    }
}
