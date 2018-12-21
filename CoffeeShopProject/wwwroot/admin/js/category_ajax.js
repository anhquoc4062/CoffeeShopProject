$(document).ready(function () {
    $('#add_category_btn').click(function (event) {
        $.ajax({
            method: "POST",
            url: "/ProductAdmin/AddCategory",
            data: {
                tenLoai: $("#category_name").val(),
                danhMuc: $("#category_parent").val()
            },
            dataType: "JSON",
            success: function (data) {
                swal("Thành công", ", Đã thêm loại sản phẩm", "success");
                var htmlString = '<option selected="" disabled="" value=0>--- Chọn loại thực đơn ---</option>'; 
                for (i in data) {
                    if (data[i].maLoaiCha == 0) {
                        htmlString += '<optgroup label="' + data[i].tenLoai + '">';
                        for (j in data) {
                            if (data[j].maLoaiCha == data[i].maLoai) {
                                htmlString += '<option value="' + data[j].maLoai + '">' + data[j].tenLoai + '</option>';
                            }
                            
                        }
                        htmlString += '</optgroup>';
                    }
                }
                
                $("#cate_modal").modal('hide');
                $("#category_select").html(htmlString);
                var filterHtmlString = '<option value="' + data[data.length - 1].maLoai + '">' + data[data.length - 1].tenLoai + '</option>';
                $("#category_filter").append(filterHtmlString);
            },
            error: function () {
            }
        }); 
    });
});  