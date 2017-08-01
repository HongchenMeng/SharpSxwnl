using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpSxwnl;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Lunar lun = new Lunar();
            double curJD, curTZ;
            sun_moon smc = new sun_moon();

            DateTime nowDT = new DateTime(2017, 8, 1);
            curTZ = -8;//TimeZone.CurrentTimeZone.GetUtcOffset(nowDT).Negate().TotalHours;     // 中国: 东 8 区
            curJD = LunarHelper.NowUTCmsSince19700101(nowDT) / 86400000d - 10957.5 - curTZ / 24d; //J2000起算的儒略日数(当前本地时间)
            JD.setFromJD(curJD + LunarHelper.J2000);
            string Cal_y = JD.Y.ToString();
            string Cal_m = JD.M.ToString();

            curJD = LunarHelper.int2(curJD + 0.5);

            // double By = LunarHelper.year2Ayear<string>(this.Cal_y.Text);
            //// C#: 注: 使用上句也可以, 如果在调用泛型方法时, 不指定类型, C# 编译器将自动推断其类型
            double By = LunarHelper.year2Ayear(Cal_y);    // 自动推断类型为: string 
            double Bm = int.Parse(Cal_m);
            lun.yueLiHTML((int)By, (int)Bm, curJD,nowDT.Day);//html月历生成,结果返回在lun中,curJD为当前日期(用于设置今日标识)
            //显示n指定的日期信息
            OB ob = lun.lun[nowDT.Day-1];
            // double vJ = JWdata.J, vW = JWdata.W;
            double vJ = -1.9768762660922441, vW = 0.40346194541935582;
            string thisDaySunMoonInfo = p.RTS1(ob.d0, vJ, vW, curTZ); // p.RTS1(ob.d0, vJ, vW, curTZ);    // 计算并显示指定日期的日月升降信息
            StringBuilder sb = new StringBuilder();

                sb.AppendLine(LunarHelper.Ayear2year(ob.y) + "年" + ob.m + "月" + ob.d + "日");//公历日期
                sb.AppendLine(ob.Lyear3 + "年 星期" + JD.Weeks[(int)(ob.week)] + " " + ob.XiZ);// 丁酉年 星期日 狮子座
                sb.AppendLine(ob.Lyear4 + "年 " + ob.Lleap + ob.Lmc + "月" + (ob.Ldn > 29 ? "大 " : "小 ") + ob.Ldc + "日");// 4715年 润六月大 初八日
                sb.AppendLine(ob.Lyear2 + "年 " + ob.Lmonth2 + "月 " + ob.Lday2 + "日");// 丁酉年 丁未月 戊午日
                sb.AppendLine("回历[" + ob.Hyear + "年" + ob.Hmonth + "月" + ob.Hday + "日]");//回历[1438年11月6日]

  

            // string nl = lun.getNL((int)By, (int)Bm, curJD,nowDT.Day);

            // string gz = lun.getgzjn((int)By, (int)Bm, curJD);

            // string sx = lun.getSX((int)By, (int)Bm, curJD);
            // Console.WriteLine(nl);
             Console.WriteLine(thisDaySunMoonInfo);
            Console.WriteLine(sb.ToString());
            Console.ReadLine();
            
        }
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
    }
}
