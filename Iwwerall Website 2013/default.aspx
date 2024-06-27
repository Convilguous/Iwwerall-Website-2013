<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Iwwerall_Website_2013._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    Iwwerall
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="container-fluid main-content d-flex justify-content-center align-items-center">
        <video autoplay muted loop class="video-player">
          <source src="../videos/iwwerall-white-background-zoomed-out.mp4" type="video/mp4">
        </video>
        <div class="info-text">
            <asp:Label ID="Label2" runat="server" Font-Names="Verdana" ForeColor="#6C56A4" 
            Text="Iwwerall sa - 35, Gruuss Strooss - L-9991 Weiswampach"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Font-Names="Verdana" ForeColor="#6C56A4" 
            Text="Tel: +352 621 318 727 - info@iwwerall.lu"></asp:Label>
        </div>
    </div>
</asp:Content>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<style>
html { 
  background: url(images/background.jpg) no-repeat center center fixed; 
  -webkit-background-size: cover;
  -moz-background-size: cover;
  -o-background-size: cover;
  background-size: cover;
}    
.footer
{
    height:150px; 
    width: 100%; 
    background-image: none;
    background-repeat: repeat;
    background-attachment: scroll;
    background-position: 0% 0%;
    position: fixed;
    bottom: 0pt;
    left: 0pt;
}
    .style1
    {
        width: 100%;
    }
</style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <div class="footer" align="center">
        <table class="style1">
            <tr>
                <td width="50%">
                    &nbsp;</td>
                <td width="50%">
                    <asp:Label ID="Label2" runat="server" Font-Names="Verdana" ForeColor="#6C56A4" 
                        Text="Iwwerall sa - 35, Gruuss Strooss - L-9991 Weiswampach"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="50%">
                    &nbsp;</td>
                <td width="50%">
                    <asp:Label ID="Label3" runat="server" Font-Names="Verdana" ForeColor="#6C56A4" 
                        Text="Tel: +352 621 318 727 - info@iwwerall.lu"></asp:Label>
                </td>
            </tr>
        </table>
</div>    </form>
</body>
</html>--%>
