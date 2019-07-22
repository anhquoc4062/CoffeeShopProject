$(document).ready(function () {
    function GetEmployeeAccountById(id) {
        $.ajax({
            type: "GET",
            url: '/Account/GetAccountById?account_id=' + id,
            dataType: 'json',
            success: function (response) {
                $("#account_name").val(response.tenTaiKhoan);
                $("#account_password").val(response.matKhau);
            },
            error: function (error) {
            }
        });
    }
    $(document).on('click', '#account_check', function (event) {
        var id = $(this).attr("data-id");
        if (id != "0") {
            $("#account_alert").css("display", "none");
            $("#account_modal input").attr("disabled", "disabled");
            $("#add_account_btn").css("display", "none");
            GetEmployeeAccountById(id);

        }
        else {
            $("#account_alert").css("display", "block");
            $("#account_modal input").removeAttr("disabled");
            $("#add_account_btn").css("display", "block");
        }
    });

    $(document).on('click', '#add_account_btn', function (event) {
        var formData = new FormData();
        formData.append("account_name", $("#account_name").val());
        formData.append("account_password", $("#account_password").val());
        formData.append("emp_id", $("#emp_id").val());

        $.ajax({
            type: "POST",
            url: '/Account/AddAccountForEmployee',
            data: formData,
            dataType: 'json',
            contentType: false,
            processData: false,
            success: function (response) {
                swal("Thành công", "Đã cấp tài khoản cho nhân viên", "success");
                $("#account_modal").modal("hide");
                $("#account_check").attr("data-id", response.maTaiKhoan);
                console.log(response);
            },
            error: function (error) {
            }
        });
    });
});