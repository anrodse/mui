using FirstFloor.ModernUI.Windows.Controls;
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

namespace FirstFloor.ModernUI.App.Content
{
    /// <summary>
    /// Interaction logic for ControlsModernWindow.xaml
    /// </summary>
    public partial class ControlsModernWindow : UserControl
    {
        public ControlsModernWindow()
        {
            InitializeComponent();
        }

        private void BlankWindow_Click(object sender, RoutedEventArgs e)
        {
            // create a blank modern window with lorem content
            // the BlankWindow ModernWindow styles is found in the mui assembly at Assets/ModernWindowStyles.xaml

            var wnd = new ModernWindow {
                Style = (Style)App.Current.Resources["BlankWindow"],
                Title = "ModernWindow",
                IsTitleVisible = true == this.title.IsChecked,
                Content = new LoremIpsum(),
                Width = 480,
                Height = 480
            };

            if (true == this.logo.IsChecked) {
				wnd.Logo = new BitmapImage(new Uri("logo.png"));
            }
            if (true == this.noresize.IsChecked) {
                wnd.ResizeMode = ResizeMode.NoResize;
            }
            else if (true == this.canminimize.IsChecked) {
                wnd.ResizeMode = ResizeMode.CanMinimize;
            }
            else if (true == this.canresize.IsChecked) {
                wnd.ResizeMode = ResizeMode.CanResize;
            }
            else if (true == this.canresizewithgrip.IsChecked) {
                wnd.ResizeMode = ResizeMode.CanResizeWithGrip;
            }

            wnd.Show();
        }
    }
}
