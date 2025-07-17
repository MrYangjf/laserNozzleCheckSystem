using LaserIntelliWeldingSystem.Communication;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using VM.Core;
using VMControls.Winform.Release;

namespace LaserIntelliWeldingSystem.UI
{
    public partial class CameraSettingPage : UIPage
    {
        bool IsAuthLevel = false;
        TabPage mVisionPage;

        public CameraSettingPage()
        {
            InitializeComponent();
            LockPageRight();
        }

        void inilzVMSolutionViwer()
        {
            try
            {
                VmMainViewConfigControl mainViewConfigControl = new VmMainViewConfigControl();
                mainViewConfigControl.Dock = DockStyle.Fill;
                mainViewConfigControl.Parent = uiPanel2;
            }
            catch
            {

            }
        }

        public void LoadCfg()
        {
            LoadLightCfg();
            ShowLimitValue();
            ShowStainsLimitValue();
            //LockPageRight();
        }

         void LoadLightCfg()
        {
            uiComboBox1.Text = GlobalCommData.TCPIPComm.mLight.PortName;
            switch (GlobalCommData.TCPIPComm.mLight.LightCH)
            {
                case "A":
                    uiIntegerUpDown2.Value = 1;
                    break;
                case "B":
                    uiIntegerUpDown2.Value = 2;
                    break;
                case "C":
                    uiIntegerUpDown2.Value = 3;
                    break;
                case "D":
                    uiIntegerUpDown2.Value = 4;
                    break;
            }

        }

        void LockPageRight()
        {
            inilzVMSolutionViwer();
            mVisionPage = uiTabControl1.TabPages[2];
            uiTabControl1.TabPages.Remove(mVisionPage);
        }

         void ShowLimitValue()
        {
            CenterCheckExp.Value = GlobalCommData.mRunCenterResult.CenterCheckExp;
            LaserCheckExp.Value = GlobalCommData.mRunCenterResult.LaserCheckExp;
            CenterLightValue.Value = GlobalCommData.mRunCenterResult.CenterCheckLightValue;
            pixelRate.Value = GlobalCommData.mRunCenterResult.PixelRate;
            NozzleRadmin.Value = GlobalCommData.mRunCenterResult.NozzleRadLimitMin;
            NozzleRadmax.Value = GlobalCommData.mRunCenterResult.NozzleRadLimitMax;
            LaserRadmin.Value = GlobalCommData.mRunCenterResult.LaserRadLimitMin;
            LaserRadmax.Value = GlobalCommData.mRunCenterResult.LaserRadLimitMax;
            Distancemin.Value = GlobalCommData.mRunCenterResult.DistanceLimitMin;
            Distancemax.Value = GlobalCommData.mRunCenterResult.DistanceLimitMax;
        }

         void WriteLimitValue()
        {
            GlobalCommData.mRunCenterResult.CenterCheckExp = CenterCheckExp.Value;
            GlobalCommData.VisionMasterFunc.SetGloVariable("CenterCheckExp", CenterCheckExp.Value.ToString());
            GlobalCommData.mRunCenterResult.LaserCheckExp = LaserCheckExp.Value;
            GlobalCommData.VisionMasterFunc.SetGloVariable("LaserCheckExp", LaserCheckExp.Value.ToString());
            GlobalCommData.mRunCenterResult.CenterCheckLightValue = CenterLightValue.Value;
            GlobalCommData.mRunCenterResult.PixelRate = pixelRate.Value;
            GlobalCommData.VisionMasterFunc.SetGloVariable("PixelRate", pixelRate.Value.ToString());
            GlobalCommData.mRunCenterResult.NozzleRadLimitMin = NozzleRadmin.Value;
            GlobalCommData.mRunCenterResult.NozzleRadLimitMax = NozzleRadmax.Value;
            GlobalCommData.mRunCenterResult.LaserRadLimitMin = LaserRadmin.Value;
            GlobalCommData.mRunCenterResult.LaserRadLimitMax = LaserRadmax.Value;
            GlobalCommData.mRunCenterResult.DistanceLimitMin = Distancemin.Value;
            GlobalCommData.mRunCenterResult.DistanceLimitMax = Distancemax.Value;
        }

         void ShowStainsLimitValue()
        {
            StainsCheckExp.Value = GlobalCommData.mRunStainsResult.StainsCheckExp;
            StainsLightValue.Value = GlobalCommData.mRunStainsResult.StainsCheckLightValue;
            StainsSizeMax.Value = GlobalCommData.mRunStainsResult.StainsLimitMax;
            StainsSizeMin.Value = GlobalCommData.mRunStainsResult.StainsLimitMin;

        }

         void WriteStainsLimitValue()
        {
            GlobalCommData.mRunStainsResult.StainsCheckExp = StainsCheckExp.Value;
            GlobalCommData.VisionMasterFunc.SetGloVariable("StainsCheckExp", StainsCheckExp.Value.ToString());
            GlobalCommData.mRunStainsResult.StainsCheckLightValue = StainsLightValue.Value;
            GlobalCommData.mRunStainsResult.StainsLimitMax = StainsSizeMax.Value;
            GlobalCommData.mRunStainsResult.StainsLimitMin = StainsSizeMin.Value;
            GlobalCommData.VisionMasterFunc.SetGloVariable("StainsLimitMax", StainsSizeMax.Value.ToString());
            GlobalCommData.VisionMasterFunc.SetGloVariable("StainsLimitMin", StainsSizeMin.Value.ToString());
        }

