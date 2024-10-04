using MySql.Data.MySqlClient;
using System;
namespace conexao{
    public class Conexao
    {
        private static MySqlConnection connection;

        private string connectionString = "Server=mysql;Database=sistema_receitas;User ID=root;Password=root;";

        public Conexao(){
            try {
                if (connection == null){
                    connection = new MySqlConnection(connectionString);
                    connection.Open();  // Abrir a conexão antes de executar comandos
                }

                // Criar a tabela de usuários
                string query = "CREATE TABLE IF NOT EXISTS usuarios(id INT PRIMARY KEY AUTO_INCREMENT NOT NULL, login varchar(30), senha varchar(6));";
                MySqlCommand comando = new MySqlCommand(query, connection);
                comando.ExecuteNonQuery();

                // Criar a tabela de receitas
                query = @"CREATE TABLE IF NOT EXISTS receitas (
                    id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
                    ingredientes LONGTEXT,
                    modo_de_preparo VARCHAR(200),
                    usuario_id INT,
                    FOREIGN KEY (usuario_id) REFERENCES usuarios(id)
                );";
                comando = new MySqlCommand(query, connection);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex){
                Console.WriteLine($"Erro ao criar conexão: {ex.Message}");
            }
        }

        public MySqlConnection getConnection(){
            if(connection == null){
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            return connection;
        }

        public void closeConnection(){
            if(connection != null){
                connection.Close();
            }
            connection = null;
        }
    }
}