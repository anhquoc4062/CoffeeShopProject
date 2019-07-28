function initFBServer() {
    window.fbAsyncInit = function() {
        FB.init({
            appId: '1981611578625971',
            autoLogAppEvents: true,
            xfbml: true,
            version: 'v2.10'
        });
        FB.AppEvents.logPageView();
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
                autoLogAppEvents: true,
                xfbml: true,
                version: 'v2.10'
            });

            // console.log(GLOBAL_VAR.domain_name);
            // FB.ui({
            //     method: 'feed',
            //     name: 'Facebook Dialogs',
            //     link: GLOBAL_VAR.domain_name + '/chi-tiet/coffee/cappuchino-1',
            //     picture: GLOBAL_VAR.domain_name + +'/uploads/product/cappuccino_PNG26.png',
            //     caption: 'Reference Documentation',
            //     description: 'Dialogs provide a simple, consistent interface for applications to interface with users.'
            // })

            FB.ui({
                    method: 'share_open_graph',
                    action_type: 'og.likes',
                    action_properties: JSON.stringify({
                        object: {
                            'og:url': GLOBAL_VAR.domain_name + '/chi-tiet/coffee/cappuchino-1',
                            'og:title': 'ABC',
                            'og:description': 'Dialogs provide a simple, consistent interface for applications to interface with users.',
                            'og:image': GLOBAL_VAR.domain_name + +'/uploads/product/cappuccino_PNG26.png'
                        }
                    })
                },
                function(response) {
                    // Action after response
                });
        });



    });

};

$(document).ready(function() {
    initFBServer();

    ShareToFacebook();
});