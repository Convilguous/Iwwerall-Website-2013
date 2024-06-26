using Convilguous_Shared;
using Convilguous_Shared_OSDependent;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Iwwerall_Website_2013.MiningCoProcessor
{
    public partial class getremotecommands : System.Web.UI.Page
    {
        GeneralFunctions GF = new GeneralFunctions();
        GeneralFunctionsAppSpecific GFS = new GeneralFunctionsAppSpecific();

        static SqlConnection conn = new SqlConnection(@"server=database.convilguous.com,14333;database=ConvilguousWC;User ID=MinerProbe;Pwd=Kwakkerl77*;Asynchronous Processing=true;MultipleActiveResultSets=true; Connect Timeout=30");
        static ConcurrentBag<long> CommandsPresent = new ConcurrentBag<long>();
        static DateTime LastDataSync = DateTime.UtcNow.AddHours(-1);
            
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Response.ContentType = "text/plain";
            string Response = "";
            try
            {
                if (Request.QueryString["SerialNumber"] != null)
                {
                    long SerialNumber = GF.Int64Parse(Request.QueryString["SerialNumber"]);

                    // Keep offline list up to date
                    if(LastDataSync.AddSeconds(60) < DateTime.UtcNow)
                    {
                        CommandsPresent = new ConcurrentBag<long>();
                        DataTable dtTemp = GFS.SQL_SendWithDirectDataTableResponse(conn, "MiningProcessorCommandsGetAll");

                        foreach(DataRow dr in dtTemp.Rows)
                        {
                            CommandsPresent.Add(GF.Int64Parse(dr["MiningProcessorID"]));
                        }

                        LastDataSync = DateTime.UtcNow;
                    }

                    // Only connect to the database if the miner needs a command (most of the time it does not)
                    if (CommandsPresent.Contains(SerialNumber))
                    {
                        object Command = GFS.SQL_SendWithObjectResponse(conn, "MiningProcessorCommandsGet", SerialNumber);
                        if (Command != null)
                        {
                            Response = Command.ToString();
                        }
                    }
                }
            }
            catch (Exception eee)
            {
                GFS.LogError(eee, GeneralFunctions.EventLogEntryType.Error, 2202161701);
            }
            Page.Response.Write(Response);
        }
    }
}