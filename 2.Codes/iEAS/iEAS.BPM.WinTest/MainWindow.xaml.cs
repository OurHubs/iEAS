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

namespace iEAS.BPM.WinTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            using (var conn = new Client.Connection("http://localhost:8733/BPMService/"))
            {
                conn.Open();
                var inst = conn.CreateProcessInstance("iEAS.BPM.Test");
                inst.Submit();
                txtId.Text = inst.Id + "";
                txtSN.Text = inst.Id + "_";
                Console.WriteLine("InstId:" + inst.Id);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var conn = new Client.Connection("http://localhost:8733/BPMService/"))
            {
                conn.Open();
                conn.ImpersonateUser(txtUser.Text.Trim());
                var worklistItem = conn.OpenWorklistItem(txtSN.Text);
                Console.WriteLine("InstId:" + worklistItem.SN);
                worklistItem.Execute();
            }
        }

        private void btnClientAPI_Click(object sender, RoutedEventArgs e)
        {
            using (var conn = new Client.Connection("http://localhost:8733/BPMService/"))
            {
                conn.Open();
                var inst=conn.CreateProcessInstance("iEAS.BPM.Test");
                inst.Submit();
                Console.WriteLine("InstId:" + inst.Id);
            }
        }
    }
}
