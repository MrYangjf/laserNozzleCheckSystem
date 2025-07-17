using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using STTech.BytesIO.Tcp;
using Sunny.UI;
using S7.Net;
using System.IO;
using System.IO.Ports;


namespace LaserIntelliWeldingSystem.Communication.TCPIP
{

    class TCPIPComm
    {

        public SSTTCPServer XMLServer = new SSTTCPServer();
        public SSTTCPClient XMLClient = new SSTTCPClient();
        public SiemensS7 mS7Plc = new SiemensS7();
        public LightControl mLight = new LightControl();

        public TCPIPComm()
        {
            LoadConfig();
        }

        public void LoadConfig()
        {
            XMLServer.ServerIP = GlobalCommData.ServerXdoc.GetIP();
            XMLServer.ServerPort = GlobalCommData.ServerXdoc.GetPort();
            XMLClient.TargetIP = GlobalCommData.ClientXdoc.GetIP();
            XMLClient.TargetPort = GlobalCommData.ClientXdoc.GetPort();

            try
            {
                mS7Plc.TargetIP = GlobalCommData.IniFile.ReadValue("PLC", "IP");
                mS7Plc.Rack = short.Parse(GlobalCommData.IniFile.ReadValue("PLC", "Rack"));
                mS7Plc.Slot = short.Parse(GlobalCommData.IniFile.ReadValue("PLC", "Slot"));

            }
            catch
            {
                mS7Plc.TargetIP = "127.0.0.1";
                mS7Plc.Rack = 1;
                mS7Plc.Slot = 0;
            }
            int.TryParse(GlobalCommData.IniFile.ReadValue("PLC", "StatusDB"), out GlobalCommData.S7PlcStDB);
            int.TryParse(GlobalCommData.IniFile.ReadValue("PLC", "StatusStart"), out GlobalCommData.S7PlcStStart);
            int.TryParse(GlobalCommData.IniFile.ReadValue("PLC", "ResultDB"), out GlobalCommData.S7PlcReDB);
            int.TryParse(GlobalCommData.IniFile.ReadValue("PLC", "ResultStart"), out GlobalCommData.S7PlcReStart);

            mLight.PortName = GlobalCommData.IniFile.ReadValue("LightControl", "PortName");
            mLight.LightCH = GlobalCommData.IniFile.ReadValue("LightControl", "LightCH");
            mLight.Ch1Value = int.Parse(GlobalCommData.IniFile.ReadValue("PLC", "ResultStart"));
        }

        public void StartServerCommmTask()
        {
            XMLServer.StartListening();
        }

        public void StopServerCommmTask()
        {
            XMLServer.StopListening();
        }

        public void StartClientCommmTask()
        {
            XMLClient.StartConnect();
        }
        public void StopClientCommmTask()
        {
            XMLClient.DisConnect();
        }

        public void StopSiemensS7Plc()
        {
            mS7Plc.StopConnect();
        }

        public void StartSiemensS7Plc()
        {
            mS7Plc.StartConnect();
        }


        public void ConnectLight()
        {
            mLight.Connect();
        }

        public void DisConnectLight()
        {
            mLight.Disconnect();
        }

        public void OpenCenterCheckLight()
        {
            mLight.SetLightValue(GlobalCommData.mRunCenterResult.CenterCheckLightValue);
        }

        public void OpenStainsCheckLight()
        {
            mLight.SetLightValue(GlobalCommData.mRunStainsResult.StainsCheckLightValue);
        }

        public void CloseLight()
        {
            mLight.SetLightValue(0);
        }
    }

    public class SSTTCPServer
    {

        string TAG = "TCPServer";

        string _serverIP = "127.0.0.1";
        public string ServerIP
        {
            get { return _serverIP; }
            set { _serverIP = value; }
        }

        int _serverPort = 6000;
        public int ServerPort
        {
            get { return _serverPort; }
            set { _serverPort = value; }
        }

        uint _clientLimited = 5;

        public uint ClientLimited
        {
            get { return _clientLimited; }
            set { _clientLimited = value; }
        }

        public TcpServer ServerSocket;

        public List<string> MessageList = new List<string>();

