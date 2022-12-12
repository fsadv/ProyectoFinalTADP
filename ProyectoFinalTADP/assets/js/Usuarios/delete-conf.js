$(document).ready(function () {


    
    $('.delete-conf').click((event) => {

        const targetUrl = event.delegateTarget.href;
        const targetArray = targetUrl.split('/');
        const idToDelete = targetArray[targetArray.length - 1];
        const url = 'https://636c31077f47ef51e143fcb9.mockapi.io/Usuarios/' + idToDelete;
        

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

                $.ajax({
                    url: url,
                    type: 'DELETE',
                    success: function (result) {
                        Swal.fire(
                            'Eliminado!',
                            'El usuario fue eliminado.',
                            'success'
                        );
                    }
                });
               
            }
        })
    

    })

})