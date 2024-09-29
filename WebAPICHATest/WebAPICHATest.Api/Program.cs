using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebAPICHATest.Domain.SeedWork;
using WebAPICHATest.Infrastructure;
using System.Reflection;
using WebAPICHATest.Api.Application.Mapping;
using WebAPICHATest.Infrastructure.Repositories;
using WebAPICHATest.Domain.ConstantDomain;
using WebAPICHATest.Api.Controllers;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceWorkOrderAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;
using WebAPICHATest.Domain.AggregateModels.ChartObjAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Domain.AggregateModels.CorrectionAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.SoundAggregate;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.TimeSeriesObjectAggregate;
using WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate;
using WebAPICHATest.Domain.AggregateModels.KitTestAggregate;
using WebAPICHATest.Domain.AggregateModels.StandardAggregate;
using WebAPICHATest.Domain.AggregateModels.MoldInforAggregate;
using WebAPICHATest.Domain.AggregateModels.ProductAggregate;
using WebAPICHATest.Domain.AggregateModels.MoldAggregate;
using WebAPICHATest.Domain.AggregateModels.WorkingTimeAggregate;
using WebAPICHATest.Domain.AggregateModels.JsonEquipmentAggregate;
using WebAPICHATest.Domain.AggregateModels.JsonPersonAggregate;
using WebAPICHATest.Repository;
using WebAPICHATest.Domain.AggregateModels.MaterialHistoryCardAggregate;
using WebAPICHATest.Domain.AggregateModels.InspectionReportAggregate;
using WebAPICHATest.Domain.AggregateModels.InputAggregate.ObjectInputAggregate;
using WebAPICHATest.Domain.AggregateModels.InputAggregate;
using WebAPICHATest.Domain.AggregateModels.NotificationAggregate;
using WebAPICHATest.Domain.AggregateModels.JsonMoldAggregate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{   
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("WebAPICHATest.Api"));
    options.EnableSensitiveDataLogging();
}); 
    
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = builder.Configuration.GetValue("Authority", "");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddAutoMapper(typeof(ModelToViewModelProfile));
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<ModelToViewModelProfile>();
    cfg.RegisterServicesFromAssemblyContaining<ApplicationDbContext>();
    cfg.RegisterServicesFromAssemblyContaining<Entity>();
});

builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IMaintenanceRequestRepository, MaintenanceRequestRepository>();
builder.Services.AddScoped<IMaintenanceWorkOrderRepository, MaintenanceWorkOrderRepository>();
builder.Services.AddScoped<IMaterialInforRepository, MaterialInforRepository>();
builder.Services.AddScoped<IMaterialRequestRepository, MaterialRequestRepository>();
//builder.Services.AddScoped<IChartObjRepository, ChartObjRepository>();
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<ICauseRepository, CauseRepository>();
builder.Services.AddScoped<ICorrectionRepository, CorrectionRepository>();
builder.Services.AddScoped<IMaintenanceResponseRepository, MaintenanceResponseRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<ISoundRepository, SoundRepository>();
builder.Services.AddScoped<IEquipmentMaterialRepository, EquipmentMaterialRepository>();
builder.Services.AddScoped<ITimeSeriesObjectRepository, TimeSeriesObjectRepository>();
builder.Services.AddScoped<IPerformanceIndexRepository, PerformanceIndexRepository>();
builder.Services.AddScoped<IKitTestRepository, KitTestRepository>();
builder.Services.AddScoped<IStandardRepository, StandardRepository>();
builder.Services.AddScoped<IMoldInforRepository, MoldInforRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IMoldRepository, MoldRepository>();
builder.Services.AddScoped<IWorkingTimeRepository, WorkingTimeRepository>();
builder.Services.AddScoped<IJsonEquipmentRepository, JsonEquipmentRepository>();
builder.Services.AddScoped<IJsonMoldRepository, JsonMoldRepository>();
builder.Services.AddScoped<IJsonPersonRepository, JsonPersonRepository>();
builder.Services.AddScoped<IObjectInputRepository, ObjectInputRepository>();
builder.Services.AddScoped<IMaterialHistoryCardRepository, MaterialHistoryCardRepository>();
builder.Services.AddScoped<IInspectionReportRepository, InspectionReportRepository>();
builder.Services.AddScoped<IInputTabuSearchRepository, InputTabuSearchRepository>();
builder.Services.AddScoped<INotificationModelRepository, NotificationModelRepository>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