        public SSTTCPServer()
        {
            ServerSocket = new TcpServer();
        }

        ~SSTTCPServer()
        {
            if (ServerSocket != null)
                ServerSocket.StopAsync();
            ServerSocket.Dispose();
        }

        public void StartListening()
        {

            ServerSocket.Host = _serverIP;
            ServerSocket.Port = _serverPort;
            ServerSocket.MaxConnections = _clientLimited;
            ServerSocket.StartAsync();

            ServerSocket.Started += ServerSocket_Started;
            ServerSocket.Closed += ServerSocket_Closed;

        }

        private void ServerSocket_ClientDisconnected(object sender, ClientDisconnectedEventArgs e)
        {
            //throw new NotImplementedException();
            GlobalCommData.ShowTcpMessage(TAG, "有客户端已断开！");
        }

        private void ServerSocket_Closed(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            GlobalCommData.ShowTcpMessage(TAG, "服务器停止监听！");
            ServerSocket.ClientConnected -= ServerSocket_ClientConnected;
            ServerSocket.ClientDisconnected -= ServerSocket_ClientDisconnected;
        }

        private void ServerSocket_Started(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            GlobalCommData.ShowTcpMessage(TAG, "服务器开启监听！");
            ServerSocket.ClientConnected += ServerSocket_ClientConnected;
            ServerSocket.ClientDisconnected += ServerSocket_ClientDisconnected;
        }

        private void ServerSocket_ClientConnected(object sender, ClientConnectedEventArgs e)
        {
            //throw new NotImplementedException();
            e.Client.OnDataReceived += Client_OnDataReceived;
            GlobalCommData.ShowTcpMessage(TAG, "有客户端连接！");
        }

        private void Client_OnDataReceived(object sender, STTech.BytesIO.Core.DataReceivedEventArgs e)
        {
            //throw new NotImplementedException();

            TcpClient tcpClient = (TcpClient)sender;
            string Message = e.Data.EncodeToString("GBK");
            string ClientShow = string.Format("服务器接受来自{0}的信息:", tcpClient.RemoteEndPoint.ToString());
            MessageList.Add(Message);

            //Message变为实时信息显示
            GlobalCommData.ShowTcpMessage(TAG, ClientShow + Message);
        }

        public void StopListening()
        {
            ServerSocket.StopAsync();
        }
    }

    public class SSTTCPClient
    {
        //格式 V,C,S,0,0,# 
        string SendStr, ReviceStr;

        string Where, Times;

        string TAG = "TCPClient";

        string _targetIP = "127.0.0.1";
        public string TargetIP
        {
            get { return _targetIP; }
            set { _targetIP = value; }
        }

        int _targetPort = 6000;
        public int TargetPort
        {
            get { return _targetPort; }
            set { _targetPort = value; }
        }

        public TcpClient TcpClient;

        public int TryTimes = 0;

        public bool IsConnected = false;
        public bool IsRunning = false;
        public int RunIndex = -1;

        public SSTTCPClient()
        {
            TcpClient = new TcpClient();
            TcpClient.OnDataReceived += TcpClient_OnDataReceived;
            TcpClient.OnConnectionFailed += TcpClient_OnConnectionFailed;
            TcpClient.OnConnectedSuccessfully += TcpClient_OnConnectedSuccessfully;
            TcpClient.OnDisconnected += TcpClient_OnDisconnected;
        }

        public void StartConnect()
        {
            TcpClient.Host = _targetIP;
            TcpClient.Port = _targetPort;


            GlobalCommData.ShowTcpClientMessage(TAG, "Try to connect Server！Try Times:" + TryTimes.ToString());

            TcpClient.Connect();

        }

        private void TcpClient_OnConnectedSuccessfully(object sender, STTech.BytesIO.Core.ConnectedSuccessfullyEventArgs e)
        {
            //throw new NotImplementedException();
            IsConnected = true;
            GlobalCommData.ShowTcpClientMessage(TAG, "Connect Succeed！" + e.ToString());
        }

