function initFBServer() {
    window.fbAsyncInit = function() {
        FB.init({
          appId      : '1981611578625971',
          xfbml      : true,
          version    : 'v2.3'
        });
      };

    (function(d, s, id){
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) {return;}
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/en_US/sdk.js";
        fjs.parentNode.insertBefore(js, fjs);
      }(document, 'script', 'facebook-jssdk'));
}
function ShareToFacebook() {
    $(document).ready(function () {
        $('#share_facebook').click(function (e) {
            e.preventDefault();
            FB.ui({

                method: 'feed',

                name: 'jQuery Dialog',

                link: 'https://localhost:5001',

                picture: 'https://www.gravatar.com/avatar/d5478f8e118cf5be65a366f4f292cf15?s=328&d=identicon&r=PG',

                caption: 'This article demonstrates how to use the jQuery dialog feature in ASP.Net.',

                description: 'First of all make a new website in ASP.Net and add a new stylesheet and add .js files and put images in the images folder and make a reference to the page.',

                message: 'hello raj message'

            });

        });

    });
} 

$(document).ready(function () {
    initFBServer();

    ShareToFacebook();
});