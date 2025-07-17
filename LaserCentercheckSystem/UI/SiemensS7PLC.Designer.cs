namespace LaserIntelliWeldingSystem.UI
{
    partial class SiemensS7PLC
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.uiReadIP = new Sunny.UI.UIButton();
            this.textSlot = new Sunny.UI.UITextBox();
            this.uiWriteIP = new Sunny.UI.UIButton();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiBtn_Connect = new Sunny.UI.UIButton();
            this.uiBtn_StopConnect = new Sunny.UI.UIButton();
            this.uiCheckBox1 = new Sunny.UI.UICheckBox();
            this.textRack = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiipTextBox1 = new Sunny.UI.UIIPTextBox();
            this.ReadStatus = new Sunny.UI.UIGroupBox();
            this.uiCheckStainsLed = new Sunny.UI.UILedBulb();
            this.uiCenterCheckLed = new Sunny.UI.UILedBulb();
            this.uiRunningLed = new Sunny.UI.UILedBulb();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.btnReadStatus = new Sunny.UI.UIButton();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.uiCameraLed = new Sunny.UI.UILedBulb();
            this.uiStainsResultLed = new Sunny.UI.UILedBulb();
            this.uiCenterResultLed = new Sunny.UI.UILedBulb();
            this.btnReadResult = new Sunny.UI.UIButton();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.uiGroupBox3 = new Sunny.UI.UIGroupBox();
            this.uitextStart = new Sunny.UI.UIIntegerUpDown();
            this.uitextDB = new Sunny.UI.UIIntegerUpDown();
            this.uitextValue = new Sunny.UI.UIIntegerUpDown();
            this.uiLabel12 = new Sunny.UI.UILabel();
            this.uiLabel11 = new Sunny.UI.UILabel();
            this.uiLabel10 = new Sunny.UI.UILabel();
            this.btnWrite = new Sunny.UI.UIButton();
            this.btnRead = new Sunny.UI.UIButton();
            this.uiGroupBox4 = new Sunny.UI.UIGroupBox();
            this.uiResultStart = new Sunny.UI.UIIntegerUpDown();
            this.uiStatusStart = new Sunny.UI.UIIntegerUpDown();
            this.uiLabel15 = new Sunny.UI.UILabel();
            this.uiLabel14 = new Sunny.UI.UILabel();
            this.uiResultDB = new Sunny.UI.UIIntegerUpDown();
            this.uiLabel16 = new Sunny.UI.UILabel();
            this.uiStatusDB = new Sunny.UI.UIIntegerUpDown();
            this.uiLabel13 = new Sunny.UI.UILabel();
            this.uiWritePLCAddress = new Sunny.UI.UIButton();
            this.uiReadPLCAddress = new Sunny.UI.UIButton();
            this.uiLine1 = new Sunny.UI.UILine();
            this.uiBtnSave = new Sunny.UI.UISymbolButton();
            this.uiRichTextBox1 = new Sunny.UI.UIRichTextBox();
            this.uiLine2 = new Sunny.UI.UILine();
            this.uiFinised = new Sunny.UI.UILedBulb();
            this.uiLabel17 = new Sunny.UI.UILabel();
            this.uiGroupBox1.SuspendLayout();
            this.ReadStatus.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            this.uiGroupBox3.SuspendLayout();
            this.uiGroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.uiReadIP);
            this.uiGroupBox1.Controls.Add(this.textSlot);
            this.uiGroupBox1.Controls.Add(this.uiWriteIP);
            this.uiGroupBox1.Controls.Add(this.uiLabel3);
            this.uiGroupBox1.Controls.Add(this.uiBtn_Connect);
            this.uiGroupBox1.Controls.Add(this.uiBtn_StopConnect);
            this.uiGroupBox1.Controls.Add(this.uiCheckBox1);
            this.uiGroupBox1.Controls.Add(this.textRack);
            this.uiGroupBox1.Controls.Add(this.uiLabel2);
            this.uiGroupBox1.Controls.Add(this.uiLabel1);
            this.uiGroupBox1.Controls.Add(this.uiipTextBox1);
            this.uiGroupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(11, 42);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(1707, 122);
            this.uiGroupBox1.TabIndex = 12;
            this.uiGroupBox1.Text = "PLC Address";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiReadIP
            // 
            this.uiReadIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiReadIP.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiReadIP.Location = new System.Drawing.Point(558, 73);
            this.uiReadIP.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiReadIP.Name = "uiReadIP";
            this.uiReadIP.Size = new System.Drawing.Size(87, 29);
            this.uiReadIP.TabIndex = 9;
            this.uiReadIP.Text = "Read";
            this.uiReadIP.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiReadIP.Click += new System.EventHandler(this.uiReadIP_Click);
            // 
            // textSlot
            // 
            this.textSlot.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textSlot.Enabled = false;
            this.textSlot.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textSlot.Location = new System.Drawing.Point(489, 73);
            this.textSlot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textSlot.MinimumSize = new System.Drawing.Size(1, 16);
            this.textSlot.Name = "textSlot";
            this.textSlot.Padding = new System.Windows.Forms.Padding(5);
            this.textSlot.ShowText = false;
            this.textSlot.Size = new System.Drawing.Size(62, 29);
            this.textSlot.TabIndex = 5;
            this.textSlot.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.textSlot.Watermark = "";
            // 
            // uiWriteIP
            // 
            this.uiWriteIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiWriteIP.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiWriteIP.Location = new System.Drawing.Point(651, 73);
            this.uiWriteIP.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiWriteIP.Name = "uiWriteIP";
            this.uiWriteIP.Size = new System.Drawing.Size(87, 29);
            this.uiWriteIP.TabIndex = 8;
            this.uiWriteIP.Text = "Write";
            this.uiWriteIP.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiWriteIP.Click += new System.EventHandler(this.uiWriteIP_Click);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel3.Location = new System.Drawing.Point(438, 79);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(54, 23);
            this.uiLabel3.TabIndex = 4;
            this.uiLabel3.Text = "Slot";
            // 
            // uiBtn_Connect
            // 
            this.uiBtn_Connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiBtn_Connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiBtn_Connect.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBtn_Connect.Location = new System.Drawing.Point(1422, 84);
            this.uiBtn_Connect.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiBtn_Connect.Name = "uiBtn_Connect";
            this.uiBtn_Connect.Size = new System.Drawing.Size(138, 35);
            this.uiBtn_Connect.TabIndex = 7;
            this.uiBtn_Connect.Text = "Connect";
            this.uiBtn_Connect.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBtn_Connect.Click += new System.EventHandler(this.uiBtn_Connect_Click);
            // 
            // uiBtn_StopConnect
            // 
            this.uiBtn_StopConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiBtn_StopConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiBtn_StopConnect.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBtn_StopConnect.Location = new System.Drawing.Point(1566, 84);
            this.uiBtn_StopConnect.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiBtn_StopConnect.Name = "uiBtn_StopConnect";
            this.uiBtn_StopConnect.Size = new System.Drawing.Size(138, 35);
            this.uiBtn_StopConnect.TabIndex = 6;
            this.uiBtn_StopConnect.Text = "Disconnect";
            this.uiBtn_StopConnect.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBtn_StopConnect.Click += new System.EventHandler(this.uiBtn_StopConnect_Click);
            // 
            // uiCheckBox1
            // 
            this.uiCheckBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiCheckBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiCheckBox1.Location = new System.Drawing.Point(7, 35);
            this.uiCheckBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox1.Name = "uiCheckBox1";
            this.uiCheckBox1.Size = new System.Drawing.Size(150, 29);
            this.uiCheckBox1.TabIndex = 4;
            this.uiCheckBox1.Text = "Enable Edit";
            this.uiCheckBox1.CheckedChanged += new System.EventHandler(this.uiCheckBox1_CheckedChanged);
            // 
            // textRack
            // 
            this.textRack.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textRack.Enabled = false;
            this.textRack.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textRack.Location = new System.Drawing.Point(369, 73);
            this.textRack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textRack.MinimumSize = new System.Drawing.Size(1, 16);
            this.textRack.Name = "textRack";
            this.textRack.Padding = new System.Windows.Forms.Padding(5);
            this.textRack.ShowText = false;
            this.textRack.Size = new System.Drawing.Size(62, 29);
            this.textRack.TabIndex = 3;
            this.textRack.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.textRack.Watermark = "";
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel2.Location = new System.Drawing.Point(308, 79);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(54, 23);
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "Rack";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(3, 79);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(41, 23);
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "IP";
            // 
            // uiipTextBox1
            // 
            this.uiipTextBox1.Enabled = false;
            this.uiipTextBox1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiipTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiipTextBox1.Location = new System.Drawing.Point(51, 73);
            this.uiipTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiipTextBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiipTextBox1.Name = "uiipTextBox1";
            this.uiipTextBox1.Padding = new System.Windows.Forms.Padding(1);
            this.uiipTextBox1.ShowText = false;
            this.uiipTextBox1.Size = new System.Drawing.Size(250, 29);
            this.uiipTextBox1.TabIndex = 0;
            this.uiipTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReadStatus
            // 
            this.ReadStatus.Controls.Add(this.uiCheckStainsLed);
            this.ReadStatus.Controls.Add(this.uiCenterCheckLed);
            this.ReadStatus.Controls.Add(this.uiRunningLed);
            this.ReadStatus.Controls.Add(this.uiLabel6);
            this.ReadStatus.Controls.Add(this.uiLabel4);
            this.ReadStatus.Controls.Add(this.btnReadStatus);
            this.ReadStatus.Controls.Add(this.uiLabel5);
            this.ReadStatus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ReadStatus.Location = new System.Drawing.Point(555, 177);
            this.ReadStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ReadStatus.MinimumSize = new System.Drawing.Size(1, 1);
            this.ReadStatus.Name = "ReadStatus";
            this.ReadStatus.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.ReadStatus.Size = new System.Drawing.Size(372, 320);
            this.ReadStatus.TabIndex = 15;
            this.ReadStatus.Text = "Status";
            this.ReadStatus.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiCheckStainsLed
            // 
            this.uiCheckStainsLed.Color = System.Drawing.Color.Gray;
            this.uiCheckStainsLed.Location = new System.Drawing.Point(279, 130);
            this.uiCheckStainsLed.Name = "uiCheckStainsLed";
            this.uiCheckStainsLed.Size = new System.Drawing.Size(32, 32);
            this.uiCheckStainsLed.TabIndex = 14;
            this.uiCheckStainsLed.Text = "uiCheckStainsLed";
            // 
            // uiCenterCheckLed
            // 
            this.uiCenterCheckLed.Color = System.Drawing.Color.Gray;
            this.uiCenterCheckLed.Location = new System.Drawing.Point(279, 92);
            this.uiCenterCheckLed.Name = "uiCenterCheckLed";
            this.uiCenterCheckLed.Size = new System.Drawing.Size(32, 32);
            this.uiCenterCheckLed.TabIndex = 13;
            this.uiCenterCheckLed.Text = "uiCenterCheckLed";
            // 
            // uiRunningLed
            // 
            this.uiRunningLed.Color = System.Drawing.Color.Gray;
            this.uiRunningLed.Location = new System.Drawing.Point(279, 53);
            this.uiRunningLed.Name = "uiRunningLed";
            this.uiRunningLed.Size = new System.Drawing.Size(32, 32);
            this.uiRunningLed.TabIndex = 12;
            this.uiRunningLed.Text = "uiRunningLed";
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel6.Location = new System.Drawing.Point(9, 132);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(148, 23);
            this.uiLabel6.TabIndex = 11;
            this.uiLabel6.Text = "IsCheckStains";
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel4.Location = new System.Drawing.Point(9, 93);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(148, 23);
            this.uiLabel4.TabIndex = 10;
            this.uiLabel4.Text = "IsCheckCenter";
            // 
            // btnReadStatus
            // 
            this.btnReadStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReadStatus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReadStatus.Location = new System.Drawing.Point(279, 280);
            this.btnReadStatus.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnReadStatus.Name = "btnReadStatus";
            this.btnReadStatus.Size = new System.Drawing.Size(90, 35);
            this.btnReadStatus.TabIndex = 9;
            this.btnReadStatus.Text = "Read";
            this.btnReadStatus.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReadStatus.Click += new System.EventHandler(this.btnReadStatus_Click);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel5.Location = new System.Drawing.Point(9, 54);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(148, 23);
            this.uiLabel5.TabIndex = 6;
            this.uiLabel5.Text = "IsRunning";
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.uiFinised);
            this.uiGroupBox2.Controls.Add(this.uiLabel17);
            this.uiGroupBox2.Controls.Add(this.uiCameraLed);
            this.uiGroupBox2.Controls.Add(this.uiStainsResultLed);
            this.uiGroupBox2.Controls.Add(this.uiCenterResultLed);
            this.uiGroupBox2.Controls.Add(this.btnReadResult);
            this.uiGroupBox2.Controls.Add(this.uiLabel7);
            this.uiGroupBox2.Controls.Add(this.uiLabel8);
            this.uiGroupBox2.Controls.Add(this.uiLabel9);
            this.uiGroupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox2.Location = new System.Drawing.Point(931, 177);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(362, 320);
            this.uiGroupBox2.TabIndex = 16;
            this.uiGroupBox2.Text = "Result";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiCameraLed
            // 
            this.uiCameraLed.Color = System.Drawing.Color.Gray;
            this.uiCameraLed.Location = new System.Drawing.Point(269, 166);
            this.uiCameraLed.Name = "uiCameraLed";
            this.uiCameraLed.Size = new System.Drawing.Size(32, 32);
            this.uiCameraLed.TabIndex = 17;
            this.uiCameraLed.Text = "uiLedBulb4";
            // 
            // uiStainsResultLed
            // 
            this.uiStainsResultLed.Color = System.Drawing.Color.Gray;
            this.uiStainsResultLed.Location = new System.Drawing.Point(269, 128);
            this.uiStainsResultLed.Name = "uiStainsResultLed";
            this.uiStainsResultLed.Size = new System.Drawing.Size(32, 32);
            this.uiStainsResultLed.TabIndex = 16;
            this.uiStainsResultLed.Text = "uiLedBulb5";
            // 
            // uiCenterResultLed
            // 
            this.uiCenterResultLed.Color = System.Drawing.Color.Gray;
            this.uiCenterResultLed.Location = new System.Drawing.Point(269, 89);
            this.uiCenterResultLed.Name = "uiCenterResultLed";
            this.uiCenterResultLed.Size = new System.Drawing.Size(32, 32);
            this.uiCenterResultLed.TabIndex = 15;
            this.uiCenterResultLed.Text = "uiCenterResult";
            // 
            // btnReadResult
            // 
            this.btnReadResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReadResult.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReadResult.Location = new System.Drawing.Point(268, 280);
            this.btnReadResult.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnReadResult.Name = "btnReadResult";
            this.btnReadResult.Size = new System.Drawing.Size(90, 35);
            this.btnReadResult.TabIndex = 13;
            this.btnReadResult.Text = "Read";
            this.btnReadResult.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReadResult.Click += new System.EventHandler(this.btnReadResult_Click);
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel7.Location = new System.Drawing.Point(22, 170);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(187, 23);
            this.uiLabel7.TabIndex = 10;
            this.uiLabel7.Text = "IsRunError";
            // 
            // uiLabel8
            // 
            this.uiLabel8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel8.Location = new System.Drawing.Point(22, 131);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(187, 23);
            this.uiLabel8.TabIndex = 8;
            this.uiLabel8.Text = "CheckStainsResult";
            // 
            // uiLabel9
            // 
            this.uiLabel9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel9.Location = new System.Drawing.Point(22, 93);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(187, 23);
            this.uiLabel9.TabIndex = 6;
            this.uiLabel9.Text = "CheckCenterResult";
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.Controls.Add(this.uitextStart);
            this.uiGroupBox3.Controls.Add(this.uitextDB);
            this.uiGroupBox3.Controls.Add(this.uitextValue);
            this.uiGroupBox3.Controls.Add(this.uiLabel12);
            this.uiGroupBox3.Controls.Add(this.uiLabel11);
            this.uiGroupBox3.Controls.Add(this.uiLabel10);
            this.uiGroupBox3.Controls.Add(this.btnWrite);
            this.uiGroupBox3.Controls.Add(this.btnRead);
            this.uiGroupBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox3.Location = new System.Drawing.Point(1301, 177);
            this.uiGroupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox3.Size = new System.Drawing.Size(417, 320);
            this.uiGroupBox3.TabIndex = 17;
            this.uiGroupBox3.Text = "Read/Write Bit Test";
            this.uiGroupBox3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uitextStart
            // 
            this.uitextStart.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uitextStart.Location = new System.Drawing.Point(290, 84);
            this.uitextStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uitextStart.Maximum = 1;
            this.uitextStart.Minimum = 0;
            this.uitextStart.MinimumSize = new System.Drawing.Size(100, 0);
            this.uitextStart.Name = "uitextStart";
            this.uitextStart.ShowText = false;
            this.uitextStart.Size = new System.Drawing.Size(116, 29);
            this.uitextStart.TabIndex = 24;
            this.uitextStart.Text = "uitextStart";
            this.uitextStart.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uitextDB
            // 
            this.uitextDB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uitextDB.Location = new System.Drawing.Point(290, 45);
            this.uitextDB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uitextDB.Maximum = 5;
            this.uitextDB.Minimum = 0;
            this.uitextDB.MinimumSize = new System.Drawing.Size(100, 0);
            this.uitextDB.Name = "uitextDB";
            this.uitextDB.ShowText = false;
            this.uitextDB.Size = new System.Drawing.Size(116, 29);
            this.uitextDB.TabIndex = 24;
            this.uitextDB.Text = "uitextDB";
            this.uitextDB.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uitextValue
            // 
            this.uitextValue.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uitextValue.Location = new System.Drawing.Point(290, 123);
            this.uitextValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uitextValue.Maximum = 1;
            this.uitextValue.Minimum = 0;
            this.uitextValue.MinimumSize = new System.Drawing.Size(100, 0);
            this.uitextValue.Name = "uitextValue";
            this.uitextValue.ShowText = false;
            this.uitextValue.Size = new System.Drawing.Size(116, 29);
            this.uitextValue.TabIndex = 23;
            this.uitextValue.Text = "uitextValue";
            this.uitextValue.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel12
            // 
            this.uiLabel12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel12.Location = new System.Drawing.Point(12, 130);
            this.uiLabel12.Name = "uiLabel12";
            this.uiLabel12.Size = new System.Drawing.Size(187, 23);
            this.uiLabel12.TabIndex = 21;
            this.uiLabel12.Text = "Value";
            // 
            // uiLabel11
            // 
            this.uiLabel11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel11.Location = new System.Drawing.Point(3, 91);
            this.uiLabel11.Name = "uiLabel11";
            this.uiLabel11.Size = new System.Drawing.Size(187, 23);
            this.uiLabel11.TabIndex = 18;
            this.uiLabel11.Text = "(int)StartBitAddress";
            // 
            // uiLabel10
            // 
            this.uiLabel10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel10.Location = new System.Drawing.Point(3, 52);
            this.uiLabel10.Name = "uiLabel10";
            this.uiLabel10.Size = new System.Drawing.Size(187, 23);
            this.uiLabel10.TabIndex = 17;
            this.uiLabel10.Text = "(int)DB";
            // 
            // btnWrite
            // 
            this.btnWrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWrite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWrite.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWrite.Location = new System.Drawing.Point(319, 280);
            this.btnWrite.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(90, 35);
            this.btnWrite.TabIndex = 16;
            this.btnWrite.Text = "Write";
            this.btnWrite.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // btnRead
            // 
            this.btnRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRead.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRead.Location = new System.Drawing.Point(223, 280);
            this.btnRead.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(90, 35);
            this.btnRead.TabIndex = 15;
            this.btnRead.Text = "Read";
            this.btnRead.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // uiGroupBox4
            // 
            this.uiGroupBox4.Controls.Add(this.uiResultStart);
            this.uiGroupBox4.Controls.Add(this.uiStatusStart);
            this.uiGroupBox4.Controls.Add(this.uiLabel15);
            this.uiGroupBox4.Controls.Add(this.uiLabel14);
            this.uiGroupBox4.Controls.Add(this.uiResultDB);
            this.uiGroupBox4.Controls.Add(this.uiLabel16);
            this.uiGroupBox4.Controls.Add(this.uiStatusDB);
            this.uiGroupBox4.Controls.Add(this.uiLabel13);
            this.uiGroupBox4.Controls.Add(this.uiWritePLCAddress);
            this.uiGroupBox4.Controls.Add(this.uiReadPLCAddress);
            this.uiGroupBox4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox4.Location = new System.Drawing.Point(11, 177);
            this.uiGroupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox4.Name = "uiGroupBox4";
            this.uiGroupBox4.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox4.Size = new System.Drawing.Size(532, 320);
            this.uiGroupBox4.TabIndex = 16;
            this.uiGroupBox4.Text = "PLC Data Address";
            this.uiGroupBox4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiResultStart
            // 
            this.uiResultStart.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiResultStart.Location = new System.Drawing.Point(296, 142);
            this.uiResultStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiResultStart.MinimumSize = new System.Drawing.Size(100, 0);
            this.uiResultStart.Name = "uiResultStart";
            this.uiResultStart.ShowText = false;
            this.uiResultStart.Size = new System.Drawing.Size(116, 23);
            this.uiResultStart.TabIndex = 20;
            this.uiResultStart.Text = "uiIntegerUpDown3";
            this.uiResultStart.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiStatusStart
            // 
            this.uiStatusStart.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiStatusStart.Location = new System.Drawing.Point(296, 77);
            this.uiStatusStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiStatusStart.MinimumSize = new System.Drawing.Size(100, 0);
            this.uiStatusStart.Name = "uiStatusStart";
            this.uiStatusStart.ShowText = false;
            this.uiStatusStart.Size = new System.Drawing.Size(116, 23);
            this.uiStatusStart.TabIndex = 16;
            this.uiStatusStart.Text = "uiIntegerUpDown2";
            this.uiStatusStart.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel15
            // 
            this.uiLabel15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel15.Location = new System.Drawing.Point(13, 143);
            this.uiLabel15.Name = "uiLabel15";
            this.uiLabel15.Size = new System.Drawing.Size(258, 23);
            this.uiLabel15.TabIndex = 19;
            this.uiLabel15.Text = "Result Datablock Start";
            // 
            // uiLabel14
            // 
            this.uiLabel14.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel14.Location = new System.Drawing.Point(13, 78);
            this.uiLabel14.Name = "uiLabel14";
            this.uiLabel14.Size = new System.Drawing.Size(258, 23);
            this.uiLabel14.TabIndex = 15;
            this.uiLabel14.Text = "Status Datablock Start";
            // 
            // uiResultDB
            // 
            this.uiResultDB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiResultDB.Location = new System.Drawing.Point(296, 110);
            this.uiResultDB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiResultDB.MinimumSize = new System.Drawing.Size(100, 0);
            this.uiResultDB.Name = "uiResultDB";
            this.uiResultDB.ShowText = false;
            this.uiResultDB.Size = new System.Drawing.Size(116, 23);
            this.uiResultDB.TabIndex = 18;
            this.uiResultDB.Text = "uiIntegerUpDown4";
            this.uiResultDB.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel16
            // 
            this.uiLabel16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel16.Location = new System.Drawing.Point(13, 110);
            this.uiLabel16.Name = "uiLabel16";
            this.uiLabel16.Size = new System.Drawing.Size(258, 23);
            this.uiLabel16.TabIndex = 17;
            this.uiLabel16.Text = "Result Datablock DB";
            // 
            // uiStatusDB
            // 
            this.uiStatusDB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiStatusDB.Location = new System.Drawing.Point(296, 45);
            this.uiStatusDB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiStatusDB.MinimumSize = new System.Drawing.Size(100, 0);
            this.uiStatusDB.Name = "uiStatusDB";
            this.uiStatusDB.ShowText = false;
            this.uiStatusDB.Size = new System.Drawing.Size(116, 23);
            this.uiStatusDB.TabIndex = 14;
            this.uiStatusDB.Text = "uiStatusDB";
            this.uiStatusDB.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel13
            // 
            this.uiLabel13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel13.Location = new System.Drawing.Point(13, 45);
            this.uiLabel13.Name = "uiLabel13";
            this.uiLabel13.Size = new System.Drawing.Size(258, 23);
            this.uiLabel13.TabIndex = 13;
            this.uiLabel13.Text = "Status Datablock DB";
            // 
            // uiWritePLCAddress
            // 
            this.uiWritePLCAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiWritePLCAddress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiWritePLCAddress.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiWritePLCAddress.Location = new System.Drawing.Point(439, 282);
            this.uiWritePLCAddress.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiWritePLCAddress.Name = "uiWritePLCAddress";
            this.uiWritePLCAddress.Size = new System.Drawing.Size(90, 35);
            this.uiWritePLCAddress.TabIndex = 12;
            this.uiWritePLCAddress.Text = "Write";
            this.uiWritePLCAddress.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiWritePLCAddress.Click += new System.EventHandler(this.uiWritePLCAddress_Click);
            // 
            // uiReadPLCAddress
            // 
            this.uiReadPLCAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiReadPLCAddress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiReadPLCAddress.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiReadPLCAddress.Location = new System.Drawing.Point(343, 282);
            this.uiReadPLCAddress.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiReadPLCAddress.Name = "uiReadPLCAddress";
            this.uiReadPLCAddress.Size = new System.Drawing.Size(90, 35);
            this.uiReadPLCAddress.TabIndex = 9;
            this.uiReadPLCAddress.Text = "Read";
            this.uiReadPLCAddress.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiReadPLCAddress.Click += new System.EventHandler(this.uiReadPLCAddress_Click);
            // 
            // uiLine1
            // 
            this.uiLine1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLine1.BackColor = System.Drawing.Color.Transparent;
            this.uiLine1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine1.Location = new System.Drawing.Point(5, 757);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(1722, 29);
            this.uiLine1.TabIndex = 18;
            // 
            // uiBtnSave
            // 
            this.uiBtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiBtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiBtnSave.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBtnSave.Location = new System.Drawing.Point(1536, 792);
            this.uiBtnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiBtnSave.Name = "uiBtnSave";
            this.uiBtnSave.Size = new System.Drawing.Size(191, 35);
            this.uiBtnSave.Symbol = 61639;
            this.uiBtnSave.TabIndex = 19;
            this.uiBtnSave.Text = "Save Plc Setting";
            this.uiBtnSave.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBtnSave.Click += new System.EventHandler(this.uiBtnSave_Click);
            // 
            // uiRichTextBox1
            // 
            this.uiRichTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiRichTextBox1.FillColor = System.Drawing.Color.White;
            this.uiRichTextBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiRichTextBox1.Location = new System.Drawing.Point(8, 542);
            this.uiRichTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiRichTextBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRichTextBox1.Name = "uiRichTextBox1";
            this.uiRichTextBox1.Padding = new System.Windows.Forms.Padding(2);
            this.uiRichTextBox1.ShowText = false;
            this.uiRichTextBox1.Size = new System.Drawing.Size(1718, 207);
            this.uiRichTextBox1.TabIndex = 20;
            this.uiRichTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLine2
            // 
            this.uiLine2.BackColor = System.Drawing.Color.Transparent;
            this.uiLine2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine2.Location = new System.Drawing.Point(11, 505);
            this.uiLine2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(1722, 29);
            this.uiLine2.TabIndex = 21;
            this.uiLine2.Text = "S7 PLC Log";
            this.uiLine2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiFinised
            // 
            this.uiFinised.Color = System.Drawing.Color.Gray;
            this.uiFinised.Location = new System.Drawing.Point(269, 50);
            this.uiFinised.Name = "uiFinised";
            this.uiFinised.Size = new System.Drawing.Size(32, 32);
            this.uiFinised.TabIndex = 19;
            this.uiFinised.Text = "uiCenterResult";
            // 
            // uiLabel17
            // 
            this.uiLabel17.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel17.Location = new System.Drawing.Point(22, 54);
            this.uiLabel17.Name = "uiLabel17";
            this.uiLabel17.Size = new System.Drawing.Size(187, 23);
            this.uiLabel17.TabIndex = 18;
            this.uiLabel17.Text = "IsFinished";
            // 
            // SiemensS7PLC
            // 
            this.AllowShowTitle = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1730, 830);
            this.Controls.Add(this.uiLine2);
            this.Controls.Add(this.uiRichTextBox1);
            this.Controls.Add(this.uiBtnSave);
            this.Controls.Add(this.uiLine1);
            this.Controls.Add(this.uiGroupBox4);
            this.Controls.Add(this.uiGroupBox3);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.ReadStatus);
            this.Controls.Add(this.uiGroupBox1);
            this.Name = "SiemensS7PLC";
            this.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.ShowTitle = true;
            this.Text = "SiemensS7Plc";
            this.uiGroupBox1.ResumeLayout(false);
            this.ReadStatus.ResumeLayout(false);
            this.uiGroupBox2.ResumeLayout(false);
            this.uiGroupBox3.ResumeLayout(false);
            this.uiGroupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UITextBox textSlot;
        private Sunny.UI.UIButton uiWriteIP;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIButton uiBtn_Connect;
        private Sunny.UI.UIButton uiBtn_StopConnect;
        private Sunny.UI.UICheckBox uiCheckBox1;
        private Sunny.UI.UITextBox textRack;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIIPTextBox uiipTextBox1;
        private Sunny.UI.UIGroupBox ReadStatus;
        private Sunny.UI.UIButton btnReadStatus;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UIGroupBox uiGroupBox3;
        private Sunny.UI.UILedBulb uiCheckStainsLed;
        private Sunny.UI.UILedBulb uiCenterCheckLed;
        private Sunny.UI.UILedBulb uiRunningLed;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILedBulb uiCameraLed;
        private Sunny.UI.UILedBulb uiStainsResultLed;
        private Sunny.UI.UILedBulb uiCenterResultLed;
        private Sunny.UI.UIButton btnReadResult;
        private Sunny.UI.UIButton btnWrite;
        private Sunny.UI.UIButton btnRead;
        private Sunny.UI.UILabel uiLabel11;
        private Sunny.UI.UILabel uiLabel10;
        private Sunny.UI.UILabel uiLabel12;
        private Sunny.UI.UIGroupBox uiGroupBox4;
        private Sunny.UI.UIIntegerUpDown uiStatusStart;
        private Sunny.UI.UILabel uiLabel14;
        private Sunny.UI.UIIntegerUpDown uiStatusDB;
        private Sunny.UI.UILabel uiLabel13;
        private Sunny.UI.UIButton uiWritePLCAddress;
        private Sunny.UI.UIButton uiReadPLCAddress;
        private Sunny.UI.UIIntegerUpDown uiResultStart;
        private Sunny.UI.UILabel uiLabel15;
        private Sunny.UI.UIIntegerUpDown uiResultDB;
        private Sunny.UI.UILabel uiLabel16;
        private Sunny.UI.UIButton uiReadIP;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UISymbolButton uiBtnSave;
        private Sunny.UI.UIIntegerUpDown uitextValue;
        private Sunny.UI.UIIntegerUpDown uitextStart;
        private Sunny.UI.UIIntegerUpDown uitextDB;
        private Sunny.UI.UIRichTextBox uiRichTextBox1;
        private Sunny.UI.UILine uiLine2;
        private Sunny.UI.UILedBulb uiFinised;
        private Sunny.UI.UILabel uiLabel17;
    }
}
