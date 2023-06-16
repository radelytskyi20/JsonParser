using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser.Models
{
    public class CustomLine
    {
        public string RouteName { get; set; }
        public int RouteWidth { get; set; } = 1; // ?
        public string RouteColor { get; set; }

        public override string ToString()
        {
            return $"R;{RouteName};{RouteWidth};{RouteColor}";
        }
    }
}
