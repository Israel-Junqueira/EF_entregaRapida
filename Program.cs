using EntregaRapida.Data;
using Microsoft.EntityFrameworkCore;
using EntregaRapida.Repository.Interfaces;
using EntregaRapida.Repository;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews(); //"10.4.27"
builder.Services.AddDbContext<Banco>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Banco")));
builder.Services.AddTransient<IEntregadores,EntregadoresRepository>(); //Esse método é usado para adicionar um serviço de tempo de execução transiente ao contêiner de injeção de dependência. Os serviços de tempo de execução transientes são criados cada vez que um consumidor solicita o serviço. Os serviços de tempo de execução transientes são adequados para serviços ligeiramente "pesados" para criar, mas que não necessitam de estado persistente.
builder.Services.AddTransient<ILojistas,LojistaRepository>();
builder.Services.AddControllersWithViews(); 

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Entregador}/{action=Index}/{id?}");

app.Run();
