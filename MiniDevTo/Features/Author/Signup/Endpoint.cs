namespace MiniDevTo.Features.Author.Signup;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("/author/signup");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {

        var author = Map.ToEntity(request);

        var emailIsTaken = await Data.EmailAddressIsTaken(author.Email);

        if (emailIsTaken)
            AddError(r => r.Email, "Извините, почта ящик уже используется");

        var userNameIsTaken = await Data.UserNameIsTaken(author.UserName);

        if (userNameIsTaken)
            AddError(r => r.UserName, "Извините, имя пользователя уже используется");

        ThrowIfAnyErrors();

        await Data.CreateNewAuthor(author);

        await SendAsync(new()
        {
            Message = "Спасибо за регистрацию в качестве автора"
        });
    }
}
