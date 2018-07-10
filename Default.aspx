<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_2Project.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" >
        <p> Изменение статуса документов</p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Документ"></asp:Label>
            <asp:DropDownList ID="IDDoc" runat="server" OnSelectedIndexChanged="IDDoc_SelectedIndexChanged">
             
                </asp:DropDownList>
            <asp:Label ID="Label2" runat="server" Text="Статус"></asp:Label>
            <asp:DropDownList ID="Statuses" runat="server">
                <asp:ListItem Text="Проведен"></asp:ListItem>
                <asp:ListItem Text="Не проведен"></asp:ListItem>
                <asp:ListItem Text="Отказано"></asp:ListItem>
            </asp:DropDownList>
        </p>
        <asp:Button ID="Button1" runat="server" Text="Сохранить" OnClick="Button1_Click" />
        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
        <p>Дата от<asp:Calendar ID="Calendar1" runat="server" Height="88px" Width="99px"></asp:Calendar>
            <asp:Label ID="Label4" runat="server" Text="Дата до"></asp:Label>
            <asp:Calendar ID="Calendar2" runat="server" Height="112px" Width="54px"></asp:Calendar>
            <asp:Label ID="Label5" runat="server" Text="ID документа"></asp:Label>
            <asp:TextBox ID="idSearch" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" Text="Поиск" OnClick="Button2_Click" style="height: 25px" /> </p>
        <p>
            История статусов документов</p>
            <div id="History" runat="server">

            </div>
        
    </form>
</body>
</html>
