using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CU0FK0_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CU0FK0_SZTGUI_2023242.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private Song selectedSong;

        public Song SelectedSong
        {
            get { return selectedSong; }
            set
            {
                if (value != null)
                {
                    selectedSong = new Song()
                    {
                        SongID = value.SongID,
                        SongTitle = value.SongTitle
                    };
                    OnPropertyChanged();
                    (DeleteSongCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public RestCollection<Song> Songs { get; set; }

        public ICommand CreateSongCommand { get; set; }
        public ICommand UpdateSongCommand { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public ICommand DeleteSongCommand { get; set; }

        public MainWindowViewModel()
        {
            
            if (!IsInDesignMode)
            {
                Songs = new RestCollection<Song>("http://localhost:17161/", "song","hub");
                CreateSongCommand = new RelayCommand(() =>
                {
                    Songs.Add(new Song()
                    {
                        SongTitle = SelectedSong.SongTitle
                    });
                });

                DeleteSongCommand = new RelayCommand(() =>
                {
                    Songs.Delete(selectedSong.SongID);
                },
                () =>
                {
                    return selectedSong != null;
                });

                UpdateSongCommand = new RelayCommand(() =>
                {
                    Songs.Update(SelectedSong);
                });
                SelectedSong = new Song();
            }
        }

    }
}
