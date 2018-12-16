$(document).ready(function () {

    $(document).on('change', '#category_filter', function (event) {
        ResetSearchBar();
        var category_id = $(this).val();
        console.log(category_id);
        $.ajax({
            type: "GET",
            url: '/ProductAdmin/FilterProduct?maloai=' + category_id,
            dataType: 'json',
            success: function (response) {
                LoadProduct(response);
                LoadPagination(category_id);
            },
            error: function (error) {
                alert("errror");
            }
        });
    });

});