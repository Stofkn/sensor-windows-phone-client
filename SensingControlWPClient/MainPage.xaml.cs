using System;
using System.Globalization;
using SensingControlWPClient.DAL;
using SensingControlWPClient.ViewModel;
using StofknControls;

namespace SensingControlWPClient
{
    public partial class MainPage {

        private SensorRepository sensorRepo;


        // Constructor
        public MainPage()
        {
            InitializeComponent();
            sensorRepo = new SensorRepository();

            Temperature.DataContext = new SensorViewModel { Measurement = "--" };
            Humidity.DataContext = new SensorViewModel { Measurement = "--" };
            CO2.DataContext = new SensorViewModel { Measurement = "--" };
            LoadMeasurements();
        }

        private void LoadMeasurements(){
            sensorRepo.GetValue("Temperature",
                sensorValue =>{
                    ((SensorViewModel)Temperature.DataContext).Measurement = sensorValue.Value.ToString("0.0");
                    UpdateLastUpdate();
                },
                error => { ((SensorViewModel)Temperature.DataContext).Measurement = "--"; });
            sensorRepo.GetValue("Humidity",
                 sensorValue => {
                     ((SensorViewModel)Humidity.DataContext).Measurement = sensorValue.Value.ToString(CultureInfo.InvariantCulture);
                     UpdateLastUpdate();
                 },
                 error => { ((SensorViewModel)Humidity.DataContext).Measurement = "--"; });
            sensorRepo.GetValue("CO2",
                sensorValue =>{
                    ((SensorViewModel)CO2.DataContext).Measurement = sensorValue.Value.ToString(CultureInfo.InvariantCulture);
                    UpdateLastUpdate();
                },
                error => { ((SensorViewModel)CO2.DataContext).Measurement = "--"; });
        }

        private void UpdateLastUpdate(){
            LastUpdated.Text = "Last updated: " + String.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now);
        }

        private void Sensor_Click(object sender, System.Windows.RoutedEventArgs e){
            var type = ((TileButton) sender).Name;
            NavigationService.Navigate(new Uri("/Views/Chart.xaml?type=" + type, UriKind.Relative));      
        }

        private void Synchronize_OnClick(object sender, EventArgs e){
            LastUpdated.Text = "Loading ...";
            LoadMeasurements();
        }
    }
}