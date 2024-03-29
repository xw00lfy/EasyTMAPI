using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTMAPI
{
    public class EasyTMAPI
    {

        public static uint ProcessID;
        public static uint[] processIDs;
        public static string snresult;
        private static string usage;
        
        public static string Info;
        public static PS3TMAPI.ConnectStatus connectStatus;
        public static string Status;
        public static string MemStatus;


        /// <summary>
        /// Initializes the dll for communication with the target PS3
        /// </summary>
        public static void InitTargetComms()
        {
            PS3TMAPI.InitTargetComms();
        }

        /// <summary>
        /// Stops communication with the DLL and target PS3
        /// </summary>
        public static void CloseTargetComms()
        {
            PS3TMAPI.CloseTargetComms();
        }


        /// <summary>
        /// Connects to the target PS3.
        /// </summary>
        public static void ConnectTarget()
        {
            PS3TMAPI.InitTargetComms();
            PS3TMAPI.Connect(0, null);
        }

        /// <summary>
        /// Connect to the target PS3. Target is 0.
        /// </summary>
        /// <param name="Target"></param>
        public static void ConnectTarget(int Target)
        {
            PS3TMAPI.InitTargetComms();
            PS3TMAPI.Connect(Target, null);
        }

        /// <summary>
        /// Connects to the target PS3. Target is 0, Application is null.
        /// </summary>
        /// <param name="Target"></param>
        /// <param name="Application"></param>
        public static void ConnectTarget(int Target = 0, string Application = null)
        {
            PS3TMAPI.InitTargetComms();
            PS3TMAPI.Connect(Target, Application);
        }

        /// <summary>
        /// Attaches to the current process you are using.
        /// </summary>
        public static void AttachProcess()
        {
            PS3TMAPI.GetProcessList(0, out processIDs);
            ulong uProcess = processIDs[0];
            ProcessID = Convert.ToUInt32(uProcess);
            PS3TMAPI.ProcessAttach(0, PS3TMAPI.UnitType.PPU, ProcessID);
            PS3TMAPI.ProcessContinue(0, ProcessID);
        }

        /// <summary>
        /// Attaches to a process. Needs PID.
        /// </summary>
        /// <param name="PID"></param>
        public static void AttachProcess(uint[] PID)
        {
            PS3TMAPI.GetProcessList(0, out PID);
            ulong uProcess = processIDs[0];
            ProcessID = Convert.ToUInt32(uProcess);
            PS3TMAPI.ProcessAttach(0, PS3TMAPI.UnitType.PPU, ProcessID);
            PS3TMAPI.ProcessContinue(0, ProcessID);
        }


        /// <summary>
        /// Continues a process.
        /// </summary>
        public static void ContinueProcess()
        {
            PS3TMAPI.GetProcessList(0, out processIDs);
            ulong uProcess = processIDs[0];
            ProcessID = Convert.ToUInt32(uProcess);
            PS3TMAPI.ProcessContinue(0, ProcessID);
        }


        /// <summary>
        /// Disconnects from the target PS3.
        /// </summary>
        public static void DisconnectTarget()
        {
            PS3TMAPI.Disconnect(0);
        }


        /// <summary>
        /// Forces the PS3 to disconnect.
        /// </summary>
        public static void DisconnectTargetWithForce()
        {
            PS3TMAPI.ForceDisconnect(0);
        }

        /// <summary>
        /// Gets the current API version
        /// </summary>
        /// <param name="Output"></param>
        public static void GetAPIVersion(string Output)
        {
            PS3TMAPI.GetAPIVersion(out Output);
        }

        /// <summary>
        /// Kills current process.
        /// </summary>
        public static void KillProcess()
        {
            PS3TMAPI.GetProcessList(0, out processIDs);
            ulong uProcess = processIDs[0];
            ProcessID = Convert.ToUInt32(uProcess);
            PS3TMAPI.ProcessKill(0, ProcessID);
        }

        /// <summary>
        /// Gets Memory from the target or process.
        /// </summary>
        /// <param name="Address"></param>
        /// <param name="bytes"></param>
        public static void GetMemory(uint Address, byte[] bytes)
        {
            PS3TMAPI.ProcessGetMemory(0, PS3TMAPI.UnitType.PPU, ProcessID, 0, Address, ref bytes);
        }

        /// <summary>
        /// Sets PS3 memory.
        /// </summary>
        /// <param name="Address"></param>
        /// <param name="bytes"></param>
        public static void SetMemory(uint Address, byte[] bytes)
        {
            PS3TMAPI.ProcessSetMemory(0, PS3TMAPI.UnitType.PPU, ProcessID, 0, Address, bytes);
        }

        /// <summary>
        /// Gets connection status from the target.
        /// </summary>
        public static void GetConnectionStatus()
        {
            Status = Convert.ToString(PS3TMAPI.GetConnectStatus(0, out connectStatus, out usage));
        }

        /// <summary>
        /// Shuts down the PS3, write true in the parameter if you want to force the PS3 to shutdown, if not, write 'false'.
        /// </summary>
        /// <param name="Force_PS3_To_Shutdown"></param>
        public static void PowerOffTarget(bool Force_PS3_To_Shutdown)
        {
            PS3TMAPI.PowerOff(0, Force_PS3_To_Shutdown);
        }

        public static void PowerOnTarget()
        {
            PS3TMAPI.PowerOn(0);
        }


        /// <summary>
        /// Maps the PS3 filesystem on your HDD, type 'C' with the apostrophes if you want to save it into the C drive
        /// </summary>
        /// <param name="DiskDriveLetter"></param>
        public static void MapFilesystem(char DiskDriveLetter)
        {
            PS3TMAPI.MapFileSystem(DiskDriveLetter);
        }

        /// <summary>
        /// Unmaps the PS3 filesystem from your HDD
        /// </summary>
        public static void UnmapFilesystem()
        {
            PS3TMAPI.UnmapFileSystem();
        }
    }
}