        private void TcpClient_OnDataReceived(object sender, STTech.BytesIO.Core.DataReceivedEventArgs e)
        {
            //throw new NotImplementedException();
            string Re = e.Data.EncodeToString();
            GlobalCommData.ShowTcpClientMessage(TAG, Re);
            if (!ReadReceive(Re)) SendResult(0);
            else IsRunning = true;
        }

        private void TcpClient_OnConnectionFailed(object sender, STTech.BytesIO.Core.ConnectionFailedEventArgs e)
        {
            //throw new NotImplementedException();
            IsConnected = false;
            GlobalCommData.ShowTcpClientMessage(TAG, "Connect Fail！" + e.ToString());
        }

        public void DisConnect()
        {
            TcpClient.Disconnect();

            GlobalCommData.ShowTcpClientMessage(TAG, "Client Disconnect！");
        }

        private void TcpClient_OnDisconnected(object sender, STTech.BytesIO.Core.DisconnectedEventArgs e)
        {
            IsConnected = false;
            //throw new NotImplementedException();
        }

        public string ConvertSendStr(int Result)
        {
            string re = string.Format("V,{0},S,{1},{2},#", Where, Times, Result.ToString());
            return re;
        }

        public bool ReadReceive(string ReMessage)
        {
            string[] Content = ReMessage.Split(',');
            if (Content.Length < 6) return false;
            Where = Content[1];
            Times = Content[3];
            return true;
        }

        public void SendResult(int Result)
        {
            if (IsConnected)
            {
                TcpClient.SendAsync(ConvertSendStr(Result).GetBytes());
            }
        }
    }

    public class SiemensS7
    {
        //格式 V,C,S,0,0,# 
        string SendStr, ReviceStr;


        string TAG = "SimensS7";

        string _targetIP = "127.0.0.1";
        public string TargetIP
        {
            get { return _targetIP; }
            set { _targetIP = value; }
        }

        short _Rack = 0;
        public short Rack
        {
            get { return _Rack; }
            set { _Rack = value; }
        }

        short _Slot = 1;
        public short Slot
        {
            get { return _Slot; }
            set { _Slot = value; }
        }

        public Plc SiemensPLC;

        public int TryTimes = 0;

        public bool IsConnected
        {
            get { return SiemensPLC.IsConnected; }
        }

        public class PLCStatusEntity
        {
            public PLCStatusEntity()
            {
                IsRunning = false;
                IsCheckCenter = false;
                IsCheckStains = false;
            }

            public void ClearStatus()
            {
                IsRunning = false;
                IsCheckCenter = false;
                IsCheckStains = false;
            }

            public bool IsRunning { get; set; }
            public bool IsCheckCenter { get; set; }
            public bool IsCheckStains { get; set; }
        }

        public class PLCResultEntity
        {

            public PLCResultEntity()
            {
                IsFinished = false;
                CheckCenterResult = false;
                CheckStainsResult = false;
                IsRunError = false;
            }

            public void ClearStatus()
            {
                IsFinished = false;
                CheckCenterResult = false;
                CheckStainsResult = false;
                IsRunError = false;
            }
            public bool IsFinished { get; set; }
            public bool CheckCenterResult { get; set; }
            public bool CheckStainsResult { get; set; }
            public bool IsRunError { get; set; }
        }

        public PLCStatusEntity PLCStatus = new PLCStatusEntity();
        public PLCResultEntity PLCResult = new PLCResultEntity();

        public SiemensS7(string ip, short Rack, short slot)
        {
            _targetIP = ip;
            _Rack = Rack;
            _Slot = slot;
        }
        public SiemensS7()
        {
        }

        public void StartConnect()
        {
            try
            {
                SiemensPLC = new Plc(CpuType.S71500, _targetIP, _Rack, _Slot);
                SiemensPLC.OpenAsync().Wait(2000);
                if (IsConnected)
                {
                    GlobalCommData.ShowLog(TAG, "Connect PLC Succeed", MessageLevel.Info);
                }
                else
                {
                    GlobalCommData.ShowLog(TAG, "Connect PLC Timeout", MessageLevel.Error);
                }

            }
            catch (Exception e)
            {
                GlobalCommData.ShowLog(TAG, "Plc connect error:" + e.ToString(), MessageLevel.Error);
            }
        }

