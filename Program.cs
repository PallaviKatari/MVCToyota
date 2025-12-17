//static void Main(string[] args)
//Minimal Hosting Model for ASP.NET Core
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Register this service to enable the use of static assets in MVC views and controllers
builder.Services.AddControllersWithViews();

//Pipeline to serve static assets
var app = builder.Build();

// Middleware Configuration
// Configure the HTTP request pipeline.
// Testing,Staging,Production,Development
if (!app.Environment.IsDevelopment())
{
    // Runtime error handling - 404 Not found, 500 server error, Under maintenance
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    // Application must be accessed over HTTPS
    app.UseHsts();
}

// Strictly enforce HTTPS
app.UseHttpsRedirection();
app.UseRouting();

// Permission
app.UseAuthorization();

// Access wwwroot folder for static files like CSS, JS, images
app.MapStaticAssets();

// Define the default route for MVC controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Start the application
app.Run();
