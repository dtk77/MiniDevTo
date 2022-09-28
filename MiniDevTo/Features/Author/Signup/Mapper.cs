using MiniDevTo.Features.Author.Signup;
using System.Globalization;


namespace MiniDevTo.Features.Author.Signup;

public class Mapper : Mapper<Request, Response, Dom.Author>
{
    private static readonly CultureInfo _culture = new CultureInfo("ru-Ru");

    public override Dom.Author ToEntity(Request request) => new()
    {
        Email = request.Email.ToLower(),
        FirstName = _culture.TextInfo.ToTitleCase(request.FirstName),
        LastName = _culture.TextInfo.ToTitleCase(request.LastName),
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
        SignUpDate = DateOnly.FromDateTime(DateTime.UtcNow),
        UserName = request.UserName
    };
}