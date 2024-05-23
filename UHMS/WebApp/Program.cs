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
        options.LoginPath = "/Login"; // Login page
        options.AccessDeniedPath = "/Index"; // Access denied
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.SlidingExpiration = true; // Reset the expiration time if the user is active
    });

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
    context.Response.Headers.Add("Pragma", "no-cache");
    context.Response.Headers.Add("Expires", "0");
    await next();
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.Run();
