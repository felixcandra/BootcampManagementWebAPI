﻿var Departments = []
var Batches = []
<<<<<<< HEAD
=======
var Employees = []
>>>>>>> d2905a1880af22bd91c3b074297a75b37bab3a43
$(document).ready(function () {
    hideAlert();
    LoadIndexClass();
    $('#table').DataTable({
        "ajax": LoadIndexClass()
    })
})

<<<<<<< HEAD
=======
function LoadEmployee(element) {
    if (Employees.length == 0) {
        $.ajax({
            type: "GET", // get
            url: 'http://localhost:53126/api/Employees',
            success: function (data) {
                Employees = data; //Class
                //and render Class to element
                renderEmployee(element); 
            }
        })
    } else {
        //render Class to element if var Classes above not empty
        renderEmployee(element);
    }
}
function renderEmployee(element) {
    var $ele = $(element);
    $ele.empty(); //kosongkan element
    $ele.append($('<option/>').val('0').text('Select')); //tambahkan item kedalam dropdown
    $.each(Employees, function (i, val) { // tambahkan item baru kedalam dropdown untuk setiap nilai yang ada didalam Classs []
        $ele.append($('<option/>').val(val.Id).text(val.First_Name)); //id sama namanyanya Provincies
    })
}

>>>>>>> d2905a1880af22bd91c3b074297a75b37bab3a43
function LoadDepartment(element) {
    if (Departments.length == 0) {
        $.ajax({
            type: "GET", // get
            url: 'http://localhost:53126/api/Departments',
            success: function (data) {
                Departments = data; //Class
                //and render Class to element
<<<<<<< HEAD
                renderDepartment(element); 
=======
                renderDepartment(element);
>>>>>>> d2905a1880af22bd91c3b074297a75b37bab3a43
            }
        })
    } else {
        //render Class to element if var Classes above not empty
        renderDepartment(element);
    }
}
function renderDepartment(element) {
    var $ele = $(element);
    $ele.empty(); //kosongkan element
    $ele.append($('<option/>').val('0').text('Select')); //tambahkan item kedalam dropdown
    $.each(Departments, function (i, val) { // tambahkan item baru kedalam dropdown untuk setiap nilai yang ada didalam Classs []
        $ele.append($('<option/>').val(val.Id).text(val.Name)); //id sama namanyanya Provincies
    })
}

function LoadBatch(element) {
    if (Batches.length == 0) {
        $.ajax({
            type: "GET", // get
            url: 'http://localhost:53126/api/Batches',
            success: function (data) {
                Batches= data; //Class
                //and render Class to element
                renderBatch(element);
            }
        })
    } else {
        //render Class to element if var Classes above not empty
        renderBatch(element);
    }
}
function renderBatch(element) {
    var $ele = $(element);
    $ele.empty(); //kosongkan element
    $ele.append($('<option/>').val('0').text('Select')); //tambahkan item kedalam dropdown
    $.each(Batches, function (i, val) { // tambahkan item baru kedalam dropdown untuk setiap nilai yang ada didalam Classs []
        $ele.append($('<option/>').val(val.Id).text(val.Name)); //id sama namanyanya Provincies
    })
}

