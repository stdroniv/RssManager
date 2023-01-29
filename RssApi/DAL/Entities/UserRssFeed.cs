﻿namespace RssApi.DAL.Entities;

public class UserRssFeed
{
    public Guid UserId { get; set; }
    
    public User User { get; set; }

    public Uri FeedUri { get; set; }

    public ICollection<SimplePost> FeedNews { get; set; } = new List<SimplePost>();
}