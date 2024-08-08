using Microsoft.EntityFrameworkCore;
using PDF_GENERATOR_PROJECT.Data;
using PDF_GENERATOR_PROJECT.Interfaces;
using PDF_GENERATOR_PROJECT.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews(); // for supporting controllers that have their own views as well
builder.Services.AddRazorPages();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IStudentRepo,StudentRepo>();
builder.Services.AddScoped<ICourseRepo, CourseRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();


app.UseStaticFiles(); // Needed for serving static files (e.g., CSS, JS)
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();  // Map Razor Pages
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // For MVC controllers and views


app.Run();
