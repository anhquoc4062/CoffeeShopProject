$(document).ready(function () {
    function LoadProduct(data) {
        var htmlString = "";
        for (i in data) {
            htmlString += '<tr class="tr-shadow">'
            htmlString += '<td><img src="/uploads/product/' + data[i].hinhAnh + '" width="70" height="70" /></td>';
            htmlString += '<td>' + data[i].tenThucDon + '</td>';
            htmlString += '<td>' + data[i].tenLoai+'</td>';
            htmlString += '<td>' + data[i].gia.toFixed(2) + '</td>';
            htmlString += '<td>' + data[i].khuyenMai + '</td>';
            htmlString += '<td><div class="table-data-feature">';
            htmlString += '<button class="item" data-placement="top" title="" data-original-title="Edit">';
            htmlString += '<i class="zmdi zmdi-edit"></i></button>';
            htmlString += '<button class="item" data-placement="top" title="" data-original-title="Delete">';
            htmlString += '<i class="zmdi zmdi-delete"></i></button></div></td></tr>';
            htmlString += '<tr class="spacer"></tr>';
        }
        $("#table_product_list").html(htmlString);
    }

    function FormAppend(formData) {
        var image = document.getElementById("product_img").files[0];
        var name = $("#product_name").val();
        var category = $("#category_select").val();
        var price = $("#product_price").val();
        var discount = $("#product_discount").val();

        formData.append("product_img", image);
        formData.append("product_name", name);
        formData.append("product_category", category);
        formData.append("product_price", price);
        formData.append("product_discount", discount);
    }

    $('#add_product_btn').click(function (event) {
        event.preventDefault();
        var formData = new FormData();
        FormAppend(formData);

        $.ajax({
            type: "POST",
            url: '/ProductAdmin/AddProduct',
            data: formData,
            dataType: 'json',
            contentType: false,
            processData: false,
            success: function (response) {
                swal("Thành công", ", Đã thêm sản phẩm", "success");
                $("#add_modal").modal('hide');
                LoadProduct(response);
            },
            error: function(error) {
                alert("errror");
            }
        });
    });
});  