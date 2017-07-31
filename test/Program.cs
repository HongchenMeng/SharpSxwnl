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
            Lunar lun = new Lunar();
            double curJD, curTZ;
            sun_moon smc = new sun_moon();

            DateTime nowDT = DateTime.Now;
            curTZ = TimeZone.CurrentTimeZone.GetUtcOffset(nowDT).Negate().TotalHours;     // 中国: 东 8 区
            curJD = LunarHelper.NowUTCmsSince19700101(nowDT) / 86400000d - 10957.5 - curTZ / 24d; //J2000起算的儒略日数(当前本地时间)
            JD.setFromJD(curJD + LunarHelper.J2000);
            curJD = LunarHelper.int2(curJD + 0.5);

            string y = JD.Y.ToString();//公历年
           string m = JD.M.ToString();//公历月
            string d = JD.D.ToString();//公历日
            string t = JD.h + ":" + JD.m + ":" + JD.s.ToString("F0").PadLeft(2, '0');//时分秒 16:25:35

            string Cal_y = JD.Y.ToString();
            string Cal_m = JD.M.ToString();

            // double By = LunarHelper.year2Ayear<string>(this.Cal_y.Text);
            //// C#: 注: 使用上句也可以, 如果在调用泛型方法时, 不指定类型, C# 编译器将自动推断其类型
            double By = LunarHelper.year2Ayear(Cal_y);    // 自动推断类型为: string 
            double Bm = int.Parse(Cal_m);
            lun.yueLiHTML((int)By, (int)Bm, curJD);//html月历生成,结果返回在lun中,curJD为当前日期(用于设置今日标识)

            string nl = lun.getNL((int)By, (int)Bm, curJD,nowDT.Day);

            Console.WriteLine(nl);
            Console.ReadLine();
            
        }
    }
}
