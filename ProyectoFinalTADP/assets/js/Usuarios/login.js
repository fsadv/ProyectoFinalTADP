$(document).ready(function () {

    $('#submit').attr('disabled', 'disabled');

    $('#mail').blur(() => {
        $('#rellenar').hide()
    })
  
    $('#password').blur(() => {

        const mail = $('#mail').val();
        const pass = $('#password').val();

        
        $.get("https://636c31077f47ef51e143fcb9.mockapi.io/Usuarios", (data) => {

            const user = data.filter(x => x.Email == mail && x.Clave == pass);

            if (user.length != 0) {
                $('#submit').removeAttr('disabled');
                $('#rellenar').hide()
            } else {
                $('#rellenar').show().html('Usuario o contraseña incorrectos')
                $('#submit').attr('disabled', 'disabled');
            }
                        

        })

        
        


    })
   



})

