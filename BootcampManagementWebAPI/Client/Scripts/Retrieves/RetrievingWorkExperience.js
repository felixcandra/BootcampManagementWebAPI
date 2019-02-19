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
            url: 'http://localhost:53126/api/WorkExperience',
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
    $.each(Students, function (i, val) { // tambahkan item baru kedalam dropdown untuk setiap nilai yang ada didalam Regencys []
        $ele.append($('<option/>').val(val.Id).text(val.Name)); //id sama namanyanya Provincies
    })
}

function LoadIndexProvince() {
    $.ajax({
        type: "GET", //untuk menampilkan data
        url: "http://localhost:53126/api/WorkExperience",
        async: false, // ini untuk menjalankan fungsi search dan sorting data table
        datatype: "json",
        success: function (province) {
            var html = '';
            $.each(province, function (index, val) {
                html += '<tr>';
                //html += '<td>' + i + '</td>'; ini kalau mau nampilkan nomor 1 sampai sekian
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Position + '</td>';
                html += '<td>' + val.Description + '</td>';
                html += '<td>' + val.StartDate + '</td>';
                html += '<td>' + val.EndDate + '</td>';
                html += '<td>' + val.Students.Name + '</td>';
                //ini untuk tampilkan foreign key
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
    item.Name = $('#Name').val(); // simpan nilai yang ada di #Name di view kedalam object 
    item.Position = $('#Position').val();
    item.Description = $('#Description').val();
    item.Position = $('#StartDate').val();
    item.Description = $('#EndDate').val();
    item.Students_Id = $('#Student').val();// masih ragu disini
    $.ajax({
        type: "POST", //insert
        url: "http://localhost:53126/api/WorkExperience",
        datatype: "json",
        data: item, //data yang akan disimpan adalah object yang di deklarasikan tadi
        success: function (result) { //kalo sukses muat ulang data kedalam tabel
            LoadIndexProvince();
            $('#myModal').modal('hide');
            $('#Name').val('');
            $('#Position').val('');
            $('#Description').val('');
            $('#StartDate').val('');
            $('#EndDate').val('');
            $('#Student').val(0);
        }
    });
}
function Edit() {
    debugger;
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{
    var item = new Object(); // sama kayak di save
    item.Id = $('#Id').val();// id dari data yang akan diedit
    item.Name = $('#Name').val();// data yang akan diedit
    item.Position = $('#Position').val();
    item.Description = $('#Description').val();
    item.Position = $('#StartDate').val();
    item.Description = $('#EndDate').val();
    item.Students_Id = $('#Student').val();// masih ragu disini
    $.ajax({
        type: "PUT", //put untuk update
        url: "http://localhost:53126/api/WorkExperience" + $('#Id').val(),
        datatype: "json",
        data: item,
        success: function (result) {
            LoadIndexProvince();
            $('#myModal').modal('hide');
            $('#Name').val('');
            $('#Position').val('');
            $('#Description').val('');
            $('#StartDate').val('');
            $('#EndDate').val('');
            $('#Student').val(0);

        }
    });
};
function GetById(Id) {
    debugger;
    $.ajax({
        url: "http://localhost:53126/api/WorkExperience" + Id, // search
        type: "GET",
        datatype: "json",
        success: function (item) {
            $('#Id').val(item.Id);
            $('#Name').val(item.Name);
            $('#Position').val(item.Position);
            $('#Description').val(item.Description);
            $('#Student').val(item.Students.Id);//udah benar
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
            url: "http://localhost:53126/api/WorkExperience" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft deleted.",
                    type: "success"
                },
                function () {
                    window.location.href = '/Regencies/Index'; // ini belum tau buat apa
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
    //cek textbox nama
    if ($('#Name').val() == "" || ($('#Name').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Name').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    if ($('#Position').val() == "" || ($('#Position').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Position').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    if ($('#Description').val() == "" || ($('#Description').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Description').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek dropdown Province
    if ($('#Student').val() == "0" || $('#Student').val() == 0) {
        isAllValid = false;
        $('#Student').siblings('span.error').css('visibility', 'visible');
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
    //cek textbox nama
    if ($('#Name').val() == "" || ($('#Name').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Name').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    if ($('#Position').val() == "" || ($('#Position').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Position').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    if ($('#Description').val() == "" || ($('#Description').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Description').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek dropdown Province
    if ($('#Student').val() == "0" || $('#Student').val() == 0) {
        isAllValid = false;
        $('#Student').siblings('span.error').css('visibility', 'visible');
    }
    // kalau semua field sudah terisi
    if (isAllValid) {
        Edit();
    }
}

function hideAlert() {
    $('#Name').siblings('span.error').css('visibility', 'hidden');
    $('#Position').siblings('span.error').css('visibility', 'hidden');
    $('#phone').siblings('span.error').css('visibility', 'hidden');
    $('#Student').siblings('span.error').css('visibility', 'hidden');
}

function nuke() {
    $('#Name').val('');
    $('#Position').val('');
    $('#Description').val('');
    $('#StartDate').val('');
    $('#EndDate').val('');
    $('#Student').val(0);
    $('#Save').show();
    $('#Update').hide();
    hideAlert();
}
LoadStudent($('#Student'));