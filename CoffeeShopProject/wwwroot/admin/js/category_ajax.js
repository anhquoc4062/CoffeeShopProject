$(document).ready(function () {
    $('#add_category_btn').click(function (event) {
        $.ajax({
            method: "POST",
            url: "/ProductAdmin/AddCategory",
            data: {
                tenLoai: $("#category_name").val()
            },
            dataType: "JSON",
            success: function (data) {
                var htmlString = '<option selected="" disabled="" value=0>--- Chọn loại thực đơn ---</option>';
                for (i in data) {
                    htmlString += '<option value="' + data[i].maLoai + '">' + data[i].tenLoai + '</option>';
                }
                $("#cate_modal").modal('hide');
                $("#category_select").html(htmlString);
            },
            error: function () {
                alert("Lỗi")
            }
        }); 
    });
});  