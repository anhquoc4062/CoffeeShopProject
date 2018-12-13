function LoadCart(data) {
    var htmlString = "";
    for (i in data) {
        htmlString += '<li><a href="#"><img src="/uploads/product/' + data[i].hinhAnh + '" alt="" width="75" height="75">';
        htmlString += '<div class="item-info"><h5>' + data[i].tenThucDon + '</h5>';
        htmlString += '<p class="item-quantity">Số lượng : ' + data[i].soLuong + '</p>';
        htmlString += '<p class="item-price">$' + (data[i].giaBan * data[i].soLuong).toFixed(2) + '</p></div></a></li>';
    }
    $("#cart_hidden li").remove();
    $("#cart_hidden").append(htmlString);
}
$(document).ready(function () {

    /*$.ajax({
        type: "GET",
        url: '/Cart/LoadCart',
        dataType: 'json',
        success: function (response) {
            console.log(response);
            LoadCart(response);
        },
        error: function (error) {
        }
    });*/

    $(document).on('click', '.order-button button', function (event) {
        var product_id = $(this).attr("data-id");
        $.ajax({
            type: "GET",
            url: '/Cart/AddToCart?product_id=' + product_id,
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