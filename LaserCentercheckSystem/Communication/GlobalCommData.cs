using LaserIntelliWeldingSystem.Communication.TCPIP;
using LaserIntelliWeldingSystem.FileIO.INIFile;
using LaserIntelliWeldingSystem.FileIO.LOGFile;
using LaserIntelliWeldingSystem.FileIO.XMLFile;
using LaserIntelliWeldingSystem.SQLiteDB;
using LaserIntelliWeldingSystem.VisionSystem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace LaserIntelliWeldingSystem.Communication
{

    public class MachineStatusMessageArgs : EventArgs
    {
        public MachineStatus CurrentMachineStatus = MachineStatus.NoInitialize;
    }
    public class MessageArgs : EventArgs
    {
        public string strMessage = "";
        public Color MessageShowColor = Color.Black;
    }
    public class MessageLineChart : EventArgs
    {
        public string Name = "";
        public string Mesage = "";
    }


    class GlobalCommData
    {
        /// <summary>
        /// 状态通知事件
        /// </summary>
        public static event EventHandler<MachineStatusMessageArgs> EevetStatusHandler;
        static MachineStatus machineStatus = MachineStatus.NoInitialize;
        public static MachineStatus LastStatus = MachineStatus.NoInitialize;
        public static MachineStatus CurrentStatus
        {
            get
            {
                return machineStatus;
            }
            set
            {
                if (machineStatus != value)
                {
                    LastStatus = machineStatus;
                    machineStatus = value;
                    EventHandler<MachineStatusMessageArgs> handler = EevetStatusHandler;
                    if (handler != null)
                    {
                        handler(null, new MachineStatusMessageArgs() { CurrentMachineStatus = machineStatus });
                    }
                }
            }
        }

        public static bool IsAuto;
        public static bool IsHanderTest;

        public static int S7PlcReDB, S7PlcReStart, S7PlcStDB, S7PlcStStart;

        public static RunCount mRunCount= new RunCount();

        public static RunCenterResult mRunCenterResult = new RunCenterResult();

        public static RunStainsResult mRunStainsResult = new RunStainsResult();

        /// <summary>
        /// 服务器xml文档
        /// </summary>
        public static XdocumentReaderWriter ServerXdoc = new XdocumentReaderWriter("Server");
        /// <summary>
        /// 客户端xml文档
        /// </summary>
        public static XdocumentReaderWriter ClientXdoc = new XdocumentReaderWriter("Client");
        /// <summary>
        /// 发送数据xml文档
        /// </summary>
        public static XdocumentReaderWriter SendXdoc = new XdocumentReaderWriter("Send");
        /// <summary>
        /// 接受数据xml文档
        /// </summary>
        public static XdocumentReaderWriter ReciveXdoc = new XdocumentReaderWriter("Recive");


        /// <summary>
        /// 初始配置文件
        /// </summary>
        public static IniFile IniFile = new IniFile();

        /// <summary>
        /// 权限管理文件
        /// </summary>
        public static AuthManage mAuthManager = new AuthManage();

        /// <summary>
        /// 生产管理文件
        /// </summary>
        public static ProductDatabaseManage mProductManager = new ProductDatabaseManage();

        /// <summary>
        /// 操作等级
        /// </summary>
        public static OperateLevel mOperateLevel = OperateLevel.Operator;

        /// <summary>
        /// 通讯类
        /// </summary>
        public static TCPIPComm TCPIPComm = new TCPIPComm();
        /// <summary>
        /// 日志操作
        /// </summary>
        public static Log MachineLog = new Log("系统日志");
        /// <summary>
        /// 日志操作
        /// </summary>
        public static Log TcpMessageLog = new Log("通讯日志");

        /// <summary>
        /// 视觉功能类
        /// </summary>
        public static VisionMasterFunc VisionMasterFunc = new VisionMasterFunc();

        /// <summary>
        /// 日志信息Handler
        /// </summary>
        public static event EventHandler<MessageArgs> EventInfoHandler;

        /// <summary>
        /// 通讯信息Handler
        /// </summary>
        public static event EventHandler<MessageArgs> EventTcpInfoHandler;

        /// <summary>
        /// Client通讯信息Handler
        /// </summary>
        public static event EventHandler<MessageArgs> EventTcpClientInfoHandler;


        /// <summary>
        /// 线激光通讯信息Handler
        /// </summary>
        public static event EventHandler<MessageLineChart> EventLineLaserInfoHandler;

        /// <summary>
        /// 机器人焊接参数通讯信息Handler
        /// </summary>
        public static event EventHandler<MessageLineChart> EventRobotInfoHandler;

        /// <summary>
        /// 显示日志
        /// </summary>
        /// <param name="TAG"></param>
        /// <param name="message"></param>
        /// <param name="msgLevel"></param>
        /// <param name="msgType"></param>
        public static void ShowLog(string TAG, string message, MessageLevel msgLevel = MessageLevel.Info, MessageType msgType = MessageType.Debug)
        {
            EventHandler<MessageArgs> Handler = EventInfoHandler;
            switch (msgLevel)
            {
                case MessageLevel.Info:
                    Handler?.Invoke(null, new MessageArgs() { strMessage = message  });
                    break;
                case MessageLevel.Warning:
                    Handler?.Invoke(null, new MessageArgs() { strMessage = message, MessageShowColor = Color.MediumVioletRed });
                    break;
                case MessageLevel.Error:
                    Handler?.Invoke(null, new MessageArgs() { strMessage = message, MessageShowColor = Color.Red });
                    break;
            }
            MachineLog.Debug(TAG + "_Thread ID:"+Thread.GetDomainID(), message);
        }

        /// <summary>
        /// 通讯显示
        /// </summary>
        /// <param name="TAG"></param>
        /// <param name="message"></param>
        /// <param name="msgLevel"></param>
        /// <param name="msgType"></param>
        public static void ShowTcpMessage(string TAG, string message, TcpMessageLevel msgLevel = TcpMessageLevel.Info)
        {
            EventHandler<MessageArgs> Handler = EventTcpInfoHandler;
            switch (msgLevel)
            {
                case TcpMessageLevel.Info:
                    Handler?.Invoke(null, new MessageArgs() { strMessage = message });
                    break;
                case TcpMessageLevel.Tips:
                    Handler?.Invoke(null, new MessageArgs() { strMessage = message, MessageShowColor = Color.Blue });
                    break;
            }
            TcpMessageLog.Debug(TAG + "_Thread ID:" + Thread.GetDomainID(), message);
        }

        public static void ShowTcpClientMessage(string TAG, string message, TcpMessageLevel msgLevel = TcpMessageLevel.Info)
        {
            EventHandler<MessageArgs> Handler = EventTcpClientInfoHandler;
            switch (msgLevel)
            {
                case TcpMessageLevel.Info:
                    Handler?.Invoke(null, new MessageArgs() { strMessage = message });
                    break;
                case TcpMessageLevel.Tips:
                    Handler?.Invoke(null, new MessageArgs() { strMessage = message, MessageShowColor = Color.Blue });
                    break;
            }
            TcpMessageLog.Debug(TAG + Thread.GetDomainID(), message);
        }

        public static bool ReadLangConfig()
        {
            try
            {
                return bool.Parse(IniFile.ReadValue("Language", "IsChinese"));
            }
            catch
            {
                return false;
            }
        }

        public static bool ReadAuthControl()
        {
            try
            {
                return bool.Parse(IniFile.ReadValue("AuthControl", "Enable"));
            }
            catch
            {
                return false;
            }
        }

    }
}
