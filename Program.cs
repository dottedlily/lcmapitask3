var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

builder.Services.AddHealthChecks();


var app = builder.Build();
app.UseHealthChecks("/health");



app.MapGet("/app/nur_matova_jan_gmail_com", (string x, string y) =>
{
    if (!int.TryParse(x, out int x_naturalnum) || !int.TryParse(y, out int y_naturalnum)){
        return Results.Text("NaN");
    }
    if (x_naturalnum > 0 && y_naturalnum > 0)
    {
        double lcm = 0, i = 1;
        while (lcm == 0)
        {
            if (x_naturalnum * i % y_naturalnum == 0)
            {
                lcm = x_naturalnum * i;
                break;
            }
            i++;
        }
        return Results.Text(lcm.ToString());
    }
    return Results.Text("NaN");
});

app.Run();