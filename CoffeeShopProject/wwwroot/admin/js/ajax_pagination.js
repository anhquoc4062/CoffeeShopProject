function LoadPagination($maloai) {
    $.ajax({
        type: "GET",
        url: '/ProductAdmin/GetProductCount?maloai=' + $maloai,
        dataType: 'json',
        success: function (response) {
            if (response == 0) {
                $totalpage = 1;
            }
            else {
                var $totalpage = Math.ceil(parseInt(response) / 5);
            }
            
            $('#pagination-demo').empty();

            $('#pagination-demo').removeData("twbs-pagination");

            $('#pagination-demo').unbind("page");
            $('#pagination-demo').twbsPagination({
                totalPages: $totalpage,
                visiblePages: 5,
                first: '<<',
                prev: '<',
                next: '>',
                last: '>>'
            });
        },
        error: function (error) {
            alert("errror");
        }
    });
    
}
$(document).ready(function () {
    LoadPagination("0");

    $(document).on('click', 'li.page-item > a.page-link', function (event) {
        var page = $('li.page-item.active').find("a.page-link").text();
        var category_id = $("#category_filter").children("option:selected").val();
        //page = parseInt(page);

        $.ajax({
            type: "GET",
            url: '/ProductAdmin/GetProductByPage?maloai=' + category_id + '&page=' + page,
            dataType: 'json',
            success: function (response) {
                LoadProduct(response);
            },
            error: function (error) {
                alert("errror");
            }
        });

    });

});