using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Microsoft.EntityFrameworkCore;
using Notification.Microservice.API.BrokerConfigurations;
using Notification.Microservice.Application.Commands;
using Notification.Microservice.Application.Services;
using Notification.Microservice.Domain.Entities;
using Notification.Microservice.Domain.Repositories;
using Notification.Microservice.Infrastructure.Persistence;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("NotificationMicroservice");
builder.Services.AddDbContext<NotificationDbContext>(options =>
options.UseSqlServer(connectionString));
builder.Services.AddScoped<INotificationService,NotificationService>();
builder.Services.AddScoped<INotificationRepository,NotificationRepository>();
builder.Services
    .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(SendNotificationCommandHandler)));

var broker = RabbitHutch.CreateBus(builder.Configuration["RabbitMQ:RabbitConn"]);
builder.Services.AddSingleton<IBus>(broker);
builder.Services.AddSingleton<MessageDispatcher>();
builder.Services.AddSingleton<AutoSubscriber>(_ =>
{
    return new AutoSubscriber(_.GetRequiredService<IBus>(), Assembly
        .GetExecutingAssembly().GetName().Name)
    {
        AutoSubscriberMessageDispatcher = _.GetRequiredService<MessageDispatcher>()
    };
});
builder.Services.AddHostedService<Worker>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
