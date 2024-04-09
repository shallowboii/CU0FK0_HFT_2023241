using CU0FK0_HFT_2023241.Models;
using CU0FK0_SZTGUI_2023242.WpfClient.ViewModels;
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
using System.Windows.Shapes;

namespace CU0FK0_SZTGUI_2023242.WpfClient
{
    /// <summary>
    /// Interaction logic for ArtistWindow.xaml
    /// </summary>
    public partial class ArtistWindow : Window
    {
        public ArtistWindow(RestCollection<Artist> artists, RestCollection<Album> albums)
        {
            InitializeComponent();
            var vm = new ArtistWindowViewModel(artists,albums);
            this.DataContext = vm;
        }
    }
}
