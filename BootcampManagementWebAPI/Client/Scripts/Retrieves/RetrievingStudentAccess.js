var Provinces = []
$(document).ready(function () {
    hideAlert();
    LoadIndexProvince();
    $('#table').DataTable({
        "ajax": LoadIndexProvince()
    })
})

function LoadProvince(element) {
    if (Provinces.length == 0) {
        $.ajax({
            type: "GET", // get
            url: 'http://localhost:53126/api/Regency',
            success: function (data) {
                Provinces = data; //Regency
                //and render Regency to element
                renderProvince(element);
            }
        })
    } else {
        //render Regency to element if var Regencies above not empty
        renderProvince(element);
    }
}
function renderProvince(element) {
    var $ele = $(element);
    $ele.empty(); //kosongkan element
    $ele.append($('<option/>').val('0').text('Select')); //tambahkan item kedalam dropdown
    $.each(Provinces, function (i, val) { // tambahkan item baru kedalam dropdown untuk setiap nilai yang ada didalam Regencys []
        $ele.append($('<option/>').val(val.Id).text(val.Name)); //id sama namanyanya Provincies
    })
}

function LoadIndexProvince() {
    $.ajax({
        type: "GET", //untuk menampilkan data
        url: "http://localhost:53126/api/Regency",
        async: false, // ini untuk menjalankan fungsi search dan sorting data table
        datatype: "json",
        success: function (province) {
            var html = '';
            $.each(province, function (index, val) {
                html += '<tr>';
                //html += '<td>' + i + '</td>'; ini kalau mau nampilkan nomor 1 sampai sekian
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Provinces.Name + '</td>'; //ini untuk tampilkan foreign key
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ')"> Edit </a>';
                html += '| <a href="#" onclick="return Delete(' + val.Id + ')"> Delete </a>  </td>';
                html += '</tr>';
                //i++;
            });
            $('.tbody').html(html);// ini untuk menerapkan koding html diatas

        }
    });
}
function Save() {
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{ (contohnya LoadIndexItem padahal diatas tulisannya LoadIndexProvince
    var item = new Object(); //deklarasikan object baru yang akan disimpan nilai nilai didalamnya
    item.Students_Id = $('#Student').val(); // simpan nilai yang ada di #Name di view kedalam object 
    item.Accesses_Id = $('#Access').val();// masih ragu disini
    $.ajax({
        type: "POST", //insert
        url: "http://localhost:53126/api/Regency",
        datatype: "json",
        data: item, //data yang akan disimpan adalah object yang di deklarasikan tadi
        success: function (result) { //kalo sukses muat ulang data kedalam tabel
            LoadIndexProvince();
            $('#myModal').modal('hide');
            $('#Student').val(0);
            $('#Access').val(0);
        }
    });
}
function Edit() {
    debugger;
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{
    var item = new Object(); // sama kayak di save
    item.Id = $('#Id').val();// id dari data yang akan diedit
    item.Students_Id = $('#Student').val();// data yang akan diedit
    item.Accesses_id = $('#Access').val();// masih ragu disini
    $.ajax({
        type: "PUT", //put untuk update
        url: "http://localhost:53126/api/Regency/" + $('#Id').val(),
        datatype: "json",
        data: item,
        success: function (result) {
            LoadIndexProvince();
            $('#myModal').modal('hide');
            $('#Student').val(0);
            $('#Access').val(0);
        }
    });
};
function GetById(Id) {
    debugger;
    $.ajax({
        url: "http://localhost:53126/api/Regency/" + Id, // search
        type: "GET",
        datatype: "json",
        success: function (item) {
            $('#Id').val(item.Id);
            $('#Student').val(item.Students_Id);
            $('#Access').val(item.Provinces.Id);//udah benar
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
            url: "http://localhost:53126/api/Regency/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft deleted.",
                    type: "success"
                },
                function () {
                    window.location.href = '/StudentAccesses/Index'; // ini belum tau buat apa
                });
            },
            error: function (response) {
                swal("Oops", "We could not connect to the server!", "error");
            }
        });
    });
}

function validationInsert() {
    hideAlert(); // setiap kali ngeklik tombol save ilangkan dulu errornya baru cek lagi satu satu
    var isAllValid = true; //asumsi semua textbox sudah terisi
    //cek dropdown Province
    if ($('#Student').val() == "0" || $('#Student').val() == 0) {
        isAllValid = false;
        $('#Student').siblings('span.error').css('visibility', 'visible');
    }
    //cek dropdown Province
    if ($('#Access').val() == "0" || $('#Access').val() == 0) {
        isAllValid = false;
        $('#Access').siblings('span.error').css('visibility', 'visible');
    }
    // kalau semua field sudah terisi
    if (isAllValid) {
        Save();
    }
}

function validationUpdate() {
    debugger;
    hideAlert();
    var isAllValid = true; //asumsi semua textbox sudah terisi
    //cek dropdown Province
    if ($('#Student').val() == "0" || $('#Student').val() == 0) {
        isAllValid = false;
        $('#Student').siblings('span.error').css('visibility', 'visible');
    }
    //cek dropdown Province
    if ($('#Access').val() == "0" || $('#Access').val() == 0) {
        isAllValid = false;
        $('#Access').siblings('span.error').css('visibility', 'visible');
    }
    // kalau semua field sudah terisi
    if (isAllValid) {
        Edit();
    }
}

function hideAlert() {
    $('#Student').siblings('span.error').css('visibility', 'hidden');
    $('#Access').siblings('span.error').css('visibility', 'hidden');
}

function nuke() {
    $('#Student').val(0);
    $('#Access').val(0);
    hideAlert();
}
LoadStudent($('#Student'));
LoadAccess($('#Access'));