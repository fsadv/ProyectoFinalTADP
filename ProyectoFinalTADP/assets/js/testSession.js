
const usuario = document.getElementById("nuevaPrueba");
const usuarioJson = JSON.parse(usuario.value);



if(usuarioJson.TipoUsuario.tipo != 'admin') {
    const gestionUser = document.getElementById('panelAdmin');
    gestionUser.setAttribute('hidden', true);
}


console.log(usuarioJson.TipoUsuario.tipo)







