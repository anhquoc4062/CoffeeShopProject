﻿function LoadCart(data) {
    var htmlString = "";
    var totalQuantity = 0;
    var totalAmount = 0;
    if (data.length != 0) {
        for (i in data) {
            totalQuantity += data[i].soLuong;
            totalAmount += data[i].soLuong * data[i].giaBan;
            htmlString += '<li class="item-in-cart"><a href="SingleProduct/Index/'+data[i].maThucDon+'"><img src="/uploads/product/' + data[i].hinhAnh + '" alt="" width="75" height="75">';
            htmlString += '<div class="item-info"><h5>' + data[i].tenThucDon + '</h5>';
            htmlString += '<p class="item-quantity">Số lượng : ' + data[i].soLuong + '</p>';
            htmlString += '<p class="item-price">$' + (data[i].giaBan * data[i].soLuong).toFixed(2) + '</p></div></a></li>';
        }
    }
    else {
        htmlString += '<li class="none-item"><p>Chưa có sản phẩm trong giỏ</p></li>';

    }
    $("#cart_hidden li.none-item").remove();
    $("#cart_hidden li.item-in-cart").remove();
    $("#cart_hidden li.item-total").before(htmlString);
    $(".cart-icon .amount-cart").html(totalQuantity);
    $(".cart-icon .item-total .total-price").html("$" + totalAmount.toFixed(2));
}

function LoadHiddenCart() {
    $.ajax({
        type: "GET",
        url: '/Cart/LoadCartHidden',
        dataType: 'json',
        success: function (response) {
            LoadCart(response);
        },
        error: function (error) {
        }
    });
}
$(document).ready(function () {

    LoadHiddenCart();

    function ResetButton(that) {
        $(that).html('<i class="fas fa-check"></i>');
    }

    $(document).on('click', '.order-button button', function (event) {
        event.preventDefault();
        console.log("da click");
        var product_id = $(this).attr("data-id");
        var $this = $(this);
        $(this).html('<i class="fas fa-check"></i>');
        setTimeout(function () {
            console.log($this.text());
            $this.html('Mua hàng');
        }, 1000);
        $.ajax({
            type: "GET",
            url: '/Cart/AddToCart?id=' + product_id,
            dataType: 'json',
            success: function (response) {
                LoadCart(response);
            },
            error: function (error) {
            }
        });
    });

    $(document).on('click', '.button-add-to-cart a', function (event) {
        event.preventDefault();
        console.log("da click");
        var product_id = $(this).attr("data-id");
        var $this = $(this);
        $(this).html('<i class="fas fa-check"></i>');
        setTimeout(function () {
            $this.html('THÊM VÀO GIỎ');
        }, 1000);
        $.ajax({
            type: "GET",
            url: '/Cart/AddToCart?id=' + product_id,
            dataType: 'json',
            success: function (response) {
                LoadCart(response);
            },
            error: function (error) {
            }
        });
    });
});