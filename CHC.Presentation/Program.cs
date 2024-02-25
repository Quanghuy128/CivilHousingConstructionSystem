using CHC.Presentation.Configuration;
using FAB.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Config builder
builder.ConfigureAutofacContainer();

// Add Configuration
builder.Configuration.SettingsBinding();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext();

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
