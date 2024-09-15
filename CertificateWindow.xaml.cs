using System;
using System.Windows;
using Microsoft.Win32;

namespace _1lb
{
    public partial class CertificateWindow : Window
    {
        public string SelectedCertificatePath { get; private set; }
        public string Username { get; private set; }

        public CertificateWindow()
        {
            InitializeComponent();
        }

        // Обработчик для кнопки "Обзор..."
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Certificate Files (*.txt)|*.txt"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                // Проверка, что имя файла соответствует "Certificate Files"
                if (System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName) == "Certificate Files")
                    CertificatePathTextBox.Text = openFileDialog.FileName;

                else throw new Exception("Пожалуйста, выберите файл с именем 'Certificate Files'.");
            }
        }

        // Обработчик для кнопки "OK"
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка: имя пользователя не должно быть пустым
            if (string.IsNullOrEmpty(UsernameTextBox.Text))
                throw new Exception("Пожалуйста, введите имя пользователя.");
            // Проверка: путь к сертификату должен быть указан
            if (string.IsNullOrEmpty(CertificatePathTextBox.Text))
                throw new Exception("Пожалуйста, выберите сертификат.");

            // Если ошибок нет, сохраняем путь к сертификату
            SelectedCertificatePath = CertificatePathTextBox.Text;
            Username = UsernameTextBox.Text;
            DialogResult = true;
            Close();
        }


        // Обработчик для кнопки "Отмена"
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}