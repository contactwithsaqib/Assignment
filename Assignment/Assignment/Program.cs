using Assignment.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext for ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity setup
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews(); // Add support for MVC controllers and views

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddCookie();

var app = builder.Build();

// Error handling logic
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error.html");
    app.UseStatusCodePagesWithRedirects("/error{0}.html");
}

app.UseHttpsRedirection();
app.UseDefaultFiles();    // Serve default pages
app.UseStaticFiles();     // Serve static files from wwwroot

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); // Map controllers for MVC routing

app.Run();
