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

        private void VizhinerButton_OnClick(object sender, RoutedEventArgs e) => SafeAction(() =>
        {
            var replacement = new VizhinerReplacement(ReplacementKeyTextBox.Text);

            ReplacementOutputTextBlock.Text = replacement.Process(ReplacementInputTextBox.Text);
        });

        private void BeaufortButton_OnClick(object sender, RoutedEventArgs e) => SafeAction(() =>
        {
            var replacement = new BeaufortReplacement(ReplacementKeyTextBox.Text);

            ReplacementOutputTextBlock.Text = replacement.Process(ReplacementInputTextBox.Text);
        });

        private void SubstitutionButton_OnClick(object sender, RoutedEventArgs e) => SafeAction(() =>
        {
            var substitution = new Substitution(SubstitutionKeyTextBox.Text);

            SubstitutionOutputTextBlock.Text = substitution.Process(SubstitutionInputTextBox.Text);
        });

        private static void SafeAction(Action action)
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
