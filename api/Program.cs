using models;
using controllers;
using conexao;
using repositories;
using System.Text.Json.Nodes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAll");
app.UseRouting();

app.MapPost("/login", static async (HttpContext context) => {
    var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
    Conexao conexao = new Conexao();
    RepositorioUsuario repo = new RepositorioUsuarioEmBdr(conexao);
    LoginController loginController = new LoginController(repo);
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
