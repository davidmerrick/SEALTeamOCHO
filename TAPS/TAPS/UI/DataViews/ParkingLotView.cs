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
        /// <summary>
        /// Creates a new ParkingLotView with the given lot name, lot region, number of total spaces, 
        /// and number of available spaces.
        /// </summary>
        /// <param name="lotName"></param>
        /// <param name="lotRegion"></param>
        /// <param name="totalSpaces"></param>
        /// <param name="availableSpaces"></param>
        public ParkingLotView(String lotName, Region lotRegion, int totalSpaces, int availableSpaces)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The name of the parking lot
        /// </summary>
        public String LotName
        {
            get
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// The total number of spaces in the parking lot. Only spaces which the user can
        /// park in given their UserParkingPermissions and UserParkingRestrictions are considered
        /// in this total.
        /// </summary>
        public int TotalSpaces
        {
            get
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// The ratio of AvailableSpaces to TotalSpaces.
        /// </summary>
        public float PercentAvailable
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Updates the AvailableSpaces and TotalSpaces properties of the ParkingLotView.
        /// </summary>
        /// <param name="availableSpaces">The new number of available spaces</param>
        /// <param name="totalSpaces">The new number of total spaces</param>
        /// <remarks>
        /// The caller should calculate the values for "availableSpaces" and "totalSpaces" 
        /// according to the definitions of these fields (as given in the documentation for the
        /// AvailableSpaces and TotalSpaces properties.</remarks>
        public void UpdateAvailableSpaces(int availableSpaces, int totalSpaces)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the LotName, LotRegion, AvailableSpaces, and TotalSpaces properties of the 
        /// ParkingLotView.
        /// </summary>
        /// <param name="lotName">the new lot name (null for no update)</param>
        /// <param name="lotRegion">the new lot region (null for no update)</param>
        /// <param name="availableSpaces">the new number of available spaces (null for no update)</param>
        /// <param name="totalSpaces">the new number of total spaces (null for no update)</param>
        /// <remarks>
        /// Any argument that is left null will result in no change to the corresponding field of the
        /// ParkingLotView object.</remarks>
        public void UpdateLot(String? lotName, Region lotRegion, int? availableSpaces, int? totalSpaces)
        {
            throw new NotImplementedException();
        }
    }
}
