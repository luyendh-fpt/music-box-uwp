using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPMusicBox.PlayMusic
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlayList : Page
    {
        MediaPlayer player;
        bool playing;
        public PlayList()
        {
            this.InitializeComponent();
            player = new MediaPlayer();
            playing = false;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //play from file
                //Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
                //Windows.Storage.StorageFile file = await folder.GetFileAsync("Way Back Home - Shaun [320kbps_MP3].mp3");            
                //player.Source = MediaSource.CreateFromStorageFile(file);
            //play from url
            Uri uri = new Uri("https://zmp3-mp3-s1.zadn.vn/95583458e41c0d42540d/5609599441378805868?authen=exp=1533949432~acl=/95583458e41c0d42540d/*~hmac=d9e0632f2a3a6c4329e14f6a2b61b6ab");
            player.Source = MediaSource.CreateFromUri(uri);
            player.AutoPlay = false;

            if (playing)
            {
                player.Source = null;
                playing = false;
            }
            else
            {
                player.Play();
                playing = true;
            }
        }
    }
}
