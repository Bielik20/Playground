using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playground.Models.VisualizationViewModels
{
    public class BackendPrintViewModel
    {
        public List<KeyValuePair<string, int>> List { get; set; }

        public string ImageURI { get; set; }
    }
}
