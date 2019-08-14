function initDatatables() {
    $.ajax({
        type: "get",
        url: "https://us3.api.mailchimp.com/3.0/lists/f2574fb0f2/members/",
        // beforeSend: function(request) {
        //     request.setRequestHeader("Authorization", "apikey b9788ffb309507ffb251f59fc5606d5a-us3");
        //     request.setRequestHeader("Access-Control-Allow-Origin", "*");
        // },
        headers: {
             "Authorization": "apikey b9788ffb309507ffb251f59fc5606d5a-us3"
        },
        async:true,
        dataType : 'json',   //you may use jsonp for cross origin request
        crossDomain:true,
        success: function (response) {
            console.log(response);
        }
    });
    $('#subscriber_table').DataTable({
        "language": {
            "lengthMenu": "Hiển thị _MENU_ dữ liệu trên trang",
            "zeroRecords": "Không tìm thấy dữ liệu",
            "info": "Hiển thị trang _PAGE_ trên _PAGES_",
            "infoEmpty": "Không có dữ liệu nào",
            "infoFiltered": "(filtered from _MAX_ total records)"
        }
    });
}

$(document).ready(function() {
    initDatatables();

});