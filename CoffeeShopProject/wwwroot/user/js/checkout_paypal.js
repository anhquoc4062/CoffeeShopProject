
function RenderPaypalButton() {
    $.ajax({
        type: "GET",
        url: '/Cart/LoadCartHidden',
        dataType: 'json',
        success: function (data) {
            var totalAmount = 0;
            for (i in data) {
                totalAmount += data[i].soLuong * data[i].giaBan;
            }
            paypal.Buttons({
                createOrder: function (data, actions) {
                    // Set up the transaction
                    return actions.order.create({
                        purchase_units: [{
                            amount: {
                                value: '7',
                                currency_code: 'USD',
                                breakdown: {
                                    item_total: {value: '7', currency_code: 'USD'}
                                }
                            },
                            items: [{
                                name: 'Hafer',
                                unit_amount: {value: '3', currency_code: 'USD'},
                                quantity: '1',
                                sku: 'haf001'
                            }, {
                                name: 'Discount',
                                unit_amount: {value: '4', currency_code: 'USD'},
                                quantity: '1',
                                sku: 'dsc002'
                            }]
                        }]
                    });
                },
                style: {
                    color: 'blue',
                    shape: 'pill',
                    label: 'pay',
                    height: 40,
                    size: 'small'
                }
            }).render('#check-out-paypal');
        },
        error: function (error) {
        }
    });
}

$(document).ready(function () {
    RenderPaypalButton();
    $(document).on('click', '#general-checkout-button', function (event) {
        event.preventDefault();
        if ($("#paypal-checkbox").is(":checked")) {
            let iframe = $('iframe[title=paypal_buttons]');
            console.log(iframe.attr('title'));
            let button = iframe.contents().find('.paypal-button.paypal-button-number-0.paypal-button-layout-vertical.paypal-button-shape-rect.paypal-button-number-multiple.paypal-button-env-sandbox.paypal-button-color-gold.paypal-logo-color-blue');
            console.log(button);
            button.click();
        }
        else {
            $("#checkout-form").submit();
        }
    });
   
    $('input[name="radio-checkout"]').click(function (event) {
        let id = $(this).attr("id");
        if (id == "paypal-checkbox") {
            $("#general-checkout-button").hide();
            $("#check-out-paypal").slideDown("slow");
        }
        else {
            $("#general-checkout-button").slideDown("slow");
            $("#check-out-paypal").hide();
        }
    });
});
