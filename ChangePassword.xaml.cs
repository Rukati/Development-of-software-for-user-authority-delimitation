using System;
using System.Windows;

namespace _1lb
{
    public partial class ChangePassword : Window
    { 
        public string _NewPasswordBox { get; private set; }

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            _NewPasswordBox = NewPasswordBox.Password;
            if (OldPasswordBox.Password == User.Info[User.Current].password)
            {
                if (NewPasswordBox.Password == RepeatPasswordBox.Password) this.DialogResult = true;
                else throw new Exception("Пароли не совпадают.");
            }
            else throw new Exception("Не верно введен старый пароль.");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}