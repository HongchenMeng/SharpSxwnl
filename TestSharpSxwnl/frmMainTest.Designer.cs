namespace TestSharpSxwnl
{
    partial class frmMainTest
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
            this.components = new System.ComponentModel.Container();
            this.webBrowserMonth = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.Cal_y = new System.Windows.Forms.TextBox();
            this.Cal_m = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnBazi = new System.Windows.Forms.Button();
            this.Cml_m = new System.Windows.Forms.TextBox();
            this.Cml_y = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Cml_d = new System.Windows.Forms.TextBox();
            this.Cml_his = new System.Windows.Forms.TextBox();
            this.txtBazi = new System.Windows.Forms.TextBox();
            this.Sel_zhou = new System.Windows.Forms.ComboBox();
            this.Sel_dq = new System.Windows.Forms.ComboBox();
            this.Sel_Region = new System.Windows.Forms.ComboBox();
            this.Sel_Province = new System.Windows.Forms.ComboBox();
            this.Sel_sqsm = new System.Windows.Forms.Label();
            this.txtLongitude = new System.Windows.Forms.TextBox();
            this.Cal_zdzb = new System.Windows.Forms.Label();
            this.Cal5 = new System.Windows.Forms.TextBox();
            this.Cal_pan = new System.Windows.Forms.TextBox();
            this.timerTick = new System.Windows.Forms.Timer(this.components);
            this.Cal_pause = new System.Windows.Forms.CheckBox();
            this.Cal_zb = new System.Windows.Forms.TextBox();
            this.lblLocalClock = new System.Windows.Forms.Label();
            this.lblSQClock = new System.Windows.Forms.Label();
            this.tabControlCal = new System.Windows.Forms.TabControl();
            this.tabPageMonthCal = new System.Windows.Forms.TabPage();
            this.tabPageTextMonthCal = new System.Windows.Forms.TabPage();
            this.txtPg0_Text = new System.Windows.Forms.TextBox();
            this.txtPg2_Text = new System.Windows.Forms.TextBox();
            this.txtPg1_Text = new System.Windows.Forms.TextBox();
            this.tabPageYearCal = new System.Windows.Forms.TabPage();
            this.Caly_y = new System.Windows.Forms.TextBox();
            this.btnMakeCaly = new System.Windows.Forms.Button();
            this.lblCaly = new System.Windows.Forms.Label();
            this.webBrowserYearCal = new System.Windows.Forms.WebBrowser();
            this.tabPageBaZi = new System.Windows.Forms.TabPage();
            this.cmbBaziTypeS = new System.Windows.Forms.ComboBox();
            this.chkCalcQi = new System.Windows.Forms.CheckBox();
            this.chkCalcJie = new System.Windows.Forms.CheckBox();
            this.btnBaZiBeijing = new System.Windows.Forms.Button();
            this.btnTestNewMethod = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBaZiNormal = new System.Windows.Forms.Button();
            this.tabPageOthers = new System.Windows.Forms.TabPage();
            this.btnTestOthers2 = new System.Windows.Forms.Button();
            this.btnGetRi12Jian = new System.Windows.Forms.Button();
            this.btnTestOthers = new System.Windows.Forms.Button();
            this.btnTestHelperClass = new System.Windows.Forms.Button();
            this.tabPageTools = new System.Windows.Forms.TabPage();
            this.btnLoadXmlSQ = new System.Windows.Forms.Button();
            this.btnLoadXmlJieqiFjia = new System.Windows.Forms.Button();
            this.btnLoadXmlJW = new System.Windows.Forms.Button();
            this.bntLoadXmlLunarJieri = new System.Windows.Forms.Button();
            this.btnLoadXmlsFtv = new System.Windows.Forms.Button();
            this.btnLoadwFtv = new System.Windows.Forms.Button();
            this.btnLoadXML = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnOutputJnbData = new System.Windows.Forms.Button();
            this.btndingQiV = new System.Windows.Forms.Button();
            this.btndingSuoV = new System.Windows.Forms.Button();
            this.tabControlCal.SuspendLayout();
            this.tabPageMonthCal.SuspendLayout();
            this.tabPageTextMonthCal.SuspendLayout();
            this.tabPageYearCal.SuspendLayout();
            this.tabPageBaZi.SuspendLayout();
            this.tabPageOthers.SuspendLayout();
            this.tabPageTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowserMonth
            // 
            this.webBrowserMonth.Location = new System.Drawing.Point(10, 37);
            this.webBrowserMonth.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserMonth.Name = "webBrowserMonth";
            this.webBrowserMonth.Size = new System.Drawing.Size(474, 521);
            this.webBrowserMonth.TabIndex = 0;
            this.webBrowserMonth.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowserMonth_DocumentCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "        年    月";
            // 
            // Cal_y
            // 
            this.Cal_y.Location = new System.Drawing.Point(10, 10);
            this.Cal_y.Name = "Cal_y";
            this.Cal_y.Size = new System.Drawing.Size(44, 21);
            this.Cal_y.TabIndex = 2;
            // 
            // Cal_m
            // 
            this.Cal_m.Location = new System.Drawing.Point(74, 10);
            this.Cal_m.Name = "Cal_m";
            this.Cal_m.Size = new System.Drawing.Size(21, 21);
            this.Cal_m.TabIndex = 3;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(117, 8);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(49, 23);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "确定";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnBazi
            // 
            this.btnBazi.Location = new System.Drawing.Point(258, 10);
            this.btnBazi.Name = "btnBazi";
            this.btnBazi.Size = new System.Drawing.Size(119, 23);
            this.btnBazi.TabIndex = 9;
            this.btnBazi.Text = "当地真太阳时八字";
            this.btnBazi.UseVisualStyleBackColor = true;
            this.btnBazi.Click += new System.EventHandler(this.btnBazi_Click);
            // 
            // Cml_m
            // 
            this.Cml_m.Location = new System.Drawing.Point(74, 12);
            this.Cml_m.Name = "Cml_m";
            this.Cml_m.Size = new System.Drawing.Size(21, 21);
            this.Cml_m.TabIndex = 8;
            // 
            // Cml_y
            // 
            this.Cml_y.Location = new System.Drawing.Point(10, 12);
            this.Cml_y.Name = "Cml_y";
            this.Cml_y.Size = new System.Drawing.Size(44, 21);
            this.Cml_y.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "        年    月     日";
            // 
            // Cml_d
            // 
            this.Cml_d.Location = new System.Drawing.Point(112, 12);
            this.Cml_d.Name = "Cml_d";
            this.Cml_d.Size = new System.Drawing.Size(21, 21);
            this.Cml_d.TabIndex = 10;
            // 
            // Cml_his
            // 
            this.Cml_his.Location = new System.Drawing.Point(159, 12);
            this.Cml_his.Name = "Cml_his";
            this.Cml_his.Size = new System.Drawing.Size(82, 21);
            this.Cml_his.TabIndex = 11;
            // 
            // txtBazi
            // 
            this.txtBazi.Location = new System.Drawing.Point(10, 149);
            this.txtBazi.Multiline = true;
            this.txtBazi.Name = "txtBazi";
            this.txtBazi.ReadOnly = true;
            this.txtBazi.Size = new System.Drawing.Size(474, 417);
            this.txtBazi.TabIndex = 12;
            // 
            // Sel_zhou
            // 
            this.Sel_zhou.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Sel_zhou.FormattingEnabled = true;
            this.Sel_zhou.Location = new System.Drawing.Point(7, 29);
            this.Sel_zhou.MaxDropDownItems = 40;
            this.Sel_zhou.Name = "Sel_zhou";
            this.Sel_zhou.Size = new System.Drawing.Size(120, 20);
            this.Sel_zhou.TabIndex = 13;
            this.Sel_zhou.SelectedIndexChanged += new System.EventHandler(this.Sel_zhou_SelectedIndexChanged);
            // 
            // Sel_dq
            // 
            this.Sel_dq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Sel_dq.FormattingEnabled = true;
            this.Sel_dq.Location = new System.Drawing.Point(133, 29);
            this.Sel_dq.MaxDropDownItems = 40;
            this.Sel_dq.Name = "Sel_dq";
            this.Sel_dq.Size = new System.Drawing.Size(137, 20);
            this.Sel_dq.TabIndex = 14;
            this.Sel_dq.SelectedIndexChanged += new System.EventHandler(this.Sel_dq_SelectedIndexChanged);
            // 
            // Sel_Region
            // 
            this.Sel_Region.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Sel_Region.FormattingEnabled = true;
            this.Sel_Region.Location = new System.Drawing.Point(133, 72);
            this.Sel_Region.MaxDropDownItems = 40;
            this.Sel_Region.Name = "Sel_Region";
            this.Sel_Region.Size = new System.Drawing.Size(137, 20);
            this.Sel_Region.TabIndex = 16;
            this.Sel_Region.SelectedIndexChanged += new System.EventHandler(this.Sel_Region_SelectedIndexChanged);
            // 
            // Sel_Province
            // 
            this.Sel_Province.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Sel_Province.FormattingEnabled = true;
            this.Sel_Province.Location = new System.Drawing.Point(7, 72);
            this.Sel_Province.MaxDropDownItems = 40;
            this.Sel_Province.Name = "Sel_Province";
            this.Sel_Province.Size = new System.Drawing.Size(120, 20);
            this.Sel_Province.TabIndex = 15;
            this.Sel_Province.SelectedIndexChanged += new System.EventHandler(this.Sel_Province_SelectedIndexChanged);
            // 
            // Sel_sqsm
            // 
            this.Sel_sqsm.Location = new System.Drawing.Point(5, 52);
            this.Sel_sqsm.Name = "Sel_sqsm";
            this.Sel_sqsm.Size = new System.Drawing.Size(166, 16);
            this.Sel_sqsm.TabIndex = 17;
            this.Sel_sqsm.Text = "时区说明";
            this.Sel_sqsm.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtLongitude
            // 
            this.txtLongitude.Location = new System.Drawing.Point(123, 44);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.Size = new System.Drawing.Size(92, 21);
            this.txtLongitude.TabIndex = 18;
            this.txtLongitude.Text = "-102°42\'0\" 昆明";
            // 
            // Cal_zdzb
            // 
            this.Cal_zdzb.AutoSize = true;
            this.Cal_zdzb.Location = new System.Drawing.Point(7, 98);
            this.Cal_zdzb.Name = "Cal_zdzb";
            this.Cal_zdzb.Size = new System.Drawing.Size(65, 12);
            this.Cal_zdzb.TabIndex = 19;
            this.Cal_zdzb.Text = "经纬度坐标";
            // 
            // Cal5
            // 
            this.Cal5.Location = new System.Drawing.Point(7, 114);
            this.Cal5.Multiline = true;
            this.Cal5.Name = "Cal5";
            this.Cal5.ReadOnly = true;
            this.Cal5.Size = new System.Drawing.Size(273, 59);
            this.Cal5.TabIndex = 20;
            // 
            // Cal_pan
            // 
            this.Cal_pan.Location = new System.Drawing.Point(7, 421);
            this.Cal_pan.Multiline = true;
            this.Cal_pan.Name = "Cal_pan";
            this.Cal_pan.ReadOnly = true;
            this.Cal_pan.Size = new System.Drawing.Size(273, 187);
            this.Cal_pan.TabIndex = 21;
            // 
            // timerTick
            // 
            this.timerTick.Interval = 1000;
            this.timerTick.Tick += new System.EventHandler(this.timerTick_Tick);
            // 
            // Cal_pause
            // 
            this.Cal_pause.AutoSize = true;
            this.Cal_pause.Location = new System.Drawing.Point(198, 10);
            this.Cal_pause.Name = "Cal_pause";
            this.Cal_pause.Size = new System.Drawing.Size(72, 16);
            this.Cal_pause.TabIndex = 22;
            this.Cal_pause.Text = "时钟暂停";
            this.Cal_pause.UseVisualStyleBackColor = true;
            // 
            // Cal_zb
            // 
            this.Cal_zb.Location = new System.Drawing.Point(7, 176);
            this.Cal_zb.Multiline = true;
            this.Cal_zb.Name = "Cal_zb";
            this.Cal_zb.ReadOnly = true;
            this.Cal_zb.Size = new System.Drawing.Size(273, 237);
            this.Cal_zb.TabIndex = 23;
            // 
            // lblLocalClock
            // 
            this.lblLocalClock.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLocalClock.ForeColor = System.Drawing.Color.Firebrick;
            this.lblLocalClock.Location = new System.Drawing.Point(7, 6);
            this.lblLocalClock.Name = "lblLocalClock";
            this.lblLocalClock.Size = new System.Drawing.Size(191, 20);
            this.lblLocalClock.TabIndex = 24;
            this.lblLocalClock.Text = "当前本地时间";
            this.lblLocalClock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSQClock
            // 
            this.lblSQClock.AutoSize = true;
            this.lblSQClock.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSQClock.ForeColor = System.Drawing.Color.Blue;
            this.lblSQClock.Location = new System.Drawing.Point(177, 52);
            this.lblSQClock.Name = "lblSQClock";
            this.lblSQClock.Size = new System.Drawing.Size(57, 12);
            this.lblSQClock.TabIndex = 25;
            this.lblSQClock.Text = "时区时间";
            // 
            // tabControlCal
            // 
            this.tabControlCal.Controls.Add(this.tabPageMonthCal);
            this.tabControlCal.Controls.Add(this.tabPageTextMonthCal);
            this.tabControlCal.Controls.Add(this.tabPageYearCal);
            this.tabControlCal.Controls.Add(this.tabPageBaZi);
            this.tabControlCal.Controls.Add(this.tabPageOthers);
            this.tabControlCal.Controls.Add(this.tabPageTools);
            this.tabControlCal.Location = new System.Drawing.Point(295, 6);
            this.tabControlCal.Name = "tabControlCal";
            this.tabControlCal.SelectedIndex = 0;
            this.tabControlCal.Size = new System.Drawing.Size(502, 602);
            this.tabControlCal.TabIndex = 26;
            // 
            // tabPageMonthCal
            // 
            this.tabPageMonthCal.Controls.Add(this.webBrowserMonth);
            this.tabPageMonthCal.Controls.Add(this.Cal_y);
            this.tabPageMonthCal.Controls.Add(this.Cal_m);
            this.tabPageMonthCal.Controls.Add(this.btnGo);
            this.tabPageMonthCal.Controls.Add(this.label1);
            this.tabPageMonthCal.Location = new System.Drawing.Point(4, 21);
            this.tabPageMonthCal.Name = "tabPageMonthCal";
            this.tabPageMonthCal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMonthCal.Size = new System.Drawing.Size(494, 577);
            this.tabPageMonthCal.TabIndex = 0;
            this.tabPageMonthCal.Text = "月历";
            this.tabPageMonthCal.UseVisualStyleBackColor = true;
            // 
            // tabPageTextMonthCal
            // 
            this.tabPageTextMonthCal.Controls.Add(this.txtPg0_Text);
            this.tabPageTextMonthCal.Controls.Add(this.txtPg2_Text);
            this.tabPageTextMonthCal.Controls.Add(this.txtPg1_Text);
            this.tabPageTextMonthCal.Location = new System.Drawing.Point(4, 21);
            this.tabPageTextMonthCal.Name = "tabPageTextMonthCal";
            this.tabPageTextMonthCal.Size = new System.Drawing.Size(494, 577);
            this.tabPageTextMonthCal.TabIndex = 2;
            this.tabPageTextMonthCal.Text = "文本月历";
            this.tabPageTextMonthCal.UseVisualStyleBackColor = true;
            // 
            // txtPg0_Text
            // 
            this.txtPg0_Text.Location = new System.Drawing.Point(15, 13);
            this.txtPg0_Text.Multiline = true;
            this.txtPg0_Text.Name = "txtPg0_Text";
            this.txtPg0_Text.ReadOnly = true;
            this.txtPg0_Text.Size = new System.Drawing.Size(468, 24);
            this.txtPg0_Text.TabIndex = 26;
            // 
            // txtPg2_Text
            // 
            this.txtPg2_Text.Location = new System.Drawing.Point(15, 502);
            this.txtPg2_Text.Multiline = true;
            this.txtPg2_Text.Name = "txtPg2_Text";
            this.txtPg2_Text.ReadOnly = true;
            this.txtPg2_Text.Size = new System.Drawing.Size(468, 63);
            this.txtPg2_Text.TabIndex = 25;
            // 
            // txtPg1_Text
            // 
            this.txtPg1_Text.Location = new System.Drawing.Point(15, 47);
            this.txtPg1_Text.Multiline = true;
            this.txtPg1_Text.Name = "txtPg1_Text";
            this.txtPg1_Text.ReadOnly = true;
            this.txtPg1_Text.Size = new System.Drawing.Size(468, 449);
            this.txtPg1_Text.TabIndex = 24;
            // 
            // tabPageYearCal
            // 
            this.tabPageYearCal.Controls.Add(this.Caly_y);
            this.tabPageYearCal.Controls.Add(this.btnMakeCaly);
            this.tabPageYearCal.Controls.Add(this.lblCaly);
            this.tabPageYearCal.Controls.Add(this.webBrowserYearCal);
            this.tabPageYearCal.Location = new System.Drawing.Point(4, 21);
            this.tabPageYearCal.Name = "tabPageYearCal";
            this.tabPageYearCal.Size = new System.Drawing.Size(494, 577);
            this.tabPageYearCal.TabIndex = 3;
            this.tabPageYearCal.Text = "年历";
            this.tabPageYearCal.UseVisualStyleBackColor = true;
            // 
            // Caly_y
            // 
            this.Caly_y.Location = new System.Drawing.Point(12, 8);
            this.Caly_y.Name = "Caly_y";
            this.Caly_y.Size = new System.Drawing.Size(44, 21);
            this.Caly_y.TabIndex = 6;
            // 
            // btnMakeCaly
            // 
            this.btnMakeCaly.Location = new System.Drawing.Point(97, 6);
            this.btnMakeCaly.Name = "btnMakeCaly";
            this.btnMakeCaly.Size = new System.Drawing.Size(49, 23);
            this.btnMakeCaly.TabIndex = 7;
            this.btnMakeCaly.Text = "确定";
            this.btnMakeCaly.UseVisualStyleBackColor = true;
            this.btnMakeCaly.Click += new System.EventHandler(this.btnMakeCaly_Click);
            // 
            // lblCaly
            // 
            this.lblCaly.AutoSize = true;
            this.lblCaly.Location = new System.Drawing.Point(12, 11);
            this.lblCaly.Name = "lblCaly";
            this.lblCaly.Size = new System.Drawing.Size(65, 12);
            this.lblCaly.TabIndex = 5;
            this.lblCaly.Text = "        年";
            // 
            // webBrowserYearCal
            // 
            this.webBrowserYearCal.Location = new System.Drawing.Point(12, 35);
            this.webBrowserYearCal.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserYearCal.Name = "webBrowserYearCal";
            this.webBrowserYearCal.ScrollBarsEnabled = false;
            this.webBrowserYearCal.Size = new System.Drawing.Size(469, 532);
            this.webBrowserYearCal.TabIndex = 1;
            // 
            // tabPageBaZi
            // 
            this.tabPageBaZi.Controls.Add(this.cmbBaziTypeS);
            this.tabPageBaZi.Controls.Add(this.chkCalcQi);
            this.tabPageBaZi.Controls.Add(this.chkCalcJie);
            this.tabPageBaZi.Controls.Add(this.btnBaZiBeijing);
            this.tabPageBaZi.Controls.Add(this.btnTestNewMethod);
            this.tabPageBaZi.Controls.Add(this.label3);
            this.tabPageBaZi.Controls.Add(this.btnBaZiNormal);
            this.tabPageBaZi.Controls.Add(this.txtBazi);
            this.tabPageBaZi.Controls.Add(this.Cml_his);
            this.tabPageBaZi.Controls.Add(this.Cml_d);
            this.tabPageBaZi.Controls.Add(this.btnBazi);
            this.tabPageBaZi.Controls.Add(this.txtLongitude);
            this.tabPageBaZi.Controls.Add(this.Cml_y);
            this.tabPageBaZi.Controls.Add(this.Cml_m);
            this.tabPageBaZi.Controls.Add(this.label2);
            this.tabPageBaZi.Location = new System.Drawing.Point(4, 21);
            this.tabPageBaZi.Name = "tabPageBaZi";
            this.tabPageBaZi.Size = new System.Drawing.Size(494, 577);
            this.tabPageBaZi.TabIndex = 4;
            this.tabPageBaZi.Text = "八字计算";
            this.tabPageBaZi.UseVisualStyleBackColor = true;
            // 
            // cmbBaziTypeS
            // 
            this.cmbBaziTypeS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaziTypeS.FormattingEnabled = true;
            this.cmbBaziTypeS.Items.AddRange(new object[] {
            "常规(北半球八字)",
            "南半球八字: 天冲地冲(月天干地支均与北半球的取法相冲)",
            "南半球八字: 天克地冲(月地支与北半球的取法相冲, 按五虎遁月法排月天干)",
            "南半球八字: 天同地冲(月地支与北半球的取法相冲, 月天干与北半球的取法相同)"});
            this.cmbBaziTypeS.Location = new System.Drawing.Point(13, 76);
            this.cmbBaziTypeS.Name = "cmbBaziTypeS";
            this.cmbBaziTypeS.Size = new System.Drawing.Size(471, 20);
            this.cmbBaziTypeS.TabIndex = 24;
            // 
            // chkCalcQi
            // 
            this.chkCalcQi.AutoSize = true;
            this.chkCalcQi.Location = new System.Drawing.Point(442, 115);
            this.chkCalcQi.Name = "chkCalcQi";
            this.chkCalcQi.Size = new System.Drawing.Size(36, 16);
            this.chkCalcQi.TabIndex = 23;
            this.chkCalcQi.Text = "气";
            this.chkCalcQi.UseVisualStyleBackColor = true;
            // 
            // chkCalcJie
            // 
            this.chkCalcJie.AutoSize = true;
            this.chkCalcJie.Checked = true;
            this.chkCalcJie.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCalcJie.Location = new System.Drawing.Point(400, 115);
            this.chkCalcJie.Name = "chkCalcJie";
            this.chkCalcJie.Size = new System.Drawing.Size(36, 16);
            this.chkCalcJie.TabIndex = 22;
            this.chkCalcJie.Text = "节";
            this.chkCalcJie.UseVisualStyleBackColor = true;
            // 
            // btnBaZiBeijing
            // 
            this.btnBaZiBeijing.Location = new System.Drawing.Point(379, 38);
            this.btnBaZiBeijing.Name = "btnBaZiBeijing";
            this.btnBaZiBeijing.Size = new System.Drawing.Size(105, 23);
            this.btnBaZiBeijing.TabIndex = 21;
            this.btnBaZiBeijing.Text = "北京时间八字";
            this.btnBaZiBeijing.UseVisualStyleBackColor = true;
            this.btnBaZiBeijing.Click += new System.EventHandler(this.btnBaZiBeijing_Click);
            // 
            // btnTestNewMethod
            // 
            this.btnTestNewMethod.Location = new System.Drawing.Point(258, 111);
            this.btnTestNewMethod.Name = "btnTestNewMethod";
            this.btnTestNewMethod.Size = new System.Drawing.Size(136, 23);
            this.btnTestNewMethod.TabIndex = 10;
            this.btnTestNewMethod.Text = "计算该日期的节气信息";
            this.btnTestNewMethod.UseVisualStyleBackColor = true;
            this.btnTestNewMethod.Click += new System.EventHandler(this.btnTestNewMethod_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "经度(负数为东经):";
            // 
            // btnBaZiNormal
            // 
            this.btnBaZiNormal.Location = new System.Drawing.Point(258, 38);
            this.btnBaZiNormal.Name = "btnBaZiNormal";
            this.btnBaZiNormal.Size = new System.Drawing.Size(119, 23);
            this.btnBaZiNormal.TabIndex = 19;
            this.btnBaZiNormal.Text = "当地平太阳时八字";
            this.btnBaZiNormal.UseVisualStyleBackColor = true;
            this.btnBaZiNormal.Click += new System.EventHandler(this.btnBaZiNormal_Click);
            // 
            // tabPageOthers
            // 
            this.tabPageOthers.Controls.Add(this.btndingSuoV);
            this.tabPageOthers.Controls.Add(this.btndingQiV);
            this.tabPageOthers.Controls.Add(this.btnTestOthers2);
            this.tabPageOthers.Controls.Add(this.btnGetRi12Jian);
            this.tabPageOthers.Controls.Add(this.btnTestOthers);
            this.tabPageOthers.Controls.Add(this.btnTestHelperClass);
            this.tabPageOthers.Location = new System.Drawing.Point(4, 21);
            this.tabPageOthers.Name = "tabPageOthers";
            this.tabPageOthers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOthers.Size = new System.Drawing.Size(494, 577);
            this.tabPageOthers.TabIndex = 1;
            this.tabPageOthers.Text = "其他测试";
            this.tabPageOthers.UseVisualStyleBackColor = true;
            // 
            // btnTestOthers2
            // 
            this.btnTestOthers2.Enabled = false;
            this.btnTestOthers2.Location = new System.Drawing.Point(198, 43);
            this.btnTestOthers2.Name = "btnTestOthers2";
            this.btnTestOthers2.Size = new System.Drawing.Size(164, 23);
            this.btnTestOthers2.TabIndex = 12;
            this.btnTestOthers2.Text = "杂项测试2";
            this.btnTestOthers2.UseVisualStyleBackColor = true;
            this.btnTestOthers2.Click += new System.EventHandler(this.btnTestOthers2_Click);
            // 
            // btnGetRi12Jian
            // 
            this.btnGetRi12Jian.Location = new System.Drawing.Point(17, 43);
            this.btnGetRi12Jian.Name = "btnGetRi12Jian";
            this.btnGetRi12Jian.Size = new System.Drawing.Size(164, 23);
            this.btnGetRi12Jian.TabIndex = 11;
            this.btnGetRi12Jian.Text = "测试新增的方法: 十二日建";
            this.btnGetRi12Jian.UseVisualStyleBackColor = true;
            this.btnGetRi12Jian.Click += new System.EventHandler(this.btnGetRi12Jian_Click);
            // 
            // btnTestOthers
            // 
            this.btnTestOthers.Location = new System.Drawing.Point(198, 14);
            this.btnTestOthers.Name = "btnTestOthers";
            this.btnTestOthers.Size = new System.Drawing.Size(164, 23);
            this.btnTestOthers.TabIndex = 9;
            this.btnTestOthers.Text = "杂项测试";
            this.btnTestOthers.UseVisualStyleBackColor = true;
            this.btnTestOthers.Click += new System.EventHandler(this.btnTestOthers_Click);
            // 
            // btnTestHelperClass
            // 
            this.btnTestHelperClass.Location = new System.Drawing.Point(17, 14);
            this.btnTestHelperClass.Name = "btnTestHelperClass";
            this.btnTestHelperClass.Size = new System.Drawing.Size(164, 23);
            this.btnTestHelperClass.TabIndex = 8;
            this.btnTestHelperClass.Text = "测试 LunarHelper 类的方法";
            this.btnTestHelperClass.UseVisualStyleBackColor = true;
            this.btnTestHelperClass.Click += new System.EventHandler(this.btnTestHelperClass_Click);
            // 
            // tabPageTools
            // 
            this.tabPageTools.Controls.Add(this.btnLoadXmlSQ);
            this.tabPageTools.Controls.Add(this.btnLoadXmlJieqiFjia);
            this.tabPageTools.Controls.Add(this.btnLoadXmlJW);
            this.tabPageTools.Controls.Add(this.bntLoadXmlLunarJieri);
            this.tabPageTools.Controls.Add(this.btnLoadXmlsFtv);
            this.tabPageTools.Controls.Add(this.btnLoadwFtv);
            this.tabPageTools.Controls.Add(this.btnLoadXML);
            this.tabPageTools.Controls.Add(this.txtOutput);
            this.tabPageTools.Controls.Add(this.btnOutputJnbData);
            this.tabPageTools.Location = new System.Drawing.Point(4, 21);
            this.tabPageTools.Name = "tabPageTools";
            this.tabPageTools.Size = new System.Drawing.Size(494, 577);
            this.tabPageTools.TabIndex = 5;
            this.tabPageTools.Text = "辅助工具";
            this.tabPageTools.UseVisualStyleBackColor = true;
            // 
            // btnLoadXmlSQ
            // 
            this.btnLoadXmlSQ.Location = new System.Drawing.Point(160, 39);
            this.btnLoadXmlSQ.Name = "btnLoadXmlSQ";
            this.btnLoadXmlSQ.Size = new System.Drawing.Size(141, 23);
            this.btnLoadXmlSQ.TabIndex = 20;
            this.btnLoadXmlSQ.Text = "加载 XML 时区数据";
            this.btnLoadXmlSQ.UseVisualStyleBackColor = true;
            this.btnLoadXmlSQ.Click += new System.EventHandler(this.btnLoadXmlSQ_Click);
            // 
            // btnLoadXmlJieqiFjia
            // 
            this.btnLoadXmlJieqiFjia.Location = new System.Drawing.Point(307, 86);
            this.btnLoadXmlJieqiFjia.Name = "btnLoadXmlJieqiFjia";
            this.btnLoadXmlJieqiFjia.Size = new System.Drawing.Size(141, 23);
            this.btnLoadXmlJieqiFjia.TabIndex = 18;
            this.btnLoadXmlJieqiFjia.Text = "加载 XML 廿四节气假日";
            this.btnLoadXmlJieqiFjia.UseVisualStyleBackColor = true;
            this.btnLoadXmlJieqiFjia.Click += new System.EventHandler(this.btnLoadXmlJieqiFjia_Click);
            // 
            // btnLoadXmlJW
            // 
            this.btnLoadXmlJW.Location = new System.Drawing.Point(11, 38);
            this.btnLoadXmlJW.Name = "btnLoadXmlJW";
            this.btnLoadXmlJW.Size = new System.Drawing.Size(143, 23);
            this.btnLoadXmlJW.TabIndex = 19;
            this.btnLoadXmlJW.Text = "加载 XML 经纬度数据";
            this.btnLoadXmlJW.UseVisualStyleBackColor = true;
            this.btnLoadXmlJW.Click += new System.EventHandler(this.btnLoadXmlJW_Click);
            // 
            // bntLoadXmlLunarJieri
            // 
            this.bntLoadXmlLunarJieri.Location = new System.Drawing.Point(160, 87);
            this.bntLoadXmlLunarJieri.Name = "bntLoadXmlLunarJieri";
            this.bntLoadXmlLunarJieri.Size = new System.Drawing.Size(141, 23);
            this.bntLoadXmlLunarJieri.TabIndex = 17;
            this.bntLoadXmlLunarJieri.Text = "加载 XML 农历节假日";
            this.bntLoadXmlLunarJieri.UseVisualStyleBackColor = true;
            this.bntLoadXmlLunarJieri.Click += new System.EventHandler(this.bntLoadXmlLunarJieri_Click);
            // 
            // btnLoadXmlsFtv
            // 
            this.btnLoadXmlsFtv.Location = new System.Drawing.Point(11, 86);
            this.btnLoadXmlsFtv.Name = "btnLoadXmlsFtv";
            this.btnLoadXmlsFtv.Size = new System.Drawing.Size(143, 23);
            this.btnLoadXmlsFtv.TabIndex = 16;
            this.btnLoadXmlsFtv.Text = "加载 XML 公历节假日";
            this.btnLoadXmlsFtv.UseVisualStyleBackColor = true;
            this.btnLoadXmlsFtv.Click += new System.EventHandler(this.btnLoadXmlsFtv_Click);
            // 
            // btnLoadwFtv
            // 
            this.btnLoadwFtv.Location = new System.Drawing.Point(160, 63);
            this.btnLoadwFtv.Name = "btnLoadwFtv";
            this.btnLoadwFtv.Size = new System.Drawing.Size(141, 23);
            this.btnLoadwFtv.TabIndex = 15;
            this.btnLoadwFtv.Text = "加载 XML 周规则节假日";
            this.btnLoadwFtv.UseVisualStyleBackColor = true;
            this.btnLoadwFtv.Click += new System.EventHandler(this.btnLoadwFtv_Click);
            // 
            // btnLoadXML
            // 
            this.btnLoadXML.Location = new System.Drawing.Point(11, 63);
            this.btnLoadXML.Name = "btnLoadXML";
            this.btnLoadXML.Size = new System.Drawing.Size(143, 23);
            this.btnLoadXML.TabIndex = 14;
            this.btnLoadXML.Text = "加载 XML 纪年表数据";
            this.btnLoadXML.UseVisualStyleBackColor = true;
            this.btnLoadXML.Click += new System.EventHandler(this.btnLoadXML_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(11, 116);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(474, 451);
            this.txtOutput.TabIndex = 13;
            this.txtOutput.WordWrap = false;
            // 
            // btnOutputJnbData
            // 
            this.btnOutputJnbData.Location = new System.Drawing.Point(11, 10);
            this.btnOutputJnbData.Name = "btnOutputJnbData";
            this.btnOutputJnbData.Size = new System.Drawing.Size(180, 23);
            this.btnOutputJnbData.TabIndex = 0;
            this.btnOutputJnbData.Text = "输出全部硬编码数据至 XML";
            this.btnOutputJnbData.UseVisualStyleBackColor = true;
            this.btnOutputJnbData.Click += new System.EventHandler(this.btnOutputJnbData_Click);
            // 
            // btndingQiV
            // 
            this.btndingQiV.Location = new System.Drawing.Point(17, 187);
            this.btndingQiV.Name = "btndingQiV";
            this.btndingQiV.Size = new System.Drawing.Size(164, 23);
            this.btndingQiV.TabIndex = 13;
            this.btndingQiV.Text = "定气速度测试";
            this.btndingQiV.UseVisualStyleBackColor = true;
            this.btndingQiV.Click += new System.EventHandler(this.btndingQiV_Click);
            // 
            // btndingSuoV
            // 
            this.btndingSuoV.Location = new System.Drawing.Point(198, 187);
            this.btndingSuoV.Name = "btndingSuoV";
            this.btndingSuoV.Size = new System.Drawing.Size(164, 23);
            this.btndingSuoV.TabIndex = 14;
            this.btndingSuoV.Text = "定朔速度测试";
            this.btndingSuoV.UseVisualStyleBackColor = true;
            this.btndingSuoV.Click += new System.EventHandler(this.btndingSuoV_Click);
            // 
            // frmMainTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 614);
            this.Controls.Add(this.tabControlCal);
            this.Controls.Add(this.lblSQClock);
            this.Controls.Add(this.lblLocalClock);
            this.Controls.Add(this.Cal_zb);
            this.Controls.Add(this.Cal_pause);
            this.Controls.Add(this.Cal_pan);
            this.Controls.Add(this.Cal5);
            this.Controls.Add(this.Cal_zdzb);
            this.Controls.Add(this.Sel_sqsm);
            this.Controls.Add(this.Sel_Region);
            this.Controls.Add(this.Sel_Province);
            this.Controls.Add(this.Sel_dq);
            this.Controls.Add(this.Sel_zhou);
            this.Name = "frmMainTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "调试寿星万年历核心算法的转换";
            this.Load += new System.EventHandler(this.frmMainTest_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMainTest_FormClosed);
            this.tabControlCal.ResumeLayout(false);
            this.tabPageMonthCal.ResumeLayout(false);
            this.tabPageMonthCal.PerformLayout();
            this.tabPageTextMonthCal.ResumeLayout(false);
            this.tabPageTextMonthCal.PerformLayout();
            this.tabPageYearCal.ResumeLayout(false);
            this.tabPageYearCal.PerformLayout();
            this.tabPageBaZi.ResumeLayout(false);
            this.tabPageBaZi.PerformLayout();
            this.tabPageOthers.ResumeLayout(false);
            this.tabPageTools.ResumeLayout(false);
            this.tabPageTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Cal_y;
        private System.Windows.Forms.TextBox Cal_m;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnBazi;
        private System.Windows.Forms.TextBox Cml_m;
        private System.Windows.Forms.TextBox Cml_y;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Cml_d;
        private System.Windows.Forms.TextBox Cml_his;
        private System.Windows.Forms.TextBox txtBazi;
        private System.Windows.Forms.ComboBox Sel_zhou;
        private System.Windows.Forms.ComboBox Sel_dq;
        private System.Windows.Forms.ComboBox Sel_Region;
        private System.Windows.Forms.ComboBox Sel_Province;
        private System.Windows.Forms.Label Sel_sqsm;
        private System.Windows.Forms.TextBox txtLongitude;
        private System.Windows.Forms.Label Cal_zdzb;
        private System.Windows.Forms.TextBox Cal5;
        private System.Windows.Forms.TextBox Cal_pan;
        private System.Windows.Forms.Timer timerTick;
        private System.Windows.Forms.CheckBox Cal_pause;
        private System.Windows.Forms.TextBox Cal_zb;
        private System.Windows.Forms.Label lblLocalClock;
        private System.Windows.Forms.Label lblSQClock;
        private System.Windows.Forms.TabControl tabControlCal;
        private System.Windows.Forms.TabPage tabPageMonthCal;
        private System.Windows.Forms.TabPage tabPageOthers;
        private System.Windows.Forms.TabPage tabPageTextMonthCal;
        private System.Windows.Forms.TextBox txtPg0_Text;
        private System.Windows.Forms.TextBox txtPg2_Text;
        private System.Windows.Forms.TextBox txtPg1_Text;
        private System.Windows.Forms.TabPage tabPageYearCal;
        private System.Windows.Forms.WebBrowser webBrowserYearCal;
        private System.Windows.Forms.TextBox Caly_y;
        private System.Windows.Forms.Button btnMakeCaly;
        private System.Windows.Forms.Label lblCaly;
        private System.Windows.Forms.Button btnTestHelperClass;
        private System.Windows.Forms.Button btnBaZiNormal;
        private System.Windows.Forms.TabPage tabPageBaZi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBaZiBeijing;
        private System.Windows.Forms.TabPage tabPageTools;
        private System.Windows.Forms.Button btnOutputJnbData;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnLoadXML;
        private System.Windows.Forms.Button btnLoadwFtv;
        private System.Windows.Forms.Button btnLoadXmlsFtv;
        private System.Windows.Forms.Button bntLoadXmlLunarJieri;
        private System.Windows.Forms.Button btnLoadXmlJieqiFjia;
        private System.Windows.Forms.Button btnTestOthers;
        private System.Windows.Forms.Button btnLoadXmlSQ;
        private System.Windows.Forms.Button btnLoadXmlJW;
        private System.Windows.Forms.Button btnTestNewMethod;
        private System.Windows.Forms.Button btnGetRi12Jian;
        private System.Windows.Forms.CheckBox chkCalcQi;
        private System.Windows.Forms.CheckBox chkCalcJie;
        private System.Windows.Forms.Button btnTestOthers2;
        private System.Windows.Forms.ComboBox cmbBaziTypeS;
        private System.Windows.Forms.Button btndingSuoV;
        private System.Windows.Forms.Button btndingQiV;
    }
}