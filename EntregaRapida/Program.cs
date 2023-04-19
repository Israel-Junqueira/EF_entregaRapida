using EntregaRapida.Data;
using Microsoft.EntityFrameworkCore;
using EntregaRapida.Repository.Interfaces;
using EntregaRapida.Repository;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using TabelasIdentity.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var banco = builder.Configuration.GetConnectionString("Banco");
var Identity = builder.Configuration.GetConnectionString("Identity");


builder.Services.AddControllersWithViews(); //"10.4.27"
builder.Services.AddDbContext<Banco>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Banco")));
builder.Services.AddDbContext<IdentityContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Identity")));


builder.Services.AddTransient<IEntregadores, EntregadoresRepository>(); //Esse método é usado para adicionar um serviço de tempo de execução transiente ao contêiner de injeção de dependência. Os serviços de tempo de execução transientes são criados cada vez que um consumidor solicita o serviço. Os serviços de tempo de execução transientes são adequados para serviços ligeiramente "pesados" para criar, mas que não necessitam de estado persistente.
builder.Services.AddTransient<ILojistas, LojistaRepository>();
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options => { options.IdleTimeout = TimeSpan.FromMinutes(90); });//sessin
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //sessin

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders(); //identyty
builder.Services.AddIdentityCore<IdentityUser>(options => { });
builder.Services.AddScoped<UserManager<IdentityUser>>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();