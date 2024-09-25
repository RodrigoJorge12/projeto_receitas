using models;
using controllers;
using System.Text.Json.Nodes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Configurar o CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost") // TODO: Alterar para o URL do frontend
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

var app = builder.Build();

app.UseRouting();
app.UseCors("AllowSpecificOrigin");

app.MapPost("/login", static async (HttpContext context) => {
    var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
    LoginController loginController = new LoginController();
    if (string.IsNullOrWhiteSpace(body)){
        return false;
    }
    var jsonNode = JsonNode.Parse(body);

    string? login = jsonNode["login"]?.ToString();
    string? senha = jsonNode["senha"]?.ToString();

    User? user = new User(login, senha);
    if(user == null){
        return false;
    }
    return loginController.Login(user);
});

app.Run();
