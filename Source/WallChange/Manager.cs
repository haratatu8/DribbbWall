using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO; 
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using Codeplex.Data;



namespace WallChange
{	
		
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Setting : System.Windows.Forms.Form
	{
		public const int SPI_SETDESKWALLPAPER = 20;
		public const int SPIF_SENDCHANGE = 0x2;
		public int picIndex ;
        private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Timer timer1;
		string fileName;
		private System.Windows.Forms.CheckBox chkRandom;
		private System.Windows.Forms.ComboBox drpInterval;
		private int GlobalTimer;
        public int GlobalInterval;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private int[] myArray;
		private System.Windows.Forms.MenuItem menuItem3;
        private TextBox txtUserName;
        private Label label1;
		private Settings mySetting;
        public string UserName;
        private Label label2;
        private string jsonDribbbleLikes;
        public bool isRandom;
        private Button cmdOK;
        public int IntervalIndex;
        public int CurrentPage;
        public int DisplayPicCnt;
        
		public Setting()
		{
			InitializeComponent();
			mySetting = new Settings(Directory.GetCurrentDirectory(), this);

			GlobalTimer = 0;
			GlobalInterval = 60 / 5;
            UserName = @"frogandcode";
			
			picIndex = 0;
			myArray = new int[]{   60 ,
								   5 * 60, 
								   15 * 60 ,
								   1 * 60 * 60 ,
								   2 * 60 * 60 , 
								   1 * 24 * 60 * 60 ,
								   2 * 24 * 60 * 60 , 
									-12
							   };
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chkRandom = new System.Windows.Forms.CheckBox();
            this.drpInterval = new System.Windows.Forms.ComboBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chkRandom
            // 
            this.chkRandom.Location = new System.Drawing.Point(87, 58);
            this.chkRandom.Name = "chkRandom";
            this.chkRandom.Size = new System.Drawing.Size(157, 23);
            this.chkRandom.TabIndex = 6;
            this.chkRandom.Text = "ランダムに壁紙を変える";
            this.chkRandom.CheckedChanged += new System.EventHandler(this.chkRandom_CheckedChanged);
            // 
            // drpInterval
            // 
            this.drpInterval.Items.AddRange(new object[] {
            "1分",
            "5分",
            "15分",
            "1時間",
            "2時間",
            "1日",
            "2日",
            "変更しない"});
            this.drpInterval.Location = new System.Drawing.Point(87, 32);
            this.drpInterval.Name = "drpInterval";
            this.drpInterval.Size = new System.Drawing.Size(72, 20);
            this.drpInterval.TabIndex = 7;
            this.drpInterval.Text = "Interval";
            this.drpInterval.SelectedIndexChanged += new System.EventHandler(this.drpInterval_SelectedIndexChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenu = this.contextMenu1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "DribbbWall";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "設定";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "壁紙変更";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "終了";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(87, 11);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 19);
            this.txtUserName.TabIndex = 9;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "ユーザ名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "タイマー間隔";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(260, 83);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 12;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // Setting
            // 
            this.AllowDrop = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(347, 118);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.drpInterval);
            this.Controls.Add(this.chkRandom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Setting";
            this.Text = "DribbbWall";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Setting_Load);
            this.Resize += new System.EventHandler(this.Setting_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Setting());
		}
		/// <summary>
		/// Change the wallpaper immediately. the method search for any image file in
		/// the directory and enter them into an checked list box
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void changeWall(object sender, System.EventArgs e)
		{
			SetWallpaper();
		}
		
		/// <summary>
		/// form load
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Setting_Load(object sender, System.EventArgs e)
		{
			this.Hide();
			mySetting.LoadSettings();

            txtUserName.Text = UserName;
            chkRandom.Checked = isRandom;
            drpInterval.SelectedIndex = IntervalIndex;

            CurrentPage = 1;
            getLikeJson(CurrentPage);
            
            SetWallpaper();
		}
		
		
		/// <summary>
		/// machine clock
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if (GlobalInterval < 0) return;
			if (GlobalTimer++ > GlobalInterval)
			{
				SetWallpaper();
				GlobalTimer = 0;
			}
		}

        /// <summary>
		/// Dribbble APIからLike情報をJSON形式で取得する
		/// </summary>
        private void getLikeJson(int page)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            jsonDribbbleLikes = wc.DownloadString("http://api.dribbble.com/players/" + UserName + "/shots/likes?page=" + page);
            wc.Dispose();
        }



		/// <summary>
		/// Set the new BMP in the background
		/// </summary>
		private void SetWallpaper()
		{
			try
			{
				int nResult ;
                int shot_count = 0;

                var djDribbbleLikes = DynamicJson.Parse(jsonDribbbleLikes);
                var shots = DynamicJson.Parse(djDribbbleLikes.shots.ToString());
                var pages = djDribbbleLikes.pages;

                foreach(var shot in shots) {
                    shot_count++;
                }

                System.Net.WebClient wc = new System.Net.WebClient();
                wc.DownloadFile(shots[picIndex].image_url.ToString(), mySetting.m_settingsPath + "\\download.png");
                wc.Dispose();
                
                fileName = mySetting.m_settingsPath + "\\download.png";
                Bitmap theImage = new Bitmap(fileName);
                fileName = Path.Combine(mySetting.m_settingsPath ,  "new.bmp");
				theImage.Save (fileName, System.Drawing.Imaging.ImageFormat.Bmp);
				theImage .Dispose();

				nResult =  WinAPI.SystemParametersInfo(SPI_SETDESKWALLPAPER,1,fileName,SPIF_SENDCHANGE);
                picIndex = (picIndex + 1) % shot_count;
                DisplayPicCnt++;
                if (DisplayPicCnt >= shot_count)
                {
                    DisplayPicCnt = 0;
                    CurrentPage++;
                    if (CurrentPage >= pages) {
                        CurrentPage = 1;
                    }
                    getLikeJson(CurrentPage);
                }

				if (chkRandom.Checked == true)
				{
					Random rnd = new Random();
                    picIndex = (rnd.Next(shot_count) % shot_count);
				}

                mySetting.SaveSettings();
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.ToString());
			}
		}

		private void drpInterval_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			GlobalInterval = myArray[drpInterval.SelectedIndex]  / 5;
			GlobalTimer = 0;
            IntervalIndex = drpInterval.SelectedIndex;
            mySetting.SaveSettings();
		}

		private void notifyIcon1_DoubleClick(object sender, System.EventArgs e)
		{
			this.Show();
			this.WindowState = FormWindowState.Normal;
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
            this.Show();
            this.WindowState = FormWindowState.Normal;
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			changeWall(sender, e);
		}

		private void Setting_Resize(object sender, System.EventArgs e)
		{
            switch (WindowState)
            {
                case FormWindowState.Minimized:
                    this.Hide();
                    break;
            }
			
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            UserName = txtUserName.Text;
        }

        private void chkRandom_CheckedChanged(object sender, EventArgs e)
        {
            isRandom = chkRandom.Checked;
            mySetting.SaveSettings();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            mySetting.SaveSettings();
            this.Hide();
        }

	}

	public class WinAPI
	{
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static  extern int SystemParametersInfo (int uAction , int uParam , string lpvParam , int fuWinIni) ;
		public const int SPI_SETDESKWALLPAPER = 20;
		public const int SPIF_SENDCHANGE = 0x2;

	}  


}
