using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrincipe.Model
{
    public class Book : IBook
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string price { get; set; }
    }
    public class TopicBook : IBook, ITopic
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string price { get; set; }
        public string Topic { get; set; }
    }
    public class Video : IBook, ITopic, IDuration
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string price { get; set; }
        public string Topic { get; set; }
        public string Duration { get; set; }
    }
}
