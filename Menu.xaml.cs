using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;

namespace _1lb
{
    public partial class Menu : Window
    {
        public Menu(string name_user)
        {
            InitializeComponent();
            Greetings.Text = $"Welcome back, {name_user}!";
            User.Current = name_user;

            if (User.Info[name_user].role == "user")
            {
                var itemsToRemove = new List<TextBlock>();

                foreach (var child in UniformGrid.Children)
                {
                    if (child is TextBlock textBlock)
                    {
                        if (textBlock.Text != "Change Password" && textBlock.Text != "Logout")
                        {
                            itemsToRemove.Add(textBlock);
                        }
                    }
                }

                foreach (var item in itemsToRemove)
                {
                    UniformGrid.Children.Remove(item);
                }
            }
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = (TextBlock)sender;

            try
            {
                // Создаем окно для ввода имени пользователя
                AddUser inputWindow = new AddUser();

                switch (textBlock.Text)
                {
                    case "View Users":
                        User.ViewUsers();
                        break;
                    case "Add User":
                        if (inputWindow.ShowDialog() == true)
                        {
                            string userName = inputWindow.UserName;
                            if (!string.IsNullOrEmpty(userName))
                            {
                                User.AddUser(userName);
                                MessageBox.Show($"Пользователь {userName} добавлен.");
                            }
                            else
                            {
                                MessageBox.Show("Имя пользователя не введено.");
                            }
                        }

                        break;
                    case "Lock User":
                        if (inputWindow.ShowDialog() == true)
                        {
                            string userName = inputWindow.UserName;
                            if (!string.IsNullOrEmpty(userName))
                            {
                                User.LockUser(userName);
                                MessageBox.Show($"Пользователь {userName} заблокирован.");
                            }
                            else
                            {
                                MessageBox.Show("Имя пользователя не введено.");
                            }
                        }

                        break;
                    case "Unlock User":
                        if (inputWindow.ShowDialog() == true)
                        {
                            string userName = inputWindow.UserName;
                            if (!string.IsNullOrEmpty(userName))
                            {
                                User.UnlockUser(userName);
                                MessageBox.Show($"Пользователь {userName} разблокирован.");
                            }
                            else
                            {
                                MessageBox.Show("Имя пользователя не введено.");
                            }
                        }

                        break;
                    case "Change Password":
                        ChangePassword changePassword = new ChangePassword();
                        if (changePassword.ShowDialog() == true)
                        {
                            string password = changePassword._NewPasswordBox;
                            User.ChangePassword(password);
                            MessageBox.Show($"Пароль изменен.");
                        }
                        
                        break;
                    case "Set Certificate File":
                        CertificateWindow certificateWindow = new CertificateWindow();
                        if (certificateWindow.ShowDialog() == true)
                        {
                            User.SetCertificateFile(certificateWindow.Username, certificateWindow.SelectedCertificatePath);
                            
                        }

                        break;
                    case "Enable Certificate":
                        if (inputWindow.ShowDialog() == true)
                        {
                            string userName = inputWindow.UserName;
                            if (!string.IsNullOrEmpty(userName))
                            {
                                User.EnableCertificate(userName);
                                MessageBox.Show($"Включена авторизация по сертифакту для пользователя {userName}.");
                            }
                            else
                            {
                                MessageBox.Show("Имя пользователя не введено.");
                            }
                        }

                        break;
                    case "Disable Certificate":
                        if (inputWindow.ShowDialog() == true)
                        {
                            string userName = inputWindow.UserName;
                            User.DisableCertificate(userName);
                            MessageBox.Show($"Выключена авторизация по сертифакту для пользователя {userName}");
                        }   
                        break;
                    case "Set Min Password Length":
                        MinPasswordWindow minPasswordWindow = new MinPasswordWindow();
                        if (minPasswordWindow.ShowDialog() == true)
                        {
                            string Username = minPasswordWindow.Username;
                            short Length = minPasswordWindow.PasswordLength;
                            User.SetMinPasswordLength(Username, Length);
                            MessageBox.Show("Минимальная длина пароля изменена");
                        }
                        break;
                    case "Logout":
                        User.Logout();
                        Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            File.WriteAllText(MainWindow.CurrentDirectory + "\\users.json",
                JsonConvert.SerializeObject(User.Info, Formatting.Indented));
        }
    }
}