using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBM.WMQ;

namespace MQSample
{
    class MQSeriesClass
    {
        static MQQueueManager queueManager;
        static MQQueue queue;
        static MQMessage queueMessage;
        static MQPutMessageOptions queuePutMessageOptions;
        static MQGetMessageOptions queueGetMessageOptions;

        static string QueueName;
        static string QueueManagerName;
        static string ChannelInfo;

        static void Main(string[] args)
        {
            QueueName = "MATH.REQUEST";
            QueueManagerName = "QM_winxp0";
            ChannelInfo = "";

            MQSeriesClass mqSeries = new MQSeriesClass();

            {
                queueMessage = new MQMessage();
                queueMessage.WriteString("Hello World");
                queueMessage.Format = MQC.MQFMT_STRING;
                queuePutMessageOptions = new MQPutMessageOptions();
                queue.Put(queueMessage, queuePutMessageOptions);
            }

            Console.WriteLine("Success fully entered the message into the queue");


            {
                queue = queueManager.AccessQueue(QueueName, MQC.MQOO_INPUT_AS_Q_DEF + MQC.MQOO_FAIL_IF_QUIESCING);
                queueMessage = new MQMessage();
                queueMessage.Format = MQC.MQFMT_STRING;
                queueGetMessageOptions = new MQGetMessageOptions();

                queue.Get(queueMessage, queueGetMessageOptions);

                System.Console.WriteLine("Received Message: {0}", queueMessage.ReadString(queueMessage.MessageLength));
            }

            Console.ReadLine();




        }
    }
}
