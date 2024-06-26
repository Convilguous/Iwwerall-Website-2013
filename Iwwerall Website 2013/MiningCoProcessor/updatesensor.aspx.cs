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
    public partial class updatesensor : System.Web.UI.Page
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
                    string ModuleModel = Request.QueryString["ModuleModel"] == null ? "RIG2021" : Request.QueryString["ModuleModel"];
                    int FirmwareVersionForHost = GF.IntParse(Request.QueryString["FirmwareVersionForHost"]);
                    SerialNumber = GF.Int64Parse(Request.QueryString["SerialNumber"]);
                    long MachineRunning = GF.Int64Parse(Request.QueryString["MachineRunning"]);
                    int FanLeftTachoPulsesPerSecond = GF.IntParse(Request.QueryString["FanLeftTachoPulsesPerSecond"]);
                    int FanRightTachoPulsesPerSecond = GF.IntParse(Request.QueryString["FanRightTachoPulsesPerSecond"]);
                    double DHTExternalTemperature = GF.DoubleParse(Request.QueryString["DHTExternalTemperature"]) / 10000;
                    double DHTExternalHumidity = GF.DoubleParse(Request.QueryString["DHTExternalHumidity"].Replace(".", ",")) / 10000;
                    double DS18B20TemperatureIntake = GF.DoubleParse(Request.QueryString["DS18B20TemperatureIntake"].Replace(".", ",")) / 10000;
                    double DS18B20TemperatureLeftExhaust = GF.DoubleParse(Request.QueryString["DS18B20TemperatureLeftExhaust"].Replace(".", ",")) / 10000;
                    double DS18B20TemperatureRightExhaust = GF.DoubleParse(Request.QueryString["DS18B20TemperatureRightExhaust"].Replace(".", ",")) / 10000;
                    double CapacitorsRelayPowerLevel = Request.QueryString["CapacitorsPowerLevel"] == null ? 0 : GF.DoubleParse(Request.QueryString["CapacitorsPowerLevel"].Replace(".", ",")) / 10000;
                    CapacitorsRelayPowerLevel = Request.QueryString["CapacitorsRelayPowerLevel"] == null ? CapacitorsRelayPowerLevel : GF.DoubleParse(Request.QueryString["CapacitorsRelayPowerLevel"].Replace(".", ",")) / 10000;
                    double CapacitorProcessorPowerLevel = Request.QueryString["CapacitorProcessorPowerLevel"] == null ? 0 : GF.DoubleParse(Request.QueryString["CapacitorProcessorPowerLevel"].Replace(".", ",")) / 10000;
                    double AmpsRightPowersupply = GF.DoubleParse(Request.QueryString["AmpsRightPowersupply"].Replace(".", ",")) / 10000;
                    double AmpsLeftPowersupply = GF.DoubleParse(Request.QueryString["AmpsLeftPowersupply"].Replace(".", ",")) / 10000;
                    double AmpsAux = GF.DoubleParse(Request.QueryString["AmpsAux"].Replace(".", ",")) / 10000;
                    double UnusedADCValue = GF.DoubleParse(Request.QueryString["UnusedADCValue"].Replace(".", ",")) / 10000;
                    long BitMaskForHost = GF.Int64Parse(Request.QueryString["BitMaskForHost"]);
                    string ConnectedToWifi = Request.QueryString["ConnectedToWifi"];
                    int ConnectionStrength = GF.IntParse(Request.QueryString["ConnectionStrength"]);
                    int SystemRecoveryState = Request.QueryString["SystemRecoveryState"] == null ? 0 : GF.IntParse(Request.QueryString["SystemRecoveryState"]);
                    long MillisToKeepPowerOff = Request.QueryString["MillisToKeepPowerOff"] == null ? 60000 : GF.Int64Parse(Request.QueryString["MillisToKeepPowerOff"]);
                    double MaxAmpsRightPowersupply = Request.QueryString["MaxAmpsRightPowersupply"] == null ? 0 : GF.DoubleParse(Request.QueryString["MaxAmpsRightPowersupply"].Replace(".", ",")) / 10000;
                    double MaxAmpsLeftPowersupply = Request.QueryString["MaxAmpsLeftPowersupply"] == null ? 0 : GF.DoubleParse(Request.QueryString["MaxAmpsLeftPowersupply"].Replace(".", ",")) / 10000;
                    double MaxAmpsAux = Request.QueryString["MaxAmpsAux"] == null ? 0 : GF.DoubleParse(Request.QueryString["MaxAmpsAux"].Replace(".", ",")) / 10000;
                    double MaxUnusedADCValue = Request.QueryString["MaxUnusedADCValue"] == null ? 0 : GF.DoubleParse(Request.QueryString["MaxUnusedADCValue"].Replace(".", ",")) / 10000;

                    long ID = GF.Int64Parse(GFS.SQL_SendWithObjectResponse(conn, "MiningProcessorsStateUpdate", new List<SqlParameter> {
                        new SqlParameter(){ParameterName = "@ID", SqlDbType = System.Data.SqlDbType.BigInt, Value = SerialNumber },
                        new SqlParameter(){ParameterName = "@ModuleModel", SqlDbType = System.Data.SqlDbType.VarChar, Size = 20, Value = ModuleModel },
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
                        new SqlParameter(){ParameterName = "@BitMaskForHost", SqlDbType = System.Data.SqlDbType.BigInt, Value = BitMaskForHost },
                        new SqlParameter(){ParameterName = "@ConnectedToWifi", SqlDbType = System.Data.SqlDbType.VarChar, Size = 255, Value = ConnectedToWifi },
                        new SqlParameter(){ParameterName = "@ConnectionStrength", SqlDbType = System.Data.SqlDbType.Int, Value = ConnectionStrength },
                        new SqlParameter(){ParameterName = "@SystemRecoveryState", SqlDbType = System.Data.SqlDbType.Int, Value = SystemRecoveryState },
                        new SqlParameter(){ParameterName = "@MillisToKeepPowerOff", SqlDbType = System.Data.SqlDbType.BigInt, Value = MillisToKeepPowerOff },
                        new SqlParameter(){ParameterName = "@MaxAmpsRightPowersupply", SqlDbType = System.Data.SqlDbType.Float, Value = MaxAmpsRightPowersupply },
                        new SqlParameter(){ParameterName = "@MaxAmpsLeftPowersupply", SqlDbType = System.Data.SqlDbType.Float, Value = MaxAmpsLeftPowersupply },
                        new SqlParameter(){ParameterName = "@MaxAmpsAux", SqlDbType = System.Data.SqlDbType.Float, Value = MaxAmpsAux },
                        new SqlParameter(){ParameterName = "@MaxUnusedADCValue", SqlDbType = System.Data.SqlDbType.Float, Value = MaxUnusedADCValue }}));

                    Response = ID.ToString();
                }
            }
            catch (Exception eee)
            {
                GFS.LogError(eee, GeneralFunctions.EventLogEntryType.Error, 2111291757);
                string WholeRequest = "";
                foreach(string Key in Request.QueryString.AllKeys)
                {
                    WholeRequest += $"{Key}={Request.QueryString[Key]}, ";
                }
                GFS.LogError($"Serialnumber with error: {SerialNumber}, {WholeRequest}", GeneralFunctions.EventLogEntryType.Error, 2111291756);
            }
            Page.Response.Write(Response);
        }
    }
}