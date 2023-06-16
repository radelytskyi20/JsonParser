using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser.Models.Node
{
    public class Node
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public NodeMetadata Metadata { get; set; }
    }
}
