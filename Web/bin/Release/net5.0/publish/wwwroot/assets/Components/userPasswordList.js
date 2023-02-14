
$(document).ready(function () {




    $("#passwordListTable").DataTable({
        responsive: true,
        searchDelay: 500,
        processing: true,
        serverSide: true,
        bDestroy: true,
        order: [[6, 'desc']],
        stateSave: true,
        select: {
            style: 'os',
            selector: 'td:first-child',
            className: 'row-selected'
        },
        ajax: {
            url: "/MyPassword/GetPasswordList",
            method: "POST"
        },
        columns: [
            { data: 'id' },
            { data: 'recordDefinition' },
            { data: 'categoryName' },
            { data: 'userName' },
            { data: 'url' },
            { data: 'createdAt' },
            { data: null },

        ],
        columnDefs: [

            {
                targets: -1,
                data: null,
                orderable: false,
                className: 'text-end',
                render: function (data, type, row) {
                    return `
                            <a href="javascript:void(0)" data-id="${data.id}"  class="btn btn-info btn-sm showInfo" ><i class="fa fa-eye"></i> İncele</a>
                            <a href="/MyPassword/Edit/${data.id}" class="btn btn-info btn-sm" ><i class="fa fa-edit"></i> Düzenle</a>
                            <a href="javascript:void(0)"  onclick="deletePass(${data.id})" class="btn btn-danger btn-sm"><i class="fa fa-trash"></i> Sil</a>
                        `;
                },
            },
        ]
    });




});


$(document).on("click", ".showInfo", function () {
    var Id = $(this).data('id');
    $.ajax({
        url: '/MyPassword/View',
        type: 'post',
        data: { Id: Id },
        success: function (response) {


            $("#KayitTanim").val(response.recordDefinition);
            $("#KategoriAdi").val(response.categoryName);
            $("#URL").val(response.url);
            $("#KullaniciAdi").val(response.userName);
            $("#Parola").val(response.password);



            $('#bilgiGoster').modal('show');
        }
    });

});





function deletePass(id) {
    
    swal({
        title: "Parola Silinecek",
        text: "Seçmiş olduğunuz parola silinecek, kabul ediyor musunuz?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Evet, Sil!",
    }).then(result => {
      
        if (result.value) {



            $.ajax({
                url: '/MyPassword/Delete',
                type: 'post',
                data: { Id: id },
                success: function (response) {

                    if (response.success) {
                        //swal("Silindi!", response.message, "success");

                        swal({
                            title: "Başarılı", text: response.message, type:
                                "success"
                        }).then(function () {
                            location.reload();
                        }
                        );

                    } else {
                        swal("HATA", "Silme İşleminde Bir Problem Oluştu", "error");
                    }

                }
            });


        } else  {
            swal("İptal Edildi", "Silme İşlemi İptal Edildi", "error");
        }
    });


}

