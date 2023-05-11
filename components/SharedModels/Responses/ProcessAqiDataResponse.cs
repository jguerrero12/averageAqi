namespace SharedModels;

public record ProcessAqiDataResponse
{
    public AqiIndex AverageAqi { get; init; }
}
