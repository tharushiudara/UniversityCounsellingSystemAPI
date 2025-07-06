using Microsoft.EntityFrameworkCore;
using UniversityCounsellingSystemAPI.Models;
using UniversityCounsellingSystemAPI.Services;

var MyAllowSpecificOrigins = "*";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("defaultDB"));
});

builder.Services.AddScoped<ICounsellorService, CounsellorService>();
builder.Services.AddScoped<IUndergraduateService, UndergraduateService>();
builder.Services.AddScoped<ISession_scheduleService, Session_scheduleService>();
builder.Services.AddScoped<IProgress_trackingService, Progress_trackingService>();
builder.Services.AddScoped<IAppointment_Service, Appointment_Service>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();






builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins("*")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
