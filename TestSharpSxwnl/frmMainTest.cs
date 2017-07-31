using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SharpSxwnl;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml;

namespace TestSharpSxwnl
{
    public partial class frmMainTest : Form
    {
        Lunar lun = new Lunar();
        double curJD, curTZ;
        sun_moon smc = new sun_moon();
        string TempPath = "";

        public frmMainTest()
        {
            InitializeComponent();
        }


        #region 初始化, 显示当前日期所在月的月历
        private void frmMainTest_Load(object sender, EventArgs e)
        {
            this.TempPath = this.AddBS(Environment.GetEnvironmentVariable("Temp"));
            this.cmbBaziTypeS.SelectedIndex = 0;

            DateTime nowDT = DateTime.Now;
            this.curTZ = TimeZone.CurrentTimeZone.GetUtcOffset(nowDT).Negate().TotalHours;     // 中国: 东 8 区
            this.curJD = LunarHelper.NowUTCmsSince19700101(nowDT) / 86400000d - 10957.5 - this.curTZ / 24d; //J2000起算的儒略日数(当前本地时间)
            JD.setFromJD(this.curJD + LunarHelper.J2000);

            this.Caly_y.Text = JD.Y.ToString();

            this.Cml_y.Text = JD.Y.ToString();//公历年
            this.Cml_m.Text = JD.M.ToString();//公历月
            this.Cml_d.Text = JD.D.ToString();//公历日
            this.Cml_his.Text = JD.h + ":" + JD.m + ":" + JD.s.ToString("F0").PadLeft(2, '0');//时分秒 16:25:35

            this.Cal_y.Text = JD.Y.ToString();
            this.Cal_m.Text = JD.M.ToString();
            this.curJD = LunarHelper.int2(this.curJD + 0.5);

            this.InitComboBoxes();

            this.ML_calc(BaZiType.ZtyBaZi);
            this.getlunar();

            this.timerTick.Enabled = true;
            this.showClockAndSunMoonInfo();

        }
        #endregion


        #region 生成和显示月历
        private void btnGo_Click(object sender, EventArgs e)
        {
            this.getlunar();
        }

        private void getlunar()
        {
            // double By = LunarHelper.year2Ayear<string>(this.Cal_y.Text);
            //// C#: 注: 使用上句也可以, 如果在调用泛型方法时, 不指定类型, C# 编译器将自动推断其类型
            double By = LunarHelper.year2Ayear(this.Cal_y.Text);    // 自动推断类型为: string 
            double Bm = int.Parse(this.Cal_m.Text);
            lun.yueLiHTML((int)By, (int)Bm, this.curJD);
            this.txtPg0_Text.Text = lun.pg0_text;
            this.txtPg1_Text.Text = lun.pg1_text;
            this.txtPg2_Text.Text = lun.pg2_text;

            this.showMessD(-2);

            this.StrToFile("<html><META http-equiv=Content-Type content='text/html; charset=utf-8'>" + lun.pg0 +
                           "<p></p>" + lun.pg1 + "<p></p>" + lun.pg2 +
                           "\r\n <script language='javascript'>" +
                           "\r\n function changeBackcolor(oTdOfDay, setBackcolor) {" +
                           "\r\n if(oTdOfDay == null) return;" +
                           "\r\n if(setBackcolor)   {    oTdOfDay.style.background = 'background-color: #99FFCC';    }" +
                           "\r\n else    {" +
                           "\r\n oTdOfDay.style.background = '';    }" +
                           "\r\n }" +
                           "\r\n </script></html>", this.TempPath + "ls.htm");

            this.webBrowserMonth.Navigate(this.TempPath + "ls.htm");

        }
        #endregion


        #region 当单击月历中的日期时, 显示该日的信息
        private void webBrowserMonth_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.webBrowserMonth.Document.ActiveElement.Click += new HtmlElementEventHandler(ActiveElement_Click);
        }


        private void ActiveElement_Click(object sender, HtmlElementEventArgs e)
        {
            int day = (int)LunarHelper.VAL(this.webBrowserMonth.Document.ActiveElement.InnerText);
            if (day > 0)
            {
                this.showMessD(day - 1);
            }
        }
        #endregion


        #region 工具函数
        public string AddBS(string cPath)
        {
            if (cPath.Trim().EndsWith("\\")) { return cPath.Trim(); }
            else { return cPath.Trim() + "\\"; }
        }


        public void StrToFile(string cExpression, string cFileName)
        {
            //Check if the sepcified file exists
            if (System.IO.File.Exists(cFileName) == true)
            {
                //If so then Erase the file first as in this case we are overwriting
                System.IO.File.Delete(cFileName);
            }

            //Create the file if it does not exist and open it
            FileStream oFs = new FileStream(cFileName, FileMode.CreateNew, FileAccess.ReadWrite);

            //Create a writer for the file
            StreamWriter oWriter = new StreamWriter(oFs);

            //Write the contents
            oWriter.Write(cExpression);
            oWriter.Flush();
            oWriter.Close();

            oFs.Close();
        }

        #endregion 工具函数


