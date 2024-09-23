using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using Newtonsoft.Json;

namespace _1lb
{
    public class User
    {
        static public Dictionary<string, User> Info = new Dictionary<string, User>();
        static public string Current;

        public string username { get; set; }
        public string password { get; set; }
        public string certificate_path { get; set; }
        public bool has_certificate { get; set; }
        public bool is_locked { get; set; }
        public string role { get; set; }
        public short min_password_length { get; set; }


        // Метод для просмотра всех пользователей
        public static void ViewUsers()
        {
            UsersWindow usersWindow = new UsersWindow();
            usersWindow.Show();
        }

        // Метод для добавления нового пользователя
        public static void AddUser(string username)
        {
            if (!Info.ContainsKey(username))
            {
                User newUser = new User
                {
                    username = username,
                    password = "",
                    certificate_path = null,
                    has_certificate = false,
                    is_locked = false,
                    role = "user",
                    min_password_length = 8
                };
                Info.Add(username, newUser);
            }
            else throw new Exception($"Пользователь {username} уже существует");
        }

        // Метод для блокировки пользователя
        public static void LockUser(string username)
        {
            if (Info.ContainsKey(username)) Info[username].is_locked = true;
            else throw new Exception($"Пользователь {username} не существует");
        }

        // Метод для разблокировки пользователя
        public static void UnlockUser(string username)
        {
            if (Info.ContainsKey(username)) Info[username].is_locked = false;
            else throw new Exception($"Пользователь {username} не существует");
        }

        public static void ChangePassword(string newPassword)
        {
            if (newPassword.Length < Info[Current].min_password_length)
                throw new Exception($"Пароль не подходит по минимальной длине.");

            // Проверка на наличие строчных и прописных букв
            if (!newPassword.Any(char.IsLower) || !newPassword.Any(char.IsUpper))
                throw new Exception("Пароль должен содержать как строчные, так и прописные буквы.");

            // Проверка на наличие цифр и знаков препинания
            if (!newPassword.Any(char.IsDigit) || !Regex.IsMatch(newPassword, @"[^\w\s]"))
                throw new Exception("Пароль должен содержать хотя бы одну цифру и один знак препинания.");

            // Проверка на отсутствие повторяющихся символов
            if (newPassword.GroupBy(c => c).Any(g => g.Count() > 1))
                throw new Exception("Пароль не должен содержать повторяющихся символов.");

            Info[Current].password = newPassword;
        }

        // Метод для установки файла сертификата
        public static void SetCertificateFile(string username, string certificatePath)
        {
            if (Info.ContainsKey(username))
            {
                Info[username].certificate_path = certificatePath + "\\Certificate File.txt";
                Info[username].has_certificate = true;
                File.WriteAllText(certificatePath + "\\Certificate File.txt", username);
            }
            else throw new Exception($"Пользователь {username} не существует");
        }

        // Метод для включения сертификата
        public static void EnableCertificate(string username)
        {
            if (Info.ContainsKey(username) && !Info[username].has_certificate) Info[username].has_certificate = true;
            else throw new Exception($"Пользователь {username} не существует");
        }

        // Метод для отключения сертификата
        public static void DisableCertificate(string username)
        {
            if (Info.ContainsKey(username) && Info[username].has_certificate) Info[username].has_certificate = false;
            else throw new Exception($"Пользователь {username} не существует");
        }

        // Метод для установки минимальной длины пароля
        public static void SetMinPasswordLength(string username, short length)
        {
            if (Info.ContainsKey(username)) Info[username].min_password_length = length;
            else throw new Exception($"Пользователь {username} не существует");
        }

        // Метод выхода
        public static void Logout()
        {
            Current = null;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Console.WriteLine("Logged out.");
        }
    }
}