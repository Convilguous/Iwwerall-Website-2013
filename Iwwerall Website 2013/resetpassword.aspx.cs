﻿using Convilguous_Shared;
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
    public partial class resetpassword : System.Web.UI.Page
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
                        string Code = Request.QueryString["Code"];

                        if (Code.Length != 64)
                        {
                            lblInfo.Text = "The provided code is not valid";
                        }
                        else
                        {
                            DataTable dtResult = GF.GetCentralDatav7(53785378, "f833571d0d6374694d320f4ceacfc2fae860f2364133cde29d4a09c56a4efd58", CentralCommsv7.DatabaseCommand.GlobalAccess_UsersEnablePasswordReset, Code);

                            if (dtResult.Rows.Count == 0)
                            {
                                lblInfo.Text = "The provided code does not exist in the database";
                            }
                            else
                            {
                                switch (GF.Int64Parse(dtResult.Rows[0]["ID"]))
                                {
                                    case 0:
                                        lblInfo.Text = "The provided code does not exist in the database";
                                        break;
                                    case 1:
                                        lblInfo.Text = "The provided code expired, please request a new one";
                                        break;
                                    default:
                                        lblInfo.Text = "Your request to reset your password has been accepted, next time you open any application or website you will be asked to provide a new password.";
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("https://www.iwwerall.lu");
                    }
                }
                catch (Exception eee)
                {
                    GFS.LogError(eee, GeneralFunctions.EventLogEntryType.Error, 2310110955);
                }
            }
        }
    }
}