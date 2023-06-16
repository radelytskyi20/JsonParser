using JsonParser.Models.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser.Utils
{
    public class Normalizer
    {
        private double minX;
        private double maxX;
        private double minY;
        private double maxY;
        private double newMin; // new min value for X and Y
        private double newMax; // new max value for X and Y
        public Normalizer(List<Node> nodes, double newMin, double newMax)
        {
            minX = nodes.Min(node => node.Metadata.X);
            maxX = nodes.Max(node => node.Metadata.X);
            minY = nodes.Min(node => node.Metadata.Y);
            maxY = nodes.Max(node => node.Metadata.Y);
            this.newMin = newMin;
            this.newMax = newMax;
        }
        /// <summary>
        /// Normalize coordinates of each node in particular area(from newMin to newMax)
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node Normalize(Node node)
        {
            var normalizedNode = new Node()
            {
                Id = node.Id,
                Label = node.Label,
                Metadata = new NodeMetadata()
                {
                    X = ((node.Metadata.X - minX) / (maxX - minX)) * (newMax - newMin) + newMin,
                    Y = ((node.Metadata.Y - minY) / (maxY - minY)) * (newMax - newMin) + newMin
                }
            };

            return normalizedNode;
        }
        /// <summary>
        /// Returns the list of nodes with normalized coordinates
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public List<Node> GetNormalizedList(List<Node> nodes)
        {
            List<Node> result = new List<Node>();

            foreach (var node in nodes)
                result.Add(Normalize(node));

            return result;
        }
    }
}
