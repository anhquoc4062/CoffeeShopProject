function LoadCart(data) {
    var htmlString = "";
    var totalQuantity = 0;
    var totalAmount = 0;
    for (i in data) {
        totalQuantity += data[i].soLuong;
        totalAmount += data[i].soLuong * data[i].giaBan;
        htmlString += '<li class="item-in-cart"><a href="#"><img src="/uploads/product/' + data[i].hinhAnh + '" alt="" width="75" height="75">';
        htmlString += '<div class="item-info"><h5>' + data[i].tenThucDon + '</h5>';
        htmlString += '<p class="item-quantity">Số lượng : ' + data[i].soLuong + '</p>';
        htmlString += '<p class="item-price">$' + (data[i].giaBan * data[i].soLuong).toFixed(2) + '</p></div></a></li>';
    }
    $("#cart_hidden li.item-in-cart").remove();
    $("#cart_hidden li.item-total").before(htmlString);
    $(".cart-icon .amount-cart").html(totalQuantity);
    $(".cart-icon .item-total .total-price").html("$" + totalAmount.toFixed(2));
}

function LoadHiddenCart(){
    $.ajax({
        type: "GET",
        url: '/Cart/LoadCartHidden',
        dataType: 'json',
        success: function (response) {
            console.log(response);
            LoadCart(response);
        },
        error: function (error) {
            alert("error");
        }
    });
}
$(document).ready(function () {

    LoadHiddenCart();

    $(document).on('click', '.order-button button', function (event) {
        event.preventDefault();
        var product_id = $(this).attr("data-id");
        $.ajax({
            type: "GET",
            url: '/Cart/AddToCart?id=' + product_id,
            dataType: 'json',
            success: function (response) {
                console.log(response);
                LoadCart(response);
            },
            error: function (error) {
            }
        });
    });
});