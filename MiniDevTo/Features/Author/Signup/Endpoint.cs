using FastEndpoints;


namespace MiniDevTo.Features.Author.Signup;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("/author/signup");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        await SendAsync(new Response()
        {
            //TODO 
        });
    }
}
