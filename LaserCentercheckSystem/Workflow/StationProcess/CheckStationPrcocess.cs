using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LaserIntelliWeldingSystem.Communication;
using LaserIntelliWeldingSystem.FileIO.XMLFile;
using Sunny.UI;

namespace LaserIntelliWeldingSystem.Workflow
{
    class CheckStationPrcocess : ProcessObj
    {
        private CheckStationPrcocess()
        {
            TAG = "CheckStationPrcocess";
            WorkStartTime = DateTime.Now;
            IsStationEnable = true;
            ResetStep = 0;
            WorkStep = 0;
        }

        public bool Comminitialize = false;
        public bool Caminitialize = false;

        public static CheckStationPrcocess Instance = new CheckStationPrcocess();

        public override void ClearProduct()
        {

        }

        public override void ClearStatus()
        {
            WorkStartTime = DateTime.Now;
            WorkStep = 0;
        }

        public override void FlowProcess()
        {
            if (!GlobalCommData.IsAuto && !GlobalCommData.IsHanderTest) return;
            CheckWorkFlow();
        }

        public override bool ResetProcess()
        {
            if (GlobalCommData.CurrentStatus != MachineStatus.Reseting) return false;
            //连接PLC
            ResetWorkFlow();
            return Comminitialize;
        }

        public override void ResetWorkTime()
        {
            WorkStartTime = DateTime.Now;
        }

        public override void LoadXmler(XdocumentReaderWriter reader)
        {

        }

        public override void SaveXmler(XdocumentReaderWriter reader)
        {

        }

