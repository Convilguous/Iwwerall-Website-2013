using Iwwerall;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Iwwerall_Website_2013
{
    public partial class updatesensor : System.Web.UI.Page
    {
        AlgemeneFuncties AF = new AlgemeneFuncties();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Response.ContentType = "text/plain";
            string Response = "0";

            try
            {
                if (Request.QueryString["SerialNumber"] != null)
                {
                    int FirmwareVersionForHost = AF.intParse(Request.QueryString["FirmwareVersionForHost"]);
                    long SerialNumber = AF.Int64Parse(Request.QueryString["SerialNumber"]);
                    long MachineRunning = AF.Int64Parse(Request.QueryString["MachineRunning"]);
                    int FanLeftTachoPulsesPerSecond = AF.intParse(Request.QueryString["FanLeftTachoPulsesPerSecond"]);
                    int FanRightTachoPulsesPerSecond = AF.intParse(Request.QueryString["FanRightTachoPulsesPerSecond"]);
                    double DHTExternalTemperature = AF.DoubleParse(Request.QueryString["DHTExternalTemperature"]) / 10000;
                    double DHTExternalHumidity = AF.DoubleParse(Request.QueryString["DHTExternalHumidity"].Replace(".", ",")) / 10000;
                    double DS18B20TemperatureIntake = AF.DoubleParse(Request.QueryString["DS18B20TemperatureIntake"].Replace(".", ",")) / 10000;
                    double DS18B20TemperatureLeftExhaust = AF.DoubleParse(Request.QueryString["DS18B20TemperatureLeftExhaust"].Replace(".", ",")) / 10000;
                    double DS18B20TemperatureRightExhaust = AF.DoubleParse(Request.QueryString["DS18B20TemperatureRightExhaust"].Replace(".", ",")) / 10000;
                    double CapacitorsRelayPowerLevel = Request.QueryString["CapacitorsPowerLevel"] == null ? 0 : AF.DoubleParse(Request.QueryString["CapacitorsPowerLevel"].Replace(".", ",")) / 10000;
                    CapacitorsRelayPowerLevel = Request.QueryString["CapacitorsRelayPowerLevel"] == null ? CapacitorsRelayPowerLevel : AF.DoubleParse(Request.QueryString["CapacitorsRelayPowerLevel"].Replace(".", ",")) / 10000;
                    double CapacitorProcessorPowerLevel = Request.QueryString["CapacitorProcessorPowerLevel"] == null ? 0 : AF.DoubleParse(Request.QueryString["CapacitorProcessorPowerLevel"].Replace(".", ",")) / 10000;
                    double AmpsRightPowersupply = AF.DoubleParse(Request.QueryString["AmpsRightPowersupply"].Replace(".", ",")) / 10000;
                    double AmpsLeftPowersupply = AF.DoubleParse(Request.QueryString["AmpsLeftPowersupply"].Replace(".", ",")) / 10000;
                    double AmpsAux = AF.DoubleParse(Request.QueryString["AmpsAux"].Replace(".", ",")) / 10000;
                    double UnusedADCValue = AF.DoubleParse(Request.QueryString["UnusedADCValue"].Replace(".", ",")) / 10000;
                    int BitMaskForHost = AF.intParse(Request.QueryString["BitMaskForHost"]);
                    string ConnectedToWifi = Request.QueryString["ConnectedToWifi"];
                    int ConnectionStrength = AF.intParse(Request.QueryString["ConnectionStrength"]);

                    AlgemeneFuncties.conn = new SqlConnection(@"server=database.convilguous.com,14333;database=ConvilguousWC;User ID=MinerProbe;Pwd=Kwakkerl77*;Asynchronous Processing=true;MultipleActiveResultSets=true; Connect Timeout=30");

                    long ID = AF.Int64Parse(AF.SQL_SendWithObjectResponse("MiningProcessorsStateUpdate", new List<SqlParameter> {
                        new SqlParameter(){ParameterName = "@ID", SqlDbType = System.Data.SqlDbType.BigInt, Value = SerialNumber },
                        new SqlParameter(){ParameterName = "@FirmwareVersionForHost", SqlDbType = System.Data.SqlDbType.Int, Value = FirmwareVersionForHost },
                        new SqlParameter(){ParameterName = "@MachineRunning", SqlDbType = System.Data.SqlDbType.BigInt, Value = MachineRunning },
                        new SqlParameter(){ParameterName = "@FanLeftTachoPulsesPerSecond", SqlDbType = System.Data.SqlDbType.Int, Value = FanLeftTachoPulsesPerSecond },
                        new SqlParameter(){ParameterName = "@FanRightTachoPulsesPerSecond", SqlDbType = System.Data.SqlDbType.Int, Value = FanRightTachoPulsesPerSecond },
                        new SqlParameter(){ParameterName = "@DHTExternalTemperature", SqlDbType = System.Data.SqlDbType.Float, Value = DHTExternalTemperature },
                        new SqlParameter(){ParameterName = "@DHTExternalHumidity", SqlDbType = System.Data.SqlDbType.Float, Value = DHTExternalHumidity },
                        new SqlParameter(){ParameterName = "@DS18B20TemperatureIntake", SqlDbType = System.Data.SqlDbType.Float, Value = DS18B20TemperatureIntake },
                        new SqlParameter(){ParameterName = "@DS18B20TemperatureLeftExhaust", SqlDbType = System.Data.SqlDbType.Float, Value = DS18B20TemperatureLeftExhaust },
                        new SqlParameter(){ParameterName = "@DS18B20TemperatureRightExhaust", SqlDbType = System.Data.SqlDbType.Float, Value = DS18B20TemperatureRightExhaust },
                        new SqlParameter(){ParameterName = "@CapacitorsRelayPowerLevel", SqlDbType = System.Data.SqlDbType.Float, Value = CapacitorsRelayPowerLevel },
                        new SqlParameter(){ParameterName = "@CapacitorProcessorPowerLevel", SqlDbType = System.Data.SqlDbType.Float, Value = CapacitorProcessorPowerLevel },
                        new SqlParameter(){ParameterName = "@AmpsRightPowersupply", SqlDbType = System.Data.SqlDbType.Float, Value = AmpsRightPowersupply },
                        new SqlParameter(){ParameterName = "@AmpsLeftPowersupply", SqlDbType = System.Data.SqlDbType.Float, Value = AmpsLeftPowersupply },
                        new SqlParameter(){ParameterName = "@AmpsAux", SqlDbType = System.Data.SqlDbType.Float, Value = AmpsAux },
                        new SqlParameter(){ParameterName = "@UnusedADCValue", SqlDbType = System.Data.SqlDbType.Float, Value = UnusedADCValue },
                        new SqlParameter(){ParameterName = "@BitMaskForHost", SqlDbType = System.Data.SqlDbType.Int, Value = BitMaskForHost },
                        new SqlParameter(){ParameterName = "@ConnectedToWifi", SqlDbType = System.Data.SqlDbType.VarChar, Size = 255, Value = ConnectedToWifi },
                        new SqlParameter(){ParameterName = "@ConnectionStrength", SqlDbType = System.Data.SqlDbType.Int, Value = ConnectionStrength }}));

                    Response = ID.ToString();
                }
            }
            catch (Exception eee)
            {
                AF.LogError(eee, System.Diagnostics.EventLogEntryType.Error, 2111160912);
            }
            Page.Response.Write(Response);
        }
    }
}