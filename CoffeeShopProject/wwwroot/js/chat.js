"use strict";
console.log("vào chat hub");
var EnterKeyPressed = false;
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

function LoadRoomsList() {
    $.ajax({
        type: "GET",
        url: '/Chat/GetAllRoomsList',
        dataType: 'json',
        success: function (response) {
            var htmlString = '';
            var newNoti = 0;
            for (var i in response) {
                //load append
                var checkRead = "unread";
                var checkMe = "";
                var checkActive = "";
                var myId = $("#myId").text();
                var quantityNew = '';
                if (response[i].quantityNewMessages > 0) {
                    quantityNew += ' (' + response[i].quantityNewMessages + ')';
                    newNoti++;
                }
                if (response[i].ownLastMessage != myId) {
                    if (response[i].status == 1) {
                        checkRead = "read";
                    }
                }
                else {
                    checkRead = "read";
                    checkMe += "You: "
                }
                if (response[i].isActive == 1) {
                    checkActive = "online";
                }
                htmlString += '<div class="au-message__item ' + checkRead + '" data-room-id="' + response[i].maPhongChat + '">';
                htmlString += '<div class="au-message__item-inner"><div class="au-message__item-text"><div class="avatar-wrap ' + checkActive + '"><div class="avatar">';
                htmlString += '<img src="uploads/employee/' + response[i].avatar + '" alt="Michelle Sims"></div></div><div class="text">';
                htmlString += '<h5 class="name">' + response[i].realName + quantityNew + '</h5><p>' + checkMe + response[i].lastMessage + '</p></div></div>';
                htmlString += '<div class="au-message__item-time">';
                htmlString += '<time class="timeago" datetime="' + response[i].time + '" title="' + response[i].time + '">đổi dùm con</time>';
                htmlString += '</div ></div ></div >';
            }
            $("#newMessages").html(newNoti);
            $("#roomsList > div").remove();
            $("#roomsList").append(htmlString);
            $("time").timeago();
        }
    });
}

function SetUserActive(userId, yes) {
    $.ajax({
        type: "GET",
        url: '/Chat/SetUserActive?userId=' + userId + '&yes=' + yes,
        dataType: 'json',
        success: function (response) {
            LoadRoomsList();        }
    });
}


function AutoScrollDown() {
    $("#messagesList").animate({
        scrollTop: $("#messagesList").get(0).scrollHeight
    }, 10);
}

connection.on("ReceiveMessage", function (user_id, message) {
    LoadRoomsList();
    //var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var check = document.getElementById("myAccountId").value;
    var avatar = $("#chatAvatar").attr("src");
    var htmlString = '';
    if (check == user_id) {
        htmlString += '<div class="send-mess-wrap"><div class="send-mess__inner"><div class="send-mess-list">';
        htmlString += '<div class="send-mess">' + message + '</div></div></div></div>';
    }
    else {
        htmlString += '<div class="recei-mess-wrap"><div class="recei-mess__inner"><div class="avatar avatar--tiny">';
        htmlString += '<img src="' + avatar + '" alt="John Smith"></div>';
        htmlString += '<div class="recei-mess-list"><div class="recei-mess">' + message + '</div></div></div></div>';

        //sound
        var audioElement = document.createElement('audio');
        audioElement.setAttribute('src', 'sound/ChatNotification.mp3');
        audioElement.play();
        
    }
    $("#messagesList").append(htmlString);
    AutoScrollDown();
});

connection.on("UserConnected", function (connection_id, user_id) {
    SetUserActive(user_id, 1);
});

connection.on("UserDisConnected", function (connection_id, user_id) {
    SetUserActive(user_id, 0);
});

connection.on("IsTyping", function (user) {
    //var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var check = document.getElementById("myAccountId").value;
    if (check != user) {
        var encodedMsg = user + " is typing...";
    }
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});
//document.getElementById("messageInput").addEventListener("keypress", function (e) {
//    if (!EnterKeyPressed) {
//        var user = document.getElementById("userInput").value;
//        connection.invoke("IsTyping", user).catch(function (err) {
//            return console.error(err.toString());
//        });
//        EnterKeyPressed = true;
//    }
   
//});

function JoinAllGroupsChat() {
    $.ajax({
        type: "GET",
        url: '/Chat/GetAllRoomsList',
        dataType: 'json',
        success: function (response) {
            for (var i in response) {
                //join room chat
                connection.invoke("JoinGroup", response[i].maPhongChat).catch(function (err) {
                    return console.error(err.toString());
                });
                console.log("Đã join group " + response[i].maPhongChat);
            }
        }
    });
                
}

