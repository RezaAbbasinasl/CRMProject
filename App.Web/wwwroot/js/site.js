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
    searchCategoryWithPagination(1);
}