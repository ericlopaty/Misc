using System;
using IBM.WMQ;

namespace MQSeries
{
class MQSeriesClass
{
MQQueueManager queueManager;
MQQueue queue;
MQMessage queueMessage;
MQPutMessageOptions queuePutMessageOptions;
MQGetMessageOptions queueGetMessageOptions;

static string QueueName;
static string QueueManagerName;
static string ChannelInfo;

string channelName;
string transportType;
string connectionName;

string message;
byte[] MessageID;

static void Main(string[] args)
{
Console.WriteLine("Enter the Queue Name : ");
QueueName = Console.ReadLine();

Console.WriteLine("Enter the Queue Manager Name : ");
QueueManagerName = Console.ReadLine();

Console.WriteLine("Enter the Channel Info, Format: ChannelName/TCP/192.168.232.500 ");
ChannelInfo = Console.ReadLine();

MQSeriesClass mqSeries = new MQSeriesClass();
mqSeries.putTheMessageIntoQueue();
mqSeries.GetMessageFromTheQueue();

Console.ReadLine();

}

public void putTheMessageIntoQueue()
{
char[] separator = {'/'};
string[] ChannelParams;
ChannelParams = ChannelInfo.Split( separator );
channelName = ChannelParams[0];
transportType = ChannelParams[1];
connectionName = ChannelParams[2];
try
{
queueManager = new MQQueueManager( QueueManagerName, channelName, connectionName );
queue = queueManager.AccessQueue( QueueName, MQC.MQOO_OUTPUT + MQC.MQOO_FAIL_IF_QUIESCING );
Console.WriteLine("Enter the message to put in MQSeries server:");
message = System.Console.ReadLine();
int msgLen = message.Length;

while(msgLen == 0)
{
if(msgLen == 0)
Console.WriteLine("Please reenter the message:");
message = System.Console.ReadLine();
msgLen = message.Length;
}


queueMessage = new MQMessage();
queueMessage.WriteString( message );
queueMessage.Format = MQC.MQFMT_STRING;
queuePutMessageOptions = new MQPutMessageOptions();

//putting the message into the queue
queue.Put( queueMessage, queuePutMessageOptions );
MessageID = queueMessage.MessageId;

Console.WriteLine("Success fully entered the message into the queue");
}
catch(MQException mqexp)
{
Console.WriteLine( "MQSeries Exception: " + mqexp.Message );
}
}

public void GetMessageFromTheQueue()
{

queue = queueManager.AccessQueue( QueueName, MQC.MQOO_INPUT_AS_Q_DEF + MQC.MQOO_FAIL_IF_QUIESCING );
queueMessage = new MQMessage();
queueMessage.Format = MQC.MQFMT_STRING;
queueMessage.MessageId = MessageID;
queueGetMessageOptions = new MQGetMessageOptions();

try
{
queue.Get( queueMessage, queueGetMessageOptions );

// Received Message.
System.Console.WriteLine( "Received Message: {0}", queueMessage.ReadString(queueMessage.MessageLength));

}
catch (MQException MQExp)
{
// report the error
System.Console.WriteLine( "MQQueue::Get ended with " + MQExp.Message );
}
}

}
}

