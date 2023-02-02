using System.ServiceModel.Syndication;
using System.Xml;
using FluentValidation;
using RssApi.BLL.DTOs;

namespace RssApi.Configuration.Validators;

public class FeedCreateDtoValidator: AbstractValidator<FeedCreateDto>
{
    public FeedCreateDtoValidator()
    {
        RuleFor(it => it.feedUrl)
            .NotEmpty()
            .Must(IsValidFeedUrl);
    }
    
    private  bool IsValidFeedUrl(string url)
    {
        bool isValid = true;
        try
        {
            XmlReader reader = XmlReader.Create(url);
            Rss20FeedFormatter formatter = new Rss20FeedFormatter();
            formatter.ReadFrom(reader);
            reader.Close();
        }
        catch
        {
            isValid = false;
        }

        return isValid;
    }
}