using CrudDapperVideo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IUsuarioInterface, UsuarioService>();


builder.Services.AddAutoMapper(typeof(Program));//Aplicando  oautomapper em toda a aplicação

builder.Services.AddCors(options =>
{
    options.AddPolicy("usuariosApp", b => {
        b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
   
});//Eh necessario para a api receber requisições de fora, do front por exemplo

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("usuariosApp"); //necessario para ser usado a politica que foi criada na linha 18 assim aceitand as requisições do front

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
