using Convilguous_Shared;
using Convilguous_Shared_OSDependent;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Iwwerall_Website_2013
{
    public partial class movesource : System.Web.UI.Page
    {
        GeneralFunctions GF = new GeneralFunctions();
        GeneralFunctionsAppSpecific GFS = new GeneralFunctionsAppSpecific();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString["Code"] != null)
                    {
                        if (Session["MoveSourceCode"] == null)
                            Session.Add("MoveSourceCode", Request.QueryString["Code"]);
                        else
                            Session["MoveSourceCode"] = Request.QueryString["Code"];

                        if (Session["MoveSourceCode"].ToString().Length != 64)
                        {
                            lblVerificationStatus.Text = "Update Email Failed!";
                            lblInfo.Text = "The provided code is not valid";
                        }
                        else
                        {
                            DataTable dtResult = GF.GetCentralDatav7(53785378, "f833571d0d6374694d320f4ceacfc2fae860f2364133cde29d4a09c56a4efd58", CentralCommsv7.DatabaseCommand.GlobalAccess_UsersCheckUpdateEmailVerification, Session["MoveSourceCode"].ToString());

                            if (dtResult.Rows.Count == 0)
                            {
                                lblInfo.Text = "The provided code is unknown.";
                                btnUpdateEmail.Visible = false;
                            }
                            else
                            {
                                switch (GF.Int64Parse(dtResult.Rows[0]["status"]))
                                {
                                    case 0:
                                        lblVerificationStatus.Text = "Update Email Failed!";
                                        lblInfo.Text = "The provided code does not exist in the database";
                                        btnUpdateEmail.Visible = false;
                                        break;
                                    case 1:
                                        lblVerificationStatus.Text = "Update Email Failed!";
                                        lblInfo.Text = "The provided code expired, please request a new one";
                                        btnUpdateEmail.Visible = false;
                                        break;
                                    default:
                                        btnUpdateEmail.Visible = true;
                                        btnUpdateEmail.Click += BtnUpdateEmail_Click;
                                        lblInfo.Text = "Ask confirmation they want to change from [SourceEmail] to [TargetEmail]";
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        lblInfo.Text = "Verification code is not found!";
                        btnUpdateEmail.Visible = false;
                    }
                }
                catch (Exception eee)
                {
                    GFS.LogError(eee, GeneralFunctions.EventLogEntryType.Error, 26060657);
                }
            }
        }

        private void BtnUpdateEmail_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtResult = GF.GetCentralDatav7(53785378, "f833571d0d6374694d320f4ceacfc2fae860f2364133cde29d4a09c56a4efd58", CentralCommsv7.DatabaseCommand.GlobalAccess_UsersDoUpdateEmailVerification, Session["MoveSourceCode"].ToString());

                if (dtResult.Rows.Count == 0)
                {
                    lblVerificationStatus.Text = "Verification Failed!";
                    lblInfo.Text = "The provided code does not exist in the database.";
                    btnUpdateEmail.Visible = false;
                }
                else
                {
                    switch (GF.Int64Parse(dtResult.Rows[0]["ID"]))
                    {
                        case 0:
                            lblVerificationStatus.Text = "Verification Failed!";
                            lblInfo.Text = "The provided code does not exist in the database.";
                            btnUpdateEmail.Visible = false;
                            break;
                        case 1:
                            lblVerificationStatus.Text = "Verification Failed!";
                            lblInfo.Text = "The provided code expired, please request a new one.";
                            btnUpdateEmail.Visible = false;
                            break;
                        default:
                            lblVerificationStatus.Text = "Verification Successful!";
                            lblInfo.Text = "Your user account has been successfully verified";
                            btnUpdateEmail.Visible = false;
                            break;
                    }
                }
            }
            catch (Exception eee)
            {
                GFS.LogError(eee, GeneralFunctions.EventLogEntryType.Error, 26060658);
            }
        }
    }
}