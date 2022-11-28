$(document).ready(function () {

    
    $('.delete-conf').click((event) => {

        event.preventDefault();

        return Swal.fire({
            title: '¿Está seguro??',
            text: "Esta acción no puede ser revertida",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si, borrar!',
            cancelButtonText: 'No, regresar'
        }).then((result) => {
            if (result.isConfirmed) {
                Swal.fire(
                    'Eliminado!',
                    'El usuario fue eliminado.',
                    'success'
                )
            }
        })
    

    })

})