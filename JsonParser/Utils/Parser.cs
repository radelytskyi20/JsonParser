using JsonParser.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser.Utils
{
    // Parse data from json file
    public class Parser 
    {
        public RootObject GetParsedData(string filePath)
        {
            if (!File.Exists(filePath))
                throw new Exception("File does not exist");
            
            return JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(filePath));
        }
    }
}
