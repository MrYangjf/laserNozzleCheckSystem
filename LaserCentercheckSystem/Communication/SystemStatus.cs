using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserIntelliWeldingSystem.Communication
{
    public enum MessageType
    {
        Summary,
        Run,
        Flow,
        Debug
    }
    public enum MessageLevel
    {
        Info,
        Warning,
        Error
    }

    public enum TcpMessageLevel
    {
        Info,
        Tips
    }
    public enum MachineStatus
    {
        Running = 0,//运行中
        Alarm = 1,//报警
        EStop = 2,//急停
        Stop = 3,//停止
        NoInitialize = 4,//未复位
        Reseting = 5 //复位中
    }

    public enum OperateLevel
    {
        Operator = 2,//操作员
        Engineer = 1,//工程师
        Admin = 0,//管理员
    }

    public class RunCount
    {
        public DateTime SystemStartTime { get; set; }

        public DateTime cycleStartTime { get; set; }
        public string Type { get; set; }
        public string Checkinfo { get; set; }
        public string SN { get; set; }
        public string Result { get; set; }

        public void ClearStatus()
        {
            cycleStartTime = DateTime.Now;
            Type = "";
            Checkinfo = "";
            SN = "";
            Result = "";
        }

        public int TotalCount { get; set; }
        public int TotalNG { get; set; }

        public int TotalPass
        { get { return (TotalCount - TotalNG); } }

        public double Rate()
        {
            if (TotalCount != 0)
            {
                double Var = (double)TotalPass / (double)TotalCount;
                Var = Var * 100;
                return Var;
            }
            else
            {
                return 0;
            }
        }

        public void ClearMachineStatus()
        {
            SystemStartTime = DateTime.Now;
            TotalCount = 0;
            TotalNG = 0;
        }
    }

    public class RunCenterResult
    {
        bool IsInitialize = false;

        public void InitializeCfg()
        {
            if (IsInitialize) return;
            try
            {
                CenterCheckExp = int.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "CenterCheckExp"));
                LaserCheckExp = int.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "LaserCheckExp"));

                PixelRate = double.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "PixelRate"));

                LaserRadLimitMin = double.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "LaserRadLimitMin"));
                LaserRadLimitMax = double.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "LaserRadLimitMax"));

                NozzleRadLimitMin = double.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "NozzleRadLimitMin"));
                NozzleRadLimitMax = double.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "NozzleRadLimitMax"));

                DistanceLimitMin = double.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "DistanceLimitMin"));
                DistanceLimitMax = double.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "DistanceLimitMax"));

                CenterCheckLightValue = int.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "CenterCheckLightValue"));

                IsInitialize = true;
            }
            catch
            {
                GlobalCommData.ShowLog("ParamSetting", "Initialize CenterCheck Config Fail!", MessageLevel.Error);
                IsInitialize = false;
            }

        }

        public void ReadCfg()
        {
            try
            {
                CenterCheckExp = int.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "CenterCheckExp"));
                LaserCheckExp = int.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "LaserCheckExp"));
                PixelRate = double.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "PixelRate"));

                LaserRadLimitMin = double.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "LaserRadLimitMin"));
                LaserRadLimitMax = double.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "LaserRadLimitMax"));

                NozzleRadLimitMin = double.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "NozzleRadLimitMin"));
                NozzleRadLimitMax = double.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "NozzleRadLimitMax"));

                DistanceLimitMin = double.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "DistanceLimitMin"));
                DistanceLimitMax = double.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "DistanceLimitMax"));

                CenterCheckLightValue = int.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "CenterCheckLightValue"));
            }
            catch
            {

            }
        }

        public void WriteCfg()
        {
            GlobalCommData.IniFile.WriteValue("VisionSetting", "CenterCheckExp", CenterCheckExp.ToString(""));
            GlobalCommData.IniFile.WriteValue("VisionSetting", "LaserCheckExp", LaserCheckExp.ToString(""));
            GlobalCommData.IniFile.WriteValue("VisionSetting", "PixelRate", PixelRate.ToString("0.000"));

            GlobalCommData.IniFile.WriteValue("VisionSetting", "LaserRadLimitMin", LaserRadLimitMin.ToString("0.00"));
            GlobalCommData.IniFile.WriteValue("VisionSetting", "LaserRadLimitMax", LaserRadLimitMax.ToString("0.00"));

            GlobalCommData.IniFile.WriteValue("VisionSetting", "NozzleRadLimitMin", NozzleRadLimitMin.ToString("0.00"));
            GlobalCommData.IniFile.WriteValue("VisionSetting", "NozzleRadLimitMax", NozzleRadLimitMax.ToString("0.00"));

            GlobalCommData.IniFile.WriteValue("VisionSetting", "DistanceLimitMin", DistanceLimitMin.ToString("0.00"));
            GlobalCommData.IniFile.WriteValue("VisionSetting", "DistanceLimitMax", DistanceLimitMax.ToString("0.00"));

            GlobalCommData.IniFile.WriteValue("VisionSetting", "CenterCheckLightValue", CenterCheckLightValue.ToString());
        }

        public int CenterCheckExp { get; set; }

        public int LaserCheckExp { get; set; }

        public double PixelRate { get; set; }

        public int CenterCheckLightValue { get; set; }

        public double LaserRadLimitMin { get; set; }

        public double LaserRadLimitMax { get; set; }

        public double LaserRad { get; set; }


        public double NozzleRadLimitMin { get; set; }

        public double NozzleRadLimitMax { get; set; }

        public double NozzleRad { get; set; }


        public double DistanceLimitMin { get; set; }

        public double DistanceLimitMax { get; set; }

        public double Distance { get; set; }

        public int iGetimageFail { get; set; }
        public bool bGetimage { get; set; }

        public bool bMatchNozzle { get; set; }

        public bool bFindNozzle { get; set; }

        public bool bFindLaser { get; set; }

        public bool bNozzleRad { get; set; }

        public bool bLaserRad { get; set; }

        public bool bPass { get; set; }

        public void IniResult()
        {
            bGetimage = false;
            bFindNozzle = false;
            bMatchNozzle = false;
            bPass = false;
            bFindLaser = false;
            bNozzleRad = false;
            bLaserRad = false;
            bPass = false;

            LaserRad = 0;
            NozzleRad = 0;
            Distance = 0;
        }

        public void GetDistance(string strNozzleRad, string strLaserRad, string strDistance)
        {
            try
            {
                Distance = double.Parse(strDistance);
                NozzleRad = double.Parse(strNozzleRad);
                LaserRad = double.Parse(strLaserRad);
                if (NozzleRad >= NozzleRadLimitMin && NozzleRad < NozzleRadLimitMax) bNozzleRad = true;
                if (LaserRad >= LaserRadLimitMin && LaserRad < LaserRadLimitMax) bLaserRad = true;
                if ((Distance >= DistanceLimitMin && Distance < DistanceLimitMax) && bNozzleRad && bLaserRad) bPass = true;
            }
            catch
            {
                bNozzleRad = false;
                bLaserRad = false;
                bPass = false;
                Distance = 0;
                NozzleRad = 0;
                LaserRad = 0;
            }
        }
    }

    public class RunStainsResult
    {
        bool IsInitialize = false;

        public void InitializeCfg()
        {
            if (IsInitialize) return;
            try
            {
                StainsCheckExp = int.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "StainsCheckExp"));

                StainsLimitMin = int.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "StainsLimitMin"));
                StainsLimitMax = int.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "StainsLimitMax"));

                StainsCheckLightValue = int.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "StainsCheckLightValue"));

                IsInitialize = true;
            }
            catch
            {
                GlobalCommData.ShowLog("ParamSetting", "Initialize StainsCheck Config Fail!", MessageLevel.Error);
                IsInitialize = false;
            }

        }

        public void ReadCfg()
        {
            try
            {
                StainsCheckExp = int.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "StainsCheckExp"));

                StainsLimitMin = int.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "StainsLimitMin"));
                StainsLimitMax = int.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "StainsLimitMax"));

                StainsCheckLightValue = int.Parse(GlobalCommData.IniFile.ReadValue("VisionSetting", "StainsCheckLightValue"));
            }
            catch
            {

            }
        }

        public void WriteCfg()
        {
            GlobalCommData.IniFile.WriteValue("VisionSetting", "StainsCheckExp", StainsCheckExp.ToString(""));

            GlobalCommData.IniFile.WriteValue("VisionSetting", "StainsLimitMin", StainsLimitMin.ToString(""));
            GlobalCommData.IniFile.WriteValue("VisionSetting", "StainsLimitMax", StainsLimitMax.ToString(""));

            GlobalCommData.IniFile.WriteValue("VisionSetting", "StainsCheckLightValue", StainsCheckLightValue.ToString());
        }

        public int StainsCheckExp { get; set; }

        public int StainsCheckLightValue { get; set; }

        public int StainsLimitMin { get; set; }

        public int StainsLimitMax { get; set; }

        public double StainsSize { get; set; }

        public int iGetimageFail { get; set; }

        public int iFindStains { get; set; }

        public bool bGetimage { get; set; }

        public bool bDLModule { get; set; }

        public bool bPass { get; set; }

        public void IniResult()
        {
            bGetimage = false;
            bDLModule = false;
            bPass = false;
            iFindStains = 0;

            StainsSize = 0;
        }

    }

}
