using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Resources;
using System.Reflection;
using System.Globalization;

namespace ScoreTweak
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private static ResourceManager rm = new ResourceManager("ScoreTweak." + CultureInfo.CurrentUICulture.TwoLetterISOLanguageName + "_local", Assembly.GetExecutingAssembly());
 
        private void LoadLanguage()
        {
            try
            {

                label1.Text = rm.GetString("label1");
                label2.Text = rm.GetString("label2");
                label40.Text = rm.GetString("label40");

                label3.Text = rm.GetString("component");
                label4.Text = rm.GetString("whatsrated");
                label5.Text = rm.GetString("subscore");
                label6.Text = rm.GetString("basescore");

                label15.Text = rm.GetString("calculation");
                label25.Text = rm.GetString("memoryram");
                label29.Text = rm.GetString("deskperformance");
                label33.Text = rm.GetString("graphperformance");
                label37.Text = rm.GetString("diskperf");

                label7.Text = rm.GetString("processor");
                label10.Text = rm.GetString("ram");
                label12.Text = rm.GetString("graphics");
                label13.Text = rm.GetString("gaming");
                label11.Text = rm.GetString("hdd");

                label38.Text = rm.GetString("determined");

                button1.Text = rm.GetString("about");
            }
            catch(Exception)
            {

            }
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hdd_score_Click(object sender, EventArgs e)
        {

        }

        private void gaming_score_Click(object sender, EventArgs e)
        {

        }

        private void graphic_score_Click(object sender, EventArgs e)
        {

        }

        private void ram_score_Click(object sender, EventArgs e)
        {

        }

        private void cpu_score_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadLanguage();

            ManagementObjectSearcher computer_system = new ManagementObjectSearcher("select * from " + "Win32_WinSAT");
            foreach (ManagementObject data in computer_system.Get())
            {
                foreach (PropertyData PC in data.Properties)
                {

                    cpu_score.Text = data["CPUScore"].ToString();
                    ram_score.Text = data["MemoryScore"].ToString();
                    graphic_score.Text = data["GraphicsScore"].ToString();
                    gaming_score.Text = data["D3DScore"].ToString();
                    hdd_score.Text = data["DiskScore"].ToString();
                    lowest_score.Text = data["WinSPRLevel"].ToString();

                    if(cpu_score.Text == lowest_score.Text)
                    {
                        panel34.BackColor = Color.DarkGray;
                    }
                    else if (ram_score.Text == lowest_score.Text)
                    {
                        panel35.BackColor = Color.DarkGray;
                    }
                    else if (graphic_score.Text == lowest_score.Text)
                    {
                        panel36.BackColor = Color.DarkGray;
                    }
                    else if (gaming_score.Text == lowest_score.Text)
                    {
                        panel37.BackColor = Color.DarkGray;
                    }
                    else if (hdd_score.Text == lowest_score.Text)
                    {
                        panel38.BackColor = Color.DarkGray;
                    }


                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AboutBox aboutbox = new AboutBox();
            aboutbox.Show();
        }
    }
}