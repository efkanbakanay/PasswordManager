
$('#passwordShow').click(function () {
    if ('password' == $('#Password').attr('type')) {
        $('#Password').prop('type', 'text');
    } else {
        $('#Password').prop('type', 'password');
    }
});

$('#generatePassword').click(function () {
    if ('password' == $('#Password').attr('type')) {
        $('#Password').prop('type', 'text');
    }
});




$('#createCategory').submit(function (e) {
    e.preventDefault();
    var $form = $(this);


    $.ajax({
        type: "POST",
        url: "/Category/Create",
        data: { "CategoryName": $("#CategoryName").val() },
        success: function (response) {

            if (response.success) {
                toastr.success(response.message, "BAŞARILI");

                $('#CategoryId').append(`<option value="${response.data.id}">
                                               ${response.data.categoryName}
                                          </option>`);

                $("#yeniKategoriModal").modal("hide");

            } else {
                toastr.warning(response.message, "UYARI");
            }

        },
        failure: function (response) {
            toastr.error(response.message, "HATA");
        },
        error: function (response) {
            toastr.error(response.message, "HATA");
        }
    });
});


$('#yeniKategoriModal').on('hidden.bs.modal', function (e) {
    $("#CategoryName").val("");
})



