using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CU0FK0_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace CU0FK0_SZTGUI_2023242.WpfClient.ViewModels
{
    public class SongWindowViewModel : ObservableRecipient
    {
        public bool IsSelected { get; set; }
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
                        SongTitle = value.SongTitle,
                        AlbumID = value.AlbumID
                    };
                    IsSelected = true;
                    OnPropertyChanged();
                    
                }
                else
                {
                    IsSelected = false;
                    (DeleteSongCommand as RelayCommand)?.NotifyCanExecuteChanged();
                    (UpdateSongCommand as RelayCommand)?.NotifyCanExecuteChanged();
                }
            }
        }
        private Song result;

        public Song Result
        {
            get { return result; }
            set
            {
                if (value != null)
                {
                    result = new Song()
                    {
                        SongID = value.SongID,
                        SongTitle = value.SongTitle
                    };
                    OnPropertyChanged();
                    (GetAnAlbumsBestSongCommand as RelayCommand)?.NotifyCanExecuteChanged();
                }
            }
        }

        public SongWindowViewModel()
        {

        }

        public RestCollection<Song> Songs { get; set; }
        


        public ICommand CreateSongCommand { get; set; }
        public ICommand UpdateSongCommand { get; set; }

        public ICommand DeleteSongCommand { get; set; }

        public ICommand GetAnAlbumsBestSongCommand { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public SongWindowViewModel(RestCollection<Song> songs)
        {

            if (!IsInDesignMode)
            {

                Songs = songs;
                CreateSongCommand = new RelayCommand(() =>
                {
                    Songs.Add(new Song()
                    {
                        SongTitle = SelectedSong.SongTitle,
                        AlbumID = SelectedSong.AlbumID, 
                    });
                });

                DeleteSongCommand = new RelayCommand(async() =>
                {
                    await Songs.Delete(SelectedSong.SongID);
                    await Songs.Refresh();
                    IsSelected = false;
                },
                () =>
                {
                    return IsSelected == true;
                });

                UpdateSongCommand = new RelayCommand(async () =>
                {
                    Songs.Update(SelectedSong);
                    await Songs.Refresh();
                },
                () =>
                {
                    return IsSelected == true;
                });
                GetAnAlbumsBestSongCommand = new RelayCommand(() =>
                {
                    Result=Songs.GetAnAlbumsBestSong<Song>(SelectedSong.AlbumID).FirstOrDefault();
                },
                () =>
                {
                    return SelectedSong != null;
                });

                SelectedSong = new Song();
                Result = new Song();
            }
        }

    }
}
