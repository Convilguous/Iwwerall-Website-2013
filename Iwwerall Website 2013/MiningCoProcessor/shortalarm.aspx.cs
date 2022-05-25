using Iwwerall;
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
        AlgemeneFuncties AF = new AlgemeneFuncties();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Response.ContentType = "text/plain";
            string Response = "";

            try
            {
                if (Request.QueryString["SerialNumber"] != null)
                {
                    long SerialNumber = AF.Int64Parse(Request.QueryString["SerialNumber"]);
                    long EventID = AF.Int64Parse(Request.QueryString["EventID"]);
                    string Alarm = Request.QueryString["Alarm"];
                    int AlarmType = Request.QueryString["Type"] == null ? 0 : AF.intParse(Request.QueryString["Type"]);

                    AlgemeneFuncties.conn = new SqlConnection(@"server=database.convilguous.com,14333;database=ConvilguousWC;User ID=MinerProbe;Pwd=Kwakkerl77*;Asynchronous Processing=true;MultipleActiveResultSets=true; Connect Timeout=30");

                    AF.SQL_SendWithoutResponse("MiningProcessorShortAlarmsAdd", new List<SqlParameter> {
                        new SqlParameter(){ParameterName = "@ID", SqlDbType = System.Data.SqlDbType.BigInt, Value = SerialNumber },
                        new SqlParameter(){ParameterName = "@Message", SqlDbType = System.Data.SqlDbType.VarChar, Size = 255, Value = Alarm },
                        new SqlParameter(){ParameterName = "@EventID", SqlDbType = System.Data.SqlDbType.BigInt, Value = EventID },
                        new SqlParameter(){ParameterName = "@Type", SqlDbType = System.Data.SqlDbType.Int, Value = AlarmType }});
                }
            }
            catch (Exception eee)
            {
                AF.LogError(eee, System.Diagnostics.EventLogEntryType.Error, 2111200202);
            }
            Page.Response.Write(Response);
        }
    }
}