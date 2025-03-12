using System.Management;
using System.Net;
namespace Wolt_ConsoleApp.Functions.SystemFunctions;
internal class SystemInfo
{
    public static int LineLong() { Console.WriteLine(new string('-', 90)); return 90; }
    public static void ViewSystemInformation()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("=== SYSTEM INFORMATION ===\n");

        CollectAndDisplayOSInfo();
        CollectAndDisplayProcessorInfo();
        CollectAndDisplayMemoryInfo();
        CollectAndDisplayDiskInfo();
        CollectAndDisplayNetworkInfo();
        CollectAndDisplayBiosInfo();
        Console.ResetColor();
    }

    public static void CollectAndDisplayOSInfo()
    {
        Console.WriteLine("=== OPERATING SYSTEM ===");
        try
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            foreach (ManagementObject os in searcher.Get())
            {
                string name = os["Caption"]?.ToString();
                string version = os["Version"]?.ToString();
                string architecture = os["OSArchitecture"]?.ToString();
                string manufacturer = os["Manufacturer"]?.ToString();
                string installDate = os["InstallDate"] != null
                    ? ManagementDateTimeConverter.ToDateTime(os["InstallDate"].ToString()).ToString()
                    : "Unknown";
                string lastBootTime = os["LastBootUpTime"] != null
                    ? ManagementDateTimeConverter.ToDateTime(os["LastBootUpTime"].ToString()).ToString()
                    : "Unknown";

                Console.WriteLine($"OS Name: {name}");
                Console.WriteLine($"Version: {version}");
                Console.WriteLine($"Architecture: {architecture}");
                Console.WriteLine($"Manufacturer: {manufacturer}");
                Console.WriteLine($"Install Date: {installDate}");
                Console.WriteLine($"Last Boot Up: {lastBootTime}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting OS info: {ex.Message}");
        }
       LineLong();
    }

    private static void CollectAndDisplayProcessorInfo()
    {
        Console.WriteLine("=== PROCESSOR ===");
        try
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach (ManagementObject processor in searcher.Get())
            {
                string name = processor["Name"]?.ToString();
                string manufacturer = processor["Manufacturer"]?.ToString();
                string cores = processor["NumberOfCores"]?.ToString();
                string logicalProcessors = processor["NumberOfLogicalProcessors"]?.ToString();
                string currentClockSpeed = processor["CurrentClockSpeed"]?.ToString();
                string maxClockSpeed = processor["MaxClockSpeed"]?.ToString();
                string l2Cache = processor["L2CacheSize"]?.ToString();
                string l3Cache = processor["L3CacheSize"]?.ToString();
                Console.WriteLine($"CPU: {name}");
                Console.WriteLine($"Manufacturer: {manufacturer}");
                Console.WriteLine($"Cores: {cores}");
                Console.WriteLine($"Logical Processors: {logicalProcessors}");
                Console.WriteLine($"Clock Speed: {currentClockSpeed} MHz");
                Console.WriteLine($"Max Speed: {maxClockSpeed} MHz");
                Console.WriteLine($"L2 Cache Size: {l2Cache} KB");
                Console.WriteLine($"L3 Cache Size: {l3Cache} KB");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting processor info: {ex.Message}");
        }
        LineLong();
    }
    private static void CollectAndDisplayMemoryInfo()
    {
        Console.WriteLine("=== MEMORY ===");
        try
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
            ulong totalMemorySize = 0;
            foreach (ManagementObject memory in searcher.Get())
            {
                string location = memory["DeviceLocator"]?.ToString();
                string manufacturer = memory["Manufacturer"]?.ToString();
                string serialNumber = memory["SerialNumber"]?.ToString();
                string speed = memory["Speed"]?.ToString();
                ulong capacity = Convert.ToUInt64(memory["Capacity"] ?? 0);
                totalMemorySize += capacity;
                double capacityGB = Math.Round(capacity / (1024.0 * 1024.0 * 1024.0), 2);
                Console.WriteLine($"Memory Bank: {location}");
                Console.WriteLine($"Manufacturer: {manufacturer}");
                Console.WriteLine($"Capacity: {capacityGB} GB");
                Console.WriteLine($"Speed: {speed} MHz");
                Console.WriteLine($"Serial Number: {serialNumber}");
                LineLong();
            }
            double totalGB = Math.Round(totalMemorySize / (1024.0 * 1024.0 * 1024.0), 2);
            Console.WriteLine($"Total RAM: {totalGB} GB");
            ManagementObjectSearcher osSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            foreach (ManagementObject os in osSearcher.Get())
            {
                ulong freePhysicalMemory = Convert.ToUInt64(os["FreePhysicalMemory"] ?? 0) * 1024;
                double freeGB = Math.Round(freePhysicalMemory / (1024.0 * 1024.0 * 1024.0), 2);
                Console.WriteLine($"Available Memory: {freeGB} GB");
                double usedPercentage = 100 - ((double)freePhysicalMemory / totalMemorySize * 100);
                Console.WriteLine($"Memory Usage: {Math.Round(usedPercentage, 1)}%");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting memory info: {ex.Message}");
        }
        LineLong();
    }
    private static void CollectAndDisplayDiskInfo()
    {
        Console.WriteLine("=== DISK DRIVES ===");
        try
        {
            ManagementObjectSearcher diskSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            foreach (ManagementObject disk in diskSearcher.Get())
            {
                string model = disk["Model"]?.ToString();
                string interfaceType = disk["InterfaceType"]?.ToString();
                string serialNumber = disk["SerialNumber"]?.ToString();
                ulong size = Convert.ToUInt64(disk["Size"] ?? 0);
                double sizeGB = Math.Round(size / (1024.0 * 1024.0 * 1024.0), 2);
                Console.WriteLine($"Disk: {model}");
                Console.WriteLine($"Interface: {interfaceType}");
                Console.WriteLine($"Size: {sizeGB} GB");
                Console.WriteLine($"Serial: {serialNumber}");
                LineLong();
            }
            ManagementObjectSearcher logicalDiskSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk WHERE DriveType=3");
            foreach (ManagementObject logicalDisk in logicalDiskSearcher.Get())
            {
                string name = logicalDisk["Name"]?.ToString();
                string volumeName = logicalDisk["VolumeName"]?.ToString();
                string fileSystem = logicalDisk["FileSystem"]?.ToString();
                ulong freeSpace = Convert.ToUInt64(logicalDisk["FreeSpace"] ?? 0);
                ulong size = Convert.ToUInt64(logicalDisk["Size"] ?? 0);
                double percentFree = ((double)freeSpace / size) * 100;
                double sizeGB = Math.Round(size / (1024.0 * 1024.0 * 1024.0), 2);
                double freeSpaceGB = Math.Round(freeSpace / (1024.0 * 1024.0 * 1024.0), 2);
                Console.WriteLine($"Drive: {name}");
                Console.WriteLine($"Volume Name: {volumeName}");
                Console.WriteLine($"File System: {fileSystem}");
                Console.WriteLine($"Size: {sizeGB} GB");
                Console.WriteLine($"Free Space: {freeSpaceGB} GB");
                Console.WriteLine($"Free Space: {Math.Round(percentFree, 1)}%");
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting disk info: {ex.Message}");
        }
        LineLong();
    }

    private static void CollectAndDisplayNetworkInfo()
    {
        Console.WriteLine("=== NETWORK ===");
        try
        {
            Console.WriteLine("IP Addresses:");
            string hostName = Dns.GetHostName();
            Console.WriteLine($"Host Name: {hostName}");
            IPAddress[] addresses = Dns.GetHostAddresses(hostName);
            foreach (IPAddress ip in addresses)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    Console.WriteLine($"IPv4 Address: {ip}");
                }
                else
                {
                    Console.WriteLine($"IPv6 Address: {ip}");
                }
            }
            LineLong();
            Console.WriteLine("Network Adapters:");
            ManagementObjectSearcher networkSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'");
            foreach (ManagementObject network in networkSearcher.Get())
            {
                string description = network["Description"]?.ToString();
                Console.WriteLine($"Adapter: {description}");
                if (network["IPAddress"] != null)
                {
                    string[] ipAddresses = (string[])network["IPAddress"];
                    if (ipAddresses.Length > 0)
                    {
                        Console.WriteLine($"IP Address: {ipAddresses[0]}");
                    }
                }
                if (network["MACAddress"] != null)
                {
                    Console.WriteLine($"MAC Address: {network["MACAddress"]}");
                }
                if (network["DefaultIPGateway"] != null)
                {
                    string[] gateways = (string[])network["DefaultIPGateway"];
                    if (gateways.Length > 0)
                    {
                        Console.WriteLine($"Default Gateway: {gateways[0]}");
                    }
                }
                if (network["DNSServerSearchOrder"] != null)
                {
                    string[] dnsServers = (string[])network["DNSServerSearchOrder"];
                    if (dnsServers.Length > 0)
                    {
                        Console.WriteLine($"DNS Server: {dnsServers[0]}");
                    }
                }
                LineLong();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting network info: {ex.Message}");
        }
    }

    private static void CollectAndDisplayBiosInfo()
    {
        Console.WriteLine("=== BIOS ===");
        try
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
            foreach (ManagementObject bios in searcher.Get())
            {
                string manufacturer = bios["Manufacturer"]?.ToString();
                string version = bios["Version"]?.ToString();
                string releaseDate = bios["ReleaseDate"]?.ToString();
                string serialNumber = bios["SerialNumber"]?.ToString();
                Console.WriteLine($"BIOS Manufacturer: {manufacturer}");
                Console.WriteLine($"BIOS Version: {version}");
                Console.WriteLine($"BIOS Release Date: {releaseDate}");
                Console.WriteLine($"Serial Number: {serialNumber}");
            }
            ManagementObjectSearcher mbSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            foreach (ManagementObject mb in mbSearcher.Get())
            {
                string manufacturer = mb["Manufacturer"]?.ToString();
                string product = mb["Product"]?.ToString();
                string serialNumber = mb["SerialNumber"]?.ToString();
                Console.WriteLine($"Motherboard Manufacturer: {manufacturer}");
                Console.WriteLine($"Motherboard Model: {product}");
                Console.WriteLine($"Motherboard Serial: {serialNumber}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting BIOS info: {ex.Message}");
        }
        LineLong();
    }
}