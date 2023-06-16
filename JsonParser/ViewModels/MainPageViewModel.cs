using CommunityToolkit.Mvvm.ComponentModel;
using JsonParser.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JsonParser.ViewModels
{
    public class MainPageViewModel : ObservableObject
    {
        public string InputPath { get; set; }
        public string OutputDataDefaultCoordinates { get; set; }
        public string OutputDataNormalizedCoordiantes { get; set; }
        public ICommand Parse { get; set; }
        public Parser Parser { get; set; }
        public Normalizer Normalizer { get; set; }
        public CustomFormatter CustomFormatter { get; set; }

        public MainPageViewModel()
        {
            Parse = new Command(ParseData);
        }
        public void ParseData()
        {
            Parser = new Parser();
            CustomFormatter = new CustomFormatter();

            var data = Parser.GetParsedData(InputPath);
            
            var nodes = data.nodes;
            var edges = data.edges;
            var lines = data.lines;

            Normalizer = new Normalizer(nodes, 5, 30);
            var normalizedCoordinatesNodes = Normalizer.GetNormalizedList(nodes);

            OutputDataDefaultCoordinates = CustomFormatter.GetFormattedEdgesAndRoutes(nodes, edges, lines, 10);
            OutputDataNormalizedCoordiantes = CustomFormatter.GetFormattedEdgesAndRoutes(normalizedCoordinatesNodes, edges, lines, 10);

            OnPropertyChanged(nameof(OutputDataDefaultCoordinates));
            OnPropertyChanged(nameof(OutputDataNormalizedCoordiantes));
        }
    }
}
