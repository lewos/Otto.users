using FluentValidation;
using MediatR;
using Microsoft.Extensions.Options;
using Otto.users.PipelineBehaviors;
using Otto.users.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Config DB
builder.Services.Configure<DatabaseSettings>(
    ((IConfiguration)builder.Services.BuildServiceProvider().GetService(typeof(IConfiguration)))
    .GetSection(nameof(DatabaseSettings)));

// requires using Microsoft.Extensions.Options
builder.Services.AddSingleton<IDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

builder.Services.AddSingleton<IUsersRepository, UsersRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);

// register for any trequest and tresponse
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

// register all the classes that implement AbstractValidator
builder.Services.AddValidatorsFromAssembly(typeof(Program).GetTypeInfo().Assembly);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
