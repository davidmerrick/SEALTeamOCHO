using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TAPS
{
    /// <summary>
    /// This class provides all the data necessary to display an overview of a parking lot on the campus map. 
    /// This includes the lot name, region, and vacancy data. 
    /// </summary>
    class ParkingLotView
    {
        protected Lot mParkingLot;

        /// <summary>
        /// Creates a new ParkingLotView with the given Lot object as the data source
        /// </summary>
        /// <param name="lotName"></param>
        /// <param name="lotRegion"></param>
        /// <param name="totalSpaces"></param>
        /// <param name="availableSpaces"></param>
        public ParkingLotView(Lot parkingLot)
        {
            if (parkingLot == null)
                throw new ArgumentNullException("dataSource", "'dataSource' cannot be null");

            this.mParkingLot = parkingLot;
        }

        /// <summary>
        /// The name of the parking lot
        /// </summary>
        public String LotName
        {
            get
            {
                return this.mParkingLot.Name;
            }
        }

        /// <summary>
        /// A System.Drawing.Region which defines where the parking lot should be drawn
        /// on the campus map
        /// </summary>
        public Region LotRegion
        {
            get
            {
                return this.mParkingLot.LotRegion;
            }
        }

        /// <summary>
        /// The total number of spaces in the parking lot. Only spaces which the user can
        /// park in given their UserParkingPermissions are considered
        /// in this total.
        /// </summary>
        public int TotalSpaces
        {
            get
            {
                return this.mParkingLot.GetTotalCount(UserSettings.ParkingPermissions);
            }
        }

        /// <summary>
        /// The number of available spaces in the parking lot. A space is considered "available"
        /// if (1) it is not occupied and (2) the user has the appropriate parking permissions for
        /// the space.
        /// </summary>
        public int AvailableSpaces
        {
            get
            {
                return this.mParkingLot.GetVacantCount(UserSettings.ParkingPermissions);
            }
        }

        /// <summary>
        /// The ratio of AvailableSpaces to TotalSpaces.
        /// </summary>
        public float PercentAvailable
        {
            get
            {
                return (float)this.AvailableSpaces / (float)this.TotalSpaces;
            }
        }

        /// <summary>
        /// Updates the AvailableSpaces and TotalSpaces properties of the ParkingLotView.
        /// </summary>
        public void UpdateAvailableSpaces()
        {
            this.mParkingLot.UpdateLot();
        }

    }
}
