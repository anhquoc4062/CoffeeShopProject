"use strict";

var EnterKeyPressed = false;
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

function LoadRoomsList() {
    $.ajax({
        type: "GET",
        url: '/Chat/GetAllRoomsList',
        dataType: 'json',
        success: function (response) {
            var htmlString = '';
            for (var i in response) {
                //join room chat
                connection.invoke("JoinGroup", response[i].maPhongChat).catch(function (err) {
                    return console.error(err.toString());
                });
                //load append
                var checkRead = "unread";
                if (response[i].status == 1) {
                    var checkRead = "read";
                }
                htmlString += '<div class="au-message__item ' + checkRead + '" data-room-id="' + response[i].maPhongChat + '">';
                htmlString += '<div class="au-message__item-inner"><div class="au-message__item-text"><div class="avatar-wrap online"><div class="avatar">';
                htmlString += '<img src="uploads/employee/' + response[i].avatar + '" alt="Michelle Sims"></div></div><div class="text">'
                htmlString += '<h5 class="name">' + response[i].realName + '</h5><p>' + response[i].lastMessage + '</p></div></div>';
                htmlString += '<div class="au-message__item-time">';
                htmlString += '<time class="timeago" datetime="' + response[i].time + '" title="' + response[i].time + '">đổi dùm con</time>';
                htmlString += '</div ></div ></div >';
            }
            $("#roomsList > div").remove();
            $("#roomsList").append(htmlString);
            $("time").timeago();
        }
    });
}

connection.on("ReceiveMessage", function (user_id, message) {
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
    }
    $("#messagesList").append(htmlString);
    LoadRoomsList();
});

connection.on("UserConnected", function (user_id) {
    console.log(user_id + " has connected");
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



function SetReadMessage(room_id) {

}

$(document).ready(function () {
    function AutoScrollDown() {
        $("#messagesList").animate({
            scrollTop: $("#messagesList").get(0).scrollHeight
        }, 10);
        console.log("đã scroll");
    }
    LoadRoomsList();
    $(".timeago").timeago();

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
    });
    
    $(document).on('click', '.au-message__item', function () {
        var room_id = $(this).attr("data-room-id");
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

                    }
                });
            }
        });
        $(this).parent().parent().parent().toggleClass('show-chat-box');

        AutoScrollDown();
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
