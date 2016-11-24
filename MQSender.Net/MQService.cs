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
        private MQQueueManager m_Qmgr;
        public void Init()
        {
            MQEnvironment.Hostname = "127.0.0.1";
            MQEnvironment.Port = 1414;
            MQEnvironment.Channel = "SVRCONN";

            m_Qmgr = new MQQueueManager("QMCENTER");
        }
    }
}
