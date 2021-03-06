﻿$(document).ready(function () {
    $('#add_category_btn').click(function (event) {
        $.ajax({
            method: "POST",
            url: "/ProductAdmin/AddCategory",
            data: {
                tenLoai: $("#category_name").val()
            },
            dataType: "JSON",
            success: function (data) {
                swal("Thành công", ", Đã thêm loại sản phẩm", "success");
                var htmlString = '<option selected="" disabled="" value=0>--- Chọn loại thực đơn ---</option>';
                for (i in data) {
                    htmlString += '<option value="' + data[i].maLoai + '">' + data[i].tenLoai + '</option>';
                }
                $("#cate_modal").modal('hide');
                $("#category_select").html(htmlString);
                var filterHtmlString = '<option value="' + data[data.length - 1].maLoai + '">' + data[data.length - 1].tenLoai + '</option>';
                $("#category_filter").append(filterHtmlString);
            },
            error: function () {
                alert("Lỗi")
            }
        }); 
    });
});  