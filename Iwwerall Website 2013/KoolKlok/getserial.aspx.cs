using Convilguous_Shared;
using Convilguous_Shared_OSDependent;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Iwwerall_Website_2013.MiningCoProcessor
{
    public partial class getserial : System.Web.UI.Page
    {
        GeneralFunctions GF = new GeneralFunctions();
        GeneralFunctionsAppSpecific GFS = new GeneralFunctionsAppSpecific();
        static SqlConnection conn = new SqlConnection(@"server=database.convilguous.com,14333;database=ConvilguousWC;User ID=MinerProbe;Pwd=Kwakkerl77*;Asynchronous Processing=true;MultipleActiveResultSets=true; Connect Timeout=30");

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Response.ContentType = "text/plain";
            string Response = "0";
            long SerialNumber = 0;

            try
            {
                if (Request.QueryString["SerialNumber"] != null)
                {
                    string ModuleModel = Request.QueryString["ModuleModel"] == null ? "KoolKlokv1" : Request.QueryString["ModuleModel"];
                    int FirmwareVersionForHost = GF.IntParse(Request.QueryString["FirmwareVersionForHost"]);
                    SerialNumber = GF.Int64Parse(Request.QueryString["SerialNumber"]);

                    long ID = GF.Int64Parse(GFS.SQL_SendWithObjectResponse(conn, "KoolKlokDevicesUpdate", new List<SqlParameter> {
                        new SqlParameter(){ParameterName = "@ID", SqlDbType = System.Data.SqlDbType.BigInt, Value = SerialNumber },
                        new SqlParameter(){ParameterName = "@ModuleModel", SqlDbType = System.Data.SqlDbType.VarChar, Size = 20, Value = ModuleModel },
                        new SqlParameter(){ParameterName = "@FirmwareVersionForHost", SqlDbType = System.Data.SqlDbType.Int, Value = FirmwareVersionForHost }}));

                    Response = ID.ToString();
                }
            }
            catch (Exception eee)
            {
                GFS.LogError(eee, GeneralFunctions.EventLogEntryType.Error, 2407041321);
                string WholeRequest = "";
                foreach(string Key in Request.QueryString.AllKeys)
                {
                    WholeRequest += $"{Key}={Request.QueryString[Key]}, ";
                }
                GFS.LogError($"Serialnumber with error: {SerialNumber}, {WholeRequest}", GeneralFunctions.EventLogEntryType.Error, 2407041320);
            }
            Page.Response.Write(Response);
        }
    }
}