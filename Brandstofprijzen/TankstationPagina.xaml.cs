using Brandstofprijzen.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI;
using Windows.Services.Maps;
using Windows.UI.Xaml.Controls.Maps;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Brandstofprijzen
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TankstationPagina : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public TankstationPagina()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            NavigatieEigenschappen eig = new NavigatieEigenschappen();
            eig = (NavigatieEigenschappen)e.NavigationParameter;
            string selectedIndex = eig.parameter1;
            int index = int.Parse(selectedIndex);
            index = index - 1;
            Tankstations tankstations = new Tankstations(eig.parameter2);
            Tankstation tankstation = tankstations.Items[index];
            this.DefaultViewModel["item"] = tankstation;
            switch (eig.parameter2)
            {
                case 0:
                    a.Foreground = new SolidColorBrush(Colors.Yellow);
                    break;
                case 1:
                    b.Foreground = new SolidColorBrush(Colors.Yellow);
                    break;
                case 2:
                    c.Foreground = new SolidColorBrush(Colors.Yellow);
                    break;
                default:
                    break;
            }
            navigate(tankstation);
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MapService.ServiceToken = "kOajc1fsAA5TZlkDVtCVSA​";
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private async void navigate(Tankstation tankstation)
        {
            Geolocator locator = new Geolocator();
            Geoposition geoposition = await locator.GetGeopositionAsync();

            BasicGeoposition position1 = new BasicGeoposition();
            position1.Latitude = geoposition.Coordinate.Point.Position.Latitude;
            position1.Longitude = geoposition.Coordinate.Point.Position.Longitude;
            Geopoint startPoint = new Geopoint(position1);

            await myMap.TrySetViewAsync(geoposition.Coordinate.Point, 13);

            BasicGeoposition position2 = new BasicGeoposition();
            position2.Latitude = tankstation.lat;
            position2.Longitude = tankstation.lon;
            Geopoint endPoint = new Geopoint(position2);
            MapRouteFinderResult result = await
            MapRouteFinder.GetDrivingRouteAsync(startPoint, endPoint);
            if (result.Status == MapRouteFinderStatus.Success)
            {
                MapRouteView routeView = new MapRouteView(result.Route);
                routeView.RouteColor = Colors.Red;
                routeView.OutlineColor = Colors.Black;
                myMap.Routes.Add(routeView);
            }
        }
    }
}
