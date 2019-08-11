function renderButtonCheckout() {
    $.ajax({
        type: "get",
        url: "Cart/LoadCartHidden",
        dataType: "json",
        success: function(response) {
            var totalAmount = 0;
            var orderItems = [];
            response.forEach(item => {
                totalAmount += item.soLuong * item.giaBan;
                var orderItem = {
                    name: item.tenThucDon,
                    unit_amount: {
                        value: item.giaBan,
                        currency_code: 'USD'
                    },
                    quantity: item.soLuong,
                    sku: item.maThucDon
                }
                orderItems.push(orderItem);
            });
            paypal.Buttons({
                createOrder: function(data, actions) {
                    // Set up the transaction
                    return actions.order.create({
                        purchase_units: [{
                            amount: {
                                value: totalAmount,
                                currency_code: 'USD',
                                breakdown: {
                                    item_total: { value: totalAmount, currency_code: 'USD' }
                                }
                            },
                            items: orderItems
                        }]
                    });
                },
                style: {
                    color: 'blue',
                    shape: 'pill',
                    label: 'pay',
                    height: 40,
                    size: 'small'
                },
                onApprove: function(data, actions) {
                    // Capture the funds from the transaction
                    return actions.order.capture().then(function(details) {
                        // Show a success message to your buyer
                        var shipping = details.purchase_units[0].shipping;
                        var fullname = shipping.name.full_name;
                        var address = shipping.address.address_line_1;
                        var email = details.payer.email_address;
                        var city = shipping.address.admin_area_2;
                        $.ajax({
                            type: "post",
                            url: "Checkout/AddOrderPaypal",
                            data: {
                                fullname: fullname,
                                address: address,
                                email: email
                            },
                            dataType: "json",
                            success: function(response) {
                                if (response == true) {
                                    swal("Thành công", "Thanh toán thành công", "success");
                                }
                            }
                        });
                    });
                }
            }).render('#check-out-paypal');
        }
    });

}
$(document).ready(function() {
    renderButtonCheckout();

    $(document).on('click', '#general-checkout-button', function(event) {
        event.preventDefault();
        if ($("#paypal-checkbox").is(":checked")) {
            let iframe = $('iframe[title=paypal_buttons]');
            console.log(iframe.attr('title'));
            let button = iframe.contents().find('.paypal-button.paypal-button-number-0.paypal-button-layout-vertical.paypal-button-shape-rect.paypal-button-number-multiple.paypal-button-env-sandbox.paypal-button-color-gold.paypal-logo-color-blue');
            console.log(button);
            button.click();
        } else {
            $("#checkout-form").submit();
        }
    });

    $('input[name="radio-checkout"]').click(function(event) {
        let id = $(this).attr("id");
        if (id == "paypal-checkbox") {
            $("#general-checkout-button").hide();
            $("#check-out-paypal").slideDown("slow");
        } else {
            $("#general-checkout-button").slideDown("slow");
            $("#check-out-paypal").hide();
        }
    });
});