using Microsoft.AspNetCore.Mvc;
using models;

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public Boolean Login([FromBody] dynamic requestBody)
        {
            User user = new User(requestBody.login, requestBody.senha);
            // Validação simples das credenciais (apenas exemplo, você pode usar um banco de dados)
            if (user.getLogin() == "usuario@teste.com" && user.getSenha() == "123456")
            {
                // se o login der certo
                return true;
            }

            // Se o login falhar
            return false;
        }
    }

