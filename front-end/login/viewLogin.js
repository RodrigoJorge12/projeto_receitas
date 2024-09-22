import { LoginController } from "./loginController.js";


document.getElementById("btnEnviar").addEventListener("click", async function(){
    const login = document.getElementById("login").value;
    const senha = document.getElementById("senha").value;
    loginController = new LoginController(login, senha);
    if(await loginController.validarAcesso() == true){
        sessionStorage.setItem("sessao_valida", true);
    }
    alert("Login ou senha incorretos, tente novamente");
});