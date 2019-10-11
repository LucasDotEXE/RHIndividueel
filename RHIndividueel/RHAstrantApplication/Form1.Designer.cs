namespace RHAstrantApplication
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.loginPanel = new System.Windows.Forms.Panel();
            this.LoginText = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Login = new System.Windows.Forms.Button();
            this.Naam = new System.Windows.Forms.TextBox();
            this.Gewicht = new System.Windows.Forms.TextBox();
            this.MainPannel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.HeartRate = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MinuteLabel = new System.Windows.Forms.Label();
            this.SessionStateLabel = new System.Windows.Forms.Label();
            this.SessieStatusBarr = new System.Windows.Forms.ProgressBar();
            this.loginPanel.SuspendLayout();
            this.MainPannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // loginPanel
            // 
            this.loginPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.loginPanel.Controls.Add(this.LoginText);
            this.loginPanel.Controls.Add(this.comboBox1);
            this.loginPanel.Controls.Add(this.dateTimePicker1);
            this.loginPanel.Controls.Add(this.Login);
            this.loginPanel.Controls.Add(this.Naam);
            this.loginPanel.Controls.Add(this.Gewicht);
            this.loginPanel.Location = new System.Drawing.Point(259, 97);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(271, 193);
            this.loginPanel.TabIndex = 0;
            // 
            // LoginText
            // 
            this.LoginText.AutoSize = true;
            this.LoginText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginText.ForeColor = System.Drawing.Color.White;
            this.LoginText.Location = new System.Drawing.Point(106, 14);
            this.LoginText.Name = "LoginText";
            this.LoginText.Size = new System.Drawing.Size(55, 20);
            this.LoginText.TabIndex = 5;
            this.LoginText.Text = "Login";
            this.LoginText.Click += new System.EventHandler(this.Label1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.comboBox1.Location = new System.Drawing.Point(60, 94);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(158, 24);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "Biologiesch Geslacht";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(22, 124);
            this.dateTimePicker1.MaxDate = new System.DateTime(2019, 10, 11, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(235, 22);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.Value = new System.DateTime(2019, 10, 11, 0, 0, 0, 0);
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.Color.White;
            this.Login.Location = new System.Drawing.Point(97, 152);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(75, 38);
            this.Login.TabIndex = 0;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = false;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // Naam
            // 
            this.Naam.Location = new System.Drawing.Point(60, 37);
            this.Naam.Name = "Naam";
            this.Naam.Size = new System.Drawing.Size(158, 22);
            this.Naam.TabIndex = 0;
            // 
            // Gewicht
            // 
            this.Gewicht.Location = new System.Drawing.Point(60, 66);
            this.Gewicht.Name = "Gewicht";
            this.Gewicht.Size = new System.Drawing.Size(158, 22);
            this.Gewicht.TabIndex = 0;
            // 
            // MainPannel
            // 
            this.MainPannel.BackColor = System.Drawing.Color.White;
            this.MainPannel.Controls.Add(this.label1);
            this.MainPannel.Controls.Add(this.HeartRate);
            this.MainPannel.Controls.Add(this.pictureBox2);
            this.MainPannel.Controls.Add(this.pictureBox1);
            this.MainPannel.Controls.Add(this.MinuteLabel);
            this.MainPannel.Controls.Add(this.SessionStateLabel);
            this.MainPannel.Controls.Add(this.SessieStatusBarr);
 
            this.MainPannel.Location = new System.Drawing.Point(13, 13);
            this.MainPannel.Name = "MainPannel";
            this.MainPannel.Size = new System.Drawing.Size(775, 440);
            this.MainPannel.TabIndex = 1;
            this.MainPannel.Visible = false;
            this.MainPannel.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(710, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "60%";
            // 
            // HeartRate
            // 
            this.HeartRate.AutoSize = true;
            this.HeartRate.Location = new System.Drawing.Point(714, 40);
            this.HeartRate.Name = "HeartRate";
            this.HeartRate.Size = new System.Drawing.Size(24, 17);
            this.HeartRate.TabIndex = 5;
            this.HeartRate.Text = "90";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(682, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(90, 90);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(682, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // MinuteLabel
            // 
            this.MinuteLabel.AutoSize = true;
            this.MinuteLabel.BackColor = System.Drawing.Color.Transparent;
            this.MinuteLabel.Location = new System.Drawing.Point(361, 378);
            this.MinuteLabel.Name = "MinuteLabel";
            this.MinuteLabel.Size = new System.Drawing.Size(66, 17);
            this.MinuteLabel.TabIndex = 2;
            this.MinuteLabel.Text = "Minute: 0";
            // 
            // SessionStateLabel
            // 
            this.SessionStateLabel.AutoSize = true;
            this.SessionStateLabel.Location = new System.Drawing.Point(303, 411);
            this.SessionStateLabel.Name = "SessionStateLabel";
            this.SessionStateLabel.Size = new System.Drawing.Size(170, 17);
            this.SessionStateLabel.TabIndex = 1;
            this.SessionStateLabel.Text = "Current Session: Warmup";
            // 
            // SessieStatusBarr
            // 
            this.SessieStatusBarr.BackColor = System.Drawing.Color.White;
            this.SessieStatusBarr.ForeColor = System.Drawing.Color.Yellow;
            this.SessieStatusBarr.Location = new System.Drawing.Point(3, 366);
            this.SessieStatusBarr.Maximum = 420;
            this.SessieStatusBarr.Name = "SessieStatusBarr";
            this.SessieStatusBarr.Size = new System.Drawing.Size(769, 42);
            this.SessieStatusBarr.Step = 7;
            this.SessieStatusBarr.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.SessieStatusBarr.TabIndex = 0;
            this.SessieStatusBarr.Click += new System.EventHandler(this.SessieStatusBarr_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loginPanel);
            this.Controls.Add(this.MainPannel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.MainPannel.ResumeLayout(false);
            this.MainPannel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Label LoginText;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.TextBox Gewicht;
        private System.Windows.Forms.TextBox Naam;
        private System.Windows.Forms.Panel MainPannel;
        private System.Windows.Forms.ProgressBar SessieStatusBarr;
        private System.Windows.Forms.Label SessionStateLabel;
        private System.Windows.Forms.Label MinuteLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label HeartRate;
        
    }
}

