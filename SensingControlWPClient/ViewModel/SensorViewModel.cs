using GalaSoft.MvvmLight;

namespace SensingControlWPClient.ViewModel
{
    // MVVM light viewmodel to update the view.
    // This viewmodel is used because the REST API call is done in a different thread
    // as the GUI thread. By using events the GUI can still be updated.
    public class SensorViewModel: ViewModelBase
    {
        private string measurement;

        public string Measurement
        {
            get
            {
                return measurement;
            }

            set
            {
                if (measurement != value)
                {
                    measurement = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
