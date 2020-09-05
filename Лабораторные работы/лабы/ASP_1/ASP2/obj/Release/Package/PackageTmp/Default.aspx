<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASP2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">    
    <html>
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
<body>
        <asp:Button ID="Button1" runat="server" Text="Get" OnClick="Button1_Click" />

        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Post" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Put" />

        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="403" />

                <input type="text" id="number1" value="First number" /><input type="text" id="number2" value="Second number" /><input type="button" value="Send" onclick="send()" /><br />

        <br />
                <br />
                &nbsp;<div id="result"></div>
       <a href="Op">Html</a>
    <br />
    <a href="OpForm">Form</a>
    </body>
</html>
</asp:Content>

