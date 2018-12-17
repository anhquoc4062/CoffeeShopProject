$(document).ready(function () {
    function testAnim(x) {
        $('.child_modal .modal-dialog').attr('class', 'modal-dialog  ' + x + '  animated');
    };

    $(".parent_modal").on('show.bs.modal', function (e) {
        $('#preview_img').attr('src', '/images/product/no-preview.jpg');
        $('form').trigger("reset");
    });

    $('.child_modal').on('show.bs.modal', function (e) {
        //$(".child_modal input").val("");
        testAnim("bounceIn");
    });
    $('.child_modal').on('hide.bs.modal', function (e) {
        testAnim("bounceOut");
    });
});
