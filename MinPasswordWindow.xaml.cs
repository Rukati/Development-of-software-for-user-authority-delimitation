using System.Windows;

namespace _1lb
{
    public partial class MinPasswordWindow : Window
    {
        // Свойство для хранения имени пользователя
        public string Username { get; private set; }

        // Свойство для хранения минимальной длины пароля
        public short PasswordLength { get; private set; }

        public MinPasswordWindow()
        {
            InitializeComponent();
            PasswordLengthSlider.Value = 8; 
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Username = UsernameTextBox.Text;
            PasswordLength = (short)PasswordLengthSlider.Value;

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}