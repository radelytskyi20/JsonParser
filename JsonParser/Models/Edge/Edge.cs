﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser.Models.Edge
{
    public class Edge
    {
        public string Source { get; set; }
        public string Target { get; set; }
        public EdgeMetadata Metadata { get; set; }
    }
}
