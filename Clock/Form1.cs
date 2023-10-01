using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Clock
{
    public partial class Form1 : Form
    {


       
        Thread clock1 { get; set; }
        public bool isRunning { get; set; }
        public int size { get; set; }
        public Brush brush { get; set; }

        public float secondAngle { get; set; }
        public float minuteAngle { get; set; }
        public float HourAngle { get; set; }

        Rectangle OuterClockCircle2;
        int centerX { get; set; }
        int centerY { get; set; }
        int Radius { get; set; }
        public Matrix rotate { get; set; }

        public Form1()
        {
            InitializeComponent();

            size = 500;
            brush = new SolidBrush(Color.Orange);
            rotate = new Matrix();

            clock1 = new Thread((RunClock));


            OuterClockCircle2= new Rectangle(35, 35, size - 50, size - 50);


          





            GraphicsPath ClockCircle = new GraphicsPath();
            ClockCircle.AddEllipse(20, 40, size, size);
            Region rgn1 = new Region(ClockCircle);



            clock1.Start();
            isRunning = true;



            this.Region = rgn1;
          
        }
  
        private void Form1_Paint(object sender, PaintEventArgs e)
        {




           
            int centerX = size / 2 + 10;
            int centerY = size / 2 + 10;
            int radius = size / 2 - 28;
            rotate.Reset();
            e.Graphics.FillEllipse(brush, OuterClockCircle2);
            DrawSections(e);
            PrintNumbs(e);


            rotate.RotateAt(secondAngle, new PointF(centerX, centerY));
            e.Graphics.Transform = rotate;

            int endX = centerX;
            int endY = centerY - radius;


            e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(centerX, centerY), new Point(endX, endY));


            rotate.Reset();
            rotate.RotateAt(HourAngle, new PointF(centerX, centerY));
            e.Graphics.Transform = rotate;
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(centerX, centerY), new Point(endX + 70, endY + 70));

            rotate.Reset();
            rotate.RotateAt(minuteAngle, new PointF(centerX, centerY));
            e.Graphics.Transform = rotate;
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(centerX, centerY), new Point(endX + 30, endY + 30));





        }
        public void DrawSections(PaintEventArgs e)
        {
            int centerX = size / 2 + 10;
            int centerY = size / 2 + 10;
            int radius = size / 2 - 28;
            int startX = centerX;
            int startY = centerY - radius + 10;
            int endX = centerX;
            int endY = centerY - radius;

            for (int i = 1; i <= 60; i++)
            {
                
                rotate.RotateAt(6, new PointF(centerX, centerY));
                e.Graphics.Transform = rotate;

                if (i % 5 != 0)
                {



                    e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(startX, startY), new Point(endX, endY));
                }
                else
                {


                    e.Graphics.DrawLine(new Pen(Color.Black, 5), new Point(startX, startY), new Point(endX, endY));
                }
            }
        }

        public void PrintNumbs(PaintEventArgs e)
        {
            int centerX = size / 2 + 2;
            int centerY = size / 2;
            int radius = size / 2 - 68;

            for (int i = 1; i <= 12; i++)
            {
                Font drawFont = new Font("Arial", 24);
                float angleInRadians = (float)(29.50 * (i - 3) * Math.PI / 180);


                int markerX = centerX + (int)(radius * Math.Cos(angleInRadians));
                int markerY = centerY + (int)(radius * Math.Sin(angleInRadians));


                e.Graphics.DrawString(i.ToString(), drawFont, new SolidBrush(Color.Black), new PointF(markerX - 10, markerY - 10));
            }
        }

        public void RunClock()
        {


           
            while (true)
            {
                DateTime time = DateTime.Now;
                int seconds = time.Second;
                int minute = time.Minute;
                int hour = time.Hour;
                secondAngle = (float)((360.0 / 60) * seconds);
                minuteAngle = (float)((360.0 / 60) * minute);
                HourAngle = (float)((360.0 / 12) * hour);


                Invalidate();
                Thread.Sleep(1000);
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
    


            //g.Clear(BackColor);

        }
    }
}

