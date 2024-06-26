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
    public partial class shortalarm : System.Web.UI.Page
    {
        GeneralFunctions GF = new GeneralFunctions();
        GeneralFunctionsAppSpecific GFS = new GeneralFunctionsAppSpecific();

        static SqlConnection conn = new SqlConnection(@"server=database.convilguous.com,14333;database=ConvilguousWC;User ID=MinerProbe;Pwd=Kwakkerl77*;Asynchronous Processing=true;MultipleActiveResultSets=true; Connect Timeout=30");

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Response.ContentType = "text/plain";
            string Response = "";

            try
            {
                if (Request.QueryString["SerialNumber"] != null)
                {
                    long SerialNumber = GF.Int64Parse(Request.QueryString["SerialNumber"]);
                    long EventID = GF.Int64Parse(Request.QueryString["EventID"]);
                    string Alarm = Request.QueryString["Alarm"];
                    int AlarmType = Request.QueryString["Type"] == null ? 0 : GF.IntParse(Request.QueryString["Type"]);

                    GFS.SQL_SendWithoutResponse(conn, "MiningProcessorShortAlarmsAdd", new List<SqlParameter> {
                        new SqlParameter(){ParameterName = "@ID", SqlDbType = System.Data.SqlDbType.BigInt, Value = SerialNumber },
                        new SqlParameter(){ParameterName = "@Message", SqlDbType = System.Data.SqlDbType.VarChar, Size = 255, Value = Alarm },
                        new SqlParameter(){ParameterName = "@EventID", SqlDbType = System.Data.SqlDbType.BigInt, Value = EventID },
                        new SqlParameter(){ParameterName = "@Type", SqlDbType = System.Data.SqlDbType.Int, Value = AlarmType }});
                }
            }
            catch (Exception eee)
            {
                GFS.LogError(eee, GeneralFunctions.EventLogEntryType.Error, 2111200202);
            }
            Page.Response.Write(Response);
        }
    }
}