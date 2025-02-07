using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple.Model
{
    internal class Book : IBook
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string price { get; set; }
    }
}
