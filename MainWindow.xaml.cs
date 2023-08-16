using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
        Bitmap bitmapImage = null;
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
        private void OpenFileDialog(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = ".png";
            dialog.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                filePath.Text = dialog.FileName;
                try
                {
                    bitmapImage = new Bitmap(dialog.FileName, true);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                }
            }
        }
        private void Save_Images(object sender, RoutedEventArgs e)
        {
            var filePathLocal = System.IO.Path.GetDirectoryName(filePath.Text);
            foreach (Resolution resolution in resolutionList.Items)
            {
                var resizedImage = new Bitmap(bitmapImage, new System.Drawing.Size(resolution.Width, resolution.Height));
                resizedImage.Save($"{filePathLocal}/{resolution.Width}x{resolution.Height}.png", ImageFormat.Png);
            }
            
        }
        
    }
}
