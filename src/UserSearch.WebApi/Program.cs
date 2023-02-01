using UserSearch.Application;
using UserSearch.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMediator();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(corsOptions => corsOptions.AddPolicy("corsPolicy",
    corsPolicyBuilder => corsPolicyBuilder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddSingleton<IUserMapper, UserMapper>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("corsPolicy");
app.UseAuthorization();
app.MapControllers();

app.Run();