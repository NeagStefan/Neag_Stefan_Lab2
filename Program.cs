using Microsoft.EntityFrameworkCore;
using Neag_Stefan_Lab2.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Neag_Stefan_Lab2Context")
    ?? throw new InvalidOperationException("Connection string 'Neag_Stefan_Lab2Context' not found.");

builder.Services.AddRazorPages();

builder.Services.AddDbContext<Neag_Stefan_Lab2Context>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<LibraryIdentityContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();