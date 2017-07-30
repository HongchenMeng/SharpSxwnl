using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SharpSxwnl;

namespace TestSharpSxwnl
{
    public partial class frmMethodsTest : Form
    {
        public frmMethodsTest()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("*" + LunarHelper.trim("\t 123 \r") + "*", "返回结果:");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LunarHelper.year2Ayear(-1) + "\r" + LunarHelper.year2Ayear("B2009") + "\r" +
                            LunarHelper.year2Ayear(10000) + "\r" + LunarHelper.year2Ayear("-4713") + "\r" +
                            LunarHelper.year2Ayear("B0"), "返回结果:");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LunarHelper.Ayear2year("-1") + "\r" + LunarHelper.Ayear2year("0") + "\r" +
                            LunarHelper.Ayear2year(2009), "返回结果:");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LunarHelper.timeStr2hour("12") + "\r" + LunarHelper.timeStr2hour("12:30") + "\r" +
                            LunarHelper.timeStr2hour("12:30:36"), "返回结果:");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LunarHelper.rad2str(3.14, 0) + "\r" + LunarHelper.rad2str(-3.14, 1) +
                            "\r\r " + LunarHelper.str2rad("+179°54'31.49\"") +
                            "\r" + LunarHelper.str2rad("-179°54'31.49\""), "返回结果:");
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LunarHelper.rad2str2(3.14) + "\r" + LunarHelper.rad2str2(-3.14), "返回结果:");
        }

        private void label7_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LunarHelper.m2fm(121, 2, 0) + "\r" + LunarHelper.m2fm(121, 0, 1), "返回结果:");
        }

        private void label8_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LunarHelper.rad2mrad(0) + "\r" + LunarHelper.rad2mrad(Math.PI / 2) + "\r" +
                            LunarHelper.rad2mrad(Math.PI * 2) + "\r" + LunarHelper.rad2mrad(Math.PI * 3) + "\r" +
                            LunarHelper.rad2mrad(Math.PI * 4), "返回结果:");
        }

        private void label9_Click(object sender, EventArgs e)
        {
           MessageBox.Show(LunarHelper.rad2rrad(0) + "\r" + LunarHelper.rad2rrad(-Math.PI/2) + "\r" + 
                           LunarHelper.rad2rrad(Math.PI) + "\r" + LunarHelper.rad2rrad(-Math.PI) + "\r" + 
                           LunarHelper.rad2rrad(Math.PI * 2) + "\r" + LunarHelper.rad2rrad(-Math.PI * 2) + "\r" +
                           LunarHelper.rad2rrad(-Math.PI * 3), "返回结果:");
        }

        private void label10_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LunarHelper.mod2(1, 2) + "\r" + LunarHelper.mod2(1.2, 2.2) + "\r" +
                            LunarHelper.mod2(2, 1) + "\r" + LunarHelper.mod2(2.2, 1.2), "返回结果:");
        }

        private void label11_Click(object sender, EventArgs e)
        {
            JWdata.JWdecode("P3Tg昆明");
            MessageBox.Show("经: " + LunarHelper.rad2str2(JWdata.J) + "\r纬: " + LunarHelper.rad2str2(JWdata.W), "返回结果:");

        }

        private void label12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("_" + LunarHelper.SUBSTRING("1", 0, 2) + "_" + "\r" +
                            "_" + LunarHelper.SUBSTRING("1", -1, 2) + "_" + "\r" +
                            "_" + LunarHelper.SUBSTRING("1", 0, -1) + "_" + "\r" +
                            "_" + LunarHelper.SUBSTRING("abc", 1, 2) + "_", "返回结果(注意前后均增加了下划线):");
        }

        private void label13_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LunarHelper.VAL("1") + "\r" +
                            LunarHelper.VAL("$1") + "\r" +
                            LunarHelper.VAL("$-1") + "\r" +
                            LunarHelper.VAL("-1E3") + "\r" +
                            LunarHelper.VAL("$1E-3") + "\r" +
                            LunarHelper.VAL("-123%") + "\r" +
                            LunarHelper.VAL("ABC") + "\r" +
                            LunarHelper.VAL("123D") + "\r" +
                            LunarHelper.VAL("$+.E+%"), "返回结果:");
        }

        private void label14_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LunarHelper.VAL("￥+1") + "\r" +
                            LunarHelper.VAL("￥+-1") + "\r" +
                            LunarHelper.VAL("￥-1.2") + "\r" +
                            LunarHelper.VAL("￥$") + "\r" +
                            LunarHelper.VAL("￥-.E-%") + "\r" +
                            LunarHelper.VAL("￥-12.3%") + "\r" +
                            LunarHelper.VAL("A100") + "\r" +
                            LunarHelper.VAL("1.2") + "\r", "返回结果:");
        }

        private void label15_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LunarHelper.VAL("001.88") + "\r" +
                            LunarHelper.VAL("001.88", 1) + "\r" +
                            LunarHelper.VAL("001.88", 1L) + "\r" +
                            LunarHelper.VAL(".22") + "\r" +
                            LunarHelper.VAL(".88.22") + "\r" +
                            LunarHelper.VAL(".22E2") + "\r" +
                            LunarHelper.VAL("  2") + "\r" +
                            LunarHelper.VAL("$  2") + "\r", "返回结果:");
        }

        private void label16_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LunarHelper.VAL("") + "\r" +
                            LunarHelper.VAL("E3") + "\r" +
                            LunarHelper.VAL("3E") + "\r" +
                            LunarHelper.VAL("3E+") + "\r" +
                            LunarHelper.VAL("3E-") + "\r" +
                            LunarHelper.VAL("3E2") + "\r" +
                            LunarHelper.VAL("3E.2") + "\r" +
                            LunarHelper.VAL(".E2") + "\r" +
                            LunarHelper.VAL("+1") + "\r", "返回结果:");
        }

    }
}
