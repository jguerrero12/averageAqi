using SharedModels;

namespace src.Models
{
    public class AirPollutionApiResponse
    {
        public IEnumerable<float>? coord { get; set; }
        public IEnumerable<AQIDataPoint>? list { get; set; }
    }
}