        #region 计算八字信息(独立)
        private void btnBazi_Click(object sender, EventArgs e)
        {
            this.ML_calc(BaZiType.ZtyBaZi);
        }
        
        private void btnBaZiNormal_Click(object sender, EventArgs e)
        {
            this.ML_calc(BaZiType.PtyBaZi);
        }

        private void btnBaZiBeijing_Click(object sender, EventArgs e)
        {
            this.ML_calc(BaZiType.EL120BaZi);
        }

        private void ML_calc(BaZiType type)
        {
            OB ob = new OB();
            this.txtBazi.Text = LunarHelper.ML_calc<string>(ob, type, this.curTZ, this.Cml_y.Text, this.Cml_m.Text,
                                                            this.Cml_d.Text, this.Cml_his.Text, this.txtLongitude.Text,
                                                            (BaZiTypeS)this.cmbBaziTypeS.SelectedIndex);
        }
        #endregion 计算八字信息(独立)


        #region 初始化地区和县市组合框, 响应其 SelectedIndexChanged 事件
        private void InitComboBoxes()
        {
            for (int i = 0; i < JWdata.SQv.Length; i++)
                this.Sel_zhou.Items.Add(JWdata.SQv[i][0]);
            this.Sel_zhou.SelectedIndex = 0;

            for (int i = 0; i < JWdata.JWv.Length; i++)
                this.Sel_Province.Items.Add(JWdata.JWv[i][0]);
            this.Sel_Province.SelectedIndex = 24;    // 选中 "云南省"
        }

