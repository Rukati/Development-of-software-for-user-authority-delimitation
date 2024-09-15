using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Newtonsoft.Json;

namespace _1lb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public static string CurrentDirectory = Directory.GetCurrentDirectory();
        public MainWindow()
        {
            InitializeComponent();
            string jsonFileWithUsers;

            var FileWithUsers =
                Directory.GetFiles(CurrentDirectory).FirstOrDefault(file => file.Contains("users.json"));
            if (FileWithUsers == null)
            {
                User.Info = new Dictionary<string, User>()
                {
                    {
                        "ADMIN", new User
                        {
                            username = "ADMIN",
                            password = "",
                            certificate_path = null,
                            has_certificate = false,
                            is_locked = false,
                            role = "admin",
                            min_password_length = 8,
                        }
                    }
                };
                jsonFileWithUsers = JsonConvert.SerializeObject(User.Info, Formatting.Indented);
                File.WriteAllText(CurrentDirectory + "\\users.json", jsonFileWithUsers);
            }
            else
            {
                jsonFileWithUsers = File.ReadAllText(FileWithUsers);
                User.Info = JsonConvert.DeserializeObject<Dictionary<string, User>>(jsonFileWithUsers);
            }
        }
        
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (User.Info.ContainsKey(UsernameBox.Text))
            {
                if (Mode == "Password")
                {
                    if (PasswordBox.Password == User.Info[UsernameBox.Text].password)
                    {
                        if (User.Info[UsernameBox.Text].is_locked)
                        {
                            MessageBox.Show("Пользователь заблокирован.", "Ошибка аутентификации", MessageBoxButton.OK);
                        }
                        else
                        {
                            Menu menu = new Menu(UsernameBox.Text);
                            menu.Show();
                            Close();
                        }
                    }
                    else
                        MessageBox.Show("Не правильный логин или пароль.");
                }
                else
                {
                    if (User.Info[UsernameBox.Text].has_certificate)
                    {
                        if (File.Exists(User.Info[UsernameBox.Text].certificate_path))
                        {
                            string fileInfo = File.ReadAllText(User.Info[UsernameBox.Text].certificate_path);
                            if (fileInfo == UsernameBox.Text)
                            {
                                Menu menu = new Menu(UsernameBox.Text);
                                menu.Show();
                                Close();
                            }
                            else MessageBox.Show("Информация в сертификате не соответствует ожидаемому значению.");
                        } 
                        else MessageBox.Show("Путь до сертификата не найден.");
                    }
                    else MessageBox.Show("Аутентификация по сертифкату отсутствует.");
                }
            }
            else MessageBox.Show("Пользователь не существует.");
        }

        private string Mode = "Password";
        private void ModeAuthentication_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ThicknessAnimation moveRightAnimation = new ThicknessAnimation
            {
                From = ColorMode.Margin,
                Duration = new Duration(TimeSpan.FromSeconds(0.25)) 
            };
            
            ThicknessAnimation movePasswordAnimation = new ThicknessAnimation
            {
                From = PasswordRow.Margin,
                Duration = new Duration(TimeSpan.FromSeconds(0.25)) 
            };
            
            ThicknessAnimation moveUsernameAnimation = new ThicknessAnimation
            {
                From = UsernameRow.Margin,
                Duration = new Duration(TimeSpan.FromSeconds(0.25)) 
            };

            
            if (Mode == "Password")
            {
                moveRightAnimation.To = new Thickness(100, 0, 0, 0);
                moveUsernameAnimation.To = new Thickness(0, 0, 0, -20);
                movePasswordAnimation.To = new Thickness(0, 100, 0, 0);
                PasswordBox.Focusable = false;
                Mode = "Certificate";
            }
            else
            {
                moveRightAnimation.To = new Thickness(0, 0, 0, 0); 
                moveUsernameAnimation.To = new Thickness(0, 0, 0, 0);
                movePasswordAnimation.To = new Thickness(0, 0, 0, 0);
                PasswordBox.Focusable = true;
                Mode = "Password";
            }
            // Создаем Storyboard и добавляем анимации
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(moveRightAnimation);
            storyboard.Children.Add(moveUsernameAnimation);
            storyboard.Children.Add(movePasswordAnimation);

            // Устанавливаем цели анимаций
            Storyboard.SetTarget(moveRightAnimation, ColorMode);
            Storyboard.SetTargetProperty(moveRightAnimation, new PropertyPath(Grid.MarginProperty));

            Storyboard.SetTarget(moveUsernameAnimation, UsernameRow);
            Storyboard.SetTargetProperty(moveUsernameAnimation, new PropertyPath(Grid.MarginProperty));

            Storyboard.SetTarget(movePasswordAnimation, PasswordRow);
            Storyboard.SetTargetProperty(movePasswordAnimation, new PropertyPath(Grid.MarginProperty));

            // Запускаем анимацию
            storyboard.Begin();
        }
    }
}