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

using System.Resources;


namespace MQSender.Net
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
        private MQService mqSrv;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            mqSrv = new MQService();

            mqSrv.Hostname = this.tbxHostName.Text;
            mqSrv.Port = int.Parse(this.tbxPort.Text);
            mqSrv.MQCCSID = this.tbxCCSID.Text;
            mqSrv.Channel = this.tbxChannel.Text;
            mqSrv.UserId = this.tbxUserId.Text;
            mqSrv.QmgrName = this.tbxQmgrName.Text;
            mqSrv.QueueName = this.tbxQueueName.Text;
            try
            {
                mqSrv.Init();
                MessageBox.Show("连接成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败！"+ex.Message);
                return;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            mqSrv.PutMessage(this.tbxMsg.Text);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string msg;
            mqSrv.GetMessage(out msg);

            MessageBox.Show(msg);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ResourceWriter rw = new ResourceWriter("Resources.resx");
            rw.AddResource("strHostName", this.tbxHostName.Text);
            rw.Generate();
            rw.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ResourceReader rr = new ResourceReader("Resources.resx");
            string type;
            byte[] data;
            rr.GetResourceData("strHostName", out type, out data);

            this.tbxHostName.Text = System.Text.Encoding.Default.GetString(data);
            rr.Close();
        }
    }
}
