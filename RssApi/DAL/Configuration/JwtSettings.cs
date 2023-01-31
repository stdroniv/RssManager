namespace RssApi.DAL.Configuration;

public class JwtSettings
{
    public const string Key = "JwtSettings";

    public string ValidAudience { get; set; } = string.Empty;

    public string ValidIssuer { get; set; } = string.Empty;
}