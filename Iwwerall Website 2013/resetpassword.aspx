﻿<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="resetpassword.aspx.cs" Inherits="Iwwerall_Website_2013.resetpassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="container-fluid d-flex justify-content-center align-items-center w-100">
        <div class="container p-3 m-1 p-md-5 m-md-5 card verification-container">
            <div class="row">
                <div class="col-sm">
                    <asp:Image runat="server" ImageUrl="~/Images/iwwerall-resetpassword.svg" CssClass="image-display" />
                </div>
                <div class="col-sm text-center text-md-left">
                    <div class="d-flex flex-column justify-content-center h-100">
                        <h1>
                            <asp:Label runat="server" ID="lblVerificationStatus" Text="Reset Password" />
                        </h1>
                        <p>
                            <asp:Label runat="server" Text="Verification Message" ID="lblInfo" />
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>