        public void StopConnect()
        {
            try
            {
                if (!SiemensPLC.IsConnected) return;
                SiemensPLC.Close();
                GlobalCommData.ShowLog(TAG, "Disconnect PLC！", MessageLevel.Info);
            }
            catch (Exception e)
            {
                GlobalCommData.ShowLog(TAG, "Plc disconnect error:" + e.ToString(), MessageLevel.Error);
            }

        }

        public bool ReadPLCBoolValue(int db, int start)
        {
            try
            {
                var re = SiemensPLC.Read(DataType.DataBlock, db, start, VarType.Bit, 1);
                GlobalCommData.ShowTcpMessage(TAG, string.Format("Read db:{0} start:{1} Value:{2}", db, start, re));
                return (bool)re;
            }
            catch
            {
                GlobalCommData.ShowTcpMessage(TAG, string.Format("Read fail db:{0} start:{1} ", db, start));
                return false;
            }
        }

        public void WritePLCBoolValue(int db, int start, bool Value)
        {
            try
            {
                SiemensPLC.Write(DataType.DataBlock, db, start, Value);
                GlobalCommData.ShowTcpMessage(TAG, string.Format("Write db:{0} start:{1} Value:{2}", db, start, Value));
            }
            catch
            {
                GlobalCommData.ShowTcpMessage(TAG, string.Format("Write fail db:{0} start:{1} Value:{2}", db, start, Value), TcpMessageLevel.Info);
            }
        }

        public void ReadPLCStatusDatas(int db, int start)
        {
            try
            {
                PLCStatus.ClearStatus();
                SiemensPLC.ReadClass(PLCStatus, db, start);
                GlobalCommData.ShowTcpMessage(TAG, "Read PLC Status");
            }
            catch (Exception e)
            {
                string m = e.ToString();
                PLCStatus.ClearStatus();
            }
        }

        public void ReadPLCStatusDatas()
        {
            try
            {
                if (!SiemensPLC.IsConnected)
                {
                    GlobalCommData.ShowTcpMessage(TAG, "Read PLC Status Fail,Not Connect PLC");
                    return;
                }
                PLCStatus.ClearStatus();
                SiemensPLC.ReadClass(PLCStatus, GlobalCommData.S7PlcStDB, GlobalCommData.S7PlcStStart);
                GlobalCommData.ShowTcpMessage(TAG, "Read PLC Status");
            }
            catch
            {
                GlobalCommData.ShowTcpMessage(TAG, "Read PLC Status Fail");
            }
        }


        public void ReadPLCResultDatas(int db, int start)
        {
            if (!SiemensPLC.IsConnected)
            {
                GlobalCommData.ShowTcpMessage(TAG, "Read PLC Result Fail,Not Connect PLC");
                return;
            }
            PLCResult.ClearStatus();
            SiemensPLC.ReadClass(PLCResult, db, start);
            GlobalCommData.ShowTcpMessage(TAG, "Read PLC Result");
        }

        public void ReadPLCResultDatas()
        {
            try
            {
                if (!SiemensPLC.IsConnected)
                {
                    GlobalCommData.ShowTcpMessage(TAG, "Read PLC Result Fail,Not Connect PLC");
                    return;
                }
                PLCResult.ClearStatus();
                SiemensPLC.ReadClass(PLCResult, GlobalCommData.S7PlcReDB, GlobalCommData.S7PlcReStart);
                GlobalCommData.ShowTcpMessage(TAG, "Read PLC Result");
            }
            catch
            {
                GlobalCommData.ShowTcpMessage(TAG, "Read PLC Result Fail");
            }
        }

        public void ClearPLCStatus()
        {
            PLCStatus.ClearStatus();
        }

        public void ClearPLCResult()
        {
            PLCResult.ClearStatus();
        }

        public void WritePLCResultDatas(int db, int start)
        {
            //PLCResult.ClearStatus();
            PLCResult.IsFinished=true;
            SiemensPLC.WriteClass(PLCResult, db, start);
            GlobalCommData.ShowTcpMessage(TAG, "Write PLC Result");
        }

