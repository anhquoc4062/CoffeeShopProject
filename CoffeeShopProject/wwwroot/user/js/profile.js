$(document).ready(function () {

    $(document).on('click', '.profile-detail-order', function (event) {
        console.log("da click");
        var cart_id = $(this).attr("data-id");
        $.ajax({
            type: "GET",
            url: '/Profile/GetDetailOrder?cart_id=' + cart_id,
            dataType: 'json',
            success: function (data) {
                console.log(data);
                if (data.redirect) {
                    window.location.href = data.redirect;
                }
                var htmlString = "";
                var total = 0;
                for (i in data) {
                    total += data[i].gia * data[i].soLuong;
                    htmlString += '<tr class="detail-order">';
                    htmlString += '<td>' + data[i].tenThucDon + '</td><td>$' + data[i].gia.toFixed(2) + '</td><td>' + data[i].soLuong + '</td><td>$' + (data[i].gia * data[i].soLuong).toFixed(2) + '</td></tr>';
                }
                $(".detail-order-list .detail-order").remove();
                $(".total-order-div").before(htmlString);
                $(".total-order").html('$' + total.toFixed(2));
            }
        });
    });
});