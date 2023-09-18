using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Window
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonAddName_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !lstNames.Items.Contains(txtName.Text))
            {
                lstNames.Items.Add(txtName.Text);
                txtName.Clear();
            }
        }

        private void EnterName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                ButtonAddName_Click(sender, e);
            }
        }

        private void ButtonRemoveName_Click(object sender, RoutedEventArgs e)
        {
            if (lstNames.SelectedItem != null)
            {
                string selectedName = lstNames.SelectedItem.ToString();
                lstNames.Items.Remove(selectedName);
            }
        }

        private void DeleteName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                ButtonRemoveName_Click(sender, e);
            }
        }

        private void ButtonEditName_Click(object sender, RoutedEventArgs e)
        {
            if (lstNames.SelectedItem != null)
            {
                string selectedName = lstNames.SelectedItem.ToString();
                if (!string.IsNullOrWhiteSpace(txtName.Text) && selectedName != txtName.Text && !lstNames.Items.Contains(txtName.Text))
                {
                    int selectedIndex = lstNames.SelectedIndex;
                    lstNames.Items.RemoveAt(selectedIndex);
                    lstNames.Items.Insert(selectedIndex, txtName.Text);
                    txtName.Clear();
                }
            }
        }
    }
}
