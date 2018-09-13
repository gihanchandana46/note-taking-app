



var baseUrl = "http://localhost:60080";


$(document).ready(function () {

    $('[data-toggle="offcanvas"]').click(function () {
        $('#side-menu').toggleClass('hidden-xs');
    });

    $('.table').dataTable({
        bFilter: false, bInfo: false

    });

});



function loadHome() {
    $('.contenr-inner').load('../home/components/Home.html');
    return false;
}

function loadCreateNote() {
    $('.contenr-inner').load('../home/components/CreateNote.html');
    return false;
}

function loadEditNote() {
    $('.contenr-inner').load('../home/components/EditNote.html');
    return false;
}

function loadHomeMain() {
    window.location.href = "home/index.html";
}


function saveUserID() {

    var contactNo = $("#loginUsername").val();
    $.cookie("username", $("#loginUsername").val());

}

var username = $.cookie("username");
var id = "";
var title = "";
var date = "";
var notebody = "";



function createUser() {

    var username = $("#regUsername").val();
    var password = $("#regPassword").val();
    var cpassword = $("#regCPassword").val();

    if (password != cpassword || username == "" || password == "" || cpassword == "") {

        alert("Please check input fields");

    }
    else {
        $.ajax({
            type: "POST",
            url: '' + baseUrl + '/api/user',
            data: {
                username: username,
                password: password
            },
            dataType: "text",

            success: function (data) {
                alert("User Created");
            },
            error: function (data) {
                alert("errr");
            }
        });
    }
}



function checkloginMain() {

    var username = $("#loginUsername").val();
    var password = $("#loginPassword").val();

    if (username == "" || password == "") {
        alert("Check username and password");
    }

    else {
        $.ajax({
            type: "POST",
            url: '' + baseUrl + '/api/login',
            data: {
                username: username,
                password: password
            },
            dataType: "text",

            success: function (data) {
                alert("Login Sucessful");
                loadHomeMain();
            },
            error: function (data) {
                alert("Login error");
            }
        });
    }
}



function createNote() {

    var title = $("#noteTitle").val();
    var body = $("#noteBody").val();

    $.ajax({
        type: "POST",
        url: '' + baseUrl + '/api/note',
        data: {

            title: title,
            body: body,
            username: username
        },
        dataType: "text",

        success: function (data) {
            alert("Note Created");
            click();

        },
        error: function (data) {
            alert("errr Created");
        }
    });
}

function loadNotes() {

    $.ajax({
        type: "GET",
        url: '' + baseUrl + '/api/note?username=' + username + '',
        data: {


        },

        dataType: "json",

        success: function (data) {

            drawTable(data);

        },
        error: function (data) {
            alert("error");

        }
    });

}

function updateNote() {

    var noteTitle = $("#noteTitle").val();
    var noteBody = $("#noteBody").val();


    $.ajax({
        type: "PUT",
        url: '' + baseUrl + '/api/Note/' + id + '',
        data: {
            title: noteTitle,
            body: noteBody

        },
        dataType: "json",

        success: function (data) {
            alert("Note Updated");
            loadHome();
            click();
        },
        error: function (data) {

            alert("errr Created");

        }
    });
}

function deleteNote() {

    $.ajax({
        type: "DELETE",
        url: '' + baseUrl + '/api/Note/' + id + '',


        success: function (data) {
            alert("Note Deleted");
            loadHome();
            click();
        },
        error: function (data) {
            alert("errr Created");

        }
    });
}



function drawTable(data) {
    for (var i = 0; i < data.length; i++) {
        drawRow(data[i]);
    }
}

function drawRow(rowData) {
    var row = $("<tr />")
    $("#noteTable").append(row);
    row.append($("<td>" + rowData.id + "</td>"));
    row.append($("<td>" + rowData.title + "</td>"));
    row.append($("<td>" + rowData.date + "</td>"));
    row.append($("<td>" + rowData.body + "</td>"));

}



function getTableData() {

    var table = document.getElementsByTagName("table")[0];
    var tbody = table.getElementsByTagName("tbody")[0];
    tbody.onclick = function (e) {
        e = e || window.event;
        var data = [];
        var target = e.srcElement || e.target;
        while (target && target.nodeName !== "TR") {
            target = target.parentNode;
        }
        if (target) {
            var cells = target.getElementsByTagName("td");
            for (var i = 0; i < cells.length; i++) {
                data.push(cells[i].innerHTML);
            }
        }
        id = data[0];
        title = data[1];
        notebody = data[3];
        alert("Note Id : " + id + " selected for edit");
    };

}

function click() {
    jQuery(function () {
        jQuery('#clickhome').click();
    });
}


