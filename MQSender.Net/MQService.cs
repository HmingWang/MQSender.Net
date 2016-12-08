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
            mqQueue = mqQMgr.AccessQueue(queuename, MQC.MQOO_OUTPUT|MQC.MQOO_FAIL_IF_QUIESCING );
            isConnected = true;
        }

        public void Commit()
        {
            mqQMgr.Commit();
        }

        public void PutMessage(byte[] msg)
        {
            if (!isConnected)
            {
                Init();
            }
            mqMsg = new MQMessage();
            mqMsg.Write(msg);
            mqMsg.MessageType = MQC.MQMT_DATAGRAM;          
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
            mqGetMsgOpts.Options = mqGetMsgOpts.Options + MQC.MQGMO_SYNCPOINT;//Get messages under sync point control（在同步点控制下获取消息）   
            mqGetMsgOpts.Options = mqGetMsgOpts.Options + MQC.MQGMO_WAIT;  // Wait if no messages on the Queue（如果在队列上没有消息则等待）   
            mqGetMsgOpts.Options = mqGetMsgOpts.Options + MQC.MQGMO_FAIL_IF_QUIESCING;// Fail if Qeue Manager Quiescing（如果队列管理器停顿则失败）   
            mqGetMsgOpts.WaitInterval = 1000;
            
            mqQueue = mqQMgr.AccessQueue(queuename, MQC.MQOO_INPUT_AS_Q_DEF | MQC.MQOO_OUTPUT);
            mqQueue.Get(mqMsg, mqGetMsgOpts);
            msg = mqMsg.ReadString(mqMsg.MessageLength);
        }
    }
}
