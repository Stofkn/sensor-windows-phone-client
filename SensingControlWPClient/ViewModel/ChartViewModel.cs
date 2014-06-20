using System.Collections.ObjectModel;
using SensingControlWPClient.Model;

namespace SensingControlWPClient.ViewModel
{
    public class ChartViewModel
    {
        public ObservableCollection<Point> Collection { get; set; }
        public string Header { get; set; }

        public ChartViewModel()
        {
            Collection = new ObservableCollection<Point>();
        }
    }
}
