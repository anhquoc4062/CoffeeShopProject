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
        }
    });
}

function LoadSearchPagination(keyword) {
    $.ajax({
        type: "GET",
        url: '/Menu/GetProductCountWithKeyword?keyword=' + keyword,
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
            $("#alert_search #quantity").html(response);
            $("#alert_search #keyword").html(keyword);
        },
        error: function (error) {
        }
    });
}

function LoadProductWithKeywordByPage(keyword, page) {
    $.ajax({
        type: "GET",
        url: '/Menu/GetProductByName?keyword=' + keyword + '&page=' + page,
        dataType: 'json',
        success: function (response) {
            LoadMenuProduct(response);
        },
        error: function (error) {
        }
    });
}

function LoadMenuProduct(data) {
    var htmlString = "";
    if (data.length != 0) {
        for (i in data) {
            htmlString += '<div class="col-lg-4"><div class="menu-image">';
            htmlString += '<a href="/SingleProduct/Index/' + data[i].maThucDon + '"><img src="/uploads/product/' + data[i].hinhAnh + '" alt="" width="200" height="200"></a></div>';
            htmlString += '<div class="single-menu"><div class="title-div justify-content-between d-flex">';
            htmlString += '<h4>' + data[i].tenThucDon + '</h4></div><p class="price">';
            if (data[i].khuyenMai == 0) {
                htmlString += '$' + data[i].gia.toFixed(2);
            }
            else {
                htmlString += '$' + data[i].getGiaKhuyenMai.toFixed(2);
                htmlString += '<del style="font-size:15px; color: gray; padding-left: 5px">$' + data[i].gia.toFixed(2) + '</del>';
            }
            htmlString += '</p><div class="order-button"><button class="btn btn-primary" data-id="' + data[i].maThucDon + '">Mua hàng</button>';
            htmlString += '</div></div></div>';
        }

    }
    else {
        htmlString += '<div class="col-lg-12 text-center" id="not-found">';
        htmlString += '<p> Không tìm thấy sản phẩm</p ></div>';

    }

    $("#menu_area .col-lg-4").remove();
    $("#menu_area .col-lg-12").remove();
    $("#menu_area").append(htmlString).hide().fadeIn(1000);
}

$(document).ready(function () {
    LoadMenuPagination(0,0);
    $(document).on('click', 'li.page-item > a.page-link', function (event) {
        var page = $('#menu_pagination li.page-item.active').find("a.page-link").text();
        if ($("#search_button").attr("data-pressed") == "0") {

            var maloai = $('ul.list-group-cate li.selected').attr("data-id");
            var sapxep = $("#sort_product").val();
            $.ajax({
                type: "GET",
                url: '/Menu/GetProductByPageWithFilter?page=' + page + '&maloai=' + maloai + '&sapxep=' + sapxep,
                dataType: 'json',
                success: function (response) {
                    LoadMenuProduct(response);
                },
                error: function (error) {
                }
            });
        }
        else {
            var keyword = $("#alert_search #keyword").text();
            LoadProductWithKeywordByPage(keyword, page);
        }

    });

    $(document).on('click', 'ul.list-group-cate-child li, #filter-all', function (event) {
        event.preventDefault();
        $("#alert_search").css("display", "none");
        $(".selected").removeClass("selected");
        $(this).addClass("selected");
        var maloai = $('ul.list-group-cate li.selected').attr("data-id");
        var sapxep = $("#sort_product").val();
        $.ajax({
            type: "GET",
            url: '/Menu/GetProductByPageWithFilter?maloai=' + maloai + '&sapxep=' + sapxep,
            dataType: 'json',
            success: function (response) {
                LoadMenuProduct(response);
                LoadMenuPagination(maloai, sapxep);
            },
            error: function (error) {
            }
        });
    });

    $(document).on('change', '#sort_product', function (event) {
        $("#alert_search").css("display", "none");
        var maloai = $('ul.list-group-cate li.selected').attr("data-id");
        var sapxep = $("#sort_product").val();
        $.ajax({
            type: "GET",
            url: '/Menu/GetProductByPageWithFilter?maloai=' + maloai + '&sapxep=' + sapxep,
            dataType: 'json',
            success: function (response) {
                LoadMenuProduct(response);
                LoadMenuPagination(maloai, sapxep);
            },
            error: function (error) {
            }
        });
    });

    $(document).on('click', '#search_button', function (event) {
        var keyword = $("#search_input").val();
        $("#alert_search").css("display", "block");
        $("#search_button").attr("data-pressed", "1");
        if (keyword == "") {
            swal("Chưa nhập từ khóa", { icon: "warning" });
        }
        else {
            $("#search_input").val("");
            LoadProductWithKeywordByPage(keyword, 1);
            LoadSearchPagination(keyword);
        }
        
    });
    
});