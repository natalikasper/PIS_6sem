<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lab2b._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        var ws;
        function exe_start() {
            if (ws == null) {
                ws = new WebSocket('ws://localhost:1200/Websocket');
                ws.onopen = function () { ws.send('Connecting') }
                ws.onclose = function (s) { console.log('onclose' + s); }
                ws.onmessage = function (evt) { ta.innerHTML += '\n' + evt.data; }
                bstart.disabled = true;
                bstop.disabled = false;
            }
        }

        function exe_stop() {
            ws.close(3001, ' stopapplication');
            ws = null;
            bstart.disabled = false;
            bstop.disabled = true;
        }
    </script>
    <h1>Web Sockets</h1>
    <span>Web sockets поддерживается?</span> <span id="support"></span>
    <br />
    <div>
        <input type="button" value="Start" id="bstart" onclick="exe_start()" />
        <input type="button" value="Stop" id="bstop" onclick="exe_stop()" />
    </div>
    <div>
        <textarea id="ta" rows="20" cols="25" style="text-align: center" readonly>
        </textarea>
    </div>
</asp:Content>
