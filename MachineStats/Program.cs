using System;
using System.Text;
using System.Management;
using System.Net.NetworkInformation;
using System.Threading;

namespace MachineStats
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length > 0 && args[0] == "?")
                {
                    Console.WriteLine();
                    Console.WriteLine("Available Options (multiple options allowed on command line):");
                    Console.WriteLine();
                    Console.WriteLine("MachineStats PROC");
                    Console.WriteLine("MachineStats MEM");
                    Console.WriteLine("MachineStats DISK");
                    Console.WriteLine("MachineStats DISPLAY");
                    Console.WriteLine("MachineStats NET");
                    Console.WriteLine();
                    return;
                }
                Console.WriteLine("Collecting Machine Information...");
                Console.WriteLine();
                Console.WriteLine("User Name: {0}\\{1}", System.Environment.UserDomainName, System.Environment.UserName);
                Console.WriteLine();
                if (args.Length == 0)
                {
                    EnumProcessor();
                    EnumMemory();
                    EnumPhysicalDisk();
                    EnumDisk();
                    EnumDisplay();
                    EnumVideo();
                    SendPing("heartlandcropinsurance.com");
                }
                else
                {
                    foreach (string arg in args)
                    {
                        if (arg.ToUpper().StartsWith("PROC"))
                        {
                            EnumProcessor();
                        }
                        if (arg.ToUpper().StartsWith("MEM"))
                        {
                            EnumMemory();
                        }
                        if (arg.ToUpper().StartsWith("DISK"))
                        {
                            EnumPhysicalDisk();
                            EnumDisk();
                        }
                        if (arg.ToUpper().StartsWith("DISPLAY") || arg.ToUpper().StartsWith("VIDEO"))
                        {
                            EnumDisplay();
                            EnumVideo();
                        }
                        if (arg.ToUpper().StartsWith("NET") || arg.ToUpper().StartsWith("PING"))
                        {
                            SendPing("heartlandcropinsurance.com");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("* Error collecting machine information: {0}", ex.Message);
            }
            Console.Write("Press ENTER to exit.");
            Console.ReadLine();
        }

        private static void EnumProcessor()
        {
            try
            {
                Console.WriteLine("[Processor]");
                Console.WriteLine();
                var query = new SelectQuery("Win32_Processor");
                var searcher = new ManagementObjectSearcher(query);
                foreach (ManagementObject mo in searcher.Get())
                {
                    Console.WriteLine("Name = {0}", mo["Name"]);
                    Console.WriteLine("Type = {0}", mo["Description"]);
                    Console.WriteLine("Manufacturer = {0}", mo["Manufacturer"]);
                    Console.WriteLine("Cores = {0}; Logical Processors: {1}", mo["NumberOfCores"], mo["NumberOfLogicalProcessors"]);
                    Console.WriteLine("Current Clock Speed = {0}; Max Clock Speed = {1} ", mo["CurrentClockSpeed"], mo["MaxClockSpeed"]);
                    Console.WriteLine("L2 Cache Size = {0}", mo["L2CacheSize"]);
                    Console.WriteLine("L3 Cache Size = {0}", mo["L3CacheSize"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("* Error collecting Processor information: {0}", ex.Message);
            }
            Console.WriteLine();
        }

        private static void EnumPhysicalDisk()
        {
            try
            {
                Console.WriteLine("[Physical Disk]");
                Console.WriteLine();
                var query = new SelectQuery("Win32_DiskDrive");
                var searcher = new ManagementObjectSearcher(query);
                foreach (ManagementObject mo in searcher.Get())
                {
                    var description = (string)mo["Name"];
                    var deviceType = (string)mo["Caption"];
                    var partitions = (UInt32)mo["Partitions"];
                    var size = (UInt64)mo["Size"] / 1073741824;
                    Console.WriteLine("{0} ({1}); Size: {2}GB; {3} Partitions", description, deviceType, size, partitions);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("* Error collecting Disk information: {0}", ex.Message);
            }
            Console.WriteLine();
        }

        private static void EnumDisk()
        {
            try
            {
                Console.WriteLine("[Logical Disk]");
                Console.WriteLine();
                var query = new SelectQuery("Win32_LogicalDisk");
                var searcher = new ManagementObjectSearcher(query);
                foreach (ManagementObject mo in searcher.Get())
                {
                    var caption = (string)mo["Caption"];
                    var description = (string)mo["Description"];
                    var fileSystem = (string)mo["FileSystem"];
                    var str = mo["Size"] == null ? "" : mo["Size"].ToString();
                    var diskSize = str.Length > 0 ? double.Parse(str) / 1073741824.0 : 0;
                    str = mo["FreeSpace"] == null ? "" : mo["FreeSpace"].ToString();
                    var freeSpace = str.Length > 0 ? double.Parse(str) / 1073741824.0 : 0;
                    var pctFree = freeSpace / diskSize * 100;
                    var driveType = (UInt32)mo["DriveType"];
                    if (diskSize > 0 && driveType == 3)
                        Console.WriteLine("Drive {0} ({1}) Size: {2:#.0}GB, {3:#.0}GB Free ({4:#.0}%)", caption, fileSystem, diskSize, freeSpace, pctFree);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("* Error collecting Disk information: {0}", ex.Message);
            }
            Console.WriteLine();
        }

        private static void EnumDisplay()
        {
            try
            {
                Console.WriteLine("[Display]");
                Console.WriteLine();
                var query = new SelectQuery("Win32_DesktopMonitor");
                var searcher = new ManagementObjectSearcher(query);
                string description = "?";
                string deviceId = "?";
                UInt32 screenHeight = 0;
                UInt32 screenWidth = 0;
                foreach (ManagementObject mo in searcher.Get())
                {
                    try
                    {
                        description = "?";
                        deviceId = "?";
                        screenHeight = 0;
                        screenWidth = 0;
                        description = (string)mo["Description"];
                        deviceId = (string)mo["DeviceID"];
                        screenHeight = (UInt32)mo["ScreenHeight"];
                        screenWidth = (UInt32)mo["ScreenWidth"];
                    }
                    catch (Exception)
                    {
                    }
                    Console.WriteLine("{0} ({1}) {2}x{3}", deviceId, description, screenWidth, screenHeight);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("* Error collecting Display information: {0}", ex.Message);
            }
            Console.WriteLine();
        }

        private static void EnumMemory()
        {
            try
            {
                Console.WriteLine("[Memory]");
                Console.WriteLine();
                var query = new SelectQuery("Win32_MemoryDevice");
                var searcher = new ManagementObjectSearcher(query);
                foreach (ManagementObject mo in searcher.Get())
                {
                    var deviceId = (string)mo["DeviceID"];
                    var startAddress = (UInt64)mo["StartingAddress"];
                    var endAddress = (UInt64)mo["EndingAddress"];
                    Console.WriteLine("{0}: {1,10:#,##0} to {2,10:#,##0}", deviceId, startAddress, endAddress);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("* Error collecting Memory information: {0}", ex.Message);
            }
            Console.WriteLine();
        }

        private static void EnumVideo()
        {
            try
            {
                Console.WriteLine("[Video]");
                Console.WriteLine();
                var query = new SelectQuery("Win32_VideoController");
                var searcher = new ManagementObjectSearcher(query);
                foreach (ManagementObject mo in searcher.Get())
                {
                    string deviceId = (string)mo["DeviceID"];
                    string name = (string)mo["Name"];
                    UInt32 adapterRam = ((UInt32)mo["AdapterRAM"]) / 1048576;
                    object obj = mo["CurrentHorizontalResolution"];
                    UInt32 horizontal = obj == null ? 0 : (UInt32)obj;
                    obj = mo["CurrentVerticalResolution"];
                    UInt32 vertical = obj == null ? 0 : (UInt32)obj;
                    obj = mo["CurrentNumberOfColors"];
                    UInt64 colors = obj == null ? 0 : ((UInt64)obj) / 1048576;
                    string videoMode = string.Format("{0}x{1}x{2:#,##0}M Colors", horizontal, vertical, colors);
                    if (horizontal == 0 && vertical == 0 && colors == 0)
                        videoMode = "NONE";
                    Console.WriteLine("{0} ({1}) RAM: {2}; Mode: {3}", deviceId, name.Trim(), adapterRam, videoMode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("* Error collecting Video Card information: {0}", ex.Message);
            }
            Console.WriteLine();
        }

        private static void EnumEnvironment()
        {
            var query = new SelectQuery("Win32_Environment");
            var searcher = new ManagementObjectSearcher(query);
            foreach (ManagementObject mo in searcher.Get())
            {
                Console.WriteLine("{0} = {1}", mo["Name"], mo["VariableValue"]);
            }
        }

        public static void SendPing(string who)
        {
            try
            {
                Console.WriteLine("[Network Ping Test: {0}]", who);
                Console.WriteLine();
                if (who.Length == 0)
                    throw new ArgumentException("Ping needs a host or IP Address.");
                var waiter = new AutoResetEvent(false);
                var pingSender = new Ping();
                // When the PingCompleted event is raised, 
                // the PingCompletedCallback method is called.
                pingSender.PingCompleted += new PingCompletedEventHandler(PingCompletedCallback);
                // Create a buffer of 32 bytes of data to be transmitted. 
                var data = "".PadRight(1024, '#');
                byte[] buffer = Encoding.ASCII.GetBytes(data);

                // Wait 12 seconds for a reply. 
                int timeout = 12000;

                // Set options for transmission: 
                // The data can go through 64 gateways or routers 
                // before it is destroyed, and the data packet 
                // cannot be fragmented.
                var options = new PingOptions(64, true);

                // Send the ping asynchronously. 
                // Use the waiter as the user token. 
                // When the callback completes, it can wake up this thread.
                pingSender.SendAsync(who, timeout, buffer, options, waiter);

                // Prevent this example application from ending. 
                // A real application should do something useful 
                // when possible.
                waiter.WaitOne();
                Console.WriteLine();
                Console.WriteLine("Ping Test Completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending Network Ping: {0}", ex.Message);
            }
            Console.WriteLine();
        }

        private static void PingCompletedCallback(object sender, PingCompletedEventArgs e)
        {
            // If the operation was canceled, display a message to the user. 
            if (e.Cancelled)
            {
                Console.WriteLine(" Ping Canceled");

                // Let the main thread resume.  
                // UserToken is the AutoResetEvent object that the main thread  
                // is waiting for.
                ((AutoResetEvent)e.UserState).Set();
            }

            // If an error occurred, display the exception to the user. 
            if (e.Error != null)
            {
                Console.WriteLine("   Ping Failed");
                Console.WriteLine(e.Error.ToString());

                // Let the main thread resume. 
                ((AutoResetEvent)e.UserState).Set();
            }

            PingReply reply = e.Reply;

            DisplayReply(reply);

            // Let the main thread resume.
            ((AutoResetEvent)e.UserState).Set();
        }

        public static void DisplayReply(PingReply reply)
        {
            if (reply == null)
                return;

            Console.WriteLine("   Ping Status: {0}", reply.Status);
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("       Address: {0}", reply.Address.ToString());
                Console.WriteLine("RoundTrip Time: {0} msec", reply.RoundtripTime);
                Console.WriteLine("  Time to Live: {0}", reply.Options.Ttl);
            }
        }
    }
}
