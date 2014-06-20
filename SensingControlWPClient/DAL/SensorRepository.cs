using System;
using RestSharp;
using SensingControlWPClient.Model;

namespace SensingControlWPClient.DAL
{
    public class SensorRepository
    {
        private RestClient client;

        public SensorRepository(){
            // REST API client
            client = new RestClient("http://sensingcontrolwebservice.apphb.com/api");
        }

        // Get last measurement of a sensor.
        public void GetValue(string label, Action<SensorValue> success, Action<string> failure)
        {
            var request = new RestRequest("sensors/" + label + "/current") { Method = Method.GET };

            client.ExecuteAsync<SensorValue>(request, response =>
            {
                if (response.ResponseStatus == ResponseStatus.Error)
                {
                    failure(response.ErrorMessage);
                }
                else
                {
                    success(response.Data);
                }
            });
        }

        // Get measurements of last few days of a sensor.
        public void GetValues(string label, Action<SensorValues> success, Action<string> failure)
        {
            var request = new RestRequest("sensors/" + label + "/values") { Method = Method.GET };

            client.ExecuteAsync<SensorValues>(request, response =>
            {
                if (response.ResponseStatus == ResponseStatus.Error)
                {
                    failure(response.ErrorMessage);
                }
                else
                {
                    success(response.Data);
                }
            });
        }
    }
}
