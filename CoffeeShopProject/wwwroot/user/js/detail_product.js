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
            //e.preventDefault();
            console.log(GLOBAR_VAR.domain_name);
             FB.ui({
                method: 'share_open_graph',
                action_type: 'og.shares',
                action_properties: JSON.stringify({
                    object : {
                       'og:url': GLOBAR_VAR.domain_name + '/SingleProduct/Index/3',
                       'og:title': 'Test Title',
                       'og:description': 'Dialogs provide a simple, consistent interface for applications to interface with users.',
                       'og:image': GLOBAR_VAR.domain_name + '/uploads/product/Americano.png',
                       'og:og:image:width': '300',
                       'og:image:height': '300',
                    }
                })
             });

            /*var link = "https://127.0.0.1:5001/SingleProduct/Index/3";
            var desc = "your caption here";
            var title = 'your title here';
            var img = 'http://127.0.0.1:5000/uploads/product/Americano.png';

            // Open FB share popup
            FB.ui({
                method: 'share_open_graph',
                action_type: 'og.shares',
                action_properties: JSON.stringify({
                    object: {
                        'og:url': link,
                        'og:title': title,
                        'og:description': desc,
                        'og:image': img
                    }
                })
            },
            function (response) {
                // Action after response
            });*/

        });

    });
} 

$(document).ready(function () {
    initFBServer();

    ShareToFacebook();
});