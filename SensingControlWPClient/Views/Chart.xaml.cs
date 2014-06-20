using Microsoft.Phone.Controls;
using SensingControlWPClient.DAL;
using SensingControlWPClient.Model;
using SensingControlWPClient.ViewModel;

namespace SensingControlWPClient.Views
{
    public partial class TemperatureChart : PhoneApplicationPage
    {
        private SensorRepository sensorRepo;

        public TemperatureChart()
        {
            InitializeComponent();
            sensorRepo = new SensorRepository();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string type;

            if (NavigationContext.QueryString.TryGetValue("type", out type)){
                LoadData(type);
            }
        }

        private void LoadData(string type){
            var viewmodel = new ChartViewModel();

            switch (type){
                case "Humidity":
                    viewmodel.Header = "Humidity (%)";
                    break;
                case "CO2":
                    viewmodel.Header = "CO₂ (ppm)";
                    break;
                default:
                    viewmodel.Header = "Temperature (°C)";
                    break;
            }

            sensorRepo.GetValues(type,
                sensorValues => {
                    foreach (var val in sensorValues.Values){
                        viewmodel.Collection.Add(new Point(val.Date, val.Value));
                    }
                    Chart.DataContext = viewmodel;
                },
                error => {  });
        }

    }
}