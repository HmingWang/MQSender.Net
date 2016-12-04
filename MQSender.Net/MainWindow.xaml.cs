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
using System.IO;

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
            if (mqSrv == null)
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
            try
            {
                mqSrv.PutMessage(this.tbxMsg.Text);
                MessageBox.Show("发生成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("发送失败！" + ex.Message);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string msg;
            try
            {
                mqSrv.GetMessage(out msg);
                MessageBox.Show(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveResource()
        {
            ResourceWriter rw = new ResourceWriter("Resources.resx");
            rw.AddResource("strHostName", this.tbxHostName.Text);
            rw.AddResource("strPort",this.tbxPort.Text);
            rw.AddResource("strCCSID", this.tbxCCSID.Text);
            rw.AddResource("strChannel", this.tbxChannel.Text);
            rw.AddResource("strUserId", this.tbxUserId.Text);
            rw.AddResource("strQmgrName", this.tbxQmgrName.Text);
            rw.AddResource("strQueueName", this.tbxQueueName.Text);
            rw.Generate();
            rw.Close();
        }

        private void LoadResource()
        {
            try
            {
                ResourceReader rr = new ResourceReader("Resources.resx");
                string type;
                byte[] byteHostName, bytePort, byteCCSID, byteChannel, byteUserId, byteQmgrName, byteQueueName;
                rr.GetResourceData("strHostName", out type, out byteHostName);
                rr.GetResourceData("strPort", out type, out bytePort);
                rr.GetResourceData("strCCSID", out type, out byteCCSID);
                rr.GetResourceData("strChannel", out type, out byteChannel);
                rr.GetResourceData("strUserId", out type, out byteUserId);
                rr.GetResourceData("strQmgrName", out type, out byteQmgrName);
                rr.GetResourceData("strQueueName", out type, out byteQueueName);
                rr.Close();

                this.tbxHostName.Text = new BinaryReader(new MemoryStream(byteHostName)).ReadString();
                this.tbxPort.Text = new BinaryReader(new MemoryStream(bytePort)).ReadString();
                this.tbxCCSID.Text = new BinaryReader(new MemoryStream(byteCCSID)).ReadString();
                this.tbxChannel.Text = new BinaryReader(new MemoryStream(byteChannel)).ReadString();
                this.tbxUserId.Text = new BinaryReader(new MemoryStream(byteUserId)).ReadString();
                this.tbxQmgrName.Text = new BinaryReader(new MemoryStream(byteQmgrName)).ReadString();
                this.tbxQueueName.Text = new BinaryReader(new MemoryStream(byteQueueName)).ReadString();

                if(mqSrv==null)
                    mqSrv = new MQService();

                mqSrv.Hostname = this.tbxHostName.Text;
                mqSrv.Port = int.Parse(this.tbxPort.Text);
                mqSrv.MQCCSID = this.tbxCCSID.Text;
                mqSrv.Channel = this.tbxChannel.Text;
                mqSrv.UserId = this.tbxUserId.Text;
                mqSrv.QmgrName = this.tbxQmgrName.Text;
                mqSrv.QueueName = this.tbxQueueName.Text;
            }
            catch (Exception)
            {
                return;
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            SaveResource();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadResource();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            LoadResource();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(this.tbxFileName.Text))
            {
                MessageBox.Show("文件不存在！");
                return;
            }

            FileStream fs = File.OpenRead(this.tbxFileName.Text);
            byte[] byteMessage = new Byte[fs.Length];
            fs.Read(byteMessage, 0,(int)fs.Length);
            mqSrv.PutMessage(Encoding.GetEncoding("UTF-8").GetString(byteMessage));
            MessageBox.Show("发送成功！");
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            //dialog.Filter = "SQLite数据库文件|*.db";

            if (dialog.ShowDialog() == true)
            {
                this.tbxFileName.Text = dialog.FileName;
            }
        }
    }
}
