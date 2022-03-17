using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace XWinService.Global
{
    
        public class Crypto
        {
            public static string GetHardwareID(string drive)
            {
                if (drive == string.Empty)
                {
                    //Find first drive
                    foreach (DriveInfo compDrive in DriveInfo.GetDrives())
                    {
                        if (compDrive.IsReady)
                        {
                            drive = compDrive.RootDirectory.ToString();
                            break;
                        }
                    }
                }

                if (drive.EndsWith(":\\"))
                {
                    //C:\ -> C
                    drive = drive.Substring(0, drive.Length - 2);
                }

                string volumeSerial = GetMachineVolumeID(drive);
                string cpuID = GetCPUID();
                return cpuID.Substring(13) + cpuID.Substring(1, 4) + volumeSerial + cpuID.Substring(4, 4);
            }
            public static string GetMachineVolumeID(string drive)
            {
                System.Management.ManagementObject disk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
                disk.Get();

                string volumeSerial = disk["VolumeSerialNumber"].ToString();
                disk.Dispose();

                return volumeSerial;
            }

            public static string GetCPUID()
            {
                string cpuInfo = "";
                ManagementClass managClass = new ManagementClass("win32_processor");
                ManagementObjectCollection managCollec = managClass.GetInstances();

                foreach (ManagementObject managObj in managCollec)
                {
                    if (cpuInfo == "")
                    {
                        //Get only the first CPU's ID
                        cpuInfo = managObj.Properties["processorID"].Value.ToString();
                        break;
                    }
                }

                return cpuInfo;
            }

            public static string Encript(string Pass)
            {
                string EncPass = "";
                string ConPass = "";
                try
                {
                    try
                    {
                        ConPass = GetHardwareID("C");
                    }
                    catch { ConPass = "OB*98*DEVAPP"; }

                    AcceleratedIdeas.AIEncryptor AIE = new AcceleratedIdeas.AIEncryptor();
                    AIE.FileDecryptExtension = "dec";
                    AIE.FileEncryptExtension = "Enc";
                    AIE.HashType = AcceleratedIdeas.AIEncryptor.AIHashTypes._SHA256;
                    AIE.InitVector = "@1B2c3D4e5F6g7H8";
                    AIE.PassPhrase = ConPass;
                    AIE.PassPhraseStrength = 5;
                    AIE.SaltValue = "DEVOBWORLD";
                    EncPass = AIE.EncryptString(Pass);
                    //string DECRE = AIE.DecryptString(EncPass);
                    //MessageBox.Show(DECRE);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return EncPass;
            }

            public static string Decript(string Pass)
            {
                //string pas = "eZ3uCqmJvMcFjXGkWpyDAw==";
                string DecPass = "";
                string ConPass = "";
                try
                {
                    try
                    {
                        ConPass = GetHardwareID("C");
                    }
                    catch { ConPass = "OB*98*DEVAPP"; }
                    AcceleratedIdeas.AIEncryptor AIE = new AcceleratedIdeas.AIEncryptor();
                    AIE.FileDecryptExtension = "dec";
                    AIE.FileEncryptExtension = "Enc";
                    AIE.HashType = AcceleratedIdeas.AIEncryptor.AIHashTypes._SHA256;
                    AIE.InitVector = "@1B2c3D4e5F6g7H8";
                    AIE.PassPhrase = ConPass;
                    AIE.PassPhraseStrength = 5;
                    AIE.SaltValue = "DEVOBWORLD";
                    //string EncPass = AIE.EncryptString(Pass);
                    DecPass = AIE.DecryptString(Pass);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return DecPass;
            }

           public static string DecriptBase64(string Pass)
            {
                byte[] pas = System.Convert.FromBase64String(Pass);
                string ConPass = GetHardwareID("C");
                AcceleratedIdeas.AIEncryptor AIE = new AcceleratedIdeas.AIEncryptor();
                AIE.FileDecryptExtension = "dec";
                AIE.FileEncryptExtension = "Enc";
                AIE.HashType = AcceleratedIdeas.AIEncryptor.AIHashTypes._SHA256;
                AIE.InitVector = "@1B2c3D4e5F6g7H8";
                AIE.PassPhrase = ConPass;
                AIE.PassPhraseStrength = 5;
                AIE.SaltValue = "DEVOBWORLD";
                string EncPass = AIE.EncryptString(Pass);
                var DecPass = AIE.DecryptString(pas.ToString());
                DecPass = AIE.DecryptString(DecPass);
                return DecPass;
            }
        }
    }
