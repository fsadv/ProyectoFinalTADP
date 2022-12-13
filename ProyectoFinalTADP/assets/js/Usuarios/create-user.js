$(document).ready(function () {


    const regexMail = /\S+@\S+\.\S+/;

    $('#Email').unbind().blur(() => {

        const Email = $('#Email').val();

        if (!regexMail.test(Email)) {

            
            Swal.fire('Por favor ingrese un mail correcto');
            $('#Email').val("");
            
        }
    })

    $('#btnCrear').click((event) => {

        event.preventDefault();

        const obj = {
            'Nombre': $('#Nombre').val(),
            'Apellido': $('#Apellido').val(),
            'Email': $('#Email').val(),
            'Clave': $('#Clave').val(),
            'UrlPerfil': $('#UrlPerfil').val(),
            'Descripcion': $('#Descripcion').val()
        }

        let CampoVacio = ValidarCampos(obj);

        if (!CampoVacio) {

                            $.ajax({
                                url: 'https://636c31077f47ef51e143fcb9.mockapi.io/Usuarios',
                                type: 'POST',
                                data: obj,
                                success: () => {

                                    Swal.fire({
                                        position: 'center',
                                        icon: 'success',
                                        title: 'IUsuario guardado con éxito',
                                        showConfirmButton: true,
                                        timer: 1500
                                    })
                                }
                            })

                            setTimeout(function () {
                                location.reload()
                            },2000)               

        } else {

            Swal.fire({
                icon: 'error',
                title: 'Campo vacío',
                text: 'Hay algún campo vacío!',
            })
        }


    function ValidarCampos(obj) {

        let errores = false;

        for (const prop in obj) {

          if (!obj[prop]) {
       
              errores = true;
      
            }
        }


        return errores;

    }

})


})
   

