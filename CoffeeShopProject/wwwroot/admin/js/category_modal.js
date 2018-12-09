$(document).ready(function () {
    function testAnim(x) {
        $('#cate_modal .modal-dialog').attr('class', 'modal-dialog  ' + x + '  animated');
    };

    $(".modal").on('show.bs.modal', function (e) {
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
