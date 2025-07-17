using LaserIntelliWeldingSystem.Communication;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaserIntelliWeldingSystem.UI
{
    public partial class FormLogin : UILoginForm
    {
        public FormLogin()
        {
            InitializeComponent();
            ButtonLoginClick += FormLogin_ButtonLoginClick;
            ButtonCancelClick += FormLogin_ButtonCancelClick;
            UserName = "Engineer";
            UIStyles.InitColorful(Color.Black, Color.White);
            ShowCorButton();
        }

        private void FormLogin_ButtonCancelClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            bool Re = UIMessageBox.ShowAsk2("is logout？");
            if (Re) GlobalCommData.mOperateLevel = OperateLevel.Operator;
            Close();
        }

        void ShowCorButton()
        {
            if (GlobalCommData.mOperateLevel == OperateLevel.Engineer)
            {
                if (!btn_CorPassword.Visible) btn_CorPassword.Visible = true;
            }
            else
            {
                btn_CorPassword.Visible = false;
            }
            if (GlobalCommData.mOperateLevel == OperateLevel.Admin)
            {
                uiCheckBox1.Checked = GlobalCommData.ReadAuthControl();
                if (!uiCheckBox1.Visible) uiCheckBox1.Visible = true;
            }
            else
            {
                uiCheckBox1.Visible = false;
            }
           uiCheckBox1.CheckedChanged += new System.EventHandler(uiCheckBox1_CheckedChanged);
        }

        private void FormLogin_ButtonLoginClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            string password;
            try
            {
                password = GlobalCommData.mAuthManager.Password[UserName];

                if (password == Password)
                {
                    IsLogin = true;
                    UIMessageBox.ShowInfo("Login Succeed！");
                    GlobalCommData.mOperateLevel = GlobalCommData.mAuthManager.Userlevel[UserName];
                    this.Close();
                }
                else
                {
                    this.ShowErrorTip("User or Password Error！");
                }
            }
            catch
            {
                this.ShowErrorTip("User or Password invalid!");
            }
            Password = "";
            ShowCorButton();
        }

        private void btn_CorPassword_Click(object sender, EventArgs e)
        {
            EditPassword editPassword = new EditPassword();
            editPassword.ShowDialog();
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            Close();
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
            this.Title = CodeTranslator.Current.Text;
            this.LoginText = CodeTranslator.Current.TitleText;
            this.ButtonLoginText = CodeTranslator.Current.LoginButtonText;
            this.ButtonCancelText = CodeTranslator.Current.CancelButtonText;
            //this.btn_CorPassword.Text = CodeTranslator.Current.CorPassword;
            //this.uiNavBar1.Nodes[4].Text = CodeTranslator.Current.Theme;



            this.Invalidate();
        }

        private class CodeTranslator : IniCodeTranslator<CodeTranslator>
        {
            public string TitleText { get; set; } = "用户登录";
            public string Text { get; set; } = "登录界面";
            public string LoginButtonText { get; set; } = "登录";
            public string CancelButtonText { get; set; } = "注销";


        }

        private void uiCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            GlobalCommData.IniFile.WriteValue("AuthControl", "Enable", uiCheckBox1.Checked.ToString());
        }
    }
}
