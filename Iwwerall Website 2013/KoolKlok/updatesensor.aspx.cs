using Convilguous_Shared;
using Convilguous_Shared_OSDependent;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Iwwerall_Website_2013.KoolKlok
{
	public partial class updatesensor : System.Web.UI.Page
    {
        GeneralFunctions GF = new GeneralFunctions();
        GeneralFunctionsAppSpecific GFS = new GeneralFunctionsAppSpecific();
        static SqlConnection conn = new SqlConnection(@"server=database.convilguous.com,14333;database=Symbiosis;User ID=MinerProbe;Pwd=Kwakkerl77*;Asynchronous Processing=true;MultipleActiveResultSets=true; Connect Timeout=30");

        protected void Page_Load(object sender, EventArgs e)
		{
            Page.Response.ContentType = "text/plain";
            long SerialNumber = 0;
            try
            {
                if (Request.QueryString["SerialNumber"] != null)
                {
                    string ModuleModel = Request.QueryString["ModuleModel"];
                    int FirmwareVersionForHost = GF.IntParse(Request.QueryString["FirmwareVersionForHost"]);
                    SerialNumber = GF.Int64Parse(Request.QueryString["SerialNumber"]);
                    long MachineRunning = GF.Int64Parse(Request.QueryString["MachineRunning"]);
                    double TempUPS = GF.DoubleParse(Request.QueryString["TempUPS"]) / 10000;
                    double TempCPU = GF.DoubleParse(Request.QueryString["TempCPU"]) / 10000;
                    int BME680_Pressure = GF.IntParse(Request.QueryString["BME680_Pressure"]);
                    double BME680_Humidity = GF.DoubleParse(Request.QueryString["BME680_Humidity"]) / 10000;
                    int BME680_Gas_Resistance = GF.IntParse(Request.QueryString["BME680_Gas_Resistance"]);
                    double BME680_Altitude = GF.DoubleParse(Request.QueryString["BME680_Altitude"]) / 10000;
                    int SGP40_VOC_Index = GF.IntParse(Request.QueryString["SGP40_VOC_Index"]);
                    int SGP40_VOC_Raw = GF.IntParse(Request.QueryString["SGP40_VOC_Raw"]);
                    double LuxMeasurement = GF.DoubleParse(Request.QueryString["LuxMeasurement"]) / 10000;
                    int FireIRLevel = GF.IntParse(Request.QueryString["FireIRLevel"]);
                    int FanPWM = GF.IntParse(Request.QueryString["FanPWM"]);
                    int FanTachoPulsesPerSecond = GF.IntParse(Request.QueryString["FanTachoPulsesPerSecond"]);
                    double AmpsMainPower = GF.DoubleParse(Request.QueryString["AmpsMainPower"]) / 10000;
                    double AmpsBackupPower = GF.DoubleParse(Request.QueryString["AmpsBackupPower"]) / 10000;
                    double SoundPressure = GF.DoubleParse(Request.QueryString["SoundPressure"]) / 10000;
                    long BitMaskForHost = GF.Int64Parse(Request.QueryString["BitMaskForHost"]);
                    string ConnectedToWifi = Request.QueryString["ConnectedToWifi"];
                    int ConnectionStrength = GF.IntParse(Request.QueryString["ConnectionStrength"]);
                    double SoundBand0 = Request.QueryString["SoundBand0"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand0"].Replace(".", ",")) / 10000;
                    double SoundBand1 = Request.QueryString["SoundBand1"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand1"].Replace(".", ",")) / 10000;
                    double SoundBand2 = Request.QueryString["SoundBand2"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand2"].Replace(".", ",")) / 10000;
                    double SoundBand3 = Request.QueryString["SoundBand3"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand3"].Replace(".", ",")) / 10000;
                    double SoundBand4 = Request.QueryString["SoundBand4"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand4"].Replace(".", ",")) / 10000;
                    double SoundBand5 = Request.QueryString["SoundBand5"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand5"].Replace(".", ",")) / 10000;
                    double SoundBand6 = Request.QueryString["SoundBand6"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand6"].Replace(".", ",")) / 10000;
                    double SoundBand7 = Request.QueryString["SoundBand7"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand7"].Replace(".", ",")) / 10000;
                    double SoundBand8 = Request.QueryString["SoundBand8"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand8"].Replace(".", ",")) / 10000;
                    double SoundBand9 = Request.QueryString["SoundBand9"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand9"].Replace(".", ",")) / 10000;
                    double SoundBand10 = Request.QueryString["SoundBand10"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand10"].Replace(".", ",")) / 10000;
                    double SoundBand11 = Request.QueryString["SoundBand11"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand11"].Replace(".", ",")) / 10000;
                    double SoundBand12 = Request.QueryString["SoundBand12"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand12"].Replace(".", ",")) / 10000;
                    double SoundBand13 = Request.QueryString["SoundBand13"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand13"].Replace(".", ",")) / 10000;
                    double SoundBand14 = Request.QueryString["SoundBand14"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand14"].Replace(".", ",")) / 10000;
                    double SoundBand15 = Request.QueryString["SoundBand15"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand15"].Replace(".", ",")) / 10000;
                    double SoundBand16 = Request.QueryString["SoundBand16"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand16"].Replace(".", ",")) / 10000;
                    double SoundBand17 = Request.QueryString["SoundBand17"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand17"].Replace(".", ",")) / 10000;
                    double SoundBand18 = Request.QueryString["SoundBand18"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand18"].Replace(".", ",")) / 10000;
                    double SoundBand19 = Request.QueryString["SoundBand19"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand19"].Replace(".", ",")) / 10000;
                    double SoundBand20 = Request.QueryString["SoundBand20"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand20"].Replace(".", ",")) / 10000;
                    double SoundBand21 = Request.QueryString["SoundBand21"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand21"].Replace(".", ",")) / 10000;
                    double SoundBand22 = Request.QueryString["SoundBand22"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand22"].Replace(".", ",")) / 10000;
                    double SoundBand23 = Request.QueryString["SoundBand23"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand23"].Replace(".", ",")) / 10000;
                    double SoundBand24 = Request.QueryString["SoundBand24"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand24"].Replace(".", ",")) / 10000;
                    double SoundBand25 = Request.QueryString["SoundBand25"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand25"].Replace(".", ",")) / 10000;
                    double SoundBand26 = Request.QueryString["SoundBand26"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand26"].Replace(".", ",")) / 10000;
                    double SoundBand27 = Request.QueryString["SoundBand27"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand27"].Replace(".", ",")) / 10000;
                    double SoundBand28 = Request.QueryString["SoundBand28"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand28"].Replace(".", ",")) / 10000;
                    double SoundBand29 = Request.QueryString["SoundBand29"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand29"].Replace(".", ",")) / 10000;
                    double SoundBand30 = Request.QueryString["SoundBand30"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand30"].Replace(".", ",")) / 10000;
                    double SoundBand31 = Request.QueryString["SoundBand31"] == null ? 0 : GF.DoubleParse(Request.QueryString["SoundBand31"].Replace(".", ",")) / 10000;


                    GFS.SQL_SendWithoutResponse(conn, "ServerBrickDataAdd", new List<SqlParameter> {
                        new SqlParameter(){ParameterName = "@ModuleID", SqlDbType = System.Data.SqlDbType.BigInt, Value = SerialNumber },
                        new SqlParameter(){ParameterName = "@ModuleModel", SqlDbType = System.Data.SqlDbType.VarChar, Size = 100, Value = ModuleModel },
                        new SqlParameter(){ParameterName = "@FirmwareVersionForHost", SqlDbType = System.Data.SqlDbType.Int, Value = FirmwareVersionForHost },
                        new SqlParameter(){ParameterName = "@MachineRunning", SqlDbType = System.Data.SqlDbType.BigInt, Value = MachineRunning },
                        new SqlParameter(){ParameterName = "@TempUPS", SqlDbType = System.Data.SqlDbType.Float, Value = TempUPS },
                        new SqlParameter(){ParameterName = "@TempCPU", SqlDbType = System.Data.SqlDbType.Float, Value = TempCPU },
                        new SqlParameter(){ParameterName = "@BME680_Pressure", SqlDbType = System.Data.SqlDbType.Int, Value = BME680_Pressure },
                        new SqlParameter(){ParameterName = "@BME680_Humidity", SqlDbType = System.Data.SqlDbType.Float, Value = BME680_Humidity },
                        new SqlParameter(){ParameterName = "@BME680_Gas_Resistance", SqlDbType = System.Data.SqlDbType.Int, Value = BME680_Gas_Resistance },
                        new SqlParameter(){ParameterName = "@BME680_Altitude", SqlDbType = System.Data.SqlDbType.Float, Value = BME680_Altitude },
                        new SqlParameter(){ParameterName = "@SGP40_VOC_Index", SqlDbType = System.Data.SqlDbType.Int, Value = SGP40_VOC_Index },
                        new SqlParameter(){ParameterName = "@SGP40_VOC_Raw", SqlDbType = System.Data.SqlDbType.Int, Value = SGP40_VOC_Raw },
                        new SqlParameter(){ParameterName = "@LuxMeasurement", SqlDbType = System.Data.SqlDbType.Float, Value = LuxMeasurement },
                        new SqlParameter(){ParameterName = "@FireIRLevel", SqlDbType = System.Data.SqlDbType.Int, Value = FireIRLevel },
                        new SqlParameter(){ParameterName = "@FanPWM", SqlDbType = System.Data.SqlDbType.Int, Value = FanPWM },
                        new SqlParameter(){ParameterName = "@FanTachoPulsesPerSecond", SqlDbType = System.Data.SqlDbType.Int, Value = FanTachoPulsesPerSecond },
                        new SqlParameter(){ParameterName = "@AmpsMainPower", SqlDbType = System.Data.SqlDbType.Float, Value = AmpsMainPower },
                        new SqlParameter(){ParameterName = "@AmpsBackupPower", SqlDbType = System.Data.SqlDbType.Float, Value = AmpsBackupPower },
                        new SqlParameter(){ParameterName = "@SoundPressure", SqlDbType = System.Data.SqlDbType.Float, Value = SoundPressure },
                        new SqlParameter(){ParameterName = "@BitMaskForHost", SqlDbType = System.Data.SqlDbType.BigInt, Value = BitMaskForHost },
                        new SqlParameter(){ParameterName = "@ConnectedToWifi", SqlDbType = System.Data.SqlDbType.VarChar, Size = 255, Value = ConnectedToWifi },
                        new SqlParameter(){ParameterName = "@ConnectionStrength", SqlDbType = System.Data.SqlDbType.Int, Value = ConnectionStrength },
                        new SqlParameter(){ParameterName = "@SoundBand0", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand0 },
                        new SqlParameter(){ParameterName = "@SoundBand1", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand1 },
                        new SqlParameter(){ParameterName = "@SoundBand2", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand2 },
                        new SqlParameter(){ParameterName = "@SoundBand3", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand3 },
                        new SqlParameter(){ParameterName = "@SoundBand4", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand4 },
                        new SqlParameter(){ParameterName = "@SoundBand5", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand5 },
                        new SqlParameter(){ParameterName = "@SoundBand6", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand6 },
                        new SqlParameter(){ParameterName = "@SoundBand7", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand7 },
                        new SqlParameter(){ParameterName = "@SoundBand8", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand8 },
                        new SqlParameter(){ParameterName = "@SoundBand9", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand9 },
                        new SqlParameter(){ParameterName = "@SoundBand10", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand10 },
                        new SqlParameter(){ParameterName = "@SoundBand11", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand11 },
                        new SqlParameter(){ParameterName = "@SoundBand12", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand12 },
                        new SqlParameter(){ParameterName = "@SoundBand13", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand13 },
                        new SqlParameter(){ParameterName = "@SoundBand14", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand14 },
                        new SqlParameter(){ParameterName = "@SoundBand15", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand15 },
                        new SqlParameter(){ParameterName = "@SoundBand16", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand16 },
                        new SqlParameter(){ParameterName = "@SoundBand17", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand17 },
                        new SqlParameter(){ParameterName = "@SoundBand18", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand18 },
                        new SqlParameter(){ParameterName = "@SoundBand19", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand19 },
                        new SqlParameter(){ParameterName = "@SoundBand20", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand20 },
                        new SqlParameter(){ParameterName = "@SoundBand21", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand21 },
                        new SqlParameter(){ParameterName = "@SoundBand22", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand22 },
                        new SqlParameter(){ParameterName = "@SoundBand23", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand23 },
                        new SqlParameter(){ParameterName = "@SoundBand24", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand24 },
                        new SqlParameter(){ParameterName = "@SoundBand25", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand25 },
                        new SqlParameter(){ParameterName = "@SoundBand26", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand26 },
                        new SqlParameter(){ParameterName = "@SoundBand27", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand27 },
                        new SqlParameter(){ParameterName = "@SoundBand28", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand28 },
                        new SqlParameter(){ParameterName = "@SoundBand29", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand29 },
                        new SqlParameter(){ParameterName = "@SoundBand30", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand30 },
                        new SqlParameter(){ParameterName = "@SoundBand31", SqlDbType = System.Data.SqlDbType.Float, Value = SoundBand31 }});
                }
            }
            catch (Exception eee)
            {
                GFS.LogError(eee, GeneralFunctions.EventLogEntryType.Error, 2502181806);
                string WholeRequest = "";
                foreach (string Key in Request.QueryString.AllKeys)
                {
                    WholeRequest += $"{Key}={Request.QueryString[Key]}, ";
                }
                GFS.LogError($"Serialnumber with error: {SerialNumber}, {WholeRequest}", GeneralFunctions.EventLogEntryType.Error, 2502181807);
            }
            Page.Response.Write("STORED");
        }
    }
}