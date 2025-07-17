using LaserIntelliWeldingSystem.Communication;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaserIntelliWeldingSystem.UI
{
    public partial class SiemensS7PLC : UIPage
    {
        public delegate void LogAppendDelegate(Color color, string text);
        public SiemensS7PLC()
        {
            InitializeComponent();
            LoadPLCcfg();
        }

        public void LoadPLCcfg()
        {
            ReadPLCIP();
            ReadPLCAddress();
            GlobalCommData.EventTcpInfoHandler += GlobalCommData_EventTcpInfoHandler;
        }
        private void GlobalCommData_EventTcpInfoHandler(object sender, MessageArgs e)
        {
            //throw new NotImplementedException();
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            uiRichTextBox1.Invoke(la, e.MessageShowColor, e.strMessage);
        }
        public void LogAppend(Color color, string strMsg)
        {
            try
            {
                if (uiRichTextBox1.TextLength > 3000)
                {
                    uiRichTextBox1.Clear();
                }
                uiRichTextBox1.SelectionColor = color;
                uiRichTextBox1.AppendText(string.Format("{0}-{1}\n", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff"), strMsg));
            }
            catch
            { }
        }

        void ReadPLCIP()
        {
            uiipTextBox1.Text = GlobalCommData.TCPIPComm.mS7Plc.TargetIP;
            textRack.Text = GlobalCommData.TCPIPComm.mS7Plc.Rack.ToString();
            textSlot.Text = GlobalCommData.TCPIPComm.mS7Plc.Slot.ToString();
        }

        void WritePLCIP()
        {
            GlobalCommData.TCPIPComm.mS7Plc.TargetIP = uiipTextBox1.Text;
            GlobalCommData.TCPIPComm.mS7Plc.Rack = short.Parse(textRack.Text);
            GlobalCommData.TCPIPComm.mS7Plc.Slot = short.Parse(textSlot.Text);
        }

        void SavePLCIP()
        {
            GlobalCommData.IniFile.WriteValue("PLC", "IP", GlobalCommData.TCPIPComm.mS7Plc.TargetIP);
            GlobalCommData.IniFile.WriteValue("PLC", "Rack", GlobalCommData.TCPIPComm.mS7Plc.Rack.ToString());
            GlobalCommData.IniFile.WriteValue("PLC", "Slot", GlobalCommData.TCPIPComm.mS7Plc.Slot.ToString());
        }

        void ReadPLCAddress()
        {
            uiStatusDB.Value = GlobalCommData.S7PlcStDB;
            uiStatusStart.Value = GlobalCommData.S7PlcStStart;
            uiResultDB.Value = GlobalCommData.S7PlcReDB;
            uiResultStart.Value = GlobalCommData.S7PlcReStart;
        }

        void WritePLCAddress()
        {
            GlobalCommData.S7PlcStDB = uiStatusDB.Value;
            GlobalCommData.S7PlcStStart = uiStatusStart.Value;
            GlobalCommData.S7PlcReDB = uiResultDB.Value;
            GlobalCommData.S7PlcReStart = uiResultStart.Value;
        }

        void SavePLCadress()
        {
            GlobalCommData.IniFile.WriteValue("PLC", "StatusDB", GlobalCommData.S7PlcStDB.ToString());
            GlobalCommData.IniFile.WriteValue("PLC", "StatusStart", GlobalCommData.S7PlcStStart.ToString());
            GlobalCommData.IniFile.WriteValue("PLC", "ResultDB", GlobalCommData.S7PlcReDB.ToString());
            GlobalCommData.IniFile.WriteValue("PLC", "ResultStart", GlobalCommData.S7PlcReStart.ToString());
        }

        void ShowPlcStatus()
        {
            GlobalCommData.TCPIPComm.mS7Plc.ReadPLCStatusDatas();
            if (GlobalCommData.TCPIPComm.mS7Plc.PLCStatus.IsRunning) uiRunningLed.Color = Color.LimeGreen;
            else uiRunningLed.Color = Color.Red;
            if (GlobalCommData.TCPIPComm.mS7Plc.PLCStatus.IsCheckCenter) uiCenterCheckLed.Color = Color.LimeGreen;
            else uiCenterCheckLed.Color = Color.Red;
            if (GlobalCommData.TCPIPComm.mS7Plc.PLCStatus.IsCheckStains) uiCheckStainsLed.Color = Color.LimeGreen;
            else uiCheckStainsLed.Color = Color.Red;
        }

        void ShowPlcResult()
        {
            GlobalCommData.TCPIPComm.mS7Plc.ReadPLCResultDatas();
            if (GlobalCommData.TCPIPComm.mS7Plc.PLCResult.CheckCenterResult) uiCenterResultLed.Color = Color.LimeGreen;
            else uiCenterResultLed.Color = Color.Red;
            if (GlobalCommData.TCPIPComm.mS7Plc.PLCResult.CheckStainsResult) uiStainsResultLed.Color = Color.LimeGreen;
            else uiStainsResultLed.Color = Color.Red;
            if (GlobalCommData.TCPIPComm.mS7Plc.PLCResult.IsRunError) uiCameraLed.Color = Color.LimeGreen;
            else uiCameraLed.Color = Color.Red;
            if (GlobalCommData.TCPIPComm.mS7Plc.PLCResult.IsFinished) uiFinised.Color = Color.LimeGreen;
            else uiFinised.Color = Color.Red;
        }

        private void uiReadIP_Click(object sender, EventArgs e)
        {
            ReadPLCIP();
            UIMessageTip.ShowOk("Read");
        }

        private void uiWriteIP_Click(object sender, EventArgs e)
        {
            WritePLCIP();
            UIMessageTip.ShowOk("Write");
        }

        private void uiBtnSave_Click(object sender, EventArgs e)
        {
            SavePLCIP();
            SavePLCadress();
        }

        private void uiReadPLCAddress_Click(object sender, EventArgs e)
        {
            ReadPLCAddress();
            UIMessageTip.Show("Read");
        }

        private void uiWritePLCAddress_Click(object sender, EventArgs e)
        {
            WritePLCAddress();
            UIMessageTip.Show("Write");
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            uitextValue.Value = GlobalCommData.TCPIPComm.mS7Plc.ReadPLCBoolValue(uitextDB.Value, uitextStart.Value) ? 1 : 0;
            UIMessageTip.Show("Read");
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            bool vb = uitextValue.Value == 1 ? true : false;
            GlobalCommData.TCPIPComm.mS7Plc.WritePLCBoolValue(uitextDB.Value, uitextStart.Value, vb);
            UIMessageTip.Show("Write");
        }

        private void uiCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            uiipTextBox1.Enabled=uiCheckBox1.Checked;
            textRack.Enabled=uiCheckBox1.Checked;
            textSlot.Enabled=uiCheckBox1.Checked;
        }

        private void uiBtn_Connect_Click(object sender, EventArgs e)
        {
            GlobalCommData.TCPIPComm.StartSiemensS7Plc();
        }

        private void uiBtn_StopConnect_Click(object sender, EventArgs e)
        {
            GlobalCommData.TCPIPComm.StopSiemensS7Plc();
        }

        private void btnReadStatus_Click(object sender, EventArgs e)
        {
            UIMessageTip.Show("ReadPLCStatus");
            ShowPlcStatus();
        }

        private void btnReadResult_Click(object sender, EventArgs e)
        {
            UIMessageTip.Show("ReadPLCResult");
            ShowPlcResult();    
        }

    }
}
