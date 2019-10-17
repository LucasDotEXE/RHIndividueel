using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace RHAstrantApplication
{
    public partial class Form1 : Form
    {
        System.Timers.Timer aTimer;
        public Form1()
        {
            InitializeComponent();
            //VerticalProgressBar progressBar = new VerticalProgressBar();
            //progressBar.Location = new Point(0, 100);
            //this.MainPannel.Controls.Add(progressBar);

            //ProgressBar progbar = new ProgressBar();
            //progbar.IsIndeterminate = false;
            //progbar.Orientation = Orientation.Horizontal;

            //   progbar.
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (LoginIsCorrect())
            {
                test();

                this.loginPanel.Visible = false;
                this.MainPannel.Visible = true;

                // Create a timer with a two second interval.
               aTimer = new System.Timers.Timer(1000);
                // Hook up the Elapsed event for the timer. 
                aTimer.Elapsed += OnTimedEvent;
                aTimer.AutoReset = true;
                aTimer.Enabled = true;

                //start client program etc

            }
        }

        private void test()
        {
            setHeartrate(100);
            setResistance(0.50);
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            this.BeginInvoke(new Action(delegate() {
                int i = this.SessieStatusBarr.Value;
                if (i < this.SessieStatusBarr.Maximum)
                {
                    this.SessieStatusBarr.Value++;
                }
                else
                {
                    aTimer.Stop();
                }
                int timeInMinutes = (i - (i % 60)) / 60;

                if (timeInMinutes >= 2 && timeInMinutes <= 5 && this.SessieStatusBarr.ForeColor != Color.Orange)
                {
                    this.SessieStatusBarr.ForeColor = Color.Orange;
                    this.SessionStateLabel.Text = "Current Session: Aan het meten";
                }
                if (timeInMinutes == 3 && this.MinuteLabel.BackColor != Color.Orange)
                {
                    this.MinuteLabel.BackColor = Color.Orange;
                }
                if (timeInMinutes >= 6 && this.SessieStatusBarr.ForeColor != Color.SkyBlue)
                {
                    this.SessieStatusBarr.ForeColor = Color.SkyBlue;
                    this.MinuteLabel.BackColor = Color.SkyBlue;
                    this.SessionStateLabel.Text = "Current Session: Cool down";
                }
                this.MinuteLabel.Text = $"Minute: {timeInMinutes}";
            }));
            

        }

        private bool LoginIsCorrect()
        {
            return true;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SessieStatusBarr_Click(object sender, EventArgs e)
        {

        }

        private void HeartRate_Click(object sender, EventArgs e)
        {

        }

        public void setResistance(double resistance)
        {
            this.resistanceLabel.Text = $"{resistance*100}%";
        }

        public void setHeartrate(int bpm)
        {
            this.HeartRate.Text = $"{bpm}";
            Console.WriteLine("hyo");
        }
    }
   

    
}
