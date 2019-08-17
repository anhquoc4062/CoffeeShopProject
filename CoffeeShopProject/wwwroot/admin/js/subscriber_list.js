function initDatatables() {
    $('#subscriber_table').DataTable({
        "language": {
            "lengthMenu": "Hiển thị _MENU_ dữ liệu trên trang",
            "zeroRecords": "Không tìm thấy dữ liệu",
            "info": "Hiển thị trang _PAGE_ trên _PAGES_",
            "infoEmpty": "Không có dữ liệu nào",
            "infoFiltered": "(filtered from _MAX_ total records)"
        }
    });
    var dataRows = [];
    $.ajax({
        type: "get",
        url: "SubscriberAdmin/GetListMember",
        // beforeSend: function(request) {
        //     request.setRequestHeader("Authorization", "apikey b9788ffb309507ffb251f59fc5606d5a-us3");
        //     request.setRequestHeader("Access-Control-Allow-Origin", "*");
        // },
        async: true,
        dataType: 'json', //you may use jsonp for cross origin request
        success: function(response) {
            response.forEach(function(member) {
                var row = [
                    member.email_address,
                    member.merge_fields.FNAME + ' ' + member.merge_fields.LNAME,
                    member.merge_fields.ADDRESS,
                    member.merge_fields.PHONE,
                    member.merge_fields.BIRTHDAY,
                    member.status
                ];
                dataRows.push(row);
            });
            // $('#subscriber_table').DataTable({
            //     data: dataRows
            // });
            var datatable = $('#subscriber_table').DataTable();
            datatable.clear();
            datatable.rows.add(dataRows);
            datatable.draw();
        }
    });
}

function exportToExcel() {
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

    htmls = $('#subscriber_table')[0].outerHTML;
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
    $('#export-excel-subscriber').click(function() {
        exportToExcel();
    });
});