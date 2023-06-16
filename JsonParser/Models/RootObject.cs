using JsonParser.Models.Edge;
using JsonParser.Models.Line;
using JsonParser.Models.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser.Models
{
    public class RootObject
    {
        public List<Node.Node> nodes { get; set; }
        public List<Edge.Edge> edges { get; set; }
        public List<Line.Line> lines { get; set; }
    }
}
