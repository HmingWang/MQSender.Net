using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IBM.WMQ;

namespace MQSender.Net
{
    class MQService
    {
        private MQQueueManager mqQMgr;
        private MQQueue mqQueue;
        private MQMessage mqMsg;
        private MQPutMessageOptions mqPutMsgOpts;    // MQPutMessageOptions instance
        private MQGetMessageOptions mqGetMsgOpts;    // MQGetMessageOptions instance
        private bool isConnected=false;
        private string mqccsid;        
        private string hostname;        
        private int    port;        
        private string channel;
        private string userid;
        private string queuename;
        private string qmgrname;
        
        public string MQCCSID   { set { mqccsid = value; } }
        public string Hostname  { set { hostname = value; } }
        public int    Port      { set { port = value; } }
        public string Channel   { set { channel = value; } }
        public string UserId    { set { userid = value; } }
        public string QueueName     { set { queuename = value; } }
        public string QmgrName    { set { qmgrname = value; } }

        public void Init()
        {
            Environment.SetEnvironmentVariable("MQCCSID", mqccsid);
            MQEnvironment.Hostname = hostname;
            MQEnvironment.Port = port;
            MQEnvironment.Channel = channel;
            MQEnvironment.UserId = string.IsNullOrEmpty(userid) ? null : userid; 

            mqQMgr = new MQQueueManager(qmgrname);
            mqQueue = mqQMgr.AccessQueue(queuename, MQC.MQOO_OUTPUT | MQC.MQOO_INPUT_SHARED | MQC.MQOO_INQUIRE);
            isConnected = true;
        }

        public void PutMessage(string msg)
        {
            if (!isConnected)
            {
                Init();
            }
            mqMsg = new MQMessage();
            mqMsg.WriteString(msg);
            mqMsg.Format = MQC.MQFMT_STRING;
            mqPutMsgOpts = new MQPutMessageOptions();

            mqQueue.Put(mqMsg, mqPutMsgOpts);
        }
        public void GetMessage(out string msg)
        {
            if (!isConnected)
            {
                Init();
            }
            mqGetMsgOpts = new MQGetMessageOptions();
            mqQueue.Get(mqMsg, mqGetMsgOpts);
            msg = mqMsg.ReadString(mqMsg.MessageLength);
        }
    }
}
