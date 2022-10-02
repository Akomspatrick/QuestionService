using MediatR;
using QuestionService.Application;
using QuestionService.Repository;
using QuestionService.Repository.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddMediatR(typeof(Program));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddApplication();
builder.Services.AddScoped(typeof(IQueryableQuestionEntityRepository), typeof(QueryableQuestionnaireEntityRepository));
builder.Services.AddScoped(typeof(IQueryableAnswerEntityRepository), typeof(QueryableAnswerEntityRepository));
//builder.Services.AddSingleton<FakeStore>();
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
