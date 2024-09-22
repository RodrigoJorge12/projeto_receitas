class LoginController{
    
    constructor(login, senha){
        this.login = login;
        this.senha = senha;
    }

    async validarAcesso(){
        try{
            const response = await fetch("http://localhost:9000/login", {
                method : "POST",
                headers : {
                    "content-type" : "application/json"
                },
                body : {
                    "login" : this.login,
                    "senha" : this.senha
                }
            });
            if(response.ok){
                return true;
            }
            return false;
        }
        catch(error){
            return false;
        }
    }
}