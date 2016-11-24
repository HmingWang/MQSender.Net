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
        public void Init()
        {
            MQEnvironment.Hostname = "127.0.0.1";
            MQEnvironment.Port = 1414;
            MQEnvironment.Channel = "SVRCONN";

            mqQMgr = new MQQueueManager("QMCENTER");

            mqQueue = mqQMgr.AccessQueue("TESTQ_1", MQC.MQOO_OUTPUT | MQC.MQOO_INPUT_SHARED | MQC.MQOO_INQUIRE);

            mqMsg = new MQMessage();
            mqMsg.WriteString("Hello world");
            mqMsg.Format = MQC.MQFMT_STRING;
            mqPutMsgOpts = new MQPutMessageOptions();


            mqQueue.Put(mqMsg, mqPutMsgOpts);

            mqGetMsgOpts = new MQGetMessageOptions();

            //mqQueue.Get(mqMsg, mqGetMsgOpts);

            System.Console.WriteLine(mqMsg.ReadString(mqMsg.MessageLength));
        }
    }
}
