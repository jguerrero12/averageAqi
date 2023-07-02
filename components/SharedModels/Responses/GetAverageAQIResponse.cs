namespace SharedModels;

public record GetAverageAqiResponse
{
    public AqiIndex AverageAqi { get; init; }
}
