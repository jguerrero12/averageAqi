namespace SharedModels
{
    public class AQIDataPoint
    {
        public Guid Id { get; set; }
        public DateTime dt { get; set; }
        public Components? components { get; set; }
        public AqiIndex main { get; set; }
    }
}