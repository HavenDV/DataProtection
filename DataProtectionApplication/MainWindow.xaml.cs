using System;
using System.Windows;
using DataProtectionLibrary;

namespace DataProtectionApplication
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PermutationButton_OnClick(object sender, RoutedEventArgs e) => SafeAction(() =>
        {
            var permutation = new Permutation(PermutationKey1TextBox.Text, PermutationKey2TextBox.Text);

            PermutationOutputTextBlock.Text = permutation.Process(PermutationInputTextBox.Text);
        });

        private void SafeAction(Action action)
        {
            try
            {
                action?.Invoke();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Exception: {exception}", "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
