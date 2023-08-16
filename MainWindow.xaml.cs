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

namespace ImageResizeTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            removeResolutionButton.IsEnabled = false;
        }
        private void resolutionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (resolutionList.SelectedItem != null)
            {
                removeResolutionButton.IsEnabled = true;
            }
        }
        private void Add_Resolution(Object sender, RoutedEventArgs e)
        {
            var height = int.Parse(resolutionHeight.Text);
            var width = int.Parse(resolutionWidth.Text);
            resolutionList.Items.Add(new Resolution { Height = height, Width = width });
        }
        private void Remove_Resolution(Object sender, RoutedEventArgs e)
        {
            if (resolutionList.SelectedItem != null)
            {
                resolutionList.Items.Remove(resolutionList.SelectedItem);
                resolutionList.Items.Refresh();
            }

            if (resolutionList.Items.Count == 0)
            {
                removeResolutionButton.IsEnabled = false;
            }
        }
    }
}
