var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

builder.Services.AddHealthChecks();


var app = builder.Build();
app.UseHealthChecks("/health");


app.MapGet("/app/nur_matova_jan_gmail_com", (int x, int y) =>
{
    if (x > 0 && y > 0 && x % 1 == 0 && y % 1 == 0)
    {
        int lcm = 0, i = 1;
        while (lcm == 0)
        {
            if (x * i % y == 0)
            {
                lcm = x * i;
                break;
            }
            i++;
        }
        return Results.Text(lcm.ToString());
    }
    return Results.Text("NaN");
});

app.Run();