        private void Sel_zhou_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Sel_dq.Items.Clear();
            for (int i = 1; i < JWdata.SQv[this.Sel_zhou.SelectedIndex].Length; i+=2)
                this.Sel_dq.Items.Add(JWdata.SQv[this.Sel_zhou.SelectedIndex][i]);
            this.Sel_dq.SelectedIndex = 0;
        }

        private void Sel_dq_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSQInfo = JWdata.SQv[this.Sel_zhou.SelectedIndex][this.Sel_dq.SelectedIndex * 2 + 2];
            JWdata.SQdecode(strSQInfo);
            this.Sel_sqsm.Text = JWdata.SQDescription;   // 注: 省略了部分代码
        }

        private void Sel_Province_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Sel_Region.Items.Clear();
            for (int i = 1; i < JWdata.JWv[this.Sel_Province.SelectedIndex].Length; i++)
            {
                this.Sel_Region.Items.Add(JWdata.JWv[this.Sel_Province.SelectedIndex][i].Substring(4));
            }
            this.Sel_Region.SelectedIndex = 0;
        }

        private void Sel_Region_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Sel_Region.Tag = JWdata.JWv[this.Sel_Province.SelectedIndex][this.Sel_Region.SelectedIndex + 1].Substring(0, 4);
            JWdata.JWdecode((string)this.Sel_Region.Tag);
            string strJ = LunarHelper.rad2str2(JWdata.J);
            this.Cal_zdzb.Text = "经度(向西为正) " + strJ + 
                                 " 纬度 " + LunarHelper.rad2str2(JWdata.W);
            this.txtLongitude.Text = strJ;
            this.showMessD(-2);
        }
        #endregion


        #region 计算并返回日月升中降信息
        private string RTS1(double jd, double vJ, double vW, double tz)
        {
            SZJ.calcRTS(jd, 1, vJ, vW, tz); //升降计算,使用北时时间,tz=-8指东8区,jd+tz应在当地正午左右(误差数小时不要紧)
            string s;
            LunarInfoListT<double> ob = SZJ.rts[0];
            JD.setFromJD(jd + LunarHelper.J2000);
            s = "日出 " + ob.s + " 日落 " + ob.j + " 中天 " + ob.z + "\r\n"
                        + "月出 " + ob.Ms + " 月落 " + ob.Mj + " 月中 " + ob.Mz + "\r\n"
                        + "晨起天亮 " + ob.c + " 晚上天黑 " + ob.h + "\r\n"
                        + "日照时间 " + ob.sj + " 白天时间 " + ob.ch + "\r\n";
            return s;
        }
        #endregion


        #region 显示日信息
        private void showMessD(int n)
        { //显时本月第n日的摘要信息。调用前应先执月历页面生成，产生有效的lun对象
            this.Cal_pan.Text = "";
            if (this.lun.dn == 0 || n >= this.lun.dn) return;
            double vJ = JWdata.J, vW = JWdata.W;


            if (n == -1)
            { //鼠标移出日期上方
                this.Cal_pan.Text = "";
                this.Cal5.Tag = this.Cal5.Text;
            }
            if (n == -2) 
                this.Cal5.Text = this.RTS1(this.curJD, vJ, vW, this.curTZ);    // 计算并显示当前日期的日月升降信息
            if (n < 0) return;
            //显示n指定的日期信息
            OB ob = this.lun.lun[n];
            string thisDaySunMoonInfo = this.RTS1(ob.d0, vJ, vW, this.curTZ);    // 计算并显示指定日期的日月升降信息

            StringBuilder sb = new StringBuilder();
            if (true)
            { //鼠标移过日期上方
                sb.AppendLine(LunarHelper.Ayear2year(ob.y) + "年" + ob.m + "月" + ob.d + "日");//公历日期
                sb.AppendLine(ob.Lyear3 + "年 星期" + JD.Weeks[(int)(ob.week)] + " " + ob.XiZ);// 丁酉年 星期日 狮子座
                sb.AppendLine(ob.Lyear4 + "年 " + ob.Lleap + ob.Lmc + "月" + (ob.Ldn > 29 ? "大 " : "小 ") + ob.Ldc + "日");// 4715年 润六月大 初八日
                sb.AppendLine(ob.Lyear2 + "年 " + ob.Lmonth2 + "月 " + ob.Lday2 + "日");// 丁酉年 丁未月 戊午日
                sb.AppendLine("回历[" + ob.Hyear + "年" + ob.Hmonth + "月" + ob.Hday + "日]");//回历[1438年11月6日]
                if (ob.yxmc.Length > 0) sb.Append(ob.yxmc + " " + ob.yxsj + " ");//
                if (ob.jqmc.Length > 0) sb.AppendLine("定" + ob.jqmc + " " + ob.jqsj);
                else { if (ob.Ljq.Length > 0) sb.AppendLine(ob.Ljq); }
                if (ob.A.Length > 0) sb.Append(ob.A + " ");
                if (ob.B.Length > 0) sb.Append(ob.B + " ");
                if (ob.C.Length > 0) sb.Append(ob.C);

                sb.AppendLine();
                sb.Append("日十二建: " + ob.Ri12Jian);
                this.Cal_pan.Text = sb.ToString() + "\r\n\r\n" + thisDaySunMoonInfo;
            }
        }
        #endregion


        #region 显示实时时钟
        private void timerTick_Tick(object sender, EventArgs e)
        {
            this.showClockAndSunMoonInfo();
        }


        private void showClockAndSunMoonInfo()
        {
            if (this.Cal_pause.Checked)
                return;
//this.timerTick.Enabled = false;   // C#: Debug
//this.Cal_pause.Checked = true;   // C#: Debug

            DateTime nowDT = DateTime.Now;

            // 显示太阳月亮坐标
            double jd = LunarHelper.NowUTCmsSince19700101(nowDT) / 86400000d - 10957.5; //J2000起算的儒略日数
//jd = 3391.31877640;   // C#: Debug
            jd += JD.deltatT2(jd);
            this.smc.calc(jd, JWdata.J, JWdata.W, 0); //传入力学时间(J2000.0起算)
            this.Cal_zb.Text = smc.toText(1);


            // 显示实时时间
            this.lblLocalClock.Text = nowDT.ToLocalTime().ToString();
            string rg = "";
            double h = JWdata.SQTimeDifference;
            string v = JWdata.DaylightInfo;
            jd = LunarHelper.NowUTCmsSince19700101(nowDT) / 86400000d - 10957.5 + h / 24;
            if (v.Length > 0)
            {
                double y1 = JD.Y, y2 = y1; //该时所在年份
                double m1 = double.Parse(v.Substring(0, 2)), m2 = double.Parse(v.Substring(5, 2));
                if (m2 < m1) y2++;
                //nnweek(y,m,n,w)求y年m月第n个星期w的jd
                double J1 = JD.nnweek(y1, m1, double.Parse(v.Substring(2, 1)), double.Parse(v.Substring(3, 1))) - 0.5 - LunarHelper.J2000 + (v[4] - 97) / 24d;
                double J2 = JD.nnweek(y2, m2, double.Parse(v.Substring(7, 1)), double.Parse(v.Substring(8, 1))) - 0.5 - LunarHelper.J2000 + (v[9] - 97) / 24d;
                if (jd >= J1 && jd < J2) { jd += 1 / 24d; rg = "¤"; }  //夏令时
            }
            JD.setFromJD(jd + LunarHelper.J2000);
            this.lblSQClock.Text = JD.D + "日 " + JD.h + ":" + JD.m + ":" + LunarHelper.int2(JD.s) + rg; //与了与clock1同步,秒数取整而不四舍五入

        }
        #endregion

        
        #region 年历生成

        private void btnMakeCaly_Click(object sender, EventArgs e)
        {
            this.getNianLi(0);
        }


        private void getNianLi(int dy)
        {
            double y = LunarHelper.year2Ayear(this.Caly_y.Text);
            if (y == -10000) return;
            y += dy;
            this.Caly_y.Text = LunarHelper.Ayear2year(y);
            if (y < -4712) { MessageBox.Show("到底了"); return; }

            this.StrToFile("<html><META http-equiv=Content-Type content='text/html; charset=utf-8'><body>\r\n" +
                           "<span style='font-family: 宋体; font-size: 12px; line-height: 18px;'>" +
                           lun.nianLiHTML(y) + "<p></p> \r\n" +
                           lun.nianLi2HTML(y) + "\r\n </span></small></body></html>", this.TempPath + "ls2.htm");

            this.webBrowserYearCal.Navigate(this.TempPath + "ls2.htm");
        }

        #endregion 年历生成


        #region 删除临时文件
        private void frmMainTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete(this.TempPath + "ls.htm");
            File.Delete(this.TempPath + "ls2.htm");
            //File.Delete(this.TempPath + "ls.xml");
        }
        #endregion


        #region 其他测试
        private void btnTestHelperClass_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("1".Substring(1));    // 返回空串
            //MessageBox.Show("1".Substring(2));    // 引发异常: System.ArgumentOutOfRangeException startIndex 不能大于字符串长度。
            //int[] my = new int[3];
            //MessageBox.Show(my[1].ToString());
            //StringBuilder sb = new StringBuilder(10);
            //MessageBox.Show(sb.Length + "\r" + sb.ToString().Length);    // 显示0, 0
            //StringBuilder sb = new StringBuilder();
            //sb.Append("$");
            //MessageBox.Show((sb[0] == '$').ToString());   // 显示 True

