
namespace Utility.SqlDatabase
{
    public class RestorePercentCompleteEventArgs
    {
        public string Database { get; internal set; }
        public string Message { get; internal set; }
        public int Percent { get; internal set; }
    }
}
