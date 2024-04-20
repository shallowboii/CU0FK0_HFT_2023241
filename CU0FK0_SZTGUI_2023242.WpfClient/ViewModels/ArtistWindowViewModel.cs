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
    public class ArtistWindowViewModel : ObservableRecipient
    {
        public bool IsSelected { get; set; }
        private Artist selectedArtist;

        public Artist SelectedArtist
        {
            get { return selectedArtist; }
            set
            {
                if (value != null)
                {
                    selectedArtist = new Artist()
                    {
                        ArtistID = value.ArtistID,
                        ArtistName = value.ArtistName
                    };
                    IsSelected = true;
                    OnPropertyChanged();
                    
                }
                else
                {
                    IsSelected = false;
                    selectedArtist = new Artist();
                }
                (DeleteArtistCommand as RelayCommand)?.NotifyCanExecuteChanged();
                (UpdateArtistCommand as RelayCommand)?.NotifyCanExecuteChanged();
            }
        }


        public RestCollection<Album> Albums { get; set; }
        public RestCollection<Artist> Artists { get; set; }

        public ICommand CreateArtistCommand { get; set; }
        public ICommand UpdateArtistCommand { get; set; }

        public ICommand DeleteArtistCommand { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public ArtistWindowViewModel()
        {

        }
        public ArtistWindowViewModel(RestCollection<Artist> artists, RestCollection<Album> albums)
        {

            
            if (!IsInDesignMode)
            {
                this.Albums = albums;
                this.Artists = artists;
                CreateArtistCommand = new RelayCommand(() =>
                {
                    Artists.Add(new Artist()
                    {
                        ArtistName = SelectedArtist.ArtistName
                    });
                    IsSelected = false;
                });

                DeleteArtistCommand = new RelayCommand(async() =>
                {
                    await Artists.Delete(SelectedArtist.ArtistID);
                    await Artists.Refresh();
                    await Albums.Refresh();
                    IsSelected = false;
                },
                () =>
                {
                    return IsSelected == true;
                });

                UpdateArtistCommand = new RelayCommand(async () =>
                {
                    Artists.Update(SelectedArtist);
                    await Artists.Refresh();
                },
                () =>
                {
                    return IsSelected == true;
                });
                SelectedArtist = null;
               
            }
        }

    }
}
