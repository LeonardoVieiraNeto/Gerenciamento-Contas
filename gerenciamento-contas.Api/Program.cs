using Gerenciamento.Contas.Services; 
using Gerenciamento.Contas.Repository; 
using Gerenciamento.Contas.Models.Interfaces; 
using Microsoft.EntityFrameworkCore.Sqlite;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IFinancialTransactionService, FinancialTransactionService>();
builder.Services.AddScoped<IRabitMQProducer, RabitMQProducer>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IFinancialTransactionRepository, FinancialTransactionRepository>();
builder.Services.AddDbContext<DbContextClass>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging(); // Adicione essa linha para configurar o provedor de logs

var app = builder.Build();

SeedDatabase();

void SeedDatabase()
{
    using(var scope = app.Services.CreateScope())
    try{
        var scopedContext = scope.ServiceProvider.GetRequiredService<DbContextClass>();
        Seeder.Initialize(scopedContext);
        }
catch{
    throw;
}
}


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
