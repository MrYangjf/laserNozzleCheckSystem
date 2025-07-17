namespace LaserIntelliWeldingSystem.UI
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.btn_CorPassword = new Sunny.UI.UIButton();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.uiCheckBox1 = new Sunny.UI.UICheckBox();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            // 
            // uiPanel1
            // 
            resources.ApplyResources(this.uiPanel1, "uiPanel1");
            // 
            // lblSubText
            // 
            resources.ApplyResources(this.lblSubText, "lblSubText");
            // 
            // btn_CorPassword
            // 
            this.btn_CorPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CorPassword.FillColor = System.Drawing.Color.Transparent;
            this.btn_CorPassword.FillColor2 = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btn_CorPassword, "btn_CorPassword");
            this.btn_CorPassword.ForeColor = System.Drawing.Color.Black;
            this.btn_CorPassword.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(204)))));
            this.btn_CorPassword.ForePressColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(204)))));
            this.btn_CorPassword.ForeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(204)))));
            this.btn_CorPassword.Name = "btn_CorPassword";
            this.btn_CorPassword.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CorPassword.Click += new System.EventHandler(this.btn_CorPassword_Click);
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.uiSymbolButton1, "uiSymbolButton1");
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.Symbol = 61453;
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.Click += new System.EventHandler(this.uiSymbolButton1_Click);
            // 
            // uiCheckBox1
            // 
            this.uiCheckBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.uiCheckBox1, "uiCheckBox1");
            this.uiCheckBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiCheckBox1.Name = "uiCheckBox1";
            // 
            // FormLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.uiCheckBox1);
            this.Controls.Add(this.uiSymbolButton1);
            this.Controls.Add(this.btn_CorPassword);
            this.LoginImage = Sunny.UI.UILoginForm.UILoginImage.Login4;
            this.Name = "FormLogin";
            this.PasswordWatermark = "Passwrd";
            this.SubText = "Verson 1.0";
            this.Title = "登录界面";
            this.UserNameWatermark = "User Name";
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.lblSubText, 0);
            this.Controls.SetChildIndex(this.uiPanel1, 0);
            this.Controls.SetChildIndex(this.btn_CorPassword, 0);
            this.Controls.SetChildIndex(this.uiSymbolButton1, 0);
            this.Controls.SetChildIndex(this.uiCheckBox1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton btn_CorPassword;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private Sunny.UI.UICheckBox uiCheckBox1;
    }
}