using Iwwerall;
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
    public partial class esp32miningmoduleupdate : System.Web.UI.Page
    {
        AlgemeneFuncties AF = new AlgemeneFuncties();
        static SqlConnection conn = new SqlConnection(@"server=database.convilguous.com,14333;database=ConvilguousWC;User ID=MinerProbe;Pwd=Kwakkerl77*;Asynchronous Processing=true;MultipleActiveResultSets=true; Connect Timeout=30");
        static ConcurrentBag<long> UpdatesPresent = new ConcurrentBag<long>();
        static DateTime LastDataSync = DateTime.UtcNow.AddHours(-1);

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Response.ContentType = "text/plain";
            string Response = "";
            try
            {
                if (Request.QueryString["SerialNumber"] != null)
                {
                    long SerialNumber = AF.Int64Parse(Request.QueryString["SerialNumber"]);

                    // Keep offline list up to date
                    if (LastDataSync.AddSeconds(60) < DateTime.UtcNow)
                    {
                        UpdatesPresent = new ConcurrentBag<long>();
                        DataTable dtTemp = AF.SQL_SendWithDirectDataTableResponse(conn, "MiningProcessorUpdateFilesGetAll");

                        foreach (DataRow dr in dtTemp.Rows)
                        {
                            UpdatesPresent.Add(AF.Int64Parse(dr["ID"]));
                        }

                        LastDataSync = DateTime.UtcNow;
                    }

                    // Only connect to the database if the miner needs an update (most of the time it does not)
                    if (UpdatesPresent.Contains(SerialNumber))
                    {
                        DataTable dtFile = AF.SQL_SendWithDirectDataTableResponse(conn, "MiningProcessorUpdateFilesGet", SerialNumber);

                        if (dtFile.Rows.Count == 1)
                        {
                            Response = $"{dtFile.Rows[0]["SizeinBytes"].ToString().PadLeft(10, '0')}{dtFile.Rows[0]["UpdateFile"]}";
                        }
                    }
                }
            }
            catch (Exception eee)
            {
                AF.LogError(eee, System.Diagnostics.EventLogEntryType.Error, 2111191846);
            }
            Page.Response.Write(Response);
        }
    }
}