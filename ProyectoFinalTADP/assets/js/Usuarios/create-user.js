$(document).ready(function () {


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

        $.ajax({
            url: 'https://636c31077f47ef51e143fcb9.mockapi.io/Usuarios',
            type: 'POST',
            data: obj,
            success: () => {

                Swal.fire({
                    position: 'center',
                    icon: 'success',
                    title: 'Your work has been saved',
                    showConfirmButton: true,
                    timer: 1500
                })
            }
        })

        setTimeout(function () {
            location.reload()
        },2000)      


                

               

    })
})



   

