using Microsoft.AspNetCore.Mvc;
using models;
    namespace controllers{
        public class LoginController : ControllerBase
        {
            public Boolean Login(User user)
            {
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
    }

