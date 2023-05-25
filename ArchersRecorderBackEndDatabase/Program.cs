using Microsoft.EntityFrameworkCore;
using ArchersRecorderBackEndDatabase.Data;
using ArchersRecorderBackEndDatabase.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ArchersRecorderContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ArcherScoreRecordContextConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddScoped<IRoundRangeMappingRepository, RoundRangeMappingRepository>();
builder.Services.AddScoped<IArchersRepository, ArchersRepository>();
builder.Services.AddScoped<IRoundScoresRepository, RoundScoresRepository>();
builder.Services.AddScoped<IEndsRepository, EndsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
