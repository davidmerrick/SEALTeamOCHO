using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace TAPS
{
    /// <summary>
    /// This class provides all the data needed to display the campus map. This includes the campus map image,
    /// the name and region of each parking lot, the vacancy status of each lot, and user settings.
    /// </summary>
    /// <remarks>
    /// The CampusMapView class serves as a facade which separates the data layer of the application (classes 
    /// such as CampusMap, ParkingLot, and UserSettings) from the UI layer. All data needed by the UI layer
    /// should be obtained using the CampusMapView or ParkingLotView classes, and not the underlying data layer
    /// classes.
    /// </remarks>
    public class CampusMapView
    {
        protected Map mMap;

        /// <summary>
        /// Creates a new CampusMapView and populates its fields with the most up-to-date data available.
        /// </summary>
        /// <remarks>
        /// After creation, the following fields of the CampusMapView object are up-to-date (meaning that 
        /// they contain the latest data available from the TAPS server):
        ///     CampusMapView.CampusMap
        ///     CampusMapView.ParkingLotViews (including lot names, regions, and vacancies)
        /// </remarks>
        public CampusMapView()
        {
            //get the parking lot data from the XML file
            this.mMap = Data.CampusMapParser.ParseCampusMap(new FileStream(
                Properties.Settings.Default.ParkingDataFilePath, FileMode.Open));

        }

        /// <summary>
        /// Returns an image of the campus map
        /// </summary>
        public Image CampusMap
        {
            get
            {
                return this.mMap.CampusImage;
            }
        }

        /// <summary>
        /// Returns an enumerable collection of ParkingLotView objects representing the parking lots on the campus map.
        /// Each ParkingLotView contains the lot name, region, and vacancy percent.
        /// </summary>
        public IEnumerable<ParkingLotView> ParkingLotViews
        {
            get
            {
                List<ParkingLotView> views = new List<ParkingLotView>();

                //create a parking lot view for every lot
                foreach (Lot curLot in this.mMap.Lots)
                {
                    views.Add(new ParkingLotView(curLot));
                }

                return views;
            }
        }

        /// <summary>
        /// Updates the following fields of the CampusMapView to be up-to-date with the server:
        ///     CampusMap
        ///     ParkingLotViews (including lot names, regions, and vacancies)
        /// </summary>
        public void UpdateMap()
        {
            this.mMap = Data.CampusMapParser.ParseCampusMap(new FileStream(
                Properties.Settings.Default.ParkingDataFilePath, FileMode.Open));
        }

        /// <summary>
        /// Updates the vacancy percentage of each ParkingLotView in CampusMapView.ParkingLotView 
        /// to be up-to-date with the server.
        /// </summary>
        public void UpdateVacancies()
        {
            this.mMap.UpdateVacancies();
        }
    }

}
