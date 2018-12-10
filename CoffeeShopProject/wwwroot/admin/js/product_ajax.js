﻿$(document).ready(function () {
    function LoadProduct(data) {
        var htmlString = "";
        for (i in data) {
            htmlString += '<tr class="tr-shadow">'
            htmlString += '<td><img src="/uploads/product/' + data[i].hinhAnh + '" width="70" height="70" /></td>';
            htmlString += '<td>' + data[i].tenThucDon + '</td>';
            htmlString += '<td>' + data[i].tenLoai+'</td>';
            htmlString += '<td>$' + data[i].gia.toFixed(2) + '</td>';
            htmlString += '<td>' + data[i].khuyenMai + '%</td>';
            htmlString += '<td><div class="table-data-feature">';
            htmlString += '<button class="product_btn item"  data-placement="top"  data-original-title="Edit" data-action="Edit" data-id="' + data[i].maThucDon + '" data-toggle="modal" data-target="#add_modal">';
            htmlString += '<i class="zmdi zmdi-edit"></i></button>';
            htmlString += '<button class="product_btn item" data-placement="top" data-original-title="Delete" data-action="Delete" data-id="' + data[i].maThucDon + '">';
            htmlString += '<i class="zmdi zmdi-delete"></i></button></div></td></tr>';
            htmlString += '<tr class="spacer"></tr>';
        }
        $("#table_product_list tr").remove();
        $("#table_product_list").append(htmlString).hide().fadeIn(2000);
    }

    function FormAppend(formData) {
        var image = document.getElementById("product_img").files[0];
        var name = $("#product_name").val();
        var category = $("#category_select").val();
        var price = $("#product_price").val();
        var discount = $("#product_discount").val();
        var info = $("#product_info").val();

        formData.append("product_img", image);
        formData.append("product_name", name);
        formData.append("product_category", category);
        formData.append("product_price", price);
        formData.append("product_discount", discount);
        formData.append("product_info", info);
    }

    function DataToForm(id) {
        $.ajax({
            type: "GET",
            url: '/ProductAdmin/BindDataToForm/' + id,
            dataType: 'JSON',
            success: function (response) {
                $("#product_id").val(response.maThucDon);
                $("#product_name").val(response.tenThucDon);
                $("#category_select").val(response.maLoai);
                $("#product_price").val(response.gia);
                $("#product_discount").val(response.khuyenMai);
                $("#product_info").val(response.moTa);
                $("#preview_img").attr('src', '/uploads/product/' + response.hinhAnh);
                $("#old_product_img").val(response.hinhAnh);
                console.log(response);
            },
            error: function (error) {
                alert("errror");
            }
        });
    }

    function AddProduct(formData) {
        $.ajax({
            type: "POST",
            url: '/ProductAdmin/AddProduct',
            data: formData,
            dataType: 'json',
            contentType: false,
            processData: false,
            success: function (response) {
                $("#add_modal").modal('hide');
                swal("Thành công", "Đã thêm thực đơn", "success");
                LoadProduct(response);
            },
            error: function (error) {
                alert("errror");
            }
        });
    }

    function UpdateProduct(formData) {
        $.ajax({
            type: "POST",
            url: '/ProductAdmin/UpdateProduct',
            data: formData,
            dataType: 'json',
            contentType: false,
            processData: false,
            success: function (response) {
                swal("Thành công", "Đã sửa thông tin thực đơn", "success");
                $("#add_modal").modal('hide');
                LoadProduct(response);
            },
            error: function (error) {
                alert("errror");
            }
        });
    }

    function DeleteProduct(id) {
        $.ajax({
            type: "GET",
            url: '/ProductAdmin/DeleteProduct/' + id,
            dataType: 'json',
            success: function (response) {
                $("#add_modal").modal('hide');
                LoadProduct(response);
                
            },
            error: function (error) {
                alert("Lỗi");
                console.log(error);
            }
        });
    }


    $(document).on('click', '.product_btn', function (event) {

        if ($(this).attr('data-action') == 'Add') {
            $("#add_product_modal_title").html('Thêm sản phẩm');
            $("#add_product_btn").html('Thêm').attr('data-action', 'add_submit');
        }
        else if ($(this).attr('data-action') == 'Edit') {
            $("#add_product_modal_title").html('Sửa sản phẩm');
            $("#add_product_btn").html('Sửa').attr('data-action', 'edit_submit');
            var id = $(this).attr('data-id');
            DataToForm(id);
        }
        else {
             var id = $(this).attr('data-id');
             swal({
                title: "Bạn có muốn xóa sản phẩm này?",
                text: "Một khi đã xóa thì không thể hoàn lại được!",
                icon: "warning",
                buttons: true,
                dangerMode: true,
             })
             .then((willDelete) => {
                if (willDelete) {
                    DeleteProduct(id);
                    swal("Xóa thành công!", {
                        icon: "success",
                    });
                }
            });
        }
    });

    $(document).on('click', '#add_product_btn', function (event) {
        event.preventDefault();
        var formData = new FormData();
        FormAppend(formData);
        if ($(this).attr('data-action') == 'add_submit') {
            AddProduct(formData);
        }
        else {
            formData.append("old_product_img", $("#old_product_img").val());
            formData.append("product_id", $("#product_id").val());
            UpdateProduct(formData);
        }
        
    });
});  