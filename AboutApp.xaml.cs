using System.Windows;

namespace _1lb
{
    public partial class AboutApp : Window
    {
        public AboutApp()
        {
            InitializeComponent();
        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}