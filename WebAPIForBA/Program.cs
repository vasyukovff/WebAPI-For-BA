using WebAPIForBA.Filters.Exceptions;
using WebAPIForBA.Orchestrators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddMvc(options =>
{
    options.Filters.Add(new ArrayExceptionFilterAttribute());
});

builder.Services.AddSingleton<AccountOrchestrator, AccountOrchestrator>();
builder.Services.AddSingleton<DepartmentOrchestrator, DepartmentOrchestrator>();
builder.Services.AddSingleton<ProfileOrchestrator, ProfileOrchestrator>();

//builder.Services.Fil

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

app.UseAuthorization();

app.MapControllers();

app.Run();