//            string numberPattern = @"(((￥|\$)?)((\+|\-)?)([0-9]*)((\.)?)([0-9]*)((E|e)?)((\+|\-)?)([0-9]*))((%)?)";
//            // string numberPattern = @"(((￥|\$)?)((\+|\-)?)([0-9]*)((\.)?)([0-9]*)((\%)?))";
//            Regex numberRegPattern = new Regex(numberPattern);
////            MatchCollection matched = numberRegPattern.Matches("$- 123.4e+2.3");
//            MatchCollection matched = numberRegPattern.Matches(@"456$-123e1%.2");
//            StringBuilder sb = new StringBuilder();
//            for (int i = 0; i < matched.Count; i++)
//                sb.AppendLine(matched[i].ToString());
//            MessageBox.Show(sb.ToString());
//            if (matched.Count > 0)
//            {
//                string numberStr = matched[0].ToString();
//                if (numberStr.StartsWith("￥") || numberStr.StartsWith("$"))
//                    numberStr = numberStr.Substring(1);
//                MessageBox.Show(double.Parse(numberStr, NumberStyles.Any).ToString());
//            }

            //MessageBox.Show(double.Parse("2e1").ToString());

            //double test = 1.5E100;
            //MessageBox.Show(((int)test).ToString());   // 溢出, 显示 -2147483648
            //MessageBox.Show(((long)test).ToString());   // 溢出, 显示 -9223372036854775808
            //MessageBox.Show(((Int64)test).ToString());   // 溢出, 显示 -9223372036854775808

            //// 泛型类测试
            //test<int> myT = new test<int>();
            //myT.Add(5);
            //test<OB> myT2 = new test<OB>();
            //OB ob = new OB();
            //ob.A = "Test";
            //myT2.Add(ob);
            //MessageBox.Show(myT[0].ToString() + "\r" + myT2[0].A + "\r" + myT2.myname);

            frmMethodsTest myTest = new frmMethodsTest();
            myTest.Show();
        }
        #endregion


        #region 辅助工具

        private void btnOutputJnbData_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            int j;

            // XML 文件信息及根节点
            sb.AppendLine("<?xml version = \"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>");
            sb.AppendLine("<SharpSxwnl>");


            // 各地经纬度数据
            sb.AppendLine(@"<SxwnlData>");
            sb.AppendLine(@"    <Data Id='JWdata_JWv' Name='各地经纬度表' Note='请参阅经纬数据压缩说明'>");
            for (int i = 0; i < JWdata.JWv.Length; i++)
            {
                for (j = 0; j < JWdata.JWv[i].Length; j++)
                {
                    sb.Append(JWdata.JWv[i][j] + (j < JWdata.JWv[i].Length - 1 ? " " : ""));
                }
                if (i < JWdata.JWv.Length - 1)
                    sb.AppendLine();
            }
            sb.AppendLine(@"</Data>");
            sb.AppendLine(@"</SxwnlData>");


            // 时区数据
            sb.AppendLine(@"<SxwnlData>");
            sb.AppendLine(@"    <Data Id='JWdata_SQv' Name='时区表' Note=''>");
            for (int i = 0; i < JWdata.SQv.Length; i++)
            {
                for (j = 0; j < JWdata.SQv[i].Length; j++)
                {
                    sb.Append(JWdata.SQv[i][j] + (j < JWdata.SQv[i].Length - 1 ? "," : ""));
                }
                if (i < JWdata.SQv.Length - 1)
                    sb.AppendLine();
            }
            sb.AppendLine(@"</Data>");
            sb.AppendLine(@"</SxwnlData>");


            // 纪年表数据
            sb.AppendLine(@"<SxwnlData>");
            sb.AppendLine(@"    <Data Id='obb_JNB' Name='历史纪年表' Note='数据用逗号分开,每7个描述一个年号,格式为:起始公元(天文纪年方式),使用年数,已用年数,朝代,朝号,皇帝,年号'>");
            for (int i = 0; i < obb.JNB.Count; i += 7)
            {
                for (j = 0; j < 7; j++)
                {
                    sb.Append(obb.JNB[i + j].ToString() + (i + j < obb.JNB.Count - 1 ? "," : ""));
                }
                if (i + j < obb.JNB.Count - 1)
                    sb.AppendLine();
            }
            sb.AppendLine(@"</Data>");
            sb.AppendLine(@"</SxwnlData>");


            // 按周规则定义的节假日(纪念日)
            sb.AppendLine(@"<SxwnlData>");
            sb.AppendLine(@"    <Data Id='oba_wFtv' Name='按周规则定义的节假日(纪念日)' Note='某月的第几个星期几,如第2个星期一指从月首开始顺序找到第2个“星期一”'>");
            for (int i = 0; i < oba.wFtv.Length; i++)
            {
                sb.Append(oba.wFtv[i] + (i < oba.wFtv.Length - 1 ? "," : ""));
            }
            sb.AppendLine(@"</Data>");
            sb.AppendLine(@"</SxwnlData>");


            // 节假日(按月列示)
            sb.AppendLine(@"<SxwnlData>");
            sb.AppendLine(@"    <Data Id='oba_sFtv' Name='公历各月的节日(纪念日)' Note='国历节日,#表示放假日,I表示重要节日或纪念日'>");
            for (int i = 0; i < oba.sFtv.Length; i++)
            {
                sb.AppendLine("        <Month Id = '" + (i+1).ToString() + "'>");
                for (j = 0; j < oba.sFtv[i].Length; j++)
                    sb.Append(oba.sFtv[i][j] + (j < oba.sFtv[i].Length - 1 ? "," : ""));
                sb.AppendLine("</Month>");
            }
            sb.AppendLine(@"</Data>");
            sb.AppendLine(@"</SxwnlData>");


            // 农历特定节日
            sb.AppendLine(@"<SxwnlData>");
            sb.AppendLine(@"    <Data Id='obb_getDayName' Name='按农历日期定义的节日(纪念日)' Note='节日重要程度从高到低排列: A-B-C '>");
            sb.AppendLine(@"        <DayName Day='正月初一' A='春节 ' B='' C='' Fjia='1' />");
            sb.AppendLine(@"        <DayName Day='正月初二' A='' B='大年初二 ' C='' Fjia='1' />");
            sb.AppendLine(@"        <DayName Day='五月初五' A='端午节 ' B='' C='' Fjia='1' />");
            sb.AppendLine(@"        <DayName Day='八月十五' A='中秋节 ' B='' C='' Fjia='1' />");
            sb.AppendLine(@"        <DayName Day='正月十五' A='元宵节 ' B='上元节 ' C='壮族歌墟节 苗族踩山节 达斡尔族卡钦 ' Fjia='0' />");
            sb.AppendLine(@"        <DayName Day='正月十六' A='' B='' C='侗族芦笙节(至正月二十) ' Fjia='0' />");
            sb.AppendLine(@"        <DayName Day='正月廿五' A='' B='' C='填仓节 ' Fjia='0' />");
            sb.AppendLine(@"        <DayName Day='正月廿九' A='' B='' C='送穷日 ' Fjia='0' />");
            sb.AppendLine(@"        <DayName Day='二月初一' A='' B='' C='瑶族忌鸟节 ' Fjia='0' />");
            sb.AppendLine(@"        <DayName Day='二月初二' A='' B='春龙节(龙抬头) ' C='畲族会亲节 ' Fjia='0' />");
            sb.AppendLine(@"        <DayName Day='二月初八' A='' B='' C='傈傈族刀杆节 ' Fjia='0' />");
            sb.AppendLine(@"        <DayName Day='三月初三' A='' B='北帝诞 ' C='苗族黎族歌墟节 ' Fjia='0' />");
            sb.AppendLine(@"        <DayName Day='三月十五' A='' B='' C='白族三月街(至三月二十) ' Fjia='0' />");
            sb.AppendLine(@"        <DayName Day='三月廿三' A='' B='天后诞 妈祖诞 ' C='' Fjia='0' />");
            sb.AppendLine(@"        <DayName Day='四月初八' A='' B='牛王诞 ' C='' Fjia='0' />");
            sb.AppendLine(@"        <DayName Day='四月十八' A='' B='' C='锡伯族西迁节 ' Fjia='0' />");
            sb.AppendLine(@"        <DayName Day='五月十三' A='' B='关帝诞 ' C='阿昌族泼水节 ' Fjia='0' />");
            sb.AppendLine(@"        <DayName Day='五月廿二' A='' B='' C='鄂温克族米阔鲁节 ' Fjia='0' />");
            sb.AppendLine(@"        <DayName Day='五月廿九' A='' B='' C='瑶族达努节 ' Fjia='0' />");
            sb.AppendLine(@"        <DayName Day='六月初六' A='' B='姑姑节 天贶节 ' C='壮族祭田节 瑶族尝新节 ' Fjia='0' />");
            sb.AppendLine(@"        <DayName Day='六月廿四' A='' B='' C='火把节、星回节(彝、白、佤、阿昌、纳西、基诺族 ) ' Fjia='0' />");
            sb.AppendLine(@"        <DayName Day='七月初七' A='' B='七夕(中国情人节 乞巧节 女儿节 ) ' C='' Fjia='0' />");
            sb.AppendLine(@"        <DayName Day='七月十三' A='' B='' C='侗族吃新节 ' Fjia='0' />");
            sb.AppendLine(@"        <DayName Day='七月十五' A='' B='中元节 鬼节' C='' Fjia='0' />");
            sb.AppendLine(@"        <DayName Day='九月初九' A='' B='重阳节 ' C='' Fjia='0' />");
            sb.AppendLine(@"        <DayName Day='十月初一' A='' B='祭祖节(十月朝) ' C='' Fjia='0' />");
            sb.AppendLine(@"        <DayName Day='十月十五' A='' B='下元节 ' C='' Fjia='0' />");
            sb.AppendLine(@"        <DayName Day='十月十六' A='' B='' C='瑶族盘王节 ' Fjia='0' />");
            sb.AppendLine(@"        <DayName Day='十二初八' A='' B='腊八节 ' C='' Fjia='0' />");
            sb.AppendLine(@"</Data>");
            sb.AppendLine(@"</SxwnlData>");


            // 放假标志
            sb.AppendLine(@"<SxwnlData>");
            sb.AppendLine(@"    <Data Id='obb_JieqiFjia' Name='按廿四节气定义的假日' Note='假日名称必须为廿四节气的名称, 用逗号分隔'>");
            sb.Append(@"清明");
            sb.AppendLine(@"</Data>");
            sb.AppendLine(@"</SxwnlData>");


            // 根节点结束标记
            sb.AppendLine(@"</SharpSxwnl>");

            this.txtOutput.Text = sb.ToString().Replace("'", "\"");
            this.StrToFile(sb.ToString().Replace("'", "\""), this.TempPath + "ls.xml");
        }

        private void btnLoadXML_Click(object sender, EventArgs e)
        {
            //XmlReader reader= XmlReader.Create(this.TempPath + "ls.xml");
            //StringBuilder sb = new StringBuilder();
            //while (reader.Read())
            //{
            //    sb.Append(reader.Value);
            //}
            //this.txtOutput.Text = sb.ToString();

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(this.TempPath + "ls.xml");
            XmlNode foundNode = xmldoc.SelectSingleNode("SharpSxwnl/SxwnlData/Data[@Id = 'obb_JNB']");
            char[] totrim = new char[] { ' ', '\r', '\n' };
            if (foundNode != null)
            {
                this.txtOutput.Text = foundNode.InnerText.Trim(totrim).Replace("\r\n", "");
            }
            else
                MessageBox.Show("加载数据失败!");
        }

        private void btnLoadwFtv_Click(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(this.TempPath + "ls.xml");
            XmlNode foundNode = xmldoc.SelectSingleNode("SharpSxwnl/SxwnlData/Data[@Id = 'oba_wFtv']");
            char[] totrim = new char[] { ' ', '\r', '\n' };
            if (foundNode != null)
            {
                this.txtOutput.Text = foundNode.InnerText.Trim(totrim).Replace("\r\n", "");
            }
            else
                MessageBox.Show("加载数据失败!");
        }

        private void btnLoadXmlsFtv_Click(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(this.TempPath + "ls.xml");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 12; i++)
            {
                string xPath = "SharpSxwnl/SxwnlData/Data[@Id = 'oba_sFtv']/Month[@Id = '" + (i + 1).ToString() + "']";
                XmlNode foundNode = xmldoc.SelectSingleNode(xPath);
                char[] totrim = new char[] { ' ', '\r', '\n' };
                if (foundNode != null)
                {
                    sb.AppendLine((i+1).ToString() + "月: " + foundNode.InnerText);
                    sb.AppendLine();
                }

                else
                {
                    MessageBox.Show("加载 " + (i+1).ToString() + " 月的数据失败!");
                    break;
                }
            }
            this.txtOutput.Text = sb.ToString();
        }

        private void bntLoadXmlLunarJieri_Click(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(this.TempPath + "ls.xml");
            XmlNodeList foundNodeList = xmldoc.SelectNodes("SharpSxwnl/SxwnlData/Data[@Id = 'obb_getDayName']");
            char[] totrim = new char[] { ' ', '\r', '\n' };
            StringBuilder sb = new StringBuilder();
            if (foundNodeList.Count > 0)
            {
                //string[] test = new string[foundNodeList.Count];
                for (int i = 0; i < foundNodeList.Count; i++)
                    for (int j = 0; j < foundNodeList[i].ChildNodes.Count; j++)
                    {
                        for (int k = 0; k < foundNodeList[i].ChildNodes[j].Attributes.Count; k++)
                            sb.Append(foundNodeList[i].ChildNodes[j].Attributes[k].InnerText +
                                         (k < foundNodeList[i].ChildNodes[j].Attributes.Count - 1 ? "," : ""));
                        sb.AppendLine();
                    }
                this.txtOutput.Text = sb.ToString();
            }
            else
                MessageBox.Show("加载数据失败!");
        }

        private void btnLoadXmlJieqiFjia_Click(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(this.TempPath + "ls.xml");
            XmlNode foundNode = xmldoc.SelectSingleNode("SharpSxwnl/SxwnlData/Data[@Id = 'obb_JieqiFjia']");
            char[] totrim = new char[] { ' ', '\r', '\n' };
            if (foundNode != null)
            {
                this.txtOutput.Text = foundNode.InnerText.Trim(totrim).Replace("\r\n", "");
            }
            else
                MessageBox.Show("加载数据失败!");
        }


        private void btnLoadXmlSQ_Click(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(this.TempPath + "ls.xml");
            XmlNode foundNode = xmldoc.SelectSingleNode("SharpSxwnl/SxwnlData/Data[@Id = 'JWdata_SQv']");
            char[] totrim = new char[] { ' ', '\r', '\n' };
            if (foundNode != null)
            {
                this.txtOutput.Text = foundNode.InnerText.Trim(totrim);
            }
            else
                MessageBox.Show("加载数据失败!");
        }

        private void btnLoadXmlJW_Click(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(this.TempPath + "ls.xml");
            XmlNode foundNode = xmldoc.SelectSingleNode("SharpSxwnl/SxwnlData/Data[@Id = 'JWdata_JWv']");
            char[] totrim = new char[] { ' ', '\r', '\n' };
            if (foundNode != null)
            {
                this.txtOutput.Text = foundNode.InnerText.Trim(totrim);
            }
            else
                MessageBox.Show("加载数据失败!");
        }

        #endregion



        #region 杂项测试: 自实现的属性, 以及数组属性
        private double myTest { get; set; }             // 数值:   初始为 0
        private static string myTest2 { get; set; }     // 字符串: 初始为 null
        private double[] myTest3 { get; set; }          // 数组: 

        private double[] testdata = new double[] {4,5,6};
        private double[] myTest4
        {
            get { return this.testdata; }
            set { this.testdata = value; }
        }
        private double[][] testdata2 = new double[][] { new double[] {1,2,3}, new double[] {4,5}};
        private double[][] myTest5
        {
            get { return this.testdata2; }
            set { this.testdata2 = value; }
        }

        private void btnTestOthers_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("属性 myTest 的值为: " + this.myTest.ToString());

            //MessageBox.Show("属性 myTest2 的值为: " + (frmMainTest.myTest2 == null ? "(null)" : frmMainTest.myTest2)); 
            //frmMainTest.myTest2 = "This is a test!";    // 字符串属性在引用前必须先赋值, 否则下面 2 句将引发异常
            //MessageBox.Show("属性 myTest2 的值为: " + myTest2.ToString());
            //MessageBox.Show("属性 myTest2 的值为: " + frmMainTest.myTest2.ToString());

            //this.myTest3 = new double[3];    // 对于数组属性, 必须先创建实例
            //this.myTest3[1] = 20;
            //MessageBox.Show("属性 myTest3 的元素个数为: " + this.myTest3.Length.ToString() + "\r" +
            //                "myTest3[0]的值为: " + this.myTest3[0].ToString() + "\r" +
            //                "myTest3[1]的值为: " + this.myTest3[1].ToString());

            //MessageBox.Show(this.myTest4.Length.ToString());    // 显示: 3
            //this.myTest4[1] = 8;
            //MessageBox.Show(this.testdata[0] + " " + this.testdata[1] + " " + this.testdata[2]);    // 显示: 4 8 6
            //this.myTest4 = new double[3] { 1,2,3 };
            //MessageBox.Show(this.testdata[0] + " " + this.testdata[1] + " " + this.testdata[2]);    // 显示: 1 2 3

            //MessageBox.Show(this.myTest5[0].Length.ToString());    // 显示: 3
            //this.myTest5[0][1] = 8;
            //MessageBox.Show(this.testdata2[0][0] + " " + this.testdata2[0][1] + " " + this.testdata2[0][2]);    // 显示: 1 8 3
            //this.myTest5[1] = new double[] { 11, 22, 33, 44 };
            //MessageBox.Show(this.testdata2[1][0] + " " + this.testdata2[1][1] + " " + this.testdata2[1][2] + " "
            //                + this.testdata2[1][3]);     // 显示:  11 22 33 44

            double[][][] a = new double[1][][];
            double[][] b = new double[2][];
            double[][] c = new double[3][];
            a[0] = b;
            b[0] = new double[] { 1, 2, 3 };
            b[1] = new double[] { 4, 5, 6 };
            MessageBox.Show(a[0][0].Length + "," + a[0][1].Length + "\r");    // 显示:   3,3
            c[0] = new double[] { 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            c[1] = new double[] { 17, 18, 19, 20 };
            a[0] = c;
            MessageBox.Show(a[0][0].Length + "," + a[0][1].Length + "\r");    // 显示:   9,4
            this.myA3 = a;     // 将局部数组保存到类的属性中, 实际上也就提升了它的应用范围(?)
            this.btnTestOthers2.Enabled = true;     // 允许测试垃圾回收

            //string empty = String.Empty;
            //string[] es = empty.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //MessageBox.Show(es.Length.ToString());    // 显示: 0, 如果不指定 StringSplitOptions.RemoveEmptyEntries 参数, 则显示 1
            //List<string> myList = new List<string>();
            //myList.AddRange(es);
            //MessageBox.Show(myList.Count.ToString());    // 显示: 0
            
        }
        double[][][] myA3;

        private void btnTestOthers2_Click(object sender, EventArgs e)
        {
            GC.Collect();    // 垃圾回收
            MessageBox.Show(this.myA3[0][0].Length + "," + this.myA3[0][1].Length + "\r");    // 显示:   9,4  (即未被回收)
        }

        #endregion 杂项测试



        #region 测试方法: 计算指定日期的节气信息
        private void btnTestNewMethod_Click(object sender, EventArgs e)
        {
            OB ob = new OB();
            ob.y = int.Parse(this.Cml_y.Text);    //DateTime.Now.Year;
            ob.m = int.Parse(this.Cml_m.Text);       //DateTime.Now.Month;
            ob.d = int.Parse(this.Cml_d.Text);       //DateTime.Now.Day;

            CalcJieQiType calcType;
            if (this.chkCalcJie.Checked && this.chkCalcQi.Checked)
                calcType = CalcJieQiType.CalcBoth;
            else
                if (this.chkCalcQi.Checked)
                    calcType = CalcJieQiType.CalcQi;
                else
                    calcType = CalcJieQiType.CalcJie;
            this.lun.CalcJieQiInfo(ob, calcType);

            StringBuilder sb = new StringBuilder();
            JieQiInfo jieqiInfo;
            for(int i = 0 ;i<3;i++)
            {
                switch (i)
                {
                    case 0:
                        jieqiInfo = ob.ThisJieQi;
                        sb.AppendLine("----------所属节气信息----------");
                        break;
                    case 1:
                        jieqiInfo = ob.PreviousJieQi;
                        sb.AppendLine("<---------前一节气信息----------");
                        break;
                    default:
                        jieqiInfo = ob.NextJieQi;
                        sb.AppendLine("----------下一节气信息--------->");
                        break;
                }
                sb.AppendLine("节气名称: " + jieqiInfo.Name);
                sb.AppendLine("月建名称: " + jieqiInfo.YueJian);
                sb.AppendLine("节或气  : " + (jieqiInfo.JieOrQi ? "节" : "气"));
                sb.AppendLine("交节时间: " + jieqiInfo.Time);
                sb.AppendLine("实历交节: " + jieqiInfo.HistoricalTime.Substring(0, 11));
                sb.AppendLine("交节差异: " + (jieqiInfo.DifferentTime ? jieqiInfo.DayDifference + " 天" : "无"));
                sb.AppendLine();
            }
            this.txtBazi.Text = sb.ToString();
        }
        #endregion


        #region 计算日十二建表
        private void btnGetRi12Jian_Click(object sender, EventArgs e)
        {
            string diZhi = "子丑寅卯辰巳午未申酉戌亥";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("日支: 子 丑 寅 卯 辰 巳 午 未 申 酉 戌 亥");
            sb.AppendLine();

            for (int i = 0; i < 12; i++)
            {
                sb.Append(diZhi.Substring(i, 1) + "月: ");
                for (int j = 0; j < 12; j++)
                {
                    sb.Append(this.lun.GetRi12Jian(diZhi.Substring(i, 1), diZhi.Substring(j, 1)));
                    sb.Append(" ");
                }
                sb.AppendLine();
            }
            MessageBox.Show(sb.ToString());

        }
        #endregion


        #region 辅助测试

        private void btndingQiV_Click(object sender, EventArgs e)
        {
            DateTime d1 = DateTime.Now;
            for (int i = 0; i < 1000; i++)
                XL.S_aLon_t(0);
            DateTime d2 = DateTime.Now;
            for (int i = 0; i < 1000; i++)
                XL.S_aLon_t2(0);
            DateTime d3 = DateTime.Now;

            MessageBox.Show("高精度: " + (d2 - d1).TotalMilliseconds.ToString() + " 毫秒/千个\r" +
                            "低精度: " + (d3 - d2).TotalMilliseconds.ToString() + " 毫秒/千个\r");
        }


        private void btndingSuoV_Click(object sender, EventArgs e)
        {
            DateTime d1 = DateTime.Now;
            for (int i = 0; i < 1000; i++)
                XL.MS_aLon_t(0);
            DateTime d2 = DateTime.Now;
            for (int i = 0; i < 1000; i++)
                XL.MS_aLon_t2(0);
            DateTime d3 = DateTime.Now;

            MessageBox.Show("高精度: " + (d2 - d1).TotalMilliseconds.ToString() + " 毫秒/千个\r" +
                            "低精度: " + (d3 - d2).TotalMilliseconds.ToString() + " 毫秒/千个\r");
        }


        #endregion 辅助测试
    }
}



//// 泛型类测试
//public class test<T> : List<T>
//{
//    public string myname = "My name is test.";
//}


//public static class test2
//{
//    public static T Val<T>(string exp, T result)
//    {
//        return result;
//    }
//}