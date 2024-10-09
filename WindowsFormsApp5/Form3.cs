using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form3 : Form
    {
        int angle;
        Random r;
        int screenHeight = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
        int screenWidth = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
        
        public Form3()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            r = new Random();
            angle = r.Next(360);
            GraphicsPath shape = new GraphicsPath();
            shape.AddEllipse(0, 0, 50, 50);
            this.Region = new Region(shape);
        }
        //
        // limits
        //
        private void timer1_Tick(object sender, EventArgs e)
        {
            double radian = (angle * Math.PI) / 180;
            Top -= (int)(30 * Math.Sin(radian));
            Left += (int)(30 * Math.Cos(radian));
            if ((Top-5) < 0)
            {
                angle = 360-angle;
            }
            if (Left-5 < 0)
            {
                angle += 2 * (270 -angle);
            }
            if ((Top+55) > screenHeight)
            {
                angle = 360 - angle;
            }
            if ((Left+55) > screenWidth)
            {
                angle = 180 - angle;
            }
        }
        //
        // enable timer
        //
        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
