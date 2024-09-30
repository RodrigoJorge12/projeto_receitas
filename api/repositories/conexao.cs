using MySql.Data.MySqlClient;
using System;
namespace conexao{
    public class Conexao
    {
        private static MySqlConnection connection;

        private string connectionString = "Server=localhost;Database=seu_banco;User ID=root;Password=;";

        public Conexao(){
            connection = getConnection();
            string query = "CREATE TABLE IF NOT EXISTS usuarios(id INT PRIMARY KEY AUTO_INCREMENT NOT NULL, login varchar(30), senha varchar(6));";
            MySqlCommand comando = new MySqlCommand(query, connection);
            MySqlDataReader reader = comando.ExecuteReader();

            query = "CREATE TABLE IF NOT EXISTS receitas(id INT PRIMARY KEY AUTO_INCREMENT NOT NULL, ingredientes longText(100), modo_de_preparo = varchar(200), FOREIGN KEY (usuario_id) REFERENCES usuarios(id));";
            comando = new MySqlCommand(query, connection);
            reader = comando.ExecuteReader();
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