function OutAllGroupsChatExcept(room_id) {
    $.ajax({
        type: "GET",
        url: '/Chat/GetAllRoomsList',
        dataType: 'json',
        success: function (response) {
            for (var i in response) {
                //out room chat
                connection.invoke("OutGroup", response[i].maPhongChat).catch(function (err) {
                    return console.error(err.toString());
                });
                console.log("Đã out group " + response[i].maPhongChat);
            }
            JoinGroupChat(room_id);
        }
    });
}

function JoinGroupChat(room_id) {
    connection.invoke("JoinGroup", room_id).catch(function (err) {
        return console.error(err.toString());
    });
    console.log("Đã join group " + room_id);
}

function SetReadMessage(room_id) {

}

$(function () {

   
});

$(document).ready(function () {

    LoadRoomsList();
    JoinAllGroupsChat();
    $(".timeago").timeago();
    console.log('vô hàm');
    $('#list_account').tagsInput({
        
        'autocomplete_url': '/EmployeeAdmin/GetListEmployee',
        'autocomplete': {
            source: function (request, response) {
                $.ajax({
                    url: "/EmployeeAdmin/GetListEmployee?keyword="+request.term,
                    dataType: "json",
                    success: function (data) {
                        response($.map(data, function (item) {
                            if (item.maTaiKhoan != null) {
                                console.log(item);
                                return {
                                    label: item.tenTaiKhoan,
                                    value: item.maTaiKhoan
                                }
                            }
                            
                        }));
                    }
                })
            }   
        }
    });

    var countries = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        prefetch: {
            url: 'data/countries.json',
            filter: function (list) {
                return $.map(list, function (name) {
                    return { name: name };
                });
            }
        }
    });
    countries.initialize();


    function AddMessage(room_id, message) {
        $.ajax({
            type: "GET",
            url: '/Chat/AddMessageToDatabase?room_id=' + room_id + '&message=' + message,
            dataType: 'json',
            success: function (response) {
                console.log("thành công");
            },
            error: function (error) {
                alert("không thêm được tin nhắn");
            }
        });
    }

    $(document).on('click', '#backToMessageList', function (event) {
        $(".show-chat-box").removeClass("show-chat-box");
        LoadRoomsList();
        JoinAllGroupsChat();
    });

   //add_conversation_btn

    $(document).on('click', '#addConversationBtn', function (event) {
        LoadRoomsList();
        JoinAllGroupsChat();
    });
    
    $(document).on('click', '.au-message__item', function () {
        var room_id = $(this).attr("data-room-id");
        OutAllGroupsChatExcept(room_id);
        //call ajax here
        var avatar = "";
        var name = "";
        $.ajax({
            type: "GET",
            url: '/Chat/GetParticipantByRoomId?room_id=' + room_id,
            dataType: 'json',
            success: function (response) {
                avatar = response.avatar;
                name = response.realName;
                var active = response.isActive;
                if (active == 1) {
                    $(".avatar-wrap").addClass("online");
                }
                else {
                    $(".avatar-wrap").removeClass("online");
                }
                $("#chatName").text(name);
                $("#chatAvatar").attr("src", "uploads/employee/" + avatar);
                $("#sendButton").attr("data-room-id", room_id);
                $.ajax({
                    type: "GET",
                    url: '/Chat/GetAllMessageByRoomId?room_id=' + room_id,
                    dataType: 'json',
                    success: function (response) {
                        var htmlString = '';

                        var check = document.getElementById("myAccountId").value;
                        for (var i in response) {
                            if (check == response[i].maTaiKhoan) {
                                htmlString += '<div class="send-mess-wrap"><div class="send-mess__inner"><div class="send-mess-list">';
                                htmlString += '<div class="send-mess">' + response[i].tinNhan1 + '</div></div></div></div>';
                            }
                            else {
                                htmlString += '<div class="recei-mess-wrap"><div class="recei-mess__inner"><div class="avatar avatar--tiny">';
                                htmlString += '<img src="uploads/employee/' + avatar + '" alt="John Smith"></div>';
                                htmlString += '<div class="recei-mess-list"><div class="recei-mess">' + response[i].tinNhan1 + '</div></div></div></div>';
                            }
                        }
                        $("#messagesList > div").remove();
                        $("#messagesList").append(htmlString);
                        AutoScrollDown();
                    }

                });
            }
        });
        $(this).parent().parent().parent().toggleClass('show-chat-box');
    });

    $(document).on('click', '#sendButton', function (event) {
        var group_id = $(this).attr("data-room-id");
        var user_id = document.getElementById("myAccountId").value;
        var message = document.getElementById("messageInput").value;
        connection.invoke("SendMessageInGroup", group_id, user_id, message).catch(function (err) {
            return console.error(err.toString());
        });
        AddMessage(group_id, message);
        $("#messageInput").val("");
        AutoScrollDown();
        event.preventDefault();

    });
});
