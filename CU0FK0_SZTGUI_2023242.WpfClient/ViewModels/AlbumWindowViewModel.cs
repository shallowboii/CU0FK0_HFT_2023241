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
    public class AlbumWindowViewModel : ObservableRecipient
    {
        private Album selectedAlbum;

        public Album SelectedAlbum
        {
            get { return selectedAlbum; }
            set
            {
                if (value != null)
                {
                    selectedAlbum = new Album()
                    {
                        AlbumID = value.AlbumID,
                        AlbumTitle = value.AlbumTitle
                    };
                    OnPropertyChanged();
                    (DeleteAlbumCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }



        public RestCollection<Album> Albums { get; set; }

        public ICommand CreateAlbumCommand { get; set; }
        public ICommand UpdateAlbumCommand { get; set; }

        public ICommand DeleteAlbumCommand { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public AlbumWindowViewModel()
        {

            if (!IsInDesignMode)
            {
                Albums = new RestCollection<Album>("http://localhost:17161/", "album", "hub");
                CreateAlbumCommand = new RelayCommand(() =>
                {
                    Albums.Add(new Album()
                    {
                        AlbumTitle = SelectedAlbum.AlbumTitle
                    });
                });

                DeleteAlbumCommand = new RelayCommand(() =>
                {
                    Albums.Delete(selectedAlbum.AlbumID);
                },
                () =>
                {
                    return selectedAlbum != null;
                });

                UpdateAlbumCommand = new RelayCommand(() =>
                {
                    Albums.Update(SelectedAlbum);
                });
                SelectedAlbum = new Album();
            }
        }

    }
}
