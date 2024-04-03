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
    /// Interaction logic for SongWindow.xaml
    /// </summary>
    public partial class SongWindow : Window
    {
        public SongWindow(RestCollection<Song> songs)
        {
            InitializeComponent();
            var vm = new SongWindowViewModel(songs);
            this.DataContext = vm;

            
        }
    }
}