        void CheckWorkFlow()
        {
            switch (WorkStep)
            {
                case 0:
                    //读取PLC状态
                    //if (!GlobalCommData.IsHanderTest)
                    //    GlobalCommData.TCPIPComm.mS7Plc.ReadPLCStatusDatas(GlobalCommData.S7PlcStDB, GlobalCommData.S7PlcStStart);
                    WorkStep = 1;
                    WorkStartTime = DateTime.Now;
                    break;
                case 1:
                    //判断PLC的运行信号后需要判断是否满足运行条件
                    if (GlobalCommData.TCPIPComm.mS7Plc.PLCStatus.IsRunning)
                    {
                        if (!GlobalCommData.VisionMasterFunc.IsSolutionLoad)
                        {
                            if (GlobalCommData.IsHanderTest) GlobalCommData.IsHanderTest = false;
                            GlobalCommData.TCPIPComm.mS7Plc.ClearPLCStatus();
                            UIMessageTip.ShowError("Please restart application! Because camera solution load fail");
                            GlobalCommData.ShowLog(TAG, "Please restart application! Because camera solution load fail", MessageLevel.Error);
                            WorkStep = 990;
                        }
                        else
                        {
                            WorkStep = 2;
                            WorkStartTime = DateTime.Now;
                        }
                    }
                    else
                    {
                        WorkStep = 990;
                    }
                    break;
                case 2:
                    //判断运行程序

                    GlobalCommData.CurrentStatus = MachineStatus.Running;
                    GlobalCommData.mRunCount.ClearStatus();
                    if (GlobalCommData.TCPIPComm.mS7Plc.PLCStatus.IsCheckCenter)
                    {
                        GlobalCommData.TCPIPComm.OpenCenterCheckLight();
                        WorkStep = 10;
                        WorkStartTime = DateTime.Now;
                    }
                    else if (GlobalCommData.TCPIPComm.mS7Plc.PLCStatus.IsCheckStains)
                    {
                        GlobalCommData.TCPIPComm.OpenStainsCheckLight();
                        WorkStep = 20;
                        WorkStartTime = DateTime.Now;
                    }
                    else
                        WorkStep = 1;//等待程序给出指令
                    break;
                case 10:
                    //运行CenterCheck
                    //PLC状态清理,防止多次触发
                    GlobalCommData.mRunCount.Type = "CenterCheck";
                    GlobalCommData.TCPIPComm.mS7Plc.PLCStatus.IsRunning = false;
                    GlobalCommData.TCPIPComm.mS7Plc.PLCStatus.IsCheckCenter = false;
                    if (!GlobalCommData.IsHanderTest)
                        GlobalCommData.TCPIPComm.mS7Plc.WritePLCStatusDatas(GlobalCommData.S7PlcStDB, GlobalCommData.S7PlcStStart);
                    else
                        GlobalCommData.TCPIPComm.mS7Plc.ClearPLCStatus();
                    GlobalCommData.VisionMasterFunc.RunProcedureIndex(0);
                    GlobalCommData.TCPIPComm.mS7Plc.ClearPLCResult();
                    WorkStep = 11;
                    WorkStartTime = DateTime.Now;
                    break;
                case 11:
                    //等待centercheck完成
                    if (GlobalCommData.VisionMasterFunc.VmProcedureRunFinished[0])
                    { WorkStep = 12; WorkStartTime = DateTime.Now; }
                    break;
                case 12:
                    //Camera状态结果判断
                    if (GlobalCommData.mRunCenterResult.bGetimage)
                    { WorkStep = 13; WorkStartTime = DateTime.Now; GlobalCommData.TCPIPComm.mS7Plc.PLCResult.IsRunError = false; }
                    else
                    { WorkStep = 13; WorkStartTime = DateTime.Now; GlobalCommData.TCPIPComm.mS7Plc.PLCResult.IsRunError = true; GlobalCommData.mRunCount.Checkinfo = "CameraError;"; }//Camera错误
                    break;
                case 13:
                    //分析状态结果判断
                    if (GlobalCommData.mRunCenterResult.bPass)
                    { WorkStep = 30; WorkStartTime = DateTime.Now; GlobalCommData.TCPIPComm.mS7Plc.PLCResult.CheckCenterResult = true; GlobalCommData.mRunCount.Result = "Pass"; GlobalCommData.mRunCount.Checkinfo += string.Format("Distance:{0};", GlobalCommData.mRunCenterResult.Distance.ToString("0.00")); }
                    else
                    { WorkStep = 30; WorkStartTime = DateTime.Now; GlobalCommData.TCPIPComm.mS7Plc.PLCResult.CheckCenterResult = false; GlobalCommData.mRunCount.TotalNG++; GlobalCommData.mRunCount.Result = "Fail";
                        GlobalCommData.mRunCount.Checkinfo += string.Format("Find Nozzle:{0};Find Laser:{1};Distance:{2};", GlobalCommData.mRunCenterResult.bFindNozzle, GlobalCommData.mRunCenterResult.bFindLaser ,GlobalCommData.mRunCenterResult.Distance.ToString("0.00"));
                    }//检测NG
                    break;
                case 20:
                    //运行StainsCheck
                    //PLC状态清理,防止多次触发
                    GlobalCommData.mRunCount.Type = "StainsCheck";
                    GlobalCommData.TCPIPComm.mS7Plc.PLCStatus.IsRunning = false;
                    GlobalCommData.TCPIPComm.mS7Plc.PLCStatus.IsCheckStains = false;
                    if (!GlobalCommData.IsHanderTest)
                        GlobalCommData.TCPIPComm.mS7Plc.WritePLCStatusDatas(GlobalCommData.S7PlcStDB, GlobalCommData.S7PlcStStart);
                    else
                        GlobalCommData.TCPIPComm.mS7Plc.ClearPLCStatus();

                    GlobalCommData.VisionMasterFunc.RunProcedureIndex(1);
                    GlobalCommData.TCPIPComm.mS7Plc.ClearPLCResult();
                    WorkStep = 21;
                    WorkStartTime = DateTime.Now;
                    break;
                case 21:
                    //等待StainsCheck完成
                    if (GlobalCommData.VisionMasterFunc.VmProcedureRunFinished[1])
                    { WorkStep = 22; WorkStartTime = DateTime.Now; }
                    break;
                case 22:
                    //Camera状态结果判断
                    if (GlobalCommData.mRunStainsResult.bGetimage)
                    { WorkStep = 23; WorkStartTime = DateTime.Now; GlobalCommData.TCPIPComm.mS7Plc.PLCResult.IsRunError = false; }
                    else
                    { WorkStep = 23; WorkStartTime = DateTime.Now; GlobalCommData.TCPIPComm.mS7Plc.PLCResult.IsRunError = true; GlobalCommData.mRunCount.Checkinfo = "CameraError;"; }//Camera错误
                    break;
                case 23:
                    //分析状态结果判断
                    if (GlobalCommData.mRunStainsResult.bPass)
                    { WorkStep = 30; WorkStartTime = DateTime.Now; GlobalCommData.TCPIPComm.mS7Plc.PLCResult.CheckStainsResult = true; GlobalCommData.mRunCount.Result = "Pass"; }
                    else
                    { WorkStep = 30; WorkStartTime = DateTime.Now; GlobalCommData.TCPIPComm.mS7Plc.PLCResult.CheckStainsResult = false; GlobalCommData.mRunCount.TotalNG++; GlobalCommData.mRunCount.Result = "Fail";
                        GlobalCommData.mRunCount.Checkinfo += string.Format("Find Nozzle:{0};Find Stains:{1};", GlobalCommData.mRunStainsResult.bDLModule, GlobalCommData.mRunStainsResult.iFindStains.ToString());
                    }//检测NG
                    break;
                case 30:
                    //写入PLC结果
                    GlobalCommData.mRunCount.TotalCount++;
                    GlobalCommData.TCPIPComm.CloseLight();

                    if (GlobalCommData.IsHanderTest)
                    {
                        //单次手动
                        GlobalCommData.mRunCount.Checkinfo += "HandTest;";
                        GlobalCommData.IsHanderTest = false;
                        GlobalCommData.mProductManager.AddProductInfo(GlobalCommData.mRunCount.SN, GlobalCommData.mRunCount.cycleStartTime,
                            GlobalCommData.mRunCount.Type, GlobalCommData.mRunCount.Result, GlobalCommData.mRunCount.Checkinfo);
                    }
                    else
                    {
                        GlobalCommData.TCPIPComm.mS7Plc.WritePLCResultDatas(GlobalCommData.S7PlcReDB, GlobalCommData.S7PlcReStart);
                        //记录数据库中
                        GlobalCommData.mProductManager.AddProductInfo(GlobalCommData.mRunCount.SN, GlobalCommData.mRunCount.cycleStartTime,
                          GlobalCommData.mRunCount.Type, GlobalCommData.mRunCount.Result, GlobalCommData.mRunCount.Checkinfo);
                    }
                    WorkStep = 0;
                    break;

                case 990:
                    GlobalCommData.CurrentStatus = MachineStatus.Stop;
                    WorkStep = 0;
                    break;
            }
        }

        void ResetWorkFlow()
        {
            if (Comminitialize) Comminitialize = false;
            GlobalCommData.TCPIPComm.StartSiemensS7Plc();
            GlobalCommData.TCPIPComm.ConnectLight();
            if (GlobalCommData.TCPIPComm.mS7Plc.IsConnected && GlobalCommData.TCPIPComm.mLight.IsConnceted) Comminitialize = true;
        }

        public void LoadVisionMasterSol()
        {
            Caminitialize = GlobalCommData.VisionMasterFunc.InizVmSolution();
            if (Caminitialize)
            {
                GlobalCommData.VisionMasterFunc.SettingProcedureSource();
                GlobalCommData.VisionMasterFunc.GetALLListProcedureButton();
            }
        }
    }
}
