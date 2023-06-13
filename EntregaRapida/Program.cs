using EntregaRapida.Data;
using Microsoft.EntityFrameworkCore;
using EntregaRapida.Repository.Interfaces;
using EntregaRapida.Repository;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using TabelasIdentity.Identity.Data;
using EntregaRapida.Models;
using EntregaRapida.Models.ClassHubs;
using EntregaRapida.Services;
using EntregaRapida.Models.Enum;

var builder = WebApplication.CreateBuilder(args);
var banco = builder.Configuration.GetConnectionString("Banco");
var Identity = builder.Configuration.GetConnectionString("Identity");



//Add signalR
builder.Services.AddSignalR();
builder.Services.AddScoped<UsersHub>();
//fim
builder.Services.AddControllersWithViews(); //"10.4.27"
builder.Services.AddDbContext<Banco>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Banco")));
builder.Services.AddDbContext<IdentityContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Identity")));


builder.Services.AddTransient<IEntregadores, EntregadoresRepository>(); //Esse método é usado para adicionar um serviço de tempo de execução transiente ao contêiner de injeção de dependência. Os serviços de tempo de execução transientes são criados cada vez que um consumidor solicita o serviço. Os serviços de tempo de execução transientes são adequados para serviços ligeiramente "pesados" para criar, mas que não necessitam de estado persistente.
builder.Services.AddTransient<ILojistas, LojistaRepository>();
builder.Services.AddTransient<IPedido,PedidoRepository>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<Banco>();
//classes de serviço
builder.Services.AddScoped<ComercianteService>();



builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

//identyty
builder.Services.AddScoped<HttpContextAccessor>();
builder.Services.AddSession(); 
builder.Services.AddIdentityCore<IdentityUser>(options => { });
builder.Services.AddScoped<UserManager<IdentityUser>>();
//Interface para criar o perfil do usuario
builder.Services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
builder.Services.AddScoped<UserManager<IdentityUser>>();
builder.Services.AddScoped<RoleManager<IdentityRole>>();
builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("Entregador", politica => { politica.RequireRole("Entregador"); });
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Lojista", politica => { politica.RequireRole("Lojista"); });
});


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var http = scope.ServiceProvider.GetRequiredService<HttpContextAccessor>();
 
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
using (var scope = app.Services.CreateScope())
{
    var seedUserRoleInitial = scope.ServiceProvider.GetRequiredService<ISeedUserRoleInitial>();
    seedUserRoleInitial.SeedRoles();
    seedUserRoleInitial.SeedUsers();
}
//Rotas 
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
           name: "default",
           pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "Entregadores",
        pattern: "Entregador/{controller=Entregador}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
           name: "Comerciantes",
           pattern: "{area:exists}/{controller=Comerciante}/{action=Index}/{id?}");
 

});

//signal
app.UseEndpoints(endpoints => { 
    endpoints.MapHub<UsersHub>("/entregadorHub");

});

//fim

app.Run();
