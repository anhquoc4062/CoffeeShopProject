function initDatatables() {
    $('#order_table').DataTable({
        "language": {
            "lengthMenu": "Hiển thị _MENU_ dữ liệu trên trang",
            "zeroRecords": "Không tìm thấy dữ liệu",
            "info": "Hiển thị trang _PAGE_ trên _PAGES_",
            "infoEmpty": "Không có dữ liệu nào",
            "infoFiltered": "(filtered from _MAX_ total records)"
        }
    });

    $(document).on('click', '.remove_order', function(event) {
        console.log('clicked');
        event.preventDefault();
        var row = $(this).closest('tr');
        var order_id = row.attr("data-id-cart");
        removeOrder(order_id, row);
    });
}

function ChangeProgress(id, status) {
    $.ajax({
        type: "GET",
        url: '/OrderAdmin/ChangeProgress?id=' + id + '&status=' + status,
        dataType: 'json',
        success: function(response) {},
        error: function(error) {}
    });
}

function GetCustomerInfo(customer_id) {
    $.ajax({
        type: "GET",
        url: '/CustomerAdmin/GetCustomerInfo?customer_id=' + customer_id,
        dataType: 'json',
        success: function(data) {
            $("#customer_name").val(data.tenKhachHang);
            $("#customer_email").val(data.email);
            $("#customer_address").val(data.diaChi);
            $("#customer_city").val(data.tenTinhThanh);
            $("#customer_tel").val(data.soDt);
        }
    });
}

function GetListDetail(cart_id) {
    $.ajax({
        type: "GET",
        url: '/OrderAdmin/GetDetailOrder?cart_id=' + cart_id,
        dataType: 'json',
        success: function(data) {
            var htmlString = "";
            var total = 0;
            for (i in data) {
                total += data[i].soLuong * data[i].gia;
                htmlString += '<tr class="item"><td>' + data[i].tenThucDon + '</td><td>' + data[i].soLuong + '</td><td>$' + (data[i].soLuong * data[i].gia).toFixed(2) + '</td></tr>';
            }
            $("#order_detail .item").remove();
            $("#amount").before(htmlString);
            $('#print-order').attr('cart-data', JSON.stringify(data));
            $("#total_amount").html('$' + total.toFixed(2));
        },
        error: function(error) {}
    });
}

function removeOrder(order_id, row) {
    $.ajax({
        type: "GET",
        url: '/OrderAdmin/RemoveOrder?id=' + order_id,
        dataType: 'text',
        success: function(data) {
            console.log('success', data);
            $('#order_table').DataTable().row(row).remove().draw(false);
        },
        error: function(error) {}
    });
}

function exportOrderToExcel() {
    var htmls = "";
    var uri = 'data:application/vnd.ms-excel;base64,';
    var template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>';
    var base64 = function(s) {
        return window.btoa(unescape(encodeURIComponent(s)))
    };

    var format = function(s, c) {
        return s.replace(/{(\w+)}/g, function(m, p) {
            return c[p];
        })
    };

    htmls = $('#order_table')[0].outerHTML;
    console.log(htmls);
    var ctx = {
        worksheet: 'Worksheet',
        table: htmls
    };


    var link = document.createElement("a");
    link.download = "export.xls";
    link.href = uri + base64(format(template, ctx));
    link.click();
}

$(document).ready(function() {
    initDatatables();

    $('#export-excel-order').click(function() {
        exportOrderToExcel();
    });

    $(document).on('click', '.detail_order_btn', function(event) {
        var cart_id = $(this).attr("data-id-cart");
        var customer_id = $(this).attr("data-id-customer");
        console.log(customer_id);
        GetListDetail(cart_id);
        GetCustomerInfo(customer_id);
    });



    $(document).on('click', '.table-data3 a', function(event) {
        event.preventDefault()
        var id = $(this).attr("data-id");
        if ($(this).hasClass("fail")) {
            $(this).text("Đã xử lý");
            $(this).removeClass("fail");
            $(this).addClass("sucess");
            ChangeProgress(id, 1);
        } else if ($(this).hasClass("sucess")) {
            $(this).text("Đang xử lý");
            $(this).removeClass("sucess");
            $(this).addClass("fail");
            ChangeProgress(id, 0);
        }
    });

});