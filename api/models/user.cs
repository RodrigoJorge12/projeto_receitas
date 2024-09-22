namespace models{
    public class User{
        private string login;
        private string senha;

        public User(string login, string senha){
            this.login = login;
            this.senha = senha;
        }

        public string getLogin(){
            return this.login;
        }
        public string getSenha(){
            return this.senha;
        }
    }
}