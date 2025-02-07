using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrincipe.Model
{
    internal interface IBook
    {
        string Title { get; set; }
        string Author { get; set; }
        string price { get; set; }
    }
    interface ITopic
    {
        string Topic { get; set; }
    }

    interface IDuration
    {
        string Duration { get; set; }
    }
}
