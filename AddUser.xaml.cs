using System.Windows;

namespace _1lb
{
    public partial class AddUser : Window
    {
        public string UserName { get; private set; }

        public AddUser()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            UserName = UserNameTextBox.Text;
            this.DialogResult = true; 
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}