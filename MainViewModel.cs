using CommunityToolkit.Mvvm.ComponentModel;
using MediaPlayerWithGestureRecognition.Areas.Player.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayerWithGestureRecognition
{
    public sealed partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private PlayerViewModel playerViewModel;

        [ObservableProperty]
        private PlayListViewModel playListViewModel;

        public MainViewModel()
        {

        }
    }
}
