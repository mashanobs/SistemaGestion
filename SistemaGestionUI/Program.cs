using SistemaGestionUI.ClientServices;
using SistemaGestionUI.Components;
//using SistemaGestionBusiness;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddTransient<ProductoBusiness>();
builder.Services.AddTransient<UsuarioBusiness>();
builder.Services.AddTransient<ProductoVendidoBusiness>();
builder.Services.AddTransient<VentaBusiness>();

builder.Services.AddHttpClient<ProductoBusiness>(
    client => client.BaseAddress = new Uri($"{builder.Configuration["ApiUrl"]}/api/Productos/")
    );

builder.Services.AddHttpClient<UsuarioBusiness>(
    client => client.BaseAddress = new Uri($"{builder.Configuration["ApiUrl"]}/api/Usuarios/")
    );

builder.Services.AddHttpClient<ProductoVendidoBusiness>(
    client => client.BaseAddress = new Uri($"{builder.Configuration["ApiUrl"]}/api/ProductoVendido/")
    );

builder.Services.AddHttpClient<VentaBusiness>(
    client => client.BaseAddress = new Uri($"{builder.Configuration["ApiUrl"]}/api/Venta/")
    );

//builder.Services.ConfigureBusinessLayer(); // Llama al configureService de Business 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
