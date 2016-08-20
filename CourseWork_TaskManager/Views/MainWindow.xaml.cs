using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Diagnostics;

namespace CourseWork_TaskManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView
    {
        System.Windows.Forms.NotifyIcon notifyIcon = new System.Windows.Forms.NotifyIcon();
        public MainView()
        {
            Process thisProc = Process.GetCurrentProcess();
            if (Process.GetProcessesByName(thisProc.ProcessName).Length > 1)
            {
                MessageBox.Show("Application is already running.", "TaskManager");
                Application.Current.Shutdown();
                return;
            }
            notifyIcon.Icon = new System.Drawing.Icon("../../Images/1.ico");
            notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(notifyIcon_Click);
            InitializeComponent();
        }

        private void DataGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Kill_button.IsEnabled = true;
        }

        private void MetroWindow_StateChanged(object sender, EventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Maximized:
                    break;
                case WindowState.Minimized:
                    this.Hide();
                    notifyIcon.Visible = true;
                    notifyIcon.ShowBalloonTip(500, "TaskManager", "lolo", System.Windows.Forms.ToolTipIcon.Info);
                    //this.notifyIcon1.ShowBalloonTip(3);
                    break;
                case WindowState.Normal:
                    notifyIcon.Visible = false;
                    break;
            } 
        }

        public void notifyIcon_Click(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.Show();
            this.WindowState = System.Windows.WindowState.Normal;
        }
    }
}
