using conexao;
using models;
using MySql.Data.MySqlClient;

namespace repositories{
    public class RepositorioUsuarioEmBdr : RepositorioUsuario {
        private Conexao conexao;
        public RepositorioUsuarioEmBdr(Conexao conexao){
            this.conexao = conexao;
        }

        public Boolean validarLogin(User user){
            using (MySqlConnection conn = conexao.getConnection())
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                string query = "SELECT * FROM `usuarios` WHERE `login` = @login AND `senha` = @senha";
                using (MySqlCommand cmd = new MySqlCommand(query, conn)){
                    cmd.Parameters.AddWithValue("@login", user.getLogin());
                    cmd.Parameters.AddWithValue("@senha", user.getSenha());
                    using(MySqlDataReader reader = cmd.ExecuteReader()){
                        if(reader.Read()){
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public Boolean cadastrar(User user){
            //TODO: implementar função de cadastro de usuario
            return false;
        }
    }  
}