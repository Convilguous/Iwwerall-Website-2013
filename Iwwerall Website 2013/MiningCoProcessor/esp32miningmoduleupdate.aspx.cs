using Iwwerall;
using System;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Response.ContentType = "text/plain";
            string Response = "";
            try
            {
                if (Request.QueryString["SerialNumber"] != null)
                {
                    long SerialNumber = AF.Int64Parse(Request.QueryString["SerialNumber"]);

                    AlgemeneFuncties.conn = new SqlConnection(@"server=database.convilguous.com,14333;database=ConvilguousWC;User ID=MinerProbe;Pwd=Kwakkerl77*;Asynchronous Processing=true;MultipleActiveResultSets=true; Connect Timeout=30");

                    DataTable dtFile = AF.SQL_SendWithDirectDataTableResponse("MiningProcessorUpdateFilesGet", SerialNumber);

                    if (dtFile.Rows.Count == 1)
                    {
                        Response = $"{dtFile.Rows[0]["SizeinBytes"].ToString().PadLeft(10, '0')}{dtFile.Rows[0]["UpdateFile"]}";
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