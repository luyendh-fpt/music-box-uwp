using Linq.Model;
using Linq.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class AddPage : Page
    {
        public AddPage()
        {
            this.InitializeComponent();
        }

        private async void AddSong_Click(object sender, RoutedEventArgs e)
        {
            DatabaseHelper Db_Helper = new DatabaseHelper();//Creating object for DatabaseHelperClass.cs from ViewModel/DatabaseHelperClass.cs    
            if (NametxtBx.Text != "" & AuthourNametxtBx.Text != "")
            {
                Db_Helper.Insert(new Songs(NametxtBx.Text, AuthourNametxtBx.Text));
                Frame.Navigate(typeof(HomePage));//after add contact redirect to contact listbox page    
            }
            else
            {
                MessageDialog messageDialog = new MessageDialog("Please fill two fields");//Text should not be empty    
                await messageDialog.ShowAsync();
            }
        }
    }
}
