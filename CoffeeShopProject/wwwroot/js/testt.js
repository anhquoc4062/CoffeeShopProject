"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.on("ReceiveMessage", function (user_id, message) {
    //var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var li = document.createElement("li");
    li.textContent = message;
    document.getElementById("listMess").appendChild(li);
});

connection.on("UserConnected", function (connectionId) {
    console.log(connectionId + " has connected");
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("joinGroup").addEventListener("click", function (event) {
    connection.invoke("JoinGroup", "PrivateGroup").catch(function (err) {
        return console.error(err.toString());
    });
    console.log("Joined Private Group");
    event.preventDefault();
});

document.getElementById("sendEveryone").addEventListener("click", function (event) {
    var message = document.getElementById("messInput").value;
    var user_id = "1";
        connection.invoke("SendMessage", user_id ,message).catch(function (err) {
            return console.error(err.toString());
        });
    console.log("Sended Message");
    event.preventDefault();
});

document.getElementById("sendPrivate").addEventListener("click", function (event) {
    var message = document.getElementById("messInput").value;
    var user_id = "1";
    connection.invoke("SendMessageInGroup", "PrivateGroup", user_id, message).catch(function (err) {
        return console.error(err.toString());
    });
    console.log("Sended Message");
    event.preventDefault();
});