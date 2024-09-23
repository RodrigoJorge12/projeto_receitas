import { LoginController } from "./loginController.js";


document.getElementById("btnEnviar").addEventListener("click", async function(){
    const loginController = new LoginController();
    const login = document.getElementById("login").value;
    const senha = document.getElementById("senha").value;
    if(await loginController.validarAcesso(login, senha) == true){
        loginController.setCookie('sessao_valida', 'true', 2);
        window.location.href = "./../index.html";
    }
});

