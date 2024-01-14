

$('#SendTaskPut').on('submit', function (event) {
    event.preventDefault();

    var form = $(this);
    var data = form.serialize();

    $.ajax({
        url: '/Task/Edit',
        type: 'PUT',
        data: data,
        success: function (response) {
            location.href = response;
        }
    });
});

const DeleteTask = (id) => {
    Swal.fire({
        title: "Estás seguro?",
        text: "Se eliminará la tarea permanentemente!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Si, eliminar!",
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: `/Task/Delete?id=${id}`,
                type: 'DELETE',
                success: function (response) {
                    location.href = response;
                }
            });
        }
    });
}