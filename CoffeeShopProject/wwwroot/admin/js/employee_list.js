function LoadEmployee(data) {
    var htmlString = "";
    for (i in data) {
        htmlString += '<tr><td width="30px"><button class="btn btn-success" style="background-color:#95a5a6;border:none"><i class="fas fa-eye"></i></button>';
        htmlString += '</td><td><img src="/uploads/employee/' + data[i].hinhAnh + '" width="80" height="70" /></td>';
        htmlString += '<td><div class="table-data__info"><h6>' + data[i].hoTen + '</h6><span><a href="#">' + data[i].email + '</a></span></div>';
        htmlString += '</td><td>' + data[i].tenChucVu + '</td><td>$' + data[i].luong.toFixed(2) + '</td>';
        htmlString += '<td><button class="btn btn-danger emp_btn" data-action="Edit" data-id="' + data[i].maNhanVien + '" data-toggle="modal" data-target="#add_employee_modal"><i class="zmdi zmdi-edit"></i></td></tr>';
    }
    $("#table_employee_list tr").remove();
    $("#table_employee_list").append(htmlString).hide().fadeIn(1000);
}

$(document).ready(function() {


    function FormAppend(formData) {
        var image = document.getElementById("emp_img").files[0];
        var name = $("#emp_name").val();
        var identity = $("#emp_identity").val();
        var email = $("#emp_email").val();
        var position = $("#position_select").val();
        var salary = $("#emp_salary").val();
        var info = $("#emp_info").val();

        formData.append("emp_img", image);
        formData.append("emp_name", name);
        formData.append("emp_identity", identity);
        formData.append("emp_email", email);
        formData.append("emp_position", position);
        formData.append("emp_salary", salary);
        formData.append("emp_info", info);
    }

    function DataToForm(id) {
        $.ajax({
            type: "GET",
            url: '/EmployeeAdmin/BindDataToForm/' + id,
            dataType: 'JSON',
            success: function(response) {
                $("#emp_id").val(response.maNhanVien);
                $("#emp_name").val(response.hoTen);
                $("#emp_identity").val(response.cmnd);
                $("#emp_email").val(response.email);
                $("#position_select").val(response.maChucVu);
                $("#emp_salary").val(response.luong);
                $("#emp_info").val(response.moTa);
                $("#preview_img").attr('src', '/uploads/employee/' + response.hinhAnh);
                $("#old_emp_img").val(response.hinhAnh);

                if (response.maTaiKhoan == null) {

                    $("#account_check").attr("data-id", "0");
                    $("#acc_id").val("0");
                } else {
                    $("#account_check").attr("data-id", response.maTaiKhoan);
                    $("#acc_id").val(response.maTaiKhoan);
                }
            },
            error: function(error) {}
        });
    }

    function AddEmployee(formData) {
        $.ajax({
            type: "POST",
            url: '/EmployeeAdmin/AddEmployee',
            data: formData,
            dataType: 'json',
            contentType: false,
            processData: false,
            success: function(response) {
                $("#add_employee_modal").modal('hide');
                swal("Thành công", "Đã thêm nhân viên", "success");
                LoadEmployee(response);
            },
            error: function(error) {}
        });
    }

    function UpdateEmployee(formData) {
        $.ajax({
            type: "POST",
            url: '/EmployeeAdmin/UpdateEmployee',
            data: formData,
            dataType: 'json',
            contentType: false,
            processData: false,
            success: function(response) {
                swal("Thành công", "Đã sửa thông tin nhân viên", "success");
                $("#add_employee_modal").modal('hide');
                LoadEmployee(response);
            },
            error: function(error) {}
        });
    }

    function DeleteEmployee(id) {
        $.ajax({
            type: "GET",
            url: '/EmployeeAdmin/DeleteEmployee?emp_id=' + id,
            dataType: 'json',
            success: function(response) {
                $("#add_employee_modal").modal('hide');
                LoadEmployee(response);
            },
            error: function(error) {}
        });
    }

    $(document).on('click', '.emp_btn', function(event) {
        if ($(this).attr('data-action') == 'Add') {
            $("#add_emp_modal_title").html('Thêm nhân viên');
            $("#add_emp_btn").html('Thêm').attr('data-action', 'add_submit');
            $("#delete_emp_btn").css("display", "none");
        } else {
            $("#add_emp_modal_title").html('Sửa nhân viên');
            $("#add_emp_btn").html('Sửa').attr('data-action', 'edit_submit');
            $("#delete_emp_btn").css("display", "block");
            var id = $(this).attr('data-id');
            DataToForm(id);

        }
    });

    $(document).on('click', '#add_emp_btn', function(event) {
        event.preventDefault();
        var formData = new FormData();
        FormAppend(formData);
        if ($(this).attr('data-action') == 'add_submit') {
            AddEmployee(formData);
        } else {
            formData.append("old_emp_img", $("#old_emp_img").val());
            formData.append("emp_id", $("#emp_id").val());
            formData.append("acc_id", $("#acc_id").val());
            UpdateEmployee(formData);
        }

    });

    $(document).on('click', '#delete_emp_btn', function(event) {
        var id = $("#emp_id").val();
        swal({
                title: "Bạn có muốn xóa nhân viên này?",
                text: "Một khi đã xóa thì không thể hoàn lại được!",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
            .then((willDelete) => {
                if (willDelete) {
                    DeleteEmployee(id);
                    swal("Xóa thành công!", {
                        icon: "success",
                    });
                }
            });
    });
});