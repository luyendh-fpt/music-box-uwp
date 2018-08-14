using Linq.Model;
using Linq.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Linq.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailsPage : Page
    {
        DatabaseHelper Db_Helper = new DatabaseHelper();
        Songs currentSong = new Songs();
        public DetailsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            currentSong = e.Parameter as Songs;
            //currentcontact = Db_Helper.ReadContact(Selected_ContactId);//Read selected DB contact
            NametxtBx.Text = currentSong.Name;//get contact Name
            AuthorNametxtBx.Text = currentSong.AuthourName;//get contact PhoneNumber
        }

        private void UpdateContact_Click(object sender, RoutedEventArgs e)
        {
            currentSong.Name = NametxtBx.Text;
            currentSong.AuthourName = AuthorNametxtBx.Text;
            Db_Helper.Update(currentSong);//Update selected DB contact Id
            Frame.Navigate(typeof(HomePage));
        }
        private void DeleteContact_Click(object sender, RoutedEventArgs e)
        {
            Db_Helper.DeleteSelected(currentSong.Id);//Delete selected DB contact Id.
            Frame.Navigate(typeof(HomePage));
        }
    }
}
