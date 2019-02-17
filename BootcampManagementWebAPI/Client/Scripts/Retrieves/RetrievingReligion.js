﻿$(document).ready(function () {
    LoadIndexReligion();
    $('#table').DataTable({
        "ajax": LoadIndexReligion()
    })
    nuke();
})

function LoadIndexReligion() {
    debugger;
    $.ajax({
        type: "GET", //untuk menampilkan data
        url: "http://localhost:53126/api/Religions",
        async: false, // ini untuk menjalankan fungsi search dan sorting data table
        datatype: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                //html += '<td>' + i + '</td>'; ini kalau mau nampilkan nomor 1 sampai sekian
                html += '<td>' + val.Name + '</td>';
                //html += '<td>' + val.Regency.Name + '</td>'; ini untuk tampilkan foreign key
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ')"> Edit </a>';
                html += '| <a href="#" onclick="return Delete(' + val.Id + ')"> Delete </a>  </td>';
                html += '</tr>';
                //i++;
            });
            $('.tbody').html(html);// ini untuk menerapkan koding html diatas

        }
    });
}
function validationInsert() {
    hideAlert();
    var isAllValid = true;
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        isAllValid = false;
        $('#Name').siblings('span.error').css('visibility', 'visible');
    }
    if (isAllValid) {
        Save();
    }
}
function validationUpdate() {
    hideAlert();
    var isAllValid = true;
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        isAllValid = false;
        $('#Name').siblings('span.error').css('visibility', 'visible');
    } if (isAllValid) {
        Edit();
    }
}
function Save() {
    debugger;
    var religion = new Object(); //deklarasikan object baru yang akan disimpan nilai nilai didalamnya
    religion.Name = $('#Name').val(); // simpan nilai yang ada di #Name di view kedalam object 
    $.ajax({
        type: "POST", //insert
        url: "http://localhost:53126/api/Religions",
        datatype: "json",
        data: religion, //data yang akan disimpan adalah object yang di deklarasikan tadi
        success: function (result) { //kalo sukses muat ulang data kedalam tabel
            LoadIndexReligion();
            $('#myModal').modal('hide');
            $('#Name').val('');
        }
    });
}
function Edit() {
    var religion = new Object(); // sama kayak di save
    religion.Id = $('#Id').val();// id dari data yang akan diedit
    religion.Name = $('#Name').val();// data yang akan diedit
    $.ajax({
        type: "PUT", //put untuk update
        url: "http://localhost:53126/api/Religions/" + $('#Id').val(),
        datatype: "json",
        data: religion,
        success: function (result) {
            LoadIndexReligion();
            $('#myModal').modal('hide');
            $('#Name').val('');
        }
    });
};
function GetById(Id) {
    hideAlert();
    $.ajax({
        url: "http://localhost:53126/api/Religions/" + Id, // search
        type: "GET",
        datatype: "json",
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            $('#myModal').modal('show');
            $('#Update').show();
            $('#Save').hide();
        }
    });
}
function Delete(Id) {
    swal({ // popup konfirmasi delete swal 
        title: "Are you sure want to delete this?",
        text: "You will not be able to recover this!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, Delete it",
        closeOnConfirm: false
    }, function () { // fungsi jika user memilih untuk menghapus
        $.ajax({
            url: "http://localhost:53126/api/Religions/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft deleted.",
                    type: "success"
                },
                function () {
                    window.location.href = '/Religions/Index'; // ini belum tau buat apa
                });
            },
            error: function (response) {
                swal("Oops", "We could not connect to the server!", "error");
            }
        });
    });
}
function hideAlert() {
    $('#Name').siblings('span.error').css('visibility', 'hidden');
}
function nuke() {
    $('#Id').val('');
    $('#Name').val('');
    $('#Save').show();
    $('#Update').hide();
    hideAlert();
}