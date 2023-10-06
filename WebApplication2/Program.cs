using WebApplication2;

var builder = WebApplication.CreateBuilder(args);

string FilePath = Path.Combine("config", "jsconfig1.json");

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(FilePath, optional: false, reloadOnChange: false)
    .AddEnvironmentVariables();

builder.Services.Configure<EmailDomainsForUsername>(builder.Configuration.GetSection("EmailDomains"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
