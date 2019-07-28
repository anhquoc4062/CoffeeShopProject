function initFBServer() {
    window.fbAsyncInit = function() {
        FB.init({
            appId: '1981611578625971',
            xfbml: true,
            version: 'v2.4'
        });
    };

    (function(d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) { return; }
        js = d.createElement(s);
        js.id = id;
        js.src = "//connect.facebook.net/en_US/sdk.js";
        fjs.parentNode.insertBefore(js, fjs);
    }(document, 'script', 'facebook-jssdk'));
}

function ShareToFacebook() {
    $(document).ready(function() {
        $('#share_facebook').click(function(e) {
            e.preventDefault();
            FB.init({
                appId: '1981611578625971',
                xfbml: true,
                version: 'v2.4'
            });

            console.log(GLOBAL_VAR.domain_name);
            FB.ui({
                method: 'feed',
                name: 'Facebook Dialogs',
                link: GLOBAL_VAR.domain_name + '/chi-tiet/coffee/cappuchino-1',
                picture: GLOBAL_VAR.domain_name + +'/uploads/product/cappuccino_PNG26.png',
                caption: 'Reference Documentation',
                description: 'Dialogs provide a simple, consistent interface for applications to interface with users.'
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

};

$(document).ready(function() {
    initFBServer();

    ShareToFacebook();
});