         void SaveLimitValue()
        {
            GlobalCommData.mRunCenterResult.WriteCfg();
            GlobalCommData.mRunStainsResult.WriteCfg();
        }

        private void CameraSettingPage_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            UIButton clickbutton = (UIButton)sender;
            VmParamConfig.ModuleSource = (VmModule)VmSolution.Instance[clickbutton.Text];
        }

        private void btnGlobalCamera_Click(object sender, EventArgs e)
        {
            VmParamConfig.ModuleSource = (VmModule)VmSolution.Instance["Global Camera1"];
        }
        private void btnCenterCheckImage_Click(object sender, EventArgs e)
        {
            VmParamConfig.ModuleSource = (VmModule)VmSolution.Instance["Flow1.Image Source1"];
        }

        private void btnCenterNozzleMatch_Click(object sender, EventArgs e)
        {
            VmParamConfig.ModuleSource = (VmModule)VmSolution.Instance["Flow1.Contour Match1"];
        }

        private void btnSearchNozzle_Click(object sender, EventArgs e)
        {
            VmParamConfig.ModuleSource = (VmModule)VmSolution.Instance["Flow1.Circle Search1"];
        }

        private void BtnLaserSeach_Click(object sender, EventArgs e)
        {
            VmParamConfig.ModuleSource = (VmModule)VmSolution.Instance["Flow1.Blob Analysis1"];
        }

        private void btnStainsImage_Click(object sender, EventArgs e)
        {
            VmParamConfig.ModuleSource = (VmModule)VmSolution.Instance["Flow2.Image Source1"];
        }

        private void BtnSaveSol_Click(object sender, EventArgs e)
        {
            GlobalCommData.VisionMasterFunc.SaveVMSolution();
        }

        private void uiTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            GlobalCommData.TCPIPComm.mLight.SetLightValue(uiTrackBar1.Value);
            uiLabelValue.Text = uiTrackBar1.Value.ToString();
        }

        private void btnSaveLightSetting_Click(object sender, EventArgs e)
        {
            string PortName = uiComboBox1.SelectedItem.ToString();
            string LightCH = "A";
            switch (uiIntegerUpDown2.Value)
            {
                case 1:
                    LightCH = "A";
                    break;
                case 2:
                    LightCH = "B";
                    break;
                case 3:
                    LightCH = "C";
                    break;
                case 4:
                    LightCH = "D";
                    break;
            }

            GlobalCommData.IniFile.WriteValue("LightControl", "PortName", PortName);
            GlobalCommData.IniFile.WriteValue("LightControl", "LightCH", LightCH);
            //GlobalCommData.IniFile.WriteValue("LightControl", "LightValue", uiTrackBar1.Value.ToString("0000"));
        }

        private void uiCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            uiPanel1.Enabled = uiCheckBox1.Checked;
        }

        private void btnConnectLight_Click(object sender, EventArgs e)
        {
            GlobalCommData.TCPIPComm.ConnectLight();
        }

        private void btnDisConnectLight_Click(object sender, EventArgs e)
        {
            GlobalCommData.TCPIPComm.DisConnectLight();
        }

        private void btnReadCenterLimit_Click(object sender, EventArgs e)
        {
            GlobalCommData.mRunCenterResult.ReadCfg();
            ShowLimitValue();
            UIMessageTip.ShowOk("Read");
        }

        private void btnWriteCenterLimit_Click(object sender, EventArgs e)
        {
            WriteLimitValue();
            UIMessageTip.ShowOk("Write");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveLimitValue();
            UIMessageTip.ShowOk("Save Param");
        }

        private void uiMillisecondTimer1_Tick(object sender, EventArgs e)
        {
            HidePage();
        }

        void HidePage()
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action(HidePage));
            }
            else
            {
                if (GlobalCommData.mOperateLevel == OperateLevel.Admin)
                {
                    if (!uiTabControl1.TabPages.Contains(mVisionPage))
                        uiTabControl1.TabPages.Add(mVisionPage);
                }
                else
                {
                    if (uiTabControl1.TabPages.Contains(mVisionPage))
                        uiTabControl1.TabPages.Remove(mVisionPage);
                }
            }
        }

        private void CameraSettingPage_AfterShown(object sender, EventArgs e)
        {
            uiMillisecondTimer1.Enabled = true;
        }

        private void btnReadStainsLimit_Click(object sender, EventArgs e)
        {
            GlobalCommData.mRunStainsResult.ReadCfg();
            ShowStainsLimitValue();
            UIMessageTip.ShowOk("Read");
        }

        private void btnWriteStainsLimit_Click(object sender, EventArgs e)
        {
            WriteStainsLimitValue();
            UIMessageTip.ShowOk("Write");
        }

        private void btnSearchNozzleDL_Click(object sender, EventArgs e)
        {
            VmParamConfig.ModuleSource = (VmModule)VmSolution.Instance["Flow2.Segment"];
        }

        private void btnFindNozzleStains_Click(object sender, EventArgs e)
        {
            VmParamConfig.ModuleSource = (VmModule)VmSolution.Instance["Flow2.Black Stains Analysis"];
        }

        private void btnLaserCheckImage_Click(object sender, EventArgs e)
        {
            VmParamConfig.ModuleSource = (VmModule)VmSolution.Instance["Flow1.Image Source2"];
        }
    }
}
