﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrinciple.Model
{
    internal interface IBook
    {
        string Title { get; set; }
        string Author { get; set; }
        string price { get; set; }
    }
}
