namespace RssApi.Configuration;

public interface IDateTimeProvider
{
    public DateTime Now { get; set; }
}

public class DateTimeProvider: IDateTimeProvider
{
    public DateTime Now { get; set; } = DateTime.Now;
}