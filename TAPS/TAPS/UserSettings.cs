using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAPS
{
    class UserSettings
    {

        public static Space.SpaceType[] ParkingPermissions
        {
            get
            {
                return new Space.SpaceType[] { Space.SpaceType.regular};
            }
            set
            {

            }
        }

        public enum ColorblindSettings
        {
            None,
            RedGreen
        }

        public enum UserParkingPermissions
        {
            None = 0,
            Handicap = 1,
            Faculty = 2,
            Service = 4
        }

        public enum UserParkingRestrictions
        {
            None = 0,
            Motorcycle = 1
        }
    }
}
