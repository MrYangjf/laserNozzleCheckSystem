using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LaserIntelliWeldingSystem.Communication;
using LaserIntelliWeldingSystem.FileIO.XMLFile;
using LaserIntelliWeldingSystem.UI;
using LaserIntelliWeldingSystem.Workflow;
using Sunny.UI;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace LaserIntelliWeldingSystem
{
    public partial class FormMain : UIForm2
    {
        DateTime CurrentDays=DateTime.Now;

        UIPage uIPage = new UIPage();
        MainPage mainPage = new MainPage();
        ParamPage paramPage = new ParamPage();
        DataPage dataPage = new DataPage();
        CameraSettingPage cameraSettingPage = new CameraSettingPage();

        bool HidePage = false;

        Dictionary<string, TreeNode> NodeDictionary = new Dictionary<string, TreeNode>();

        public FormMain()
        {
            InitializeComponent();
            MaximizedBounds = Screen.PrimaryScreen.Bounds;

            this.MainTabControl = uiTabControl1;
            uiNavBar1.TabControl = uiTabControl1;
            //设置初始页面索引（关联页面，唯一不重复即可）
            int pageIndex = 1000;

            LoadPage(pageIndex);
            Initialize();

        }

        void Initialize()
        {
            HidePage=false;

            if (GlobalCommData.ReadLangConfig())
                UIStyles.CultureInfo = CultureInfos.zh_CN;
            else
                UIStyles.CultureInfo = CultureInfos.en_US;

            UIStyles.InitColorful(Color.Black, Color.White);

        }

        void LoadPage(int pageIndex)
        {
            GlobalCommData.mRunCount.SystemStartTime = DateTime.Now;
            //uiNavBar1设置节点，也可以在Nodes属性里配置
            uiNavBar1.Nodes.Add("主页面");
            uiNavBar1.Nodes.Add("参数界面");
            uiNavBar1.Nodes.Add("图形界面");
            uiNavBar1.Nodes.Add("生产界面");

            uiNavBar1.Nodes[0].Name = "主页面";
            uiNavBar1.SetNodePageIndex(uiNavBar1.Nodes[0], pageIndex);
            uiNavBar1.SetNodeSymbol(uiNavBar1.Nodes[0], 57460);
            AddPage(mainPage, pageIndex);
            mainPage.SetStartTime(GlobalCommData.mRunCount.SystemStartTime);


            uiNavBar1.Nodes[1].Name = "参数界面";
            uiNavBar1.SetNodePageIndex(uiNavBar1.Nodes[1], ++pageIndex);
            uiNavBar1.SetNodeSymbol(uiNavBar1.Nodes[1], 61451);
            NodeDictionary.Add("参数界面", uiNavBar1.Nodes["参数界面"]);
            AddPage(paramPage, pageIndex);

            uiNavBar1.Nodes[2].Name = "图形界面";
            uiNavBar1.SetNodePageIndex(uiNavBar1.Nodes[2], ++pageIndex);
            uiNavBar1.SetNodeSymbol(uiNavBar1.Nodes[2], 361550);
            NodeDictionary.Add("图形界面", uiNavBar1.Nodes["图形界面"]);
            AddPage(cameraSettingPage, pageIndex);

            uiNavBar1.Nodes[3].Name = "生产界面";
            uiNavBar1.SetNodePageIndex(uiNavBar1.Nodes[3], ++pageIndex);
            uiNavBar1.SetNodeSymbol(uiNavBar1.Nodes[3], 61950);
            NodeDictionary.Add("生产界面", uiNavBar1.Nodes["生产界面"]);
            AddPage(dataPage, pageIndex);
        }

        private void uiHeaderButton6_Click(object sender, EventArgs e)
        {
            FormLogin mLogin = new FormLogin();
            mLogin.ShowDialog();
        }


        void ShowStatus()
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action(ShowStatus));
            }
            else
            {
                statusrightlabel.Text = GlobalCommData.mOperateLevel.ToString();
                switch (GlobalCommData.mOperateLevel)
                {
                    case OperateLevel.Operator:
                        statusrightlabel.BackColor = Color.Gray;
                        break;
                    case OperateLevel.Engineer:
                        statusrightlabel.BackColor = Color.Green;
                        break;
                    case OperateLevel.Admin:
                        statusrightlabel.BackColor = Color.YellowGreen;
                        break;
                }

                systemtimelabel.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                if (GlobalCommData.VisionMasterFunc.IsSolutionLoad && GlobalCommData.VisionMasterFunc.CameraSn != "-1" && GlobalCommData.VisionMasterFunc.CameraSn != "-2")
                {
                    statucamlabel.Text = "Connect:CamSn_" + GlobalCommData.VisionMasterFunc.CameraSn;
                    statucamlabel.BackColor = Color.Green;
                }
                else
                {
                    statucamlabel.Text = "DisConnect:CamSn_" + GlobalCommData.VisionMasterFunc.CameraSn;
                    statucamlabel.BackColor = Color.Red;
                }

                if (GlobalCommData.TCPIPComm.mS7Plc.IsConnected)
                {
                    statusCommLabel.Text = "Online";
                    statusCommLabel.BackColor = Color.Green;
                }
                else
                {
                    statusCommLabel.Text = "Offline";
                    statusCommLabel.BackColor = Color.Red;
                }

                if (GlobalCommData.TCPIPComm.mLight.IsConnceted)
                {
                    LightStatus.Text = "Online";
                    LightStatus.BackColor = Color.Green;
                }
                else
                {
                    LightStatus.Text = "Offline";
                    LightStatus.BackColor = Color.Red;
                }

                mainPage.StatusChange(GlobalCommData.CurrentStatus);
            }
        }

        void OperateLevelControl()
        {
            if (GlobalCommData.ReadAuthControl())
            {
                switch (GlobalCommData.mOperateLevel)
                {
                    case OperateLevel.Admin:
                    case OperateLevel.Engineer:
                        ShowTreeNode();
                        break;
                    case OperateLevel.Operator:
                        HideTreeNode();
                        break;
                }
            }
            else
            {
                ShowTreeNode();
            }
        }

        void HideTreeNode()
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action(HideTreeNode));
            }
            else
            if (!HidePage)
            {
                uiNavBar1.SelectedIndex = 0;
                uiNavBar1.SelectedForeColor = Color.Gray;
                uiNavBar1.SelectedHighColor = Color.Gray;
                uiNavBar1.MenuHoverColor = Color.DarkGray;

                uiNavBar1.SetNodePageIndex(uiNavBar1.Nodes[1], 1000);
                uiNavBar1.SetNodePageIndex(uiNavBar1.Nodes[2], 1000);
                uiNavBar1.SetNodePageIndex(uiNavBar1.Nodes[3], 1000);

                HidePage = true;
            }
        }

        void ShowTreeNode()
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action(ShowTreeNode));
            }
            else
            {
                if (HidePage)
                {
                    uiNavBar1.SelectedForeColor = Color.FromArgb(80, 160, 255);
                    uiNavBar1.SelectedHighColor = Color.FromArgb(80, 160, 255);
                    uiNavBar1.MenuHoverColor = Color.FromArgb(230, 230, 230);
                    uiNavBar1.SetNodePageIndex(uiNavBar1.Nodes[1], 1001);
                    uiNavBar1.SetNodePageIndex(uiNavBar1.Nodes[2], 1002);
                    uiNavBar1.SetNodePageIndex(uiNavBar1.Nodes[3], 1003);
                    HidePage = false;
                }
            }
        }

        void NewDaysCreatFile()
        {
            if(CurrentDays.DayOfYear!=DateTime.Now.DayOfYear)
            {
                CurrentDays = DateTime.Now;
                GlobalCommData.VisionMasterFunc.WriteNewDaysPath();
                GlobalCommData.mProductManager.NewDaysDatebase();
            }
        }

        private void uiMillisecondTimer1_Tick(object sender, EventArgs e)
        {
            ShowStatus();
            OperateLevelControl();
            NewDaysCreatFile();
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
            this.Text = CodeTranslator.Current.TitleText;
            this.CloseAskString = CodeTranslator.Current.CloseAskString;
            this.uiNavBar1.Nodes[0].Text = CodeTranslator.Current.MainPage;
            this.uiNavBar1.Nodes[1].Text = CodeTranslator.Current.ParamPage;
            this.uiNavBar1.Nodes[2].Text = CodeTranslator.Current.ImagePage;
            this.uiNavBar1.Nodes[3].Text = CodeTranslator.Current.ProductPage;
            this.toolRightLabel.Text = CodeTranslator.Current.OperateLevel;
            this.toolcamlabel.Text = CodeTranslator.Current.CameraStatus;
            //this.uiNavBar1.Nodes[4].Text = CodeTranslator.Current.Theme;

            this.uiNavBar1.Invalidate();
        }

        private class CodeTranslator : IniCodeTranslator<CodeTranslator>
        {
            public string CloseAskString { get; set; } = "您确认要退出程序吗？";
            public string TitleText { get; set; } = "激光对中检测系统";
            public string MainPage { get; set; } = "主页面";
            public string ParamPage { get; set; } = "通用参数";
            public string ImagePage { get; set; } = "视觉参数";
            public string ProductPage { get; set; } = "生产界面";
            public string NeedAuthInfo { get; set; } = "缺乏权限！";
            public string OperateLevel { get; set; } = "权限等级：";
            public string CameraStatus { get; set; } = "设备状态：";

        }

        private void eNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIStyles.CultureInfo = CultureInfos.en_US;
            GlobalCommData.IniFile.WriteValue("Language", "IsChinese", "false");
        }

        private void cHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIStyles.CultureInfo = CultureInfos.zh_CN;
            GlobalCommData.IniFile.WriteValue("Language", "IsChinese", "true");
        }

        private void FormMain_AfterShown(object sender, EventArgs e)
        {

            uIPage.ShowWaitForm("Waitting Application Load Compliteted");
            uiNavBar1.MenuItemClick += uiNavBar1_MenuItemClick;


            MachineControlWork.GetInstance().LoadCamSol();
            MachineControlWork.GetInstance().StationReset();
            MachineControlWork.GetInstance().StartWork();

            mainPage.LoadCameraViewer();
            cameraSettingPage.LoadCfg();
            uIPage.HideWaitForm();
            //BringToFront();
            uiMillisecondTimer1.Enabled = true;
            if (GlobalCommData.TCPIPComm.mS7Plc.IsConnected && GlobalCommData.VisionMasterFunc.IsSolutionLoad && GlobalCommData.TCPIPComm.mLight.IsConnceted)
                GlobalCommData.IsAuto = true;
        }

        private void uiNavBar1_MenuItemClick(string itemText, int menuIndex, int pageIndex)
        {
            if (itemText == "MainPage" || itemText == "主页面") return;
            if (GlobalCommData.mOperateLevel == OperateLevel.Operator && GlobalCommData.ReadAuthControl())
            {
                UIMessageBox.ShowInfo(CodeTranslator.Current.NeedAuthInfo);
                uiNavBar1.SelectedIndex = 0;
            }
            else if(GlobalCommData.IsAuto)
            {
                UIMessageBox.ShowInfo("Stop auto and try again!");
                uiNavBar1.SelectedIndex = 0;
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
            GlobalCommData.VisionMasterFunc.DisposeVm();
        }

    }
}
