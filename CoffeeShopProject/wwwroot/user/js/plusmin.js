$(document).ready(function () {
    function LoadTotal() {
        $.ajax({
            type: "GET",
            url: '/Cart/GetTotal',
            dataType: 'json',
            success: function (response) {
                $(".subtotal-cart").html('$'+response.toFixed(2));
                $(".total-cart").html('$' + response.toFixed(2));
            },
            error: function (error) {
            }
        });
    }
    function UpdateCart(id, quantity) {
        $.ajax({
            type: "GET",
            url: '/Cart/UpdateCart?id=' + id + '&quantity=' + quantity,
            dataType: 'json',
            success: function (response) {
                console.log(response);
                $('.total-item[data-id="' + id + '"]').html('$' + response.toFixed(2));
                LoadHiddenCart();
                LoadTotal();
            },
            error: function (error) {
            }
        });
    }
    function RemoveItem(id) {
        $.ajax({
            type: "GET",
            url: '/Cart/RemoveItem?id=' + id,
            dataType: 'json',
            success: function (response) {
                $("tr.item-cart[data-id='" + id + "']").remove();
                LoadHiddenCart();
                LoadTotal();
            },
            error: function (error) {
            }
        });
    }
    $('.count').prop('disabled', true);

    $(document).on('click', '.plus', function () {
        var id = $(this).attr("data-id");
        $('.count[data-id="' + id + '"]').val(parseInt($('.count[data-id="' + id + '"]').val()) + 1);
        var quantity = $('.count[data-id="' + id + '"]').val();
        UpdateCart(id, quantity);
    });

    $(document).on('click', '.minus', function () {
        var id = $(this).attr("data-id");
        $('.count[data-id="' + id + '"]').val(parseInt($('.count[data-id="' + id + '"]').val()) - 1 );
        if ($('.count[data-id="' + id + '"]').val() == 0) {
            $('.count[data-id="' + id + '"]').val(1);
        }
        var quantity = $('.count[data-id="' + id + '"]').val();
        UpdateCart(id, quantity);
    });

    $(document).on('click', '.remove-item-cart', function (event) {
        event.preventDefault();
        var id = $(this).attr("data-id");
        swal({
            title: "Bạn có muốn xóa sản phẩm này?",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
        .then((willDelete) => {
            if (willDelete) {
                RemoveItem(id);
                swal("Xóa thành công!", {
                    icon: "success",
                });
            }
        });
        
    });
 });