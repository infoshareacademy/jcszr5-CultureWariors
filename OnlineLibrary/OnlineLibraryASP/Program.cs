using Microsoft.EntityFrameworkCore;
using OnlineLibrary.BLL.Repositories;
using OnlineLibrary.BLL.Services;
using OnlineLibraryASP;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using OnlineLibrary.BLL.Utility;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");;

builder.Services.AddDbContext<BookContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<BookContext>();;
builder.Services.AddSingleton<IEmailSender, EmailSender>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BookContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
builder.Services.AddScoped<IRentedBookRepository, RentedBookRepository>();
builder.Services.AddScoped<IRentedBookService,RentedBookService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Reader}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}");

app.Run();
