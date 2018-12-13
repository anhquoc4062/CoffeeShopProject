function LoadMenuPagination(maloai, sapxep) {
    $.ajax({
        type: "GET",
        url: '/Menu/GetProductCountWithFilter?maloai=' + maloai + '&sapxep=' + sapxep,
        dataType: 'json',
        success: function (response) {
            if (response == 0) {
                $totalpage = 1;
            }
            else {
                var $totalpage = Math.ceil(parseInt(response) / 6);
            }

            $('#menu_pagination').empty();

            $('#menu_pagination').removeData("twbs-pagination");

            $('#menu_pagination').unbind("page");
            $('#menu_pagination').twbsPagination({
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

function LoadMenuProduct(data) {
    var htmlString = "";
    for (i in data) {
        htmlString += '<div class="col-lg-4"><div class="menu-image">';
        htmlString += '<img src="/uploads/product/' + data[i].hinhAnh + '" alt="" width="200" height="200"></div>';
        htmlString += '<div class="single-menu"><div class="title-div justify-content-between d-flex">';
        htmlString += '<h4>' + data[i].tenThucDon + '</h4></div><p class="price">';
        if (data[i].khuyenMai == 0) {
            htmlString += '$' + data[i].gia.toFixed(2);
        }
        else {
            htmlString += '$' + data[i].getGiaKhuyenMai.toFixed(2);
            htmlString += '<del style="font-size:15px; color: gray; padding-left: 5px">$' + data[i].gia.toFixed(2)+'</del>';
        }
        htmlString += '</p><div class="order-button"><button class="btn btn-primary" data-id="' + data[i].maThucDon + '">Mua hàng</button>';
        htmlString += '</div></div></div>';
    }

    $("#menu_area .col-lg-4").remove();
    $("#menu_area").append(htmlString).hide().fadeIn(1000);
}

function SetDataFromFilters(maloai, sapxep) {
    maloai = $('ul.list-group-cate li.selected').attr("data-id");
    sapxep = $("#sort_product").val();
}
$(document).ready(function () {
    LoadMenuPagination(0,0);
    $(document).on('click', 'li.page-item > a.page-link', function (event) {
        var page = $('#menu_pagination li.page-item.active').find("a.page-link").text();
        var maloai = $('ul.list-group-cate li.selected').attr("data-id");
        var sapxep = $("#sort_product").val();
        //var searchBtnIsPressed = $("#search_button").attr("data-press-check");

        //if (searchBtnIsPressed == "0") {
            //var category_id = $("#category_filter").children("option:selected").val();
            $.ajax({
                type: "GET",
                url: '/Menu/GetProductByPageWithFilter?page=' + page + '&maloai=' + maloai + '&sapxep=' + sapxep,
                dataType: 'json',
                success: function (response) {
                    console.log(response);
                    LoadMenuProduct(response);
                },
                error: function (error) {
                    alert("errror");
                }
            });
        //}

        /*else {
            var keyword = $("#search_input").val();
            SearchProduct(keyword, page);
        }*/

    });

    $(document).on('click', 'ul.list-group-cate li', function (event) {
        event.preventDefault();
        $(".selected").removeClass("selected");
        $(this).addClass("selected");
        var maloai = $('ul.list-group-cate li.selected').attr("data-id");
        var sapxep = $("#sort_product").val();
        $.ajax({
            type: "GET",
            url: '/Menu/GetProductByPageWithFilter?maloai=' + maloai + '&sapxep=' + sapxep,
            dataType: 'json',
            success: function (response) {
                console.log(response);
                LoadMenuProduct(response);
                LoadMenuPagination(maloai, sapxep);
            },
            error: function (error) {
                alert("errror");
            }
        });
    });

    $(document).on('change', '#sort_product', function (event) {
        var maloai = $('ul.list-group-cate li.selected').attr("data-id");
        var sapxep = $("#sort_product").val();
        $.ajax({
            type: "GET",
            url: '/Menu/GetProductByPageWithFilter?maloai=' + maloai + '&sapxep=' + sapxep,
            dataType: 'json',
            success: function (response) {
                console.log(response);
                LoadMenuProduct(response);
                LoadMenuPagination(maloai, sapxep);
            },
            error: function (error) {
                alert("errror");
            }
        });
    });
});