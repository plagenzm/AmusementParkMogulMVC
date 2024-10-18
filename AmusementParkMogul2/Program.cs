using AmusementParkMogul2.Models;
using AmusementParkMogul2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<ShopService>();
builder.Services.AddHttpClient<ParkService>();
builder.Services.AddHttpClient<InvestorService>();
builder.Services.AddHttpClient<GentlerideService>();
builder.Services.AddHttpClient<RollercoasterService>();
builder.Services.AddHttpClient<CashService>();
builder.Services.AddControllersWithViews();

var services = builder.Services;
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("v1/swagger.json", "MyAPI V1");
});



app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();

