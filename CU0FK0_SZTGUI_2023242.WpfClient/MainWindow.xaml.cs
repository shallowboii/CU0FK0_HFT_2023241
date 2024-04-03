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

namespace CU0FK0_SZTGUI_2023242.WpfClient
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

        private void SongWindow(object sender, RoutedEventArgs e)
        {
            new SongWindow().Show();

        }
        private void AlbumWindow(object sender, RoutedEventArgs e)
        {
            new AlbumWindow().Show();
        }
        private void ArtistWindow(object sender, RoutedEventArgs e)
        {
            new ArtistWindow().Show();
        }
    }
}
