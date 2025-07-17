namespace LaserIntelliWeldingSystem.UI
{
    partial class MainPage
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
            this.components = new System.ComponentModel.Container();
            this.rtb_Log = new Sunny.UI.UIRichTextBox();
            this.uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            this.uiTitlePanelCenter = new Sunny.UI.UITitlePanel();
            this.vmRenderControl1 = new VMControls.Winform.Release.VmRenderControl();
            this.uiSplitContainer1 = new Sunny.UI.UISplitContainer();
            this.uiTableLayoutPanel3 = new Sunny.UI.UITableLayoutPanel();
            this.uiTitlePanel4 = new Sunny.UI.UITitlePanel();
            this.vmRenderControl3 = new VMControls.Winform.Release.VmRenderControl();
            this.uiTitlePanelStains = new Sunny.UI.UITitlePanel();
            this.vmRenderControl2 = new VMControls.Winform.Release.VmRenderControl();
            this.uiSplitContainer2 = new Sunny.UI.UISplitContainer();
            this.uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            this.LblRate = new Sunny.UI.UILabel();
            this.uiRate = new Sunny.UI.UISymbolLabel();
            this.LblPass = new Sunny.UI.UILabel();
            this.uiPass = new Sunny.UI.UISymbolLabel();
            this.LblTotal = new Sunny.UI.UILabel();
            this.uiCount = new Sunny.UI.UISymbolLabel();
            this.LblStatus = new Sunny.UI.UISymbolLabel();
            this.uiStartTime = new Sunny.UI.UISymbolLabel();
            this.LblStartTime = new Sunny.UI.UILabel();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.uiQuickPanel = new Sunny.UI.UIPanel();
            this.uiTurnSwitch1 = new Sunny.UI.UITurnSwitch();
            this.uiTableLayoutPanel2 = new Sunny.UI.UITableLayoutPanel();
            this.btnHelper = new Sunny.UI.UISymbolButton();
            this.uiClearStatus = new Sunny.UI.UISymbolButton();
            this.btnCheckStains = new Sunny.UI.UISymbolButton();
            this.btnCheckCenter = new Sunny.UI.UISymbolButton();
            this.uiPLCconnect = new Sunny.UI.UISymbolButton();
            this.uiPlcDisconnect = new Sunny.UI.UISymbolButton();
            this.uiSwitch1 = new Sunny.UI.UISwitch();
            this.uiMillisecondTimer1 = new Sunny.UI.UIMillisecondTimer(this.components);
            this.uiTitlePanel1.SuspendLayout();
            this.uiTitlePanelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSplitContainer1)).BeginInit();
            this.uiSplitContainer1.Panel1.SuspendLayout();
            this.uiSplitContainer1.Panel2.SuspendLayout();
            this.uiSplitContainer1.SuspendLayout();
            this.uiTableLayoutPanel3.SuspendLayout();
            this.uiTitlePanel4.SuspendLayout();
            this.uiTitlePanelStains.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSplitContainer2)).BeginInit();
            this.uiSplitContainer2.Panel1.SuspendLayout();
            this.uiSplitContainer2.Panel2.SuspendLayout();
            this.uiSplitContainer2.SuspendLayout();
            this.uiTableLayoutPanel1.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            this.uiQuickPanel.SuspendLayout();
            this.uiTableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtb_Log
            // 
            this.rtb_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Log.FillColor = System.Drawing.Color.White;
            this.rtb_Log.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtb_Log.Location = new System.Drawing.Point(1, 35);
            this.rtb_Log.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtb_Log.MinimumSize = new System.Drawing.Size(1, 1);
            this.rtb_Log.Name = "rtb_Log";
            this.rtb_Log.Padding = new System.Windows.Forms.Padding(2);
            this.rtb_Log.Radius = 1;
            this.rtb_Log.ShowText = false;
            this.rtb_Log.Size = new System.Drawing.Size(587, 395);
            this.rtb_Log.TabIndex = 0;
            this.rtb_Log.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.rtb_Log.TextChanged += new System.EventHandler(this.rtb_Log_TextChanged);
            // 
            // uiTitlePanel1
            // 
            this.uiTitlePanel1.Controls.Add(this.rtb_Log);
            this.uiTitlePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTitlePanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanel1.Location = new System.Drawing.Point(0, 0);
            this.uiTitlePanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel1.Name = "uiTitlePanel1";
            this.uiTitlePanel1.Padding = new System.Windows.Forms.Padding(1, 35, 1, 1);
            this.uiTitlePanel1.ShowText = false;
            this.uiTitlePanel1.Size = new System.Drawing.Size(589, 431);
            this.uiTitlePanel1.TabIndex = 1;
            this.uiTitlePanel1.Text = "LOG";
            this.uiTitlePanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTitlePanelCenter
            // 
            this.uiTitlePanelCenter.Controls.Add(this.vmRenderControl1);
            this.uiTitlePanelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTitlePanelCenter.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanelCenter.Location = new System.Drawing.Point(4, 5);
            this.uiTitlePanelCenter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanelCenter.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanelCenter.Name = "uiTitlePanelCenter";
            this.uiTitlePanelCenter.Padding = new System.Windows.Forms.Padding(1, 35, 1, 1);
            this.uiTitlePanelCenter.ShowText = false;
            this.uiTitlePanelCenter.Size = new System.Drawing.Size(645, 428);
            this.uiTitlePanelCenter.TabIndex = 2;
            this.uiTitlePanelCenter.Text = "CenterCheck Camera Viewer";
            this.uiTitlePanelCenter.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanelCenter.ZoomScaleDisabled = true;
            // 
            // vmRenderControl1
            // 
            this.vmRenderControl1.BackColor = System.Drawing.Color.Black;
            this.vmRenderControl1.CoordinateInfoVisible = true;
            this.vmRenderControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vmRenderControl1.ImageSource = null;
            this.vmRenderControl1.IsShowCustomROIMenu = false;
            this.vmRenderControl1.Location = new System.Drawing.Point(1, 35);
            this.vmRenderControl1.Margin = new System.Windows.Forms.Padding(724, 2069, 724, 2069);
            this.vmRenderControl1.ModuleSource = null;
            this.vmRenderControl1.Name = "vmRenderControl1";
            this.vmRenderControl1.Size = new System.Drawing.Size(643, 392);
            this.vmRenderControl1.TabIndex = 1;
            // 
            // uiSplitContainer1
            // 
            this.uiSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.uiSplitContainer1.IsSplitterFixed = true;
            this.uiSplitContainer1.Location = new System.Drawing.Point(0, 35);
            this.uiSplitContainer1.MinimumSize = new System.Drawing.Size(20, 20);
            this.uiSplitContainer1.Name = "uiSplitContainer1";
            // 
            // uiSplitContainer1.Panel1
            // 
            this.uiSplitContainer1.Panel1.Controls.Add(this.uiTableLayoutPanel3);
            // 
            // uiSplitContainer1.Panel2
            // 
            this.uiSplitContainer1.Panel2.Controls.Add(this.uiSplitContainer2);
            this.uiSplitContainer1.Size = new System.Drawing.Size(1900, 877);
            this.uiSplitContainer1.SplitterDistance = 1306;
            this.uiSplitContainer1.SplitterWidth = 5;
            this.uiSplitContainer1.TabIndex = 1;
            // 
            // uiTableLayoutPanel3
            // 
            this.uiTableLayoutPanel3.ColumnCount = 2;
            this.uiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel3.Controls.Add(this.uiTitlePanel4, 0, 1);
            this.uiTableLayoutPanel3.Controls.Add(this.uiTitlePanelCenter, 0, 0);
            this.uiTableLayoutPanel3.Controls.Add(this.uiTitlePanelStains, 1, 0);
            this.uiTableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.uiTableLayoutPanel3.Name = "uiTableLayoutPanel3";
            this.uiTableLayoutPanel3.RowCount = 2;
            this.uiTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel3.Size = new System.Drawing.Size(1306, 877);
            this.uiTableLayoutPanel3.TabIndex = 3;
            this.uiTableLayoutPanel3.TagString = null;
            // 
            // uiTitlePanel4
            // 
            this.uiTitlePanel4.Controls.Add(this.vmRenderControl3);
            this.uiTitlePanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTitlePanel4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanel4.Location = new System.Drawing.Point(4, 443);
            this.uiTitlePanel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel4.Name = "uiTitlePanel4";
            this.uiTitlePanel4.Padding = new System.Windows.Forms.Padding(1, 35, 1, 1);
            this.uiTitlePanel4.ShowText = false;
            this.uiTitlePanel4.Size = new System.Drawing.Size(645, 429);
            this.uiTitlePanel4.TabIndex = 3;
            this.uiTitlePanel4.Text = "Helper Camera Viewer";
            this.uiTitlePanel4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanel4.ZoomScaleDisabled = true;
            // 
            // vmRenderControl3
            // 
            this.vmRenderControl3.BackColor = System.Drawing.Color.Black;
            this.vmRenderControl3.CoordinateInfoVisible = true;
            this.vmRenderControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vmRenderControl3.ImageSource = null;
            this.vmRenderControl3.IsShowCustomROIMenu = false;
            this.vmRenderControl3.Location = new System.Drawing.Point(1, 35);
            this.vmRenderControl3.Margin = new System.Windows.Forms.Padding(901, 2759, 901, 2759);
            this.vmRenderControl3.ModuleSource = null;
            this.vmRenderControl3.Name = "vmRenderControl3";
            this.vmRenderControl3.Size = new System.Drawing.Size(643, 393);
            this.vmRenderControl3.TabIndex = 1;
            // 
            // uiTitlePanelStains
            // 
            this.uiTitlePanelStains.Controls.Add(this.vmRenderControl2);
            this.uiTitlePanelStains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTitlePanelStains.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanelStains.Location = new System.Drawing.Point(657, 5);
            this.uiTitlePanelStains.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanelStains.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanelStains.Name = "uiTitlePanelStains";
            this.uiTitlePanelStains.Padding = new System.Windows.Forms.Padding(1, 35, 1, 1);
            this.uiTitlePanelStains.ShowText = false;
            this.uiTitlePanelStains.Size = new System.Drawing.Size(645, 428);
            this.uiTitlePanelStains.TabIndex = 3;
            this.uiTitlePanelStains.Text = "StainsCheck Camera Viewer";
            this.uiTitlePanelStains.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanelStains.ZoomScaleDisabled = true;
            // 
            // vmRenderControl2
            // 
            this.vmRenderControl2.BackColor = System.Drawing.Color.Black;
            this.vmRenderControl2.CoordinateInfoVisible = true;
            this.vmRenderControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vmRenderControl2.ImageSource = null;
            this.vmRenderControl2.IsShowCustomROIMenu = false;
            this.vmRenderControl2.Location = new System.Drawing.Point(1, 35);
            this.vmRenderControl2.Margin = new System.Windows.Forms.Padding(901, 2759, 901, 2759);
            this.vmRenderControl2.ModuleSource = null;
            this.vmRenderControl2.Name = "vmRenderControl2";
            this.vmRenderControl2.Size = new System.Drawing.Size(643, 392);
            this.vmRenderControl2.TabIndex = 1;
            // 
            // uiSplitContainer2
            // 
            this.uiSplitContainer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.uiSplitContainer2.MinimumSize = new System.Drawing.Size(20, 20);
            this.uiSplitContainer2.Name = "uiSplitContainer2";
            this.uiSplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // uiSplitContainer2.Panel1
            // 
            this.uiSplitContainer2.Panel1.Controls.Add(this.uiTableLayoutPanel1);
            // 
            // uiSplitContainer2.Panel2
            // 
            this.uiSplitContainer2.Panel2.Controls.Add(this.uiTitlePanel1);
            this.uiSplitContainer2.Size = new System.Drawing.Size(589, 877);
            this.uiSplitContainer2.SplitterDistance = 435;
            this.uiSplitContainer2.SplitterWidth = 11;
            this.uiSplitContainer2.TabIndex = 2;
            // 
            // uiTableLayoutPanel1
            // 
            this.uiTableLayoutPanel1.ColumnCount = 2;
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel1.Controls.Add(this.LblRate, 1, 5);
            this.uiTableLayoutPanel1.Controls.Add(this.uiRate, 0, 5);
            this.uiTableLayoutPanel1.Controls.Add(this.LblPass, 1, 4);
            this.uiTableLayoutPanel1.Controls.Add(this.uiPass, 0, 4);
            this.uiTableLayoutPanel1.Controls.Add(this.LblTotal, 1, 3);
            this.uiTableLayoutPanel1.Controls.Add(this.uiCount, 0, 3);
            this.uiTableLayoutPanel1.Controls.Add(this.LblStatus, 0, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.uiStartTime, 0, 2);
            this.uiTableLayoutPanel1.Controls.Add(this.LblStartTime, 1, 2);
            this.uiTableLayoutPanel1.Controls.Add(this.uiGroupBox1, 0, 6);
            this.uiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            this.uiTableLayoutPanel1.RowCount = 11;
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.uiTableLayoutPanel1.Size = new System.Drawing.Size(589, 435);
            this.uiTableLayoutPanel1.TabIndex = 0;
            this.uiTableLayoutPanel1.TagString = null;
            // 
            // LblRate
            // 
            this.LblRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblRate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.LblRate.Location = new System.Drawing.Point(297, 180);
            this.LblRate.Name = "LblRate";
            this.LblRate.Size = new System.Drawing.Size(289, 30);
            this.LblRate.TabIndex = 8;
            this.LblRate.Text = "0.00";
            this.LblRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiRate
            // 
            this.uiRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiRate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiRate.Location = new System.Drawing.Point(3, 183);
            this.uiRate.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRate.Name = "uiRate";
            this.uiRate.Size = new System.Drawing.Size(288, 24);
            this.uiRate.Symbol = 57385;
            this.uiRate.TabIndex = 7;
            this.uiRate.Text = "Rate";
            this.uiRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPass
            // 
            this.LblPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPass.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.LblPass.Location = new System.Drawing.Point(297, 150);
            this.LblPass.Name = "LblPass";
            this.LblPass.Size = new System.Drawing.Size(289, 30);
            this.LblPass.TabIndex = 6;
            this.LblPass.Text = "0";
            this.LblPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiPass
            // 
            this.uiPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPass.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPass.Location = new System.Drawing.Point(3, 153);
            this.uiPass.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPass.Name = "uiPass";
            this.uiPass.Size = new System.Drawing.Size(288, 24);
            this.uiPass.Symbol = 559208;
            this.uiPass.TabIndex = 5;
            this.uiPass.Text = "Pass";
            this.uiPass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTotal
            // 
            this.LblTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblTotal.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.LblTotal.Location = new System.Drawing.Point(297, 120);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(289, 30);
            this.LblTotal.TabIndex = 4;
            this.LblTotal.Text = "0";
            this.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiCount
            // 
            this.uiCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiCount.Location = new System.Drawing.Point(3, 123);
            this.uiCount.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCount.Name = "uiCount";
            this.uiCount.Size = new System.Drawing.Size(288, 24);
            this.uiCount.Symbol = 561553;
            this.uiCount.TabIndex = 3;
            this.uiCount.Text = "Total";
            this.uiCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblStatus
            // 
            this.LblStatus.BackColor = System.Drawing.Color.Yellow;
            this.uiTableLayoutPanel1.SetColumnSpan(this.LblStatus, 2);
            this.LblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblStatus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblStatus.Location = new System.Drawing.Point(3, 3);
            this.LblStatus.MinimumSize = new System.Drawing.Size(1, 1);
            this.LblStatus.Name = "LblStatus";
            this.uiTableLayoutPanel1.SetRowSpan(this.LblStatus, 2);
            this.LblStatus.Size = new System.Drawing.Size(583, 84);
            this.LblStatus.Symbol = 61530;
            this.LblStatus.SymbolSize = 50;
            this.LblStatus.TabIndex = 0;
            this.LblStatus.Text = "Status Data";
            // 
            // uiStartTime
            // 
            this.uiStartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiStartTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiStartTime.Location = new System.Drawing.Point(3, 93);
            this.uiStartTime.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiStartTime.Name = "uiStartTime";
            this.uiStartTime.Size = new System.Drawing.Size(288, 24);
            this.uiStartTime.Symbol = 558405;
            this.uiStartTime.TabIndex = 1;
            this.uiStartTime.Text = "StartTime";
            this.uiStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblStartTime
            // 
            this.LblStartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblStartTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblStartTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.LblStartTime.Location = new System.Drawing.Point(297, 90);
            this.LblStartTime.Name = "LblStartTime";
            this.LblStartTime.Size = new System.Drawing.Size(289, 30);
            this.LblStartTime.TabIndex = 2;
            this.LblStartTime.Text = "0000/00/00 00:00:00";
            this.LblStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiGroupBox1
            // 
            this.uiTableLayoutPanel1.SetColumnSpan(this.uiGroupBox1, 2);
            this.uiGroupBox1.Controls.Add(this.uiQuickPanel);
            this.uiGroupBox1.Controls.Add(this.uiSwitch1);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(4, 215);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiTableLayoutPanel1.SetRowSpan(this.uiGroupBox1, 5);
            this.uiGroupBox1.Size = new System.Drawing.Size(581, 215);
            this.uiGroupBox1.TabIndex = 9;
            this.uiGroupBox1.Text = "Quick Test Button";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiQuickPanel
            // 
            this.uiQuickPanel.Controls.Add(this.uiTurnSwitch1);
            this.uiQuickPanel.Controls.Add(this.uiTableLayoutPanel2);
            this.uiQuickPanel.Enabled = false;
            this.uiQuickPanel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiQuickPanel.Location = new System.Drawing.Point(4, 54);
            this.uiQuickPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiQuickPanel.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiQuickPanel.Name = "uiQuickPanel";
            this.uiQuickPanel.Size = new System.Drawing.Size(577, 156);
            this.uiQuickPanel.TabIndex = 4;
            this.uiQuickPanel.Text = null;
            this.uiQuickPanel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTurnSwitch1
            // 
            this.uiTurnSwitch1.ActiveText = "Auto";
            this.uiTurnSwitch1.BackColor = System.Drawing.Color.Gray;
            this.uiTurnSwitch1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTurnSwitch1.InActiveText = "Manual";
            this.uiTurnSwitch1.Location = new System.Drawing.Point(3, 2);
            this.uiTurnSwitch1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTurnSwitch1.Name = "uiTurnSwitch1";
            this.uiTurnSwitch1.Size = new System.Drawing.Size(234, 143);
            this.uiTurnSwitch1.TabIndex = 0;
            this.uiTurnSwitch1.Text = "uiTurnSwitch1";
            this.uiTurnSwitch1.Click += new System.EventHandler(this.uiTurnSwitch1_Click);
            // 
            // uiTableLayoutPanel2
            // 
            this.uiTableLayoutPanel2.ColumnCount = 2;
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.uiTableLayoutPanel2.Controls.Add(this.btnHelper, 0, 3);
            this.uiTableLayoutPanel2.Controls.Add(this.uiClearStatus, 0, 2);
            this.uiTableLayoutPanel2.Controls.Add(this.btnCheckStains, 1, 1);
            this.uiTableLayoutPanel2.Controls.Add(this.btnCheckCenter, 0, 1);
            this.uiTableLayoutPanel2.Controls.Add(this.uiPLCconnect, 1, 0);
            this.uiTableLayoutPanel2.Controls.Add(this.uiPlcDisconnect, 0, 0);
            this.uiTableLayoutPanel2.Location = new System.Drawing.Point(243, 9);
            this.uiTableLayoutPanel2.Name = "uiTableLayoutPanel2";
            this.uiTableLayoutPanel2.RowCount = 4;
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel2.Size = new System.Drawing.Size(331, 136);
            this.uiTableLayoutPanel2.TabIndex = 3;
            this.uiTableLayoutPanel2.TagString = null;
            // 
            // btnHelper
            // 
            this.btnHelper.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHelper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHelper.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHelper.Location = new System.Drawing.Point(3, 105);
            this.btnHelper.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnHelper.Name = "btnHelper";
            this.btnHelper.Size = new System.Drawing.Size(159, 28);
            this.btnHelper.Symbol = 61515;
            this.btnHelper.TabIndex = 5;
            this.btnHelper.Text = "Start Helper";
            this.btnHelper.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHelper.Click += new System.EventHandler(this.btnHelper_Click);
            // 
            // uiClearStatus
            // 
            this.uiClearStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiClearStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiClearStatus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiClearStatus.Location = new System.Drawing.Point(3, 71);
            this.uiClearStatus.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiClearStatus.Name = "uiClearStatus";
            this.uiClearStatus.Size = new System.Drawing.Size(159, 28);
            this.uiClearStatus.Symbol = 61473;
            this.uiClearStatus.TabIndex = 4;
            this.uiClearStatus.Text = "Clear Status";
            this.uiClearStatus.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiClearStatus.Click += new System.EventHandler(this.uiClearStatus_Click);
            // 
            // btnCheckStains
            // 
            this.btnCheckStains.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckStains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCheckStains.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCheckStains.Location = new System.Drawing.Point(168, 37);
            this.btnCheckStains.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCheckStains.Name = "btnCheckStains";
            this.btnCheckStains.Size = new System.Drawing.Size(160, 28);
            this.btnCheckStains.Symbol = 561567;
            this.btnCheckStains.TabIndex = 3;
            this.btnCheckStains.Text = "Check Stains";
            this.btnCheckStains.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCheckStains.Click += new System.EventHandler(this.btnCheckStains_Click);
            // 
            // btnCheckCenter
            // 
            this.btnCheckCenter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCheckCenter.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCheckCenter.Location = new System.Drawing.Point(3, 37);
            this.btnCheckCenter.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCheckCenter.Name = "btnCheckCenter";
            this.btnCheckCenter.Size = new System.Drawing.Size(159, 28);
            this.btnCheckCenter.Symbol = 559644;
            this.btnCheckCenter.TabIndex = 2;
            this.btnCheckCenter.Text = "Check Center";
            this.btnCheckCenter.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCheckCenter.Click += new System.EventHandler(this.btnCheckCenter_Click);
            // 
            // uiPLCconnect
            // 
            this.uiPLCconnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiPLCconnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPLCconnect.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPLCconnect.Location = new System.Drawing.Point(168, 3);
            this.uiPLCconnect.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPLCconnect.Name = "uiPLCconnect";
            this.uiPLCconnect.Size = new System.Drawing.Size(160, 28);
            this.uiPLCconnect.Symbol = 560239;
            this.uiPLCconnect.TabIndex = 1;
            this.uiPLCconnect.Text = "PLC Connect";
            this.uiPLCconnect.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPLCconnect.Click += new System.EventHandler(this.uiPLCconnect_Click);
            // 
            // uiPlcDisconnect
            // 
            this.uiPlcDisconnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiPlcDisconnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPlcDisconnect.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPlcDisconnect.Location = new System.Drawing.Point(3, 3);
            this.uiPlcDisconnect.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPlcDisconnect.Name = "uiPlcDisconnect";
            this.uiPlcDisconnect.Size = new System.Drawing.Size(159, 28);
            this.uiPlcDisconnect.Symbol = 560238;
            this.uiPlcDisconnect.TabIndex = 0;
            this.uiPlcDisconnect.Text = "PLC Disconnect";
            this.uiPlcDisconnect.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPlcDisconnect.Click += new System.EventHandler(this.uiPlcDisconnect_Click);
            // 
            // uiSwitch1
            // 
            this.uiSwitch1.ActiveText = "Enable";
            this.uiSwitch1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSwitch1.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSwitch1.InActiveText = "Unable";
            this.uiSwitch1.Location = new System.Drawing.Point(500, 23);
            this.uiSwitch1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSwitch1.Name = "uiSwitch1";
            this.uiSwitch1.Size = new System.Drawing.Size(75, 23);
            this.uiSwitch1.TabIndex = 2;
            this.uiSwitch1.Text = "uiSwitch1";
            this.uiSwitch1.ValueChanged += new Sunny.UI.UISwitch.OnValueChanged(this.uiSwitch1_ValueChanged);
            // 
            // uiMillisecondTimer1
            // 
            this.uiMillisecondTimer1.Interval = 200;
            this.uiMillisecondTimer1.Tick += new System.EventHandler(this.uiMillisecondTimer1_Tick);
            // 
            // MainPage
            // 
            this.AllowAddControlOnTitle = true;
            this.AllowShowTitle = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1900, 912);
            this.Controls.Add(this.uiSplitContainer1);
            this.Name = "MainPage";
            this.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.ShowTitle = true;
            this.Symbol = 57460;
            this.Text = "MainPage";
            this.AfterShown += new System.EventHandler(this.MainPage_AfterShown);
            this.uiTitlePanel1.ResumeLayout(false);
            this.uiTitlePanelCenter.ResumeLayout(false);
            this.uiSplitContainer1.Panel1.ResumeLayout(false);
            this.uiSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiSplitContainer1)).EndInit();
            this.uiSplitContainer1.ResumeLayout(false);
            this.uiTableLayoutPanel3.ResumeLayout(false);
            this.uiTitlePanel4.ResumeLayout(false);
            this.uiTitlePanelStains.ResumeLayout(false);
            this.uiSplitContainer2.Panel1.ResumeLayout(false);
            this.uiSplitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiSplitContainer2)).EndInit();
            this.uiSplitContainer2.ResumeLayout(false);
            this.uiTableLayoutPanel1.ResumeLayout(false);
            this.uiGroupBox1.ResumeLayout(false);
            this.uiQuickPanel.ResumeLayout(false);
            this.uiTableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIRichTextBox rtb_Log;
        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private Sunny.UI.UITitlePanel uiTitlePanelCenter;
        private Sunny.UI.UISplitContainer uiSplitContainer1;
        private Sunny.UI.UISplitContainer uiSplitContainer2;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UISymbolLabel LblStatus;
        private Sunny.UI.UILabel LblTotal;
        private Sunny.UI.UISymbolLabel uiCount;
        private Sunny.UI.UISymbolLabel uiStartTime;
        private Sunny.UI.UILabel LblStartTime;
        private Sunny.UI.UILabel LblRate;
        private Sunny.UI.UISymbolLabel uiRate;
        private Sunny.UI.UILabel LblPass;
        private Sunny.UI.UISymbolLabel uiPass;
        private VMControls.Winform.Release.VmRenderControl vmRenderControl1;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UITurnSwitch uiTurnSwitch1;
        private Sunny.UI.UISwitch uiSwitch1;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel2;
        private Sunny.UI.UISymbolButton uiClearStatus;
        private Sunny.UI.UISymbolButton btnCheckStains;
        private Sunny.UI.UISymbolButton btnCheckCenter;
        private Sunny.UI.UISymbolButton uiPLCconnect;
        private Sunny.UI.UISymbolButton uiPlcDisconnect;
        private Sunny.UI.UIPanel uiQuickPanel;
        private Sunny.UI.UIMillisecondTimer uiMillisecondTimer1;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel3;
        private Sunny.UI.UITitlePanel uiTitlePanel4;
        private VMControls.Winform.Release.VmRenderControl vmRenderControl3;
        private Sunny.UI.UITitlePanel uiTitlePanelStains;
        private VMControls.Winform.Release.VmRenderControl vmRenderControl2;
        private Sunny.UI.UISymbolButton btnHelper;
    }
}
