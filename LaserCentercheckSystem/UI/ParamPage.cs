using LaserIntelliWeldingSystem.FileIO.XMLFile;
using LaserIntelliWeldingSystem.UI;
using Sunny.UI;
using System.Drawing;
using System.Windows.Forms;


namespace LaserIntelliWeldingSystem.UI
{
    public partial class ParamPage : UIPage
    {
        //XMLEditor mXMLEditor=new XMLEditor ();
        //TCPServer mTCPServer=new TCPServer ();
        //TCPClinet mTCPClinet=new TCPClinet ();
        SiemensS7PLC siemensS7PLC = new SiemensS7PLC ();
        public ParamPage()
        {
            InitializeComponent();

            uiNavBar1.TabControl = uiTabControl1;
            uiNavMenu1.TabControl = uiTabControl1;



            //uiNavBar1设置节点，也可以在Nodes属性里配置
            //uiNavBar1.Nodes.Add("文件配置");
            int pageIndex = 1000;

            uiNavBar1.Nodes.Add("通讯配置");

            uiNavBar1.SetNodePageIndex(uiNavBar1.Nodes[0], pageIndex);
            uiNavBar1.SetNodeSymbol(uiNavBar1.Nodes[0], 61451);

            TreeNode parent = uiNavMenu1.CreateNode("通讯配置", 61451, 24, pageIndex);
            siemensS7PLC.PageIndex = pageIndex;   
            uiTabControl1.AddPage(siemensS7PLC);
            uiNavMenu1.CreateChildNode(parent, siemensS7PLC.Text, pageIndex);

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
            this.uiNavBar1.Nodes[0].Text = CodeTranslator.Current.PLCSetting;
            this.uiNavMenu1.Nodes[0].Text = CodeTranslator.Current.PLCSetting;

        }

        private class CodeTranslator : IniCodeTranslator<CodeTranslator>
        {
            public string PLCSetting { get; set; } = "PLC Setting";
            //public string Plcdisconnect { get; set; } = "PLC断开";
            //public string ClearStatus { get; set; } = "清理状态";
            //public string CheckCenter { get; set; } = "对中检测";
            //public string CheckStain { get; set; } = "脏污检测";
            //public string StartTime { get; set; } = "开始时间";
            //public string Count { get; set; } = "总数";
            //public string Pass { get; set; } = "通过数";
            //public string Rate { get; set; } = "通过率";

        }
    }
}
