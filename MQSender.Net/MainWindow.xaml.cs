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
using System.Windows.Threading;

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
        private Signature signature;
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
                mqSrv.PutMessage(Encoding.GetEncoding("GBK").GetBytes( this.tbxMsg.Text));
                mqSrv.Commit();
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
                Console.Out.WriteLineAsync(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveResource()
        {
            ResourceWriter rw = new ResourceWriter("Resources.resx");
            rw.AddResource("HostName", this.tbxHostName.Text);
            rw.AddResource("Port",this.tbxPort.Text);
            rw.AddResource("CCSID", this.tbxCCSID.Text);
            rw.AddResource("Channel", this.tbxChannel.Text);
            rw.AddResource("UserId", this.tbxUserId.Text);
            rw.AddResource("QmgrName", this.tbxQmgrName.Text);
            rw.AddResource("QueueName", this.tbxQueueName.Text);
            rw.AddResource("KeyPath", this.tbxKeyPath.Text);
            rw.AddResource("CertPath", this.tbxCrtPath.Text);
            rw.AddResource("Password", this.tbxPwd.Text);
            rw.AddResource("SignOffset", this.tbxSignOffset.Text);
            rw.AddResource("SignLength", this.tbxSignLength.Text);
            rw.AddResource("VerifyOffset", this.tbxVerifyOffset.Text);
            rw.AddResource("SendCount", this.tbxSendCount.Text);
            rw.AddResource("NumString", this.tbxNumString.Text);
            rw.AddResource("StartNum", this.tbxStartNum.Text);
            rw.AddResource("FileName", this.tbxFileName.Text);
            rw.Generate();
            rw.Close();
        }

        private void LoadResource()
        {
            try
            {
                ResourceReader rr = new ResourceReader("Resources.resx");
                string type;
                byte[] byteTmp;
                rr.GetResourceData("HostName", out type, out byteTmp);
                this.tbxHostName.Text = new BinaryReader(new MemoryStream(byteTmp)).ReadString();
                rr.GetResourceData("Port", out type, out byteTmp);
                this.tbxPort.Text = new BinaryReader(new MemoryStream(byteTmp)).ReadString();
                rr.GetResourceData("CCSID", out type, out byteTmp);
                this.tbxCCSID.Text = new BinaryReader(new MemoryStream(byteTmp)).ReadString();
                rr.GetResourceData("Channel", out type, out byteTmp);
                this.tbxChannel.Text = new BinaryReader(new MemoryStream(byteTmp)).ReadString();
                rr.GetResourceData("UserId", out type, out byteTmp);
                this.tbxUserId.Text = new BinaryReader(new MemoryStream(byteTmp)).ReadString();
                rr.GetResourceData("QmgrName", out type, out byteTmp);
                this.tbxQmgrName.Text = new BinaryReader(new MemoryStream(byteTmp)).ReadString();
                rr.GetResourceData("QueueName", out type, out byteTmp);
                this.tbxQueueName.Text = new BinaryReader(new MemoryStream(byteTmp)).ReadString();
                rr.GetResourceData("KeyPath", out type, out byteTmp);
                this.tbxKeyPath.Text= new BinaryReader(new MemoryStream(byteTmp)).ReadString();
                rr.GetResourceData("CertPath", out type, out byteTmp);
                this.tbxCrtPath.Text = new BinaryReader(new MemoryStream(byteTmp)).ReadString();
                rr.GetResourceData("Password", out type, out byteTmp);
                this.tbxPwd.Text = new BinaryReader(new MemoryStream(byteTmp)).ReadString();
                rr.GetResourceData("SignOffset", out type, out byteTmp);
                this.tbxSignOffset.Text = new BinaryReader(new MemoryStream(byteTmp)).ReadString();
                rr.GetResourceData("SignLength", out type, out byteTmp);
                this.tbxSignLength.Text = new BinaryReader(new MemoryStream(byteTmp)).ReadString();
                rr.GetResourceData("VerifyOffset", out type, out byteTmp);
                this.tbxVerifyOffset.Text = new BinaryReader(new MemoryStream(byteTmp)).ReadString();
                rr.GetResourceData("SendCount", out type, out byteTmp);
                this.tbxSendCount.Text = new BinaryReader(new MemoryStream(byteTmp)).ReadString();
                rr.GetResourceData("NumString", out type, out byteTmp);
                this.tbxNumString.Text = new BinaryReader(new MemoryStream(byteTmp)).ReadString();
                rr.GetResourceData("StartNum", out type, out byteTmp);
                this.tbxStartNum.Text = new BinaryReader(new MemoryStream(byteTmp)).ReadString();
                rr.GetResourceData("FileName", out type, out byteTmp);
                this.tbxFileName.Text = new BinaryReader(new MemoryStream(byteTmp)).ReadString();
                rr.Close();

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

            byte[] byteMessage = File.ReadAllBytes(this.tbxFileName.Text);
            mqSrv.PutMessage(byteMessage);
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

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "PFX文件|*.pfx";

            if (dialog.ShowDialog() == true)
            {
                this.tbxKeyPath.Text = dialog.FileName;
            }
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(this.tbxKeyPath.Text))
            {
                MessageBox.Show("私钥文件不存在");
                return;
            }
            if (!File.Exists(this.tbxCrtPath.Text))
            {
                MessageBox.Show("证书文件不存在");
                return;
            }

            if (string.IsNullOrEmpty(this.tbxPwd.Text))
            {
                MessageBox.Show("请输入密码");
                return;
            }

            signature = new Signature(this.tbxCrtPath.Text, this.tbxKeyPath.Text, this.tbxPwd.Text);
            MessageBox.Show("绑定成功！");
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(this.tbxFileName.Text))
            {
                MessageBox.Show("文件不存在！");
                return;
            }

            if (String.IsNullOrEmpty(this.tbxSignLength.Text) || String.IsNullOrEmpty(this.tbxSignOffset.Text) || String.IsNullOrEmpty(this.tbxVerifyOffset.Text))
            {
                MessageBox.Show("请填写加核签偏移值相关字段");
                return;
            }


            byte[] fileText = File.ReadAllBytes(this.tbxFileName.Text);

            File.WriteAllBytes(this.tbxFileName.Text, SignString(fileText));

            MessageBox.Show("加签成功");
            
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            //dialog.Filter = "PFX文件|*.pfx";

            if (dialog.ShowDialog() == true)
            {
                this.tbxCrtPath.Text = dialog.FileName;
            }
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(this.tbxFileName.Text))
            {
                MessageBox.Show("文件不存在！");
                return;
            }

            if (String.IsNullOrEmpty(this.tbxSignLength.Text) || String.IsNullOrEmpty(this.tbxSignOffset.Text) || String.IsNullOrEmpty(this.tbxVerifyOffset.Text))
            {
                MessageBox.Show("请填写加核签偏移值相关字段");
                return;
            }


            string fileText = File.ReadAllText(this.tbxFileName.Text, Encoding.GetEncoding("GBK"));
            

            int startIndex = int.Parse(this.tbxVerifyOffset.Text);
            int index = int.Parse(this.tbxSignOffset.Text);
            int length = int.Parse(this.tbxSignLength.Text);

            byte[] fileBytes = File.ReadAllBytes(this.tbxFileName.Text).Skip(startIndex).ToArray();
            string signedDate = fileText.Substring(index, length).Trim();

            bool isSucess = signature.VerifySigned(fileBytes, signedDate);

            if (isSucess)
            {
                MessageBox.Show("验签成功");
            }
            else
            {
                MessageBox.Show("验签失败");
            }
        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(this.tbxFileName.Text))
            {
                MessageBox.Show("文件不存在！");
                return;
            }
            if (string.IsNullOrEmpty(tbxStartNum.Text) || string.IsNullOrEmpty(tbxSendCount.Text) || string.IsNullOrEmpty(tbxNumString.Text))
            {
                MessageBox.Show("请填写批量发送相关字段");
                return;
            }

            string msg = File.ReadAllText(this.tbxFileName.Text, Encoding.GetEncoding("GBK"));
            byte[] bytesData = File.ReadAllBytes(this.tbxFileName.Text);
            if (!msg.Contains(this.tbxNumString.Text))
            {
                MessageBox.Show("序号字符串未出现");
                return;
            }
            int count = int.Parse(this.tbxSendCount.Text);
            int startnum = int.Parse(this.tbxStartNum.Text);

            for (int i = 0; i < count; ++i)
            {
                this.lblCurNum.Content = startnum.ToString();

                bytesData = Encoding.GetEncoding("GBK").GetBytes(msg.Replace(this.tbxNumString.Text, startnum++.ToString()));
                bytesData = SignString(bytesData);
                mqSrv.PutMessage(bytesData);

                this.prbSendProgress.Value = Convert.ToDouble(i) / count * 100;
                this.lblPersent.Content = (Convert.ToDouble(i) / count * 100.0).ToString() + "%";

                DoEvents();
            }

            this.prbSendProgress.Value = 100;
            this.lblPersent.Content = "100%";
            

            MessageBox.Show("发送成功！");
        }

        private byte[] SignString(byte[] orgDate)
        {
            int startIndex = int.Parse(this.tbxVerifyOffset.Text);
            string sign = signature.HashAndSign(orgDate.Skip(startIndex).ToArray());

            byte[] sb = orgDate;

            int index = int.Parse(this.tbxSignOffset.Text);
            int length = int.Parse(this.tbxSignLength.Text);
            sign += new string(' ', length - sign.Length);//空格填充
            for (int i = 0; i < length; ++i)
            {
                sb[index++] = (byte)sign[i];
            }

            return sb;
        }

        public void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
                new DispatcherOperationCallback(delegate (object f)
                {
                    ((DispatcherFrame)f).Continue = false;

                    return null;
                }
                    ), frame);
            Dispatcher.PushFrame(frame);
        }
    }
}