        public void WritePLCStatusDatas(int db, int start)
        {
            PLCStatus.ClearStatus();
            SiemensPLC.WriteClass(PLCStatus, db, start);
            GlobalCommData.ShowTcpMessage(TAG, "Write PLC Status");
        }
    }

    public class LightControl
    {
        public SerialPort mSerialPort;

        string TAG = "LightControl";
        string TempData;
        string ReciveData;


        public bool IsConnceted
        {
            get { return mSerialPort.IsOpen; }
        }

        string _portName = "COM1";
        public string PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }

        string _lightCH = "A";
        public string LightCH
        {
            get { return _lightCH; }
            set { _lightCH = value; }
        }

        int _ch1Value = 0;
        public int Ch1Value
        {
            get { return _ch1Value; }
            set
            {
                if (value <= 255 && value > 0)
                    _ch1Value = value;
                else
                    _ch1Value = 0;
            }
        }
        public LightControl()
        {
            mSerialPort = new SerialPort();
            mSerialPort.PortName = _portName;
            mSerialPort.BaudRate = 19200; // 设置波特率
            mSerialPort.DataBits = 8; // 设置数据位
            mSerialPort.StopBits = StopBits.One; // 设置停止位
            mSerialPort.Parity = Parity.None; // 设置校验位
        }

        public void Connect()
        {
            try
            {
                mSerialPort.Open();
                mSerialPort.DataReceived += MSerialPort_DataReceived;
                SetLightValue(0);
            }
            catch
            {
                GlobalCommData.ShowLog(TAG, "Light Connect Fail!", MessageLevel.Error);
            }
        }

        public void ReConnect()
        {
            if (mSerialPort != null)
            {
                mSerialPort.Close();
                mSerialPort.Dispose();
                mSerialPort = new SerialPort();
            }

            mSerialPort.Open();
            mSerialPort.DataReceived += MSerialPort_DataReceived;
        }

        public void Disconnect()
        {
            mSerialPort.Close();
        }

        private void MSerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //throw new NotImplementedException();

            TempData = mSerialPort.ReadExisting();
            ReciveData += TempData;
            if (ReciveData.Contains("a"))
            {
                char[] delimiterChars = { 'a' };
                string[] Value = ReciveData.Split(delimiterChars);
                int.TryParse(Value[1], out _ch1Value);
            }
            else if (ReciveData.Contains("b"))
            {
                char[] delimiterChars = { 'b' };
                string[] Value = ReciveData.Split(delimiterChars);
                int.TryParse(Value[1], out _ch1Value);
            }
            else if (ReciveData.Contains("c"))
            {
                char[] delimiterChars = { 'c' };
                string[] Value = ReciveData.Split(delimiterChars);
                int.TryParse(Value[1], out _ch1Value);
            }
            else if (ReciveData.Contains("d"))
            {
                char[] delimiterChars = { 'd' };
                string[] Value = ReciveData.Split(delimiterChars);
                int.TryParse(Value[1], out _ch1Value);
            }
            ReciveData = "";
        }

        void Send(string message)
        {
            try
            {
                if (mSerialPort.IsOpen)
                {
                    mSerialPort.Write(message); GlobalCommData.ShowLog(TAG, "Write/Read Light Value");
                }
                else
                    GlobalCommData.ShowLog(TAG, "Write/Read Light Value Fail: COM is not Connect!", MessageLevel.Error);
            }
            catch
            {

                GlobalCommData.ShowLog(TAG, "Write/Read Light Value Fail: COM is not Connect!", MessageLevel.Error);
            }
        }

        void ReadCHValue(string CH)
        {
            string readstr = string.Format("S{0}#", CH);
            Send(readstr);
        }

        void SetCHValue(string CH, string Value)
        {
            string Writestr = string.Format("S{0}{1}#", CH, Value);
            Send(Writestr);
        }

        public void ReadLightValue()
        {
            ReadCHValue(_lightCH);
        }

        public void SetLightValue(int Value)
        {
            string Valuestr = string.Format("0{0}", Value.ToString("000"));
            SetCHValue(_lightCH, Valuestr);
        }
    }
}


