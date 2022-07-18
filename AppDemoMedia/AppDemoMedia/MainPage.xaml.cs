using MediaManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace AppDemoMedia
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
            CrossMediaManager.Current.PositionChanged += Current_PositionChanged;
            //video.Current.MediaType = MediaManager.Library.MediaType.Video;
           
        }
        private double width = 0;
        private double height = 0;
        protected override async void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width != this.width || height != this.height)
            {
                await DisplayAlert("mensaje if", $"{this.width}  {width} {this.height} {height} video: {MediaManager.CrossMediaManager.Current.MediaPlayer.VideoWidth} {MediaManager.CrossMediaManager.Current.MediaPlayer.VideoHeight}", "Ok");
                this.width = width;
                this.height = height;
                if (width > height)
                {
                    stack.Orientation = StackOrientation.Horizontal;
                    video.VideoAspect = MediaManager.Video.VideoAspectMode.AspectFill;
                    await DisplayAlert("mensajew", "horizontal", "Ok");
                    
                }
                else
                {
                    stack.Orientation = StackOrientation.Vertical;
                    video.VideoAspect = MediaManager.Video.VideoAspectMode.AspectFit;
                    await DisplayAlert("mensajew", "vertical", "Ok");
                }
            }
            else
            {
                await DisplayAlert("mensaje else", $"{this.width}  {width} {this.height} {height} video.  {MediaManager.CrossMediaManager.Current.MediaPlayer.VideoWidth} {MediaManager.CrossMediaManager.Current.MediaPlayer.VideoHeight}", "Ok");
            }
        }
        private void Current_PositionChanged(object sender, MediaManager.Playback.PositionChangedEventArgs e)
        {
            //video.VideoAspect = MediaManager.Video.VideoAspectMode.AspectFill;
            System.Diagnostics.Debug.WriteLine($"giro {e.Position.TotalSeconds}");
        }
        
    }
}
