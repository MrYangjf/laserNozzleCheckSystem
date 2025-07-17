using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LaserIntelliWeldingSystem.Communication;
using Sunny.UI;

namespace LaserIntelliWeldingSystem.Workflow
{
    public class MachineControlWork
    {
        private MachineControlWork()
        {

        }
        private static MachineControlWork instance = new MachineControlWork();
        public static MachineControlWork GetInstance()
        {
            if (instance == null)
            {
                instance = new MachineControlWork();
            }
            return instance;
        }

        string TAG = "MachineControl";
        private bool IsReseting = false;//是否正在复位中
        private bool IsClose = false;//关闭标志位
        private bool IsWorkStart = false;
        public bool IsAlarmStop = false;


        Thread thInspectWork;
        Thread thPLCWork;
        Thread thResetWork;


        public void StartWork()
        {

            if (!IsWorkStart)
            {
                thInspectWork = new Thread(InspectWork);
                thInspectWork.IsBackground = true;
                thInspectWork.Start();
            }
            //if (!IsWorkStart)
            //{
            //    thPLCWork = new Thread(PLCWork);
            //    thPLCWork.IsBackground = true;
            //    thPLCWork.Start();
            //}

        }
        public void CloseWork()
        {
            IsClose = true;
        }
        #region 启动
        /// <summary>
        /// 启动
        /// </summary>
        public void StartMachine()
        {

        }
        #endregion

        #region 停止
        /// <summary>
        /// 停止
        /// </summary>
        public void StopMachine()
        {

        }
        #endregion

        #region 复位
        /// <summary>
        /// 复位
        /// </summary>
        public void ResetMachine()
        {
            thResetWork = new Thread(StationReset);
            thResetWork.IsBackground = true;
            thResetWork.Start();

        }
        /// <summary>
        /// 清除设备状态
        /// </summary>
        /// <returns></returns>
        public bool ClearMachineStatus()
        {

            return true;
        }
        /// <summary>
        /// 各工位复位
        /// </summary>
        /// <returns></returns>
        public void StationReset()
        {
            IsReseting = true;
            GlobalCommData.CurrentStatus = MachineStatus.Reseting;

            if (CheckStationPrcocess.Instance.ResetProcess())
            {
                GlobalCommData.ShowLog(TAG, "Commuication initialize succeed!");
                GlobalCommData.CurrentStatus = MachineStatus.Stop;
            }
            else
            {
                GlobalCommData.ShowLog(TAG, "Commuication initialize Fail!", MessageLevel.Error);
                GlobalCommData.CurrentStatus = MachineStatus.NoInitialize;
            }
        }
        #endregion

        public void LoadCamSol()
        {
            CheckStationPrcocess.Instance.LoadVisionMasterSol();
        }

        #region 报警急停处理
        /// <summary>
        /// 报警清除
        /// </summary>
        public void ClearAlarm()
        {

        }
        /// <summary>
        /// 急停
        /// </summary>
        public void EStopMachine()
        {

        }
        /// <summary>
        /// 取消急停
        /// </summary>
        public void EStopCancel()
        {

        }
        #endregion

        #region 流程

        void InspectWork()
        {
            while (!IsClose)
            {
                if (GlobalCommData.IsAuto)
                {
                    if (!GlobalCommData.TCPIPComm.mS7Plc.IsConnected
                        || !GlobalCommData.VisionMasterFunc.IsSolutionLoad
                        || !GlobalCommData.TCPIPComm.mLight.IsConnceted)
                    {
                        GlobalCommData.CurrentStatus = MachineStatus.NoInitialize; GlobalCommData.IsAuto = false;
                        GlobalCommData.ShowLog(TAG, "Can't Start Auto Run: Light or Camera or PLC is offline", MessageLevel.Error);
                    }
                }
                if (GlobalCommData.CurrentStatus != MachineStatus.Running)
                {
                    CheckStationPrcocess.Instance.ResetWorkTime();
                }
                CheckStationPrcocess.Instance.FlowProcess();
                Thread.Sleep(100);
            }
        }

        void PLCWork()
        {
            while (!IsClose)
            {
                if (GlobalCommData.IsAuto)
                {
                    if (!GlobalCommData.TCPIPComm.mS7Plc.IsConnected)
                    {
                        if (!GlobalCommData.IsHanderTest)
                            GlobalCommData.TCPIPComm.mS7Plc.ReadPLCStatusDatas(GlobalCommData.S7PlcStDB, GlobalCommData.S7PlcStStart);
                    }
                }
                Thread.Sleep(500);
            }
        }
        #endregion
    }
}
