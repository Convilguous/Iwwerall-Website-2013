<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="verification.aspx.cs" Inherits="Iwwerall_Website_2013.verification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="container-fluid d-flex justify-content-center align-items-center w-100">
        <div class="container container p-3 m-1 p-md-5 m-md-5 card verification-container">
            <div class="row">
                <div class="col-sm">
                    <asp:Image runat="server" ImageUrl="~/Images/iwwerall-verification.svg" CssClass="image-display p-5" />
                </div>
                <div class="col-sm text-center text-md-left">
                    <div class="d-flex flex-column justify-content-center h-100">
                        <h1>
                            <asp:Label runat="server" ID="lblStatus" Text="Verification" />
                        </h1>
                        <p>
                            <asp:Label runat="server" Text="Verification Message" ID="lblInfo" />
                        </p>
                        <div class="d-flex justify-content-center justify-content-lg-start flex-wrap">
                            <asp:Button Text="Resend verification" runat="server" CssClass="btn btn-custom m-1" ID="bntResendVerification" Visible="false" PostBackUrl="~/SendVerification.aspx" />
                            <asp:Button Text="Login" runat="server" CssClass="btn btn-custom m-1" ID="btnLogin" Visible="false" PostBackUrl="~/Login.aspx" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
