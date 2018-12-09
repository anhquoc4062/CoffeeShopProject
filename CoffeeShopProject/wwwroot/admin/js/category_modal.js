$(document).ready(function () {
    function testAnim(x) {
        $('#cate_modal .modal-dialog').attr('class', 'modal-dialog  ' + x + '  animated');
    };

    $(".modal").on('show.bs.modal', function (e) {
        $(this).attr("overflow-y", "auto");
    });

    $("#add_modal").on('show.bs.modal', function (e) {
        $('#preview_img').attr('src', '/images/product/no-preview.jpg');
        $('#product_form').trigger("reset");
    });

    $('#cate_modal').on('show.bs.modal', function (e) {
        $("#category_name").val("");
        testAnim("bounceIn");
    });
    $('#cate_modal').on('hide.bs.modal', function (e) {
        testAnim("bounceOut");
    });
});
