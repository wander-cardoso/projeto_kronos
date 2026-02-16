using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ProjKronos.Data;



//251107: para o login
//já cá estava! -> using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();


//################################################################################################# string connection aqui:
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SC")));


//251107: para o login:
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // rota do login
        options.AccessDeniedPath = "/Account/AccessDenied";
    });
// Lê o "AppSettings" do appsettings.json [251030]
//builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

//para ANC-PJ-TI
//builder.Services.Configure<CompanyOptions>(
//   builder.Configuration.GetSection("Company"));

// Necessário para Session
builder.Services.AddDistributedMemoryCache(); // provedor de memória
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // tempo que a sessão dura
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//é necessário adicionar a lina app.UseSession antes
//da app.MapControllerRoute ao fundo
builder.Services.AddSession();

var app = builder.Build();


// colocar depois de `var app = builder.Build();`
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var feature = context.Features.Get<IExceptionHandlerPathFeature>();
        var ex = feature?.Error;

        context.Response.StatusCode = 500;
        context.Response.ContentType = "text/html; charset=utf-8";

        await context.Response.WriteAsync("<h1>Erro interno (DEBUG)</h1>");
        await context.Response.WriteAsync("<p><strong>Path:</strong> " +
            System.Net.WebUtility.HtmlEncode(feature?.Path ?? "") + "</p>");
        await context.Response.WriteAsync("<pre>");
        await context.Response.WriteAsync(System.Net.WebUtility.HtmlEncode(ex?.ToString() ?? "Sem exceção"));
        await context.Response.WriteAsync("</pre>");
    });
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession();  // << tem de vir antes do UseEndpoints/MapControllerRoute
//251107: para o login
app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "Home",
    pattern: "{controller=Home}/{action=Index}/{id?}");
   
app.Run();
