namespace RssApi.BLL.DTOs;

public record UserForRegistrationDto
{
    public string Email { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;
    
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }
}

public record UserForAuthenticationDto
{
    public string UserName { get; set; }
    
    public string Password { get; set; }
}