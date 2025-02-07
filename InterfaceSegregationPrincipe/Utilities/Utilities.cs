using Newtonsoft.Json;
using InterfaceSegregationPrincipe.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace InterfaceSegregationPrincipe.Utilities
{
    internal class Utilities
    {
        static string ReadFile(string filename)
        {
            return File.ReadAllText(filename);
        }

        internal static List<Video> ReadData(string fileId)
        {
            var filename = "Data/BookStore" + fileId + ".json";
            var cadJSON = ReadFile(filename);
            return JsonConvert.DeserializeObject<List<Video>>(cadJSON);
        }
    }
}
