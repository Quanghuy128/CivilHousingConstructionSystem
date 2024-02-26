using CHC.Application.Service;
using CHC.Infrastructure.Service;
using CHC.Presentation.Configuration;
using CHC.Presentation.SeedData;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

// Config builder
builder.ConfigureAutofacContainer();

// Add Configuration
builder.Configuration.SettingsBinding();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext();

//Seed Data
builder.Services.SeedData().GetAwaiter().GetResult();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
