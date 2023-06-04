using Microsoft.EntityFrameworkCore;
using ArchersRecorderBackEndDatabase.Data;
using ArchersRecorderBackEndDatabase.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAuthorization();

builder.Services.AddDbContext<ArchersRecorderContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ArcherScoreRecordContextConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddScoped<IRoundRangeMappingRepository, RoundRangeMappingRepository>();
builder.Services.AddScoped<IArchersRepository, ArchersRepository>();
builder.Services.AddScoped<IRoundScoresRepository, RoundScoresRepository>();
builder.Services.AddScoped<IEndsRepository, EndsRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin",
        builder => builder.WithOrigins("http://localhost:3000") // React app url
                            .AllowAnyMethod()
                            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseCors("AllowMyOrigin");

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
