$(document).ready(function () {
    $("#exTab1 ul li").click(function (e) { 
        e.preventDefault();
        var href = $(this).find("a").attr("href");
        $(".active").removeClass("active");
        $(href).addClass("active").removeClass("show");
        $(this).addClass("active");

    });

    $("#exTab1 ul li").hover(function () {
            // over
            if(!$(this).hasClass("active")){
                $(this).addClass("hover");
            }
        }, function () {
            // out
            if($(this).hasClass("hover")){
                $(this).removeClass("hover");
            }
        }
    );
});