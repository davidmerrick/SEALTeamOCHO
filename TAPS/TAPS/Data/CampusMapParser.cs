using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TAPS.Data
{
    /// <summary>
    /// Parses a file containing campus data (campus map, names of parking lots, 
    /// </summary>
    class CampusMapParser
    {
        public static TAPS.Map ParseCampusMap(Stream file)
        {

            Map newMap = new Map();

            XmlDocument doc = new XmlDocument();
            doc.Load(file);

            //get path of map image
            XmlNode image = doc.SelectSingleNode("/Map/CampusImage");
            if (image == null)
                throw new InvalidDataException("The campus map XML file does not contain a map image tag");

            //load the image from file
            newMap.CampusImage = Image.FromFile(image.InnerText);

            //get all lot tags
            XmlNodeList lots = doc.SelectNodes("/Map/Lot");
            foreach (XmlNode lot in lots)
            {
                newMap.Lots.Add(ParseParkingLot(lot));
            }

            return newMap;
        }

        protected static Lot ParseParkingLot(XmlNode lotNode)
        {
            Lot newLot = new Lot();
            Boolean foundName = false;
            Boolean foundImage = false;
            Boolean foundRegion = false;

            newLot.Spaces.Clear();

            //process every child node
            foreach (XmlNode child in lotNode.ChildNodes)
            {
                if (child.Name.ToUpper() == "NAME")
                {
                    newLot.Name = child.InnerText;
                    foundName = true;
                }
                else if (child.Name.ToUpper() == "IMAGE")
                {
                    try
                    {
                        newLot.LotImage = Image.FromFile(child.InnerText);
                    }
                    catch (Exception ex)
                    {
                        throw new InvalidDataException("The parking lot image could not be loaded");
                    }

                    foundImage = true;
                }
                else if (child.Name.ToUpper() == "REGION")
                {
                    newLot.LotRegion = ParseRegion(child);
                    foundRegion = true;
                }
                else if (child.Name.ToUpper() == "SPACE")
                {
                    newLot.Spaces.Add(ParseParkingSpace(child));
                }
                else
                    throw new InvalidDataException("The Lot contains an invalid node");
            }

            //make sure that the parking lot name and image were parsed
            if (!foundImage || !foundName || !foundRegion)
                throw new InvalidDataException("The Lot XML node is missing one or more required child nodes");

            return newLot;
        }

        protected static Space ParseParkingSpace(XmlNode spaceNode)
        {
            Space newSpace = new Space();
            newSpace.faculty = false;
            newSpace.handicap = false;
            newSpace.vacant = true;

            XmlNode attrib = spaceNode.Attributes.GetNamedItem("flag");
            if(attrib != null)
            {
                switch(attrib.Value)
                {
                    case "faculty":
                        newSpace.faculty = true;
                        break;
                    case "handicap":
                        newSpace.handicap = true;
                        break;
                    case "regular":
                        break;
                    default:
                        throw new InvalidDataException("Space XML node contains invalid value for 'flag' attribute");
                        break;
                }
            }

            attrib = spaceNode.Attributes.GetNamedItem("rect");
            if(attrib == null) throw new InvalidDataException("Space XML node must contain a 'rect' attribute");
            newSpace.rect = ParseRectangle(attrib.Value);

            attrib = spaceNode.Attributes.GetNamedItem("id");
            if (attrib == null) throw new InvalidDataException("Space XML node must contain an 'id' attribute");
            int parsedValue;
            if (int.TryParse(attrib.Value, out parsedValue) == false)
                throw new InvalidDataException("'id' attribute of Space XML node could not be convered to an int");
            newSpace.spaceID = parsedValue;

            return newSpace;
        }

        //string should be formatted as "left,top,width,height"
        protected static Rectangle ParseRectangle(String data)
        {
            if (data == null) throw new InvalidCastException("Rectangle string cannot be null");

            String[] parts = data.Split(new char[] {','});

            Rectangle parsedRect = new Rectangle();
            int parsedValue;

            if (parts.Length != 4) throw new InvalidDataException("Incorrectly formatted rectangle string");
            if (int.TryParse(parts[0], out parsedValue) == false)
                throw new InvalidDataException("Incorrectly formatted rectangle string");
            parsedRect.X = parsedValue;

            if (int.TryParse(parts[1], out parsedValue) == false)
                throw new InvalidDataException("Incorrectly formatted rectangle string");
            parsedRect.Y = parsedValue;

            if (int.TryParse(parts[2], out parsedValue) == false)
                throw new InvalidDataException("Incorrectly formatted rectangle string");
            parsedRect.Width = parsedValue;

            if (int.TryParse(parts[3], out parsedValue) == false)
                throw new InvalidDataException("Incorrectly formatted rectangle string");
            parsedRect.Height = parsedValue;

            return parsedRect;
        }

        protected static Region ParseRegion(XmlNode regionNode)
        {
            XmlNodeList pointNodes = regionNode.ChildNodes;
            int x,y;
            Region newRegion;
            GraphicsPath path = new GraphicsPath();
            List<Point> points = new List<Point>();

            foreach (XmlNode pt in pointNodes)
            {
                if (pt.Name.ToUpper() != "PT")
                    throw new InvalidDataException("Region node must contain only 'pt' nodes");

                //parse into a point
                String[] xy = pt.InnerText.Split(new char[] { ',' });
                if(xy.Length != 2)
                    throw new InvalidDataException("Could not parse 'pt' node");
                if (int.TryParse(xy[0], out x) == false || int.TryParse(xy[1], out y) == false)
                    throw new InvalidDataException("Could not parse 'pt' node");

                points.Add(new Point(x, y));
            }

            path.AddPolygon(points.ToArray());
            newRegion = new Region(path);
            return newRegion;
        }
    }
}
