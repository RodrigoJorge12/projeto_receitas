

using models;
namespace repositories{

    public interface RepositorioUsuario{
        public Boolean validarLogin(User user);

        public Boolean cadastrar(User user);
    }
}