import { LoginController } from "./controllers/loginController.js";

const loginController = new LoginController();

const sessaoValida = loginController.getCookie('sessao_valida');

if (!sessaoValida) {
    window.location.href = './src/login.html';
}