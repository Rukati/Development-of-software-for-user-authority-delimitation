using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace _1lb
{
    public partial class UsersWindow : Window
    {
        public UsersWindow()
        {
            InitializeComponent();
            Deactivated += UserListWindow_Deactivated;
            LoadUsers();
        }
        private void UserListWindow_Deactivated(object sender, EventArgs e)
        {
            // Закрываем окно при потере фокуса
            Close();
        }
        private void LoadUsers()
        {
            // Преобразуйте ваш словарь в список для отображения
            var users = User.Info.Values.ToList();
            UserItemsControl.ItemsSource = users;
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}