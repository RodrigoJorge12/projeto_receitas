using Microsoft.AspNetCore.Mvc;
using models;
using repositories;
    namespace controllers{
        public class LoginController
        {
            private RepositorioUsuario repositorio;

            public LoginController(RepositorioUsuario repositorio){
                this.repositorio = repositorio;
            }

            public Boolean Login(User user)
            {
                return this.repositorio.validarLogin(user);
            }
        }
    }