function LoadIndexClass() {
    $.ajax({
        type: "GET", //untuk menampilkan data
        url: "http://localhost:53126/api/Classes",
        async: false, // ini untuk menjalankan fungsi search dan sorting data table
        datatype: "json",
        success: function (kelas) {
            var html = '';
            $.each(kelas, function (index, val) {
                html += '<tr>';
                //html += '<td>' + i + '</td>'; ini kalau mau nampilkan nomor 1 sampai sekian
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Departments.Name + '</td>';
                html += '<td>' + val.Batches.Name + '</td>';//ini untuk tampilkan foreign key
<<<<<<< HEAD
=======
                html += '<td>' + val.Employees.First_Name + '</td>'
>>>>>>> d2905a1880af22bd91c3b074297a75b37bab3a43
                html += '<td> <a href="#" onclick="return GetById('+val.Id+')"> Edit </a>';
                html += '| <a href="#" onclick="return Delete('+val.Id+')"> Delete </a>  </td>';
                html += '</tr>';
                //i++;
            });
            $('.tbody').html(html);// ini untuk menerapkan koding html diatas

        }
    });
}
function Save() {
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{ (contohnya LoadIndexItem padahal diatas tulisannya LoadIndexDepartment
    var item = new Object(); //deklarasikan object baru yang akan disimpan nilai nilai didalamnya
    item.Name = $('#Name').val(); // simpan nilai yang ada di #Name di view kedalam object 
    item.Department_Id = $('#Department').val();// masih ragu disini
    item.Batch_Id = $('#Batch').val();
<<<<<<< HEAD
=======
    item.Employee_Id = $('#Employee').val();
>>>>>>> d2905a1880af22bd91c3b074297a75b37bab3a43
    $.ajax({
        type: "POST", //insert
        url: "http://localhost:53126/api/Classes",
        datatype: "json",
        data: item, //data yang akan disimpan adalah object yang di deklarasikan tadi
        success: function (result) { //kalo sukses muat ulang data kedalam tabel
            LoadIndexClass();
            $('#myModal').modal('hide');
            $('#Name').val('');
            $('#Department').val(0);
            $('#Batch').val(0);
<<<<<<< HEAD
=======
            $('#Employee').val(0);
>>>>>>> d2905a1880af22bd91c3b074297a75b37bab3a43
        }
    });
}
function Edit() {
    debugger;
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{
    var item = new Object(); // sama kayak di save
    item.Id = $('#Id').val();// id dari data yang akan diedit
    item.Name = $('#Name').val();// data yang akan diedit
    item.Department_id = $('#Department').val();// masih ragu disini
    item.Batch_Id = $('#Batch').val();
<<<<<<< HEAD
=======
    item.Employee_Id = $('#Employee').val();
>>>>>>> d2905a1880af22bd91c3b074297a75b37bab3a43
    $.ajax({
        type: "PUT", //put untuk update
        url: "http://localhost:53126/api/Classes/" + $('#Id').val(),
        datatype: "json",
        data: item,
        success: function (result) {
            LoadIndexClass();
            $('#myModal').modal('hide');
            $('#Name').val('');
            $('#Department').val(0);
            $('#Batch').val(0);
<<<<<<< HEAD
=======
            $('#Employee').val(0);

>>>>>>> d2905a1880af22bd91c3b074297a75b37bab3a43
        }
    });
};
function GetById(Id) {
    debugger;
    $.ajax({
        url: "http://localhost:53126/api/Classes/" + Id, // search
        type: "GET",
        datatype: "json",
        success: function (item) {
            $('#Id').val(item.Id);
            $('#Name').val(item.Name);
            $('#Department').val(item.Departments.Id);//udah benar
            $('#Batch').val(item.Batches.Id);
<<<<<<< HEAD
=======
            $('#Employee').val(item.Employees.Id);
>>>>>>> d2905a1880af22bd91c3b074297a75b37bab3a43
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
            url: "http://localhost:53126/api/Classes/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft deleted.",
                    type: "success"
                },
                function () {
                    window.location.href = '/Classes/Index'; // ini belum tau buat apa
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
    //cek dropdown Department
    if ($('#Department').val() == "0" || $('#Department').val() == 0) {
        isAllValid = false;
        $('#Department').siblings('span.error').css('visibility', 'visible');
    }
    // kalau semua field sudah terisi
<<<<<<< HEAD
    if (isAllValid) { 
=======
    if ($('#Batch').val() == "0" || $('#Batch').val() == 0) {
        isAllValid = false;
        $('#Batch').siblings('span.error').css('visibility', 'visible');
    }
    if ($('#Employee').val() == "0" || $('#Employee').val() == 0) {
        isAllValid = false;
        $('#Employee').siblings('span.error').css('visibility', 'visible');
    }
    // kalau semua field sudah terisi
    if (isAllValid) {
>>>>>>> d2905a1880af22bd91c3b074297a75b37bab3a43
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
    //cek dropdown Department
    if ($('#Department').val() == "0" || $('#Department').val() == 0) {
        isAllValid = false;
        $('#Department').siblings('span.error').css('visibility', 'visible');
    }
    // kalau semua field sudah terisi
<<<<<<< HEAD
=======
    if ($('#Batch').val() == "0" || $('#Batch').val() == 0) {
        isAllValid = false;
        $('#Batch').siblings('span.error').css('visibility', 'visible');
    }
    if ($('#Employee').val() == "0" || $('#Employee').val() == 0) {
        isAllValid = false;
        $('#Employee').siblings('span.error').css('visibility', 'visible');
    }
    // kalau semua field sudah terisi
>>>>>>> d2905a1880af22bd91c3b074297a75b37bab3a43
    if (isAllValid) {
        Edit();
    }
}

function hideAlert() {
    $('#Name').siblings('span.error').css('visibility', 'hidden');
    $('#Department').siblings('span.error').css('visibility', 'hidden');
    $('#Batch').siblings('span.error').css('visibility', 'hidden');
<<<<<<< HEAD
=======
    $('#Employee').siblings('span.error').css('visibility', 'hidden');

>>>>>>> d2905a1880af22bd91c3b074297a75b37bab3a43
}

function nuke() {
    $('#Name').val('');
    $('#Department').val(0);
    $('#Batch').val(0);
<<<<<<< HEAD
    hideAlert();
}
LoadDepartment($('#Department'));
LoadBatch($('#Batch'));
=======
    $('#Employee').val(0);
    hideAlert();
}
LoadDepartment($('#Department'));
LoadBatch($('#Batch'));
LoadEmployee($('#Employee'));
>>>>>>> d2905a1880af22bd91c3b074297a75b37bab3a43
