using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MQSender.Net.View.WinForm
{
    public partial class MQConfig: Form
    {
        private MQService mqSrv;

        public MQConfig()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                MessageBox.Show("连接失败！" + ex.Message);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Configer.SetSettingsValue("HostName", this.tbxHostName.Text);
            Configer.SetSettingsValue("Port", this.tbxPort.Text);
            Configer.SetSettingsValue("MQCCSID", this.tbxCCSID.Text);
            Configer.SetSettingsValue("Channel", this.tbxChannel.Text);
            Configer.SetSettingsValue("UserId", this.tbxUserId.Text);
            Configer.SetSettingsValue("QmgrName", this.tbxQmgrName.Text);
            Configer.SetSettingsValue("QueueName", this.tbxQueueName.Text);
        }

        private void MQConfig_Load(object sender, EventArgs e)
        {
            tbxHostName.Text = Configer.GetSettingsValue("HostName");
            tbxPort.Text = Configer.GetSettingsValue("Port");
            tbxCCSID.Text = Configer.GetSettingsValue("MQCCSID");
            tbxChannel.Text = Configer.GetSettingsValue("Channel");
            tbxUserId.Text = Configer.GetSettingsValue("UserId");
            tbxQmgrName.Text = Configer.GetSettingsValue("QmgrName");
            tbxQueueName.Text = Configer.GetSettingsValue("QueueName");
        }
    }
}
