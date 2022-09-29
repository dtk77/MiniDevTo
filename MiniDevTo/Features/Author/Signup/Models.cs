namespace MiniDevTo.Features.Author.Signup;

public class Request
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class Response
{
    public string Message { get; set; } = string.Empty;
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("не указано ваше имя")
            .MinimumLength(3).WithMessage("слишком короткое имя")
            .MaximumLength(25).WithMessage("слишком длиная запись");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("не указана электронная почта")
            .EmailAddress().WithMessage("неверный формат электронной почты");

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("не указано имя пользователя")
            .MinimumLength(3).WithMessage("имя пользователя слишком короткое!")
            .MaximumLength(15).WithMessage("имя пользователя слишком длинное!");

        RuleFor(x => x.Password)
             .NotEmpty().WithMessage("не указан пароль")
            .MinimumLength(10).WithMessage("пароль слишком короткий!")
            .MaximumLength(25).WithMessage("парооль слишком длинный");
    }
}
