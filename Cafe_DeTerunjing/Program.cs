using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cafe_DeTerunjing.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Cafe_DeTerunjingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Cafe_DeTerunjingContext") ?? throw new InvalidOperationException("Connection string 'Cafe_DeTerunjingContext' not found.")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
 .AddEntityFrameworkStores<Cafe_DeTerunjingContext>()
 .AddRoles<IdentityRole>()
 .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(option =>
{
    option.LoginPath = new PathString("/Account/Login");
    option.AccessDeniedPath = new PathString("/Account/AccessDenied");
    option.LogoutPath = new PathString("/Index");
}
    );

//define the admin policy
builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("AdminPolicy",
        policy => policy.RequireRole("Admin"));
}); 

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/MenuModel", "AdminPolicy");
});


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
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
