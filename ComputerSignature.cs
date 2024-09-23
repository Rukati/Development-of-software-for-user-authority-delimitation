using System;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows;

namespace _1lb
{
    public class ComputerSignature
    {
        public static void WriteComputerSignature(string filePath)
        {
            // Получаем имя пользователя системы
            string userName = Environment.UserName;

            // Получаем имя компьютера
            string computerName = Environment.MachineName;

            // Получаем путь к папке с ОС Windows
            string windowsPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows);

            // Получаем ширину и высоту экрана
            int screenWidth = (int)SystemParameters.PrimaryScreenWidth;
            int screenHeight = (int)SystemParameters.PrimaryScreenHeight;

            // Получаем данные об объеме ОЗУ
            ulong totalRAM = GetTotalRAM();

            // Получаем данные о файловой системе и объеме диска
            string driveInfo = GetDriveInfo();

            // Собираем все данные в одну строку (сигнатура)
            string signature = $"Username: {User.Current}\n" +
                               $"Computer Name: {computerName}\n" +
                               $"Windows Path: {windowsPath}\n" +
                               $"Screen: {screenWidth}x{screenHeight}\n" +
                               $"Total RAM: {totalRAM / (1024 * 1024)} MB\n" +
                               $"{driveInfo}";

            // Записываем сигнатуру в файл
            File.WriteAllText(filePath, signature);
        }

        // Метод для получения общего объема ОЗУ
        private static ulong GetTotalRAM()
        {
            ulong totalRAM = 0;

            using (var searcher = new ManagementObjectSearcher("SELECT Capacity FROM Win32_PhysicalMemory"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    totalRAM += (ulong)obj["Capacity"];
                }
            }

            return totalRAM;
        }

        // Метод для получения данных о файловой системе и объеме HDD
        private static string GetDriveInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady && drive.DriveType == DriveType.Fixed) // Проверяем только основные диски
                {
                    return $"Drive {drive.Name}\n" +
                           $"File System: {drive.DriveFormat}\n" +
                           $"Total Size: {drive.TotalSize / (1024 * 1024 * 1024)} GB\n" +
                           $"Volume Label: {drive.VolumeLabel}";
                }
            }

            return "Drive information not available.";
        }
    }
}