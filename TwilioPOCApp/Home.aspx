<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TwilioPOCApp.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Label Text="From Number" runat="server"></asp:Label> : <asp:Label ID="from" Text="+1954-880-3970" runat="server"></asp:Label><br /><br />

         <br />
        Select SendFor: <asp:DropDownList ID="Select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Select_SelectedIndexChanged">
            <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
            <asp:ListItem Text="Breakfast" Value="B"></asp:ListItem>
            <asp:ListItem Text="Lunch" Value="L"></asp:ListItem>
            <asp:ListItem Text="Registration" Value="N"></asp:ListItem>
                        </asp:DropDownList>
        <br />
       <br />

     <asp:Label ID="Label2" Text="To Number" runat="server"></asp:Label> :  <asp:ListBox ID="lstnum" runat="server" Height="87px" Width="160px"> </asp:ListBox><br />
       
          
        <br />
        
    <br />
     <asp:TextBox ID="txtsend" runat="server" Height="33px" TextMode="MultiLine" Width="518px" ></asp:TextBox>
         
     <br />
         <asp:Label ID="sendcount" runat="server" Visible="false"></asp:Label>
        <br />
        
        <asp:Label ID="response" runat="server" Visible="false"></asp:Label>
      <br />
        <asp:Button ID="btnSend" Text="Send" runat="server" OnClick="btnSend_Click" />
    </div>
    </form>
</body>
</html>
