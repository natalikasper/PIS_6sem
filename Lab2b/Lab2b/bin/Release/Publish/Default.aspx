﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lab2b._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <input type="text" id="user" />
    <input type="text" id="message" />
    <input type="button" value="send" id="send" />
    <div id='messages'></div>
    <script type="text/javascript">
        var socket,
            $txt = document.getElementById('message'),
            $user = document.getElementById('user'),
            $messages = document.getElementById('messages');

        if (typeof (WebSocket) !== 'undefined') {
            socket = new WebSocket("ws://localhost/Websocket");
        } else {
            socket = new MozWebSocket("ws://localhost/Websocket");
        }

        socket.onmessage = function (msg) {
            var $el = document.createElement('p');
            $el.innerHTML = msg.data;
            $messages.appendChild($el);
        };

        socket.onclose = function (event) {
            alert('Мы потеряли её. Пожалуйста, обновите страницу');
        };

        document.getElementById('send').onclick = function () {
            socket.send($user.value + ' : ' + $txt.value);
            $txt.value = '';
        };
    </script>
</asp:Content>
