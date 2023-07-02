namespace SharedModels;

public class DateRange
{
    public DateTime Start { get; }
    public DateTime End { get; }

    public DateRange(DateTime start, DateTime end)
    {
        if (end < start)
            throw new Exception("End cannot be before start.");
        Start = start;
        End = end;
    }
}
