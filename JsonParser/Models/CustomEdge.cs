using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser.Models
{
    public class CustomEdge
    {
        public string RouteName { get; set; }
        public double X0 { get; set; }
        public double Y0 { get; set; }
        public double X1 { get; set; }
        public double Y1 { get; set; }

        public override string ToString()
        {
            return $"E;{RouteName};{X0};{Y0};{X1};{Y1}";
        }
    }
}
