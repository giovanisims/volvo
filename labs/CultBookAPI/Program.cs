using service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options => 
    {
        // This dis to tell the serializer to not include null fields to make the get for the books cleaner
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<LivroService>();
builder.Services.AddSingleton<ClienteService>();
builder.Services.AddSingleton<EnderecoService>();
builder.Services.AddSingleton<PedidoService>();
builder.Services.AddSingleton<ServicoAutenticacao>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();