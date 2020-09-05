<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASP2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">    
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <script>
        function send() {
            var xhr = new XMLHttpRequest();
            xhr.open('POST', 'Sum', true);
            xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
            xhr.onreadystatechange = function () {
                if (xhr.readyState != 4) return;
                if (xhr.status != 200) {
                    alert(xhr.status + ': ' + xhr.statusText);
                } else {
                    WebForm_GetElementById("result").textContent = "Result: " + xhr.responseText
                }
            }
            xhr.send("X=" + document.getElementById("number1").value + "&Y=" + document.getElementById("number2").value);
        }
    </script>
</head>
<body style="height:300px;width:800px;margin-top:20px;">
        <asp:Button ID="Button1" runat="server" Text="Get" OnClick="Button1_Click" />

        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Post" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Put" />

        <br />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="403" />

        <br />
                <input type="text" id="number1" value="First number" /><br />
                <input type="text" id="number2" value="Second number" /><br />
                <input type="button" value="Send" onclick="send()" />
            <div id="result"></div>
       <a href="Op">OpXHTML</a>
    <br />
    <a href="OpForm">OpForm</a>
    </body>
</html>
</asp:Content>

