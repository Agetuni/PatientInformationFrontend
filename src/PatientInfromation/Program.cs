using PatientInformation.Application.Services;
using PatientInfromation.Infrastructure.Interface;
using PatientInfromation.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IHttpService, HttpService>();

builder.Services.AddHttpClient<IAllergy, AllergyService>();
builder.Services.AddScoped<IAllergy, AllergyService>();


builder.Services.AddHttpClient<IDisease, DiseaseService>();
builder.Services.AddScoped<IDisease, DiseaseService>();

builder.Services.AddHttpClient<INCD, NCDService>();
builder.Services.AddScoped<INCD, NCDService>();

builder.Services.AddHttpClient<IPatient, PatientService>();
builder.Services.AddScoped<IPatient, PatientService>();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
