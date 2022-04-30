using Soinsoft.Inventory.Infra.Persistence.Container;
using Soinsoft.Inventory.Application.Commands.FProduct.Commands;
using Soinsoft.Inventory.Application.Commands.Validators;
using MediatR;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.PersistenceRegister(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(AddProductCmd)); //Para hacer mediator
builder.Services.AddAutoMapper(typeof(AddProductCmd)); //Aqui tengo profiles de mapping registrados
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>)); //Registro el comportamiento de validaciones
builder.Services.AddValidatorsFromAssembly(typeof(AddProductCmd).Assembly);
builder.Services.AddCors(opt=>{

   opt.AddPolicy("MyPolicy", p=> 
    p.WithOrigins("https://myapp01.azurewebsites.com")
    .AllowAnyHeader()
    .AllowAnyMethod());
}); //Added Policy for client app

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseCors(); //Added for client app

app.UseAuthorization();

app.MapControllers();

app.Run();
