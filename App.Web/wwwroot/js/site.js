$(document).ready(function () {
    let errorToast = document.getElementById('error-toast');
    if (!!errorToast) {
        let toastBlock = new bootstrap.Toast(errorToast);
        toastBlock.show();
    }

    let successToast = document.getElementById('success-toast');
    if (!!successToast) {
        let toastBlock = new bootstrap.Toast(successToast);
        toastBlock.show();
    }
})

//Category
$(document).ready(function () {
    $(document).on("click", "#pagination a", function (e) {
        e.preventDefault();
        var page = $(this).data("page");
        searchCategoryWithPagination(page);
    });
});

function searchCategoryWithPagination(pageIndex) {
    let searchValue = $("#searchBox").val();

    $.ajax({
        type: 'GET',
        url: '/Category/Index',
        data: { pageIndex: pageIndex, searchName: searchValue },
        success: function (data) {
            console.log("AJAX request successful.");
            var newContent = $(data).find('#data-container').html();
            $("#data-container").html(newContent);
        },
        error: function (error) {
            console.error("AJAX request failed: ", error);
            ShowMessage('', 'internal server error', '');
        }
    });
}

function searchReset() {
    $("#searchBox").val('');
    searchDepartementWithPagination(1);
}

///Departement

$(document).ready(function () {
    $(document).on("click", "#pagination a", function (e) {
        e.preventDefault();
        var page = $(this).data("page");
        searchDepartementWithPagination(page);
    });
});

function searchDepartementWithPagination(pageIndex) {
    let searchValue = $("#searchBox").val();

    $.ajax({
        type: 'GET',
        url: '/Departement/GetAll',
        data: { pageIndex: pageIndex, searchName: searchValue },
        success: function (data) {
            console.log("AJAX request successful.");
            var newContent = $(data).find('#data-container').html();
            $("#data-container").html(newContent);
        },
        error: function (error) {
            console.error("AJAX request failed: ", error);
            ShowMessage('', 'internal server error', '');
        }
    });
}

function searchReset() {
    $("#searchBox").val('');
    searchDepartementWithPagination(1);
}

/// Role
$(document).ready(function () {
    $(document).on("click", "#pagination a", function (e) {
        e.preventDefault();
        var page = $(this).data("page");
        searchRoleWithPagination(page);
    });
});

function searchRoleWithPagination(pageIndex) {
    let searchValue = $("#searchBox").val();

    $.ajax({
        type: 'GET',
        url: '/Role/GetAll',
        data: { pageIndex: pageIndex, searchName: searchValue },
        success: function (data) {
            console.log("AJAX request successful.");
            var newContent = $(data).find('#data-container').html();
            $("#data-container").html(newContent);
        },
        error: function (error) {
            console.error("AJAX request failed: ", error);
            ShowMessage('', 'internal server error', '');
        }
    });
}

function searchReset() {
    $("#searchBox").val('');
    searchTicketWithPagination(1);
}


/// Ticket

$(document).ready(function () {
    $(document).on("click", "#pagination a", function (e) {
        e.preventDefault();
        var page = $(this).data("page");
        searchTicketWithPagination(page);
    });
});

function searchTicketWithPagination(pageIndex) {
    let searchValue = $("#searchBox").val();

    $.ajax({
        type: 'GET',
        url: '/Ticket/GetAll',
        data: { pageIndex: pageIndex, searchName: searchValue },
        success: function (data) {
            console.log("AJAX request successful.");
            var newContent = $(data).find('#data-container').html();
            $("#data-container").html(newContent);
        },
        error: function (error) {
            console.error("AJAX request failed: ", error);
            ShowMessage('', 'internal server error', '');
        }
    });
}

function searchReset() {
    $("#searchBox").val('');
    searchTicketWithPagination(1);
}


/// Message

function createMessageWithAjax(e) {
    let content = $("#messageContent").val();
    let ticketId = $("#messageTicketId").val();

    
    e.preventDefault();
    $.ajax({
        type: 'Post',
        url: '/Ticket/Chat',
        data : { Name: content, TicketId: ticketId },
        contentType: false,
        processData: false,
        success: function (response) {
            if (response) {
                if (response.name) {
                    ShowMessage('Success', "insert message succeed", 'success');
                } else {
                    ShowMessage('Error', response.errorMessages[0], 'error');
                }
            } else {
                ShowMessage('Error', 'Internal server error', 'error');
            }
        }
    });

}
function ShowMessage(title, text, theme) {
    alert(text);
}