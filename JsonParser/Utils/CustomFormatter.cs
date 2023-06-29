using JsonParser.Models;
using JsonParser.Models.Edge;
using JsonParser.Models.Line;
using JsonParser.Models.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser.Utils
{
    public class CustomFormatter
    {

        /// <summary>
        /// Returns string of formatted edges
        /// Edge: E;routeNmae;x0;y0;x1;y1
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public string GetFormattedEdges(List<Node> nodes, List<Edge> edges)
        {
            string resultStr = string.Empty;

            foreach (var node in nodes)
            {
                foreach (var edge in edges)
                {
                    CustomEdge customEdge = new CustomEdge()
                    {
                        X0 = node.Metadata.X,
                        Y0 = node.Metadata.Y,
                    };

                    //without complete amount of lines
                    //if (node.Id == edge.Source)
                    //{
                    //    customEdge.RouteName = edge.Metadata.lines[0];

                    //    var secondNode = nodes.Find(x => x.Id == edge.Target);
                    //    customEdge.X1 = secondNode.Metadata.X;
                    //    customEdge.Y1 = secondNode.Metadata.Y;

                    //    resultStr += customEdge.ToString() + "\n";
                    //}

                    //complete amount of lines
                    if (node.Id == edge.Source)
                    {
                        foreach (var line in edge.Metadata.lines)
                        {
                            customEdge.RouteName = line;

                            var secondNode = nodes.Find(x => x.Id == edge.Target);
                            customEdge.X1 = secondNode.Metadata.X;
                            customEdge.Y1 = secondNode.Metadata.Y;

                            resultStr += customEdge.ToString() + "\n";
                        }

                    }
                }
            }

            return resultStr;
        }
        /// <summary>
        /// Returns string of formatted routes
        /// Route: R;routeName;routeWidth;routeColor
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string GetFormattedRoutes(List<Line> lines, int width = 3)
        {
            if (lines == null)
                throw new Exception("Data is null");

            string resultStr = string.Empty;
            foreach (var line in lines)
            {
                CustomLine customLine = new CustomLine()
                {
                    RouteName = line.Id,
                    RouteColor = line.Color,
                    RouteWidth = width
                };

                resultStr += customLine.ToString() + "\n";
            }

            return resultStr;
        }

        /// <summary>
        /// Returns string with all necessary data to build a graph
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="edges"></param>
        /// <param name="lines"></param>
        /// <param name="lineWidth"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string GetFormattedEdgesAndRoutes(List<Node> nodes, List<Edge> edges, List<Line> lines, int lineWidth)
        {
            if (nodes == null && edges == null && lines == null && lineWidth >= 1)
                throw new Exception("Data is empty");

            var formattedEdges = GetFormattedEdges(nodes, edges);
            var formattedLines = GetFormattedRoutes(lines, lineWidth);

            string resultStr = formattedLines + "\n" + formattedEdges;


            return resultStr;
        }
    }
}
