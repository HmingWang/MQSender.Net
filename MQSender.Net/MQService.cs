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
            //MQEnvironment.UserId = userid;

            try
            {
                mqQMgr = new MQQueueManager(qmgrname);
                mqQueue = mqQMgr.AccessQueue(queuename, MQC.MQOO_OUTPUT | MQC.MQOO_INPUT_SHARED | MQC.MQOO_INQUIRE);
            }
            catch (MQException e)
            {
                System.Console.WriteLine(e.Message);
                throw new AppException("(" + e.ReasonCode + ")" + e.Message);
            }
        }

        public void PutMessage(string msg)
        {
            mqMsg = new MQMessage();
            mqMsg.WriteString(msg);
            mqMsg.Format = MQC.MQFMT_STRING;
            mqPutMsgOpts = new MQPutMessageOptions();

            mqQueue.Put(mqMsg, mqPutMsgOpts);
        }
        public void GetMessage(out string msg)
        {
            mqGetMsgOpts = new MQGetMessageOptions();
            mqQueue.Get(mqMsg, mqGetMsgOpts);
            msg = mqMsg.ReadString(mqMsg.MessageLength);
        }
    }

    class AppException : ApplicationException
    {
        public AppException() : base() { }
        public AppException(String msg) : base(msg) { }
    }
}
