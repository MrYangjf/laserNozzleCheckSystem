using LaserIntelliWeldingSystem.Communication;
using Sunny.UI;
using System.Drawing;
using System;
using System.Reflection;
using VM.PlatformSDKCS;


namespace LaserIntelliWeldingSystem.UI
{
    public partial class MainPage : UIPage
    {
        public delegate void LogAppendDelegate(Color messageColor, string text);
        bool IsStartHelper;
        public MainPage()
        {
            InitializeComponent();
            LoadComponent();
        }
        ~MainPage()
        {
            GlobalCommData.EventInfoHandler -= CommenData_EventInfoHandler;
        }

        void LoadComponent()
        {
            GlobalCommData.EventInfoHandler += CommenData_EventInfoHandler;
            uiSwitch1.Active = false;
        }


        private void CommenData_EventInfoHandler(object sender, MessageArgs e)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            rtb_Log.Invoke(la, e.MessageShowColor, e.strMessage);
        }
        public void LogAppend(Color color, string strMsg)
        {
            try
            {
                if (rtb_Log.TextLength > 3000)
                {
                    rtb_Log.Clear();
                }
                rtb_Log.SelectionColor = color;
                rtb_Log.AppendText(string.Format("{0}-{1}\n", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff"), strMsg));
            }
            catch
            { }
        }

        private void rtb_Log_TextChanged(object sender, EventArgs e)
        {
            rtb_Log.SelectionStart = rtb_Log.Text.Length;
            rtb_Log.ScrollToCaret();
        }

        public void RefreshData(int Total, int Pass)
        {
            LblTotal.Text = Total.ToString();
            LblPass.Text = Pass.ToString();
            try
            {
                if (Total != 0)
                    LblRate.Text = (GlobalCommData.mRunCount.Rate()).ToString("0") + " %";
                else
                    LblRate.Text = "0 %";
            }
            catch
            {
                LblRate.Text = "Null %";
            }
        }

        public void SetStartTime(DateTime dateTime)
        {
            LblStartTime.Text = dateTime.ToString("yyyy/MM/dd HH:mm:ss");
        }

        public void StatusChange(MachineStatus status)
        {
            string strStatus;
            if (GlobalCommData.IsAuto)
            {
                strStatus = "Auto: Flow—" + status.ToString();
                LblStatus.BackColor = Color.LimeGreen;
            }
            else
            {
                strStatus = "Manual: Stop Flow";
                LblStatus.BackColor = Color.Red;
            }
            LblStatus.Text = strStatus;


        }

        private void MainPage_AfterShown(object sender, EventArgs e)
        {
            uiMillisecondTimer1.Enabled = true;
        }

        public void LoadCameraViewer()
        {
            GlobalCommData.VisionMasterFunc.ShowworkProcedure(vmRenderControl1, 0);
            GlobalCommData.VisionMasterFunc.ShowworkProcedure(vmRenderControl2, 1);
            GlobalCommData.VisionMasterFunc.ShowworkProcedure(vmRenderControl3, 2);
        }

        private void btnCheckCenter_Click(object sender, EventArgs e)
        {
            //GlobalCommData.VisionMasterFunc.RunProcedureIndex(0);
            if (IsStartHelper) { UIMessageTip.Show("Camera is alive,Please Stop!"); return; }

            UISymbolButton mbutton = (UISymbolButton)sender;
            UIMessageTip.Show(mbutton.Text);

            if (GlobalCommData.IsHanderTest) return;
            GlobalCommData.IsHanderTest = true;
            GlobalCommData.TCPIPComm.mS7Plc.PLCStatus.IsRunning = true;
            GlobalCommData.TCPIPComm.mS7Plc.PLCStatus.IsCheckCenter = true;
        }

        private void uiSwitch1_ValueChanged(object sender, bool value)
        {
            uiQuickPanel.Enabled = value;
            if (value) uiTurnSwitch1.BackColor = Color.BlueViolet;
            else uiTurnSwitch1.BackColor = Color.Gray;
        }

        private void uiTurnSwitch1_Click(object sender, EventArgs e)
        {
            if (uiTurnSwitch1.Active)
            {
                if (UIMessageBox.ShowAsk("Is Turn Auto"))
                { uiTurnSwitch1.Active = true; GlobalCommData.IsAuto = true; uiSwitch1.Active = false; }
            }
            else
            {
                if (UIMessageBox.ShowAsk("Is Turn Manual")) { uiTurnSwitch1.Active = false; GlobalCommData.IsAuto = false; }
            }
        }

        public void IsAuto(bool auto)
        {
            uiTurnSwitch1.Active = auto;
            uiTableLayoutPanel2.Enabled = !auto;
        }

        private void uiMillisecondTimer1_Tick(object sender, EventArgs e)
        {
            ShowAutoSwitch();

            ShowCenterCheck();

            ShowCenterStains();
        }

        void ShowAutoSwitch()
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action(ShowAutoSwitch));
            }
            else
            {
                IsAuto(GlobalCommData.IsAuto);
                RefreshData(GlobalCommData.mRunCount.TotalCount, GlobalCommData.mRunCount.TotalPass);
            }
        }

        private void uiPlcDisconnect_Click(object sender, EventArgs e)
        {
            UISymbolButton mbutton = (UISymbolButton)sender;
            UIMessageTip.Show(mbutton.Text);
            GlobalCommData.TCPIPComm.StopSiemensS7Plc();
        }

        private void uiPLCconnect_Click(object sender, EventArgs e)
        {
            UISymbolButton mbutton = (UISymbolButton)sender;
            UIMessageTip.Show(mbutton.Text);
            GlobalCommData.TCPIPComm.StartSiemensS7Plc();
        }

        private void btnCheckStains_Click(object sender, EventArgs e)
        {
            //GlobalCommData.VisionMasterFunc.RunProcedureIndex(0);
            if (IsStartHelper) { UIMessageTip.Show("Camera is alive,Please Stop!"); return; }

            UISymbolButton mbutton = (UISymbolButton)sender;
            UIMessageTip.Show(mbutton.Text);
            if (GlobalCommData.IsHanderTest) return;
            GlobalCommData.IsHanderTest = true;
            GlobalCommData.TCPIPComm.mS7Plc.PLCStatus.IsRunning = true;
            GlobalCommData.TCPIPComm.mS7Plc.PLCStatus.IsCheckStains = true;
        }

        private void uiClearStatus_Click(object sender, EventArgs e)
        {
            if (IsStartHelper) { UIMessageTip.Show("Camera is alive,Please Stop!"); return; }

            UISymbolButton mbutton = (UISymbolButton)sender;
            UIMessageTip.Show(mbutton.Text);
            GlobalCommData.IsHanderTest = false;
            GlobalCommData.VisionMasterFunc.ClearStatus();
            GlobalCommData.TCPIPComm.mS7Plc.PLCStatus.ClearStatus();
            GlobalCommData.TCPIPComm.mS7Plc.PLCResult.ClearStatus();
            GlobalCommData.mRunCount.ClearMachineStatus();

        }

        public void ShowCenterCheck()
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action(ShowCenterCheck));
            }
            else
            {
                try
                {
                    if (GlobalCommData.VisionMasterFunc.VmProcedureRunFinished[0])
                    {
                        if (GlobalCommData.mRunCenterResult.bPass)
                        {
                            uiTitlePanelCenter.Text = "CenterCheck:OK";
                            uiTitlePanelCenter.TitleColor = Color.Green;
                        }
                        else
                        {
                            uiTitlePanelCenter.Text = "CenterCheck:NG";
                            uiTitlePanelCenter.TitleColor = Color.Red;
                        }
                    }
                    else
                    {
                        uiTitlePanelCenter.Text = "CenterCheck Camera Viewer";
                        uiTitlePanelCenter.TitleColor = Color.Black;
                    }
                }
                catch
                {

                }
            }
        }

        public void ShowCenterStains()
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action(ShowCenterStains));
            }
            else
            {
                try
                {
                    if (GlobalCommData.VisionMasterFunc.VmProcedureRunFinished[1])
                    {
                        if (GlobalCommData.mRunStainsResult.bPass)
                        {
                            uiTitlePanelStains.Text = "StainsCheck:OK";
                            uiTitlePanelStains.TitleColor = Color.Green;
                        }
                        else
                        {
                            uiTitlePanelStains.Text = "StainsCheck:NG";
                            uiTitlePanelStains.TitleColor = Color.Red;
                        }
                    }
                    else
                    {
                        uiTitlePanelStains.Text = "StainsCheck Camera Viewer";
                        uiTitlePanelStains.TitleColor = Color.Black;
                    }
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// 重载多语翻译
        /// </summary>
        public override void Translate()
        {
            //必须保留
            base.Translate();
            //读取翻译代码中的多语资源
            CodeTranslator.Load(this);

            //设置多语资源
            this.uiPLCconnect.Text = CodeTranslator.Current.Plcconnect;
            this.uiPlcDisconnect.Text = CodeTranslator.Current.Plcdisconnect;
            this.btnCheckCenter.Text = CodeTranslator.Current.CheckCenter;
            this.btnCheckStains.Text = CodeTranslator.Current.CheckStain;
            this.uiClearStatus.Text = CodeTranslator.Current.ClearStatus;
            this.uiStartTime.Text = CodeTranslator.Current.StartTime;
            this.uiCount.Text = CodeTranslator.Current.Count;
            this.uiPass.Text = CodeTranslator.Current.Pass;
            this.uiRate.Text = CodeTranslator.Current.Rate;

        }

        private class CodeTranslator : IniCodeTranslator<CodeTranslator>
        {
            public string Plcconnect { get; set; } = "PLC连接";
            public string Plcdisconnect { get; set; } = "PLC断开";
            public string ClearStatus { get; set; } = "清理状态";
            public string CheckCenter { get; set; } = "对中检测";
            public string CheckStain { get; set; } = "脏污检测";
            public string StartTime { get; set; } = "开始时间";
            public string Count { get; set; } = "总数";
            public string Pass { get; set; } = "通过数";
            public string Rate { get; set; } = "通过率";

        }

        private void btnHelper_Click(object sender, EventArgs e)
        {
            UISymbolButton mbutton = (UISymbolButton)sender;
            UIMessageTip.Show(mbutton.Text);
            if (GlobalCommData.IsAuto) return;
            if (!IsStartHelper)
            {
                GlobalCommData.TCPIPComm.OpenCenterCheckLight();
                btnHelper.Symbol = 61517;
                btnHelper.Text = "Stop Helper";
                btnHelper.FillColor = Color.Red;
                IsStartHelper = true;
                GlobalCommData.VisionMasterFunc.RunContinueProcedureIndex(2);
            }
            else
            {
                GlobalCommData.TCPIPComm.CloseLight();
                GlobalCommData.VisionMasterFunc.StopContinueProcedureIndex(2);
                btnHelper.Symbol = 61515;
                btnHelper.Text = "Start Helper";
                btnHelper.FillColor = Color.Black;
                IsStartHelper = false;
            }
        }
    }
}
