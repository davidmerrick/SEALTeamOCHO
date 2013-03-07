using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TAPS
{

    public class Map
    {
        //5 is just an arbitrary lot count
        protected Image mCampusImage;
        protected List<Lot> mLotList;
        //double[] lotVacancy = new double[5]()

        public Map()
        {
            this.mLotList = new List<Lot>();
        }

        public void UpdateVacancies()
        {
            foreach (Lot curLot in this.mLotList)
            {
                curLot.UpdateLot();
            }
        }

        public List<Lot> Lots
        {
            get
            {
                return this.mLotList;
            }
        }

        public Image CampusImage
        {
            get
            {
                return this.mCampusImage;
            }
            set
            {
                this.mCampusImage = value;
            }
        }
    }

    public class Space
    {
        public bool vacant;
        public bool handicap;
        //public bool motorcycle;
        public bool faculty;
        public int spaceID;
        public Rectangle rect;

        public Space()
        {
            this.vacant = true;
            this.handicap = false;
            this.faculty = false;
            this.rect = new Rectangle(0, 0, 100, 100);
            this.spaceID = 0;
        }

        public Space(bool vacant, bool handicap, bool faculty, int spaceID, Rectangle rect)
        {
            if (handicap && faculty) throw new ArgumentException("A parking space cannot have both 'vacant' and 'handicap' set to true");
            this.vacant = vacant;
            this.handicap = handicap;
            this.faculty = faculty;
            this.spaceID = spaceID;
            this.rect = rect;
        }

        public Boolean CanUserPark(SpaceType[] userPermissions)
        {
            //user must have at least one of the restrictions associated with the space
            //in their permissions list
            if (this.faculty && userPermissions.Contains(SpaceType.faculty))
                return true;
            else if (this.handicap && userPermissions.Contains(SpaceType.handicap))
                return true;
            else if (!this.handicap && !this.faculty)
                return true;
            else
                return false;

            
        }

        public enum SpaceType
        {
            regular,
            handicap,
            faculty,
            any
        }
    }

    public class Lot
    {
        //size is an arbitrary number of spaces in the lot
        protected String mLotName;
        protected Image mLotImage;
        protected Region mLotRegion;
        protected List<Space> mSpaceList;

        public double vacancyPercent;

        public Lot()
        {
            this.mSpaceList = new List<Space>();
        }

        public Lot(String lotName, Image lotImage, Region mLotRegion, IList<Space> spaceList)
        {
            this.mLotName = lotName;
            this.mLotImage = lotImage;
            this.mLotRegion = mLotRegion;
            if (spaceList == null)
                throw new ArgumentException("spaceList cannot be null", "spaceList");
            this.mSpaceList = (List<Space>) spaceList;

            //randomly occupy parking spots
            this.UpdateLot();
        }

        public String Name
        {
            get
            {
                return this.mLotName;
            }
            set
            {
                this.mLotName = value;
            }
        }

        public Image LotImage
        {
            get
            {
                return this.mLotImage;
            }
            set
            {
                this.mLotImage = value;
            }
        }

        public Region LotRegion
        {
            get
            {
                return this.mLotRegion;
            }
            set
            {
                this.mLotRegion = value;
            }
        }

        public IList<Space> Spaces
        {
            get
            {
                return this.mSpaceList;
            }
        }

        public void UpdateLot()
        {
            Random rand = new Random();
            float r;
            int numberVacant = 0;

            int i;
            for (i = 0; i < mSpaceList.Count; ++i)
            {
                //These random numbers are arbitrary
                r = rand.Next();
                r = r % 109;

                if ((r > 4.2) && (r < 75.9))
                {

                    if (mSpaceList[i].vacant == true)
                    {
                        mSpaceList[i].vacant = false;
                    }
                    else
                    {
                        mSpaceList[i].vacant = true;
                    }
                }
            }

            //The below write is to show each space's vacancy.
            //Console.WriteLine("\nLot ID is " + (lotID + 1));

            //updates vacancyPercent
            //this.mVacancyCounts[Space.SpaceType.faculty] = 0;
            //this.mVacancyCounts[Space.SpaceType.handicap] = 0;
            //this.mVacancyCounts[Space.SpaceType.regular] = 0;

            //for (i = 0; i < mSpaceList.Count; ++i)
            //{
            //    Console.WriteLine("spot" + mSpaceList[i].spaceID + " is   " + mSpaceList[i].vacant);
            //    if (mSpaceList[i].vacant == true)
            //    {
            //        if (mSpaceList[i].faculty)
            //            this.mVacancyCounts[Space.SpaceType.faculty]++;
            //        else if (mSpaceList[i].handicap)
            //            this.mVacancyCounts[Space.SpaceType.handicap]++;
            //        else
            //            this.mVacancyCounts[Space.SpaceType.regular]++;

            //        ++numberVacant;
            //    }
            //}

            //vacancyPercent = 100.0 * ((double)numberVacant / (double)mSpaceList.Count);
        }

        public int GetTotalCount(Space.SpaceType[] spaceTypes)
        {
            if (this.mSpaceList == null)
                throw new InvalidOperationException("Cannot call GetTotalCount() unless Spaces has been initialized");

            Dictionary<Space.SpaceType, int> totalCounts = new Dictionary<Space.SpaceType, int>();
            if(spaceTypes.Contains(Space.SpaceType.any))
            {
                return this.mSpaceList.Count;
            }

            totalCounts.Add(Space.SpaceType.faculty, 0);
            totalCounts.Add(Space.SpaceType.handicap, 0);
            totalCounts.Add(Space.SpaceType.regular, 0);
            
            foreach(Space spc in this.mSpaceList)
            {
                if(spc.faculty) totalCounts[Space.SpaceType.faculty]++;
                else if(spc.handicap) totalCounts[Space.SpaceType.handicap]++;
                else totalCounts[Space.SpaceType.regular]++;
            }

            int sum = 0;
            foreach(Space.SpaceType type in spaceTypes)
            {
                sum += totalCounts[type];
            }

            return sum;
        }

        public int GetTotalCount(Space.SpaceType spaceType)
        {
            if (this.mSpaceList == null)
                throw new InvalidOperationException("Cannot call GetTotalCount() unless Spaces has been initialized");

            int count = 0;

            switch (spaceType)
            {
                case Space.SpaceType.any:
                    count = this.mSpaceList.Count;
                    break;
                case Space.SpaceType.faculty:
                    foreach (Space spc in this.mSpaceList)
                        if (spc.faculty) count++;
                    break;
                case Space.SpaceType.handicap:
                    foreach (Space spc in this.mSpaceList)
                        if (spc.handicap) count++;
                    break;
                case Space.SpaceType.regular:
                    foreach (Space spc in this.mSpaceList)
                        if (!(spc.handicap || spc.faculty)) count++;
                    break;
            }

            return count;
        }

        public int GetVacantCount(Space.SpaceType[] spaceTypes)
        {
            if (this.mSpaceList == null)
                throw new InvalidOperationException("Cannot call GetTotalCount() unless Spaces has been initialized");

            Dictionary<Space.SpaceType, int> vacantCounts = new Dictionary<Space.SpaceType, int>();
            vacantCounts.Add(Space.SpaceType.any, 0);
            vacantCounts.Add(Space.SpaceType.faculty, 0);
            vacantCounts.Add(Space.SpaceType.handicap, 0);
            vacantCounts.Add(Space.SpaceType.regular, 0);
            int totalCount = 0;

            foreach(Space spc in this.mSpaceList)
            {
                if(spc.vacant) {
                    if(spc.faculty) vacantCounts[Space.SpaceType.faculty]++;
                    else if(spc.handicap) vacantCounts[Space.SpaceType.handicap]++;
                    else vacantCounts[Space.SpaceType.regular]++;

                    vacantCounts[Space.SpaceType.any]++;
                }
            }

            if(spaceTypes.Contains(Space.SpaceType.any)) return vacantCounts[Space.SpaceType.any];
            else
            {
                foreach(Space.SpaceType type in spaceTypes)
                {
                    totalCount += vacantCounts[type];
                }

                return totalCount;
            }
        }

        public int GetVacantCount(Space.SpaceType spaceType)
        {
             if (this.mSpaceList == null)
                throw new InvalidOperationException("Cannot call GetTotalCount() unless Spaces has been initialized");

            int count = 0;

            switch (spaceType)
            {
                case Space.SpaceType.any:
                    count = this.mSpaceList.Count;
                    break;
                case Space.SpaceType.faculty:
                    foreach (Space spc in this.mSpaceList)
                        if (spc.faculty) count++;
                    break;
                case Space.SpaceType.handicap:
                    foreach (Space spc in this.mSpaceList)
                        if (spc.handicap) count++;
                    break;
                case Space.SpaceType.regular:
                    foreach (Space spc in this.mSpaceList)
                        if (!(spc.handicap || spc.faculty)) count++;
                    break;
            }

            return count;
        }
    }

}
    
//    class MainTest
//    {
//        static void Main(string[] args)
//        {
            


//            Map taps = new Map();
//            taps.initializeMap();


//            double[] test = new double[5];


//            int i;


//            taps.updateVacancies();
//            test = taps.getLotVacancies();


//            for (i = 0; i < 5; ++i)
//            {
//                Console.Write(" \n Lot " + (i + 1) + "'s vacancy percentage is " + test[i].ToString() + "%");
//            }


//            Console.ReadLine();
//        }
//    }
    

//}