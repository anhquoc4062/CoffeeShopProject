$(document).ready(function () {
    $(window).scroll(function () { 
        var currentPosition = $(document).scrollTop();
        if(currentPosition >= 1400){
            $('#coffee').fadeTo(2000, 1).animate({'margin-top': '30px'}, {duration: '3000', queue: false}, function() {
                // Animation complete.
            });
        }
    });
    
});