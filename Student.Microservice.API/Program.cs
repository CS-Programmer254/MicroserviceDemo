using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Student.Microservice.API.BrokerConfigurations;
using Student.Microservice.Application.Commands;
using Student.Microservice.Application.Services;
using Student.Microservice.Domain.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStudentService,StudentService>();
builder.Services.AddScoped<IStudentRepository,IStudentRepository>();
builder.Services
    .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(RegisterStudentCommandHandler)));

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
