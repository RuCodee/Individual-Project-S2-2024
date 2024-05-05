using BusinessLogic;
using DataAccessLayer;
using DataAccessLayer.UnitTestInterfaces;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<DoctorDAL>();
builder.Services.AddScoped<DoctorManager>();
builder.Services.AddScoped<AdministratorManager>();
builder.Services.AddScoped<AdministratorDAL>();
builder.Services.AddScoped<PatientManager>();
builder.Services.AddScoped<PatientDAL>();
builder.Services.AddScoped<UserManager>();
builder.Services.AddScoped<IUserDAL, UserDAL>();
builder.Services.AddScoped<MedicalRecordManager>();
builder.Services.AddScoped<MedicalRecordDAL>();
builder.Services.AddScoped<PatientMedicalRecordManager>();
builder.Services.AddScoped<PatientMedicalRecordDAL>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login"; //Login page path
        options.AccessDeniedPath = "/AccessDenied"; // Access denied page path
    });

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
