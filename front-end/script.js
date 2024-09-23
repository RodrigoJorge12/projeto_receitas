import { LoginController } from "./login/loginController.js";

const loginController = new LoginController();

const sessaoValida = loginController.getCookie('sessao_valida');

if (!sessaoValida) {
    window.location.href = './login/login.html';
}