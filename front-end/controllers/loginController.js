export class LoginController{

    async validarAcesso(login, senha){
        try{
            const response = await fetch("http://localhost:9000/login", {
                method : "POST",
                headers : {
                    "content-type" : "application/json"
                },
                body : JSON.stringify({
                    "login" : login,
                    "senha" : senha
                })
            });
            if(response.ok){
                const result = await response.json();
                if(result == true){
                    return true;
                }
                return false
            }
            return false;
        }
        catch(error){
            return false;
        }
    }

    setCookie(name, value, minutes) {
        const date = new Date();
        date.setTime(date.getTime() + (minutes * 60 * 1000)); 
        document.cookie = `${name}=${value};expires=${date.toUTCString()};path=/`;
    }
    
    getCookie(name) {
        const value = `; ${document.cookie}`;
        const parts = value.split(`; ${name}=`);
        if (parts.length === 2) return parts.pop().split(';').shift();
    } 
}