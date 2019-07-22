$(document).ready(function() {
    function GetCustomerInfo(customer_id) {
        $.ajax({
            type: "GET",
            url: '/CustomerAdmin/GetCustomerInfo?customer_id=' + customer_id,
            dataType: 'json',
            success: function(data) {
                console.log(data);
                $("#customer_name").val(data.tenKhachHang);
                $("#customer_email").val(data.email);
                $("#customer_address").val(data.diaChi);
                $("#customer_city").val(data.tenTinhThanh);
                $("#customer_tel").val(data.soDt);
                if (data.maTaiKhoan != null) {
                    $("#account_user_check").css("display", "block");
                    $("#not_has_account").css("display", "none");
                    $("#account_user_name").val(data.tenTaiKhoan);
                    $("#account_user_password").val(data.matKhau);
                } else {
                    $("#account_user_check").css("display", "none");
                    $("#not_has_account").css("display", "block");
                }
            },
            error: function(error) {}
        });
    }
    $(document).on('click', '.customer_btn', function(event) {
        var customer_id = $(this).attr("data-id");
        GetCustomerInfo(customer_id);
    });
});