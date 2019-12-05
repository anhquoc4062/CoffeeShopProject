$(document).ready(function() {

    $(document).on('click', '#print-order', function(event) {
        console.log($(this).attr('cart-data'));
        console.log('clicked');
        cartData = JSON.parse($(this).attr('cart-data'));

        var newArray = [];
        for (let item of cartData) {
            item.tongCong = item.soLuong * item.gia;
            item.gia = '$' + item.gia.toFixed(2);
            item.tongCong = '$' + item.tongCong.toFixed(2);
            newArray.push(item);
        }
        console.log($('#bill-print').outerHTML);
        $('#customer-name-parse').text($('#customer_name').val());
        $('#customer-tel-parse').text($('#customer_tel').val());
        $('#customer-address-parse').text($('#customer_address').val() + ', ' + $('#customer_city').val());

        printJS({
            printable: newArray,
            properties: [{
                    field: 'tenThucDon',
                    displayName: 'Tên món'
                },
                {
                    field: 'gia',
                    displayName: 'Đơn giá'
                },
                {
                    field: 'soLuong',
                    displayName: 'Số lượng'
                },
                {
                    field: 'tongCong',
                    displayName: 'Tổng cộng'
                }
            ],
            type: 'json',
            header: $('#bill-print').get(0).outerHTML,
            gridHeaderStyle: 'color: black;  border: 1px solid #000;padding: 10px;',
            gridStyle: 'color: black;  border: 1px solid #000; padding: 5px; text-align: center'
        });
    });

});

/* <div class="not-show-kitchen">
        <div class="logo-area">{{Logo_Cua_Hang}}</div>
            <div class="name_shop">
                {{Ten_Cua_Hang}}
            </div>
            <div ng-show="shop_init.is_show_phone_bill == 1" class="address_shop">
                {{So_Dien_Thoai_Cua_Hang}}
            </div>
            <div ng-show="shop_init.is_show_address_bill == 1" class="address_shop">
                {{Dia_Chi_Cua_Hang}}
            </div>
        </div>
        <div class="bill_name" id="bill_print_name{{order.order_id}}">
            Hóa đơn
        </div>
</div> */