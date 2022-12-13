using oEmbedTester.BackgroundServices;
using oEmbedTester.Domain.oEmbedProvider;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<OEmbedProviderWrapper>();
builder.Services.AddHostedService<OEmbedProviderFetcher>();
builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console());

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