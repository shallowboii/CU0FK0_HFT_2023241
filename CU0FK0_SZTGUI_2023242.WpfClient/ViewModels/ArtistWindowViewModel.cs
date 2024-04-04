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
                    OnPropertyChanged();
                    (DeleteArtistCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }



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
        public ArtistWindowViewModel(RestCollection<Artist> artists)
        {

            
            if (!IsInDesignMode)
            {
                
                this.Artists = artists;
                CreateArtistCommand = new RelayCommand(() =>
                {
                    Artists.Add(new Artist()
                    {
                        ArtistName = SelectedArtist.ArtistName
                    });
                });

                DeleteArtistCommand = new RelayCommand(() =>
                {
                    Artists.Delete(SelectedArtist.ArtistID);
                    SelectedArtist.ArtistID = 0;
                },
                () =>
                {
                    return SelectedArtist.ArtistID != 0;
                });

                UpdateArtistCommand = new RelayCommand(() =>
                {
                    Artists.Update(SelectedArtist);
                });
                SelectedArtist = new Artist() { ArtistID = 0 };
            }
        }

    }
}
