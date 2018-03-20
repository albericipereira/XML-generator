using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMLGenerator
{
    public enum Eventype
    {
        Assault,
        AttemptRape,
        BankRelated,
        FirearmIncidents,
        FirearmSeized,
        Homicide,
        HNPKilled,
        HNPWounded,
        Kidnapping,
        MotorcycleMurder,
        MotorcycleNonMurder,
        Narcotics,
        RapeDay,
        RapeNight,
        RapeUnknown,
        Robbery,
        None
    }
    public enum CivilEventype
    {
        Commemoration,
        Justice,
        Political,
        Security,
        Socioeconomic,
        Unknown,
        None
    }
    public class Point
    {
        public Eventype _eventType;
        public string _pointId;
        public string _latitude;
        public string _longitude;
        public string _description;
        public DateTime _dataEvento;

        public Point(Eventype et, string ptId, string lat, string lon, string description, string date)
        {
            _eventType = et;
            _pointId = ptId;
            _latitude = lat;
            _longitude = lon;

            _description = description;
            _dataEvento = Convert.ToDateTime(date);
        }

        public string getStyleMap()
        {
            switch (this._eventType)
            {
                case Eventype.Assault:
                    return "m_Assault";
                case Eventype.AttemptRape:
                    return "m_AttemptRape";
                case Eventype.BankRelated:
                    return "m_BankRelated";
                case Eventype.FirearmIncidents:
                    return "m_FirearmIncidents";
                case Eventype.FirearmSeized:
                    return "m_FirearmSeized";
                case Eventype.HNPKilled:
                    return "m_HNPKilled";
                case Eventype.HNPWounded:
                    return "m_HNPWounded";
                case Eventype.Homicide:
                    return "m_Homicide";
                case Eventype.Kidnapping:
                    return "m_Kidnapping";
                case Eventype.MotorcycleMurder:
                    return "m_MotorcycleMurder";
                case Eventype.MotorcycleNonMurder:
                    return "m_MotorcycleNonMurder";
                case Eventype.Narcotics:
                    return "m_Narcotics";
                case Eventype.RapeDay:
                    return "m_RapeDay";
                case Eventype.RapeNight:
                    return "m_RapeNight";
                case Eventype.RapeUnknown:
                    return "m_RapeUnknown";
                case Eventype.Robbery:
                    return "m_Robbery";
                default:
                    return String.Empty;
            }
        }

    }

    public class PointWeapon
    {
        public string _pointId;
        public string _latitude;
        public string _longitude;
        public DateTime _dataEvento;
        public string _description;

        public PointWeapon(string ptId, string lat, string lon, string description, string date)
        {
            _pointId = ptId;
            _latitude = lat;
            _longitude = lon;
            _description = description;
            _dataEvento = Convert.ToDateTime(date);
        }

        public string getStyleMap()
        {
            return "m_FirearmSeized";
        }

    }

    public class PointCivilEv
    {
        public CivilEventype _eventType;
        public string _pointId;
        public string _latitude;
        public string _longitude;
        public DateTime _dataEvento;
        public Boolean _violent;
        public string _description;

        public PointCivilEv(CivilEventype et, string ptId, string lat, string lon, string description, string date, bool violent)
        {
            _eventType = et;
            _pointId = ptId;
            _latitude = lat;
            _longitude = lon;
            _violent = violent;
            _description = description;
            _dataEvento = Convert.ToDateTime(date);
        }

        public string getStyleMap()
        {
            switch (this._eventType)
            {
                case CivilEventype.Commemoration:
                    if (!this._violent)
                        return "m_Commemoration";
                    else
                        return "m_ViolentCommemoration";
                case CivilEventype.Justice:
                    if (!this._violent)
                        return "m_Justice";
                    else
                        return "m_ViolentJustice";
                case CivilEventype.Political:
                    if (!this._violent)
                        return "m_Political";
                    else
                        return "m_ViolentPolitical";
                case CivilEventype.Security:
                    if (!this._violent)
                        return "m_Security";
                    else
                        return "m_ViolentSecurity";
                case CivilEventype.Socioeconomic:
                    if (!this._violent)
                        return "m_Socioeconomic";
                    else
                        return "m_ViolentSocioeconomic";
                case CivilEventype.Unknown:
                    if (!this._violent)
                        return "m_Unknown";
                    else
                        return "m_ViolentUnknown";
                default:
                    return String.Empty;
            }
        }

    }

    public class PointGeneric
    {
        public string _pointId;
        public string _latitude;
        public string _longitude;
        public string _description;
        public string _directory1;
        public string _directory2;
        public string _icon;
        public string _picture;

        public PointGeneric(string ptId, string lat, string lon, string description, string directory1, string directory2, string icon, string picture)
        {
            _pointId = ptId;
            _latitude = lat;
            _longitude = lon;
            _description = description;
            _directory2 = directory2;
            _directory1 = directory1;
            _icon = icon;
            _picture = picture;
        }


        public string getStyleMap()
        {
            switch (this._icon)
            {
                case "YellowPushpin":
                    return "m_YellowPushpin";
                case "BluePushpin":
                    return "m_BluePushpin";
                case "RedPushpin":
                    return "m_RedPushpin";
                case "GreenPushpin":
                    return "m_GreenPushpin";
                case "RedDot":
                    return "m_RedDot";
                case "BlueDot":
                    return "m_BlueDot";
                case "YellowDot":
                    return "m_YellowDot";
                case "GreenDot":
                    return "m_GreenDot";
                case "YellowDollar":
                    return "m_YellowDollar";
                case "RedDollar":
                    return "m_RedDollar";
                case "Caution":
                    return "m_Caution";
                case "RedMotorcycle":
                    return "m_RedMotorcycle";
                case "BlueMotorcycle":
                    return "m_BlueMotorcycle";
                case "RedMan":
                    return "m_RedMan";
                case "YellowMan":
                    return "m_YellowMan";
                case "BlueMan":
                    return "m_BlueMan";
                case "RedWoman":
                    return "m_RedWoman";
                case "YellowWoman":
                    return "m_YellowWoman";
                case "BlueWoman":
                    return "m_BlueWoman";
                case "RedSquare":
                    return "m_RedSquare";
                case "YellowSquare":
                    return "m_YellowSquare";
                case "BlueSquare":
                    return "m_BlueSquare";
                case "RedTriangle":
                    return "m_RedTriangle";
                case "YellowTriangle":
                    return "m_YellowTriangle";
                case "BlueTriangle":
                    return "m_BlueTriangle";
                case "RedPin":
                    return "m_RedPin";
                case "YellowPin":
                    return "m_YellowPin";
                case "BluePin":
                    return "m_BluePin";
                default:
                    return String.Empty;
            }
        }

    }
    public class Map
    {
        public List<PointWeapon> _pointWeapon;
        public List<Point> _points;
        public List<PointCivilEv> _pointsCivEvt;
        public List<PointGeneric> _pointsGeneric;
        public Eventype[] _crimeTypes;
        public CivilEventype[] _CivilEvTypes;
        public bool _Directory1;
        public bool _Directory2;

        public Map()
        {
            _points = new List<Point>();
            _pointsCivEvt = new List<PointCivilEv>();
            _pointWeapon = new List<PointWeapon>();
            _pointsGeneric = new List<PointGeneric>();
            _Directory1 = true;
            _Directory2 = true;

            _crimeTypes = new Eventype[16]{Eventype.Assault,Eventype.AttemptRape,Eventype.BankRelated,Eventype.FirearmIncidents,Eventype.FirearmSeized,
                Eventype.HNPKilled,Eventype.HNPWounded, Eventype.Homicide, Eventype.Kidnapping, Eventype.MotorcycleMurder, Eventype.MotorcycleNonMurder,
                Eventype.Narcotics, Eventype.RapeDay, Eventype.RapeNight, Eventype.RapeUnknown, Eventype.Robbery};

            _CivilEvTypes = new CivilEventype[6] { CivilEventype.Commemoration, CivilEventype.Justice, CivilEventype.Political, CivilEventype.Security, 
                CivilEventype.Socioeconomic, CivilEventype.Unknown};
        }

        public string getParentFolder(Eventype _event)
        {
            switch (_event)
            {
                case Eventype.Assault:
                    return "Assault";
                case Eventype.AttemptRape:
                    return "Attempt to Rape";
                case Eventype.BankRelated:
                    return "Bank Related";
                case Eventype.FirearmIncidents:
                    return "Firearm Incidents";
                case Eventype.FirearmSeized:
                    return "Firearm Seized";
                case Eventype.HNPKilled:
                    return "HNP Killed";
                case Eventype.HNPWounded:
                    return "HNP Wounded";
                case Eventype.Homicide:
                    return "Homicide";
                case Eventype.Kidnapping:
                    return "Kidnapping";
                case Eventype.MotorcycleMurder:
                    return "Motorcycle Murder";
                case Eventype.MotorcycleNonMurder:
                    return "Motorcycle Non-Murder";
                case Eventype.Narcotics:
                    return "Narcotics";
                case Eventype.RapeDay:
                    return "Rape Day";
                case Eventype.RapeNight:
                    return "Rape Night";
                case Eventype.RapeUnknown:
                    return "Rape Unknown Time";
                case Eventype.Robbery:
                    return "Robbery";
                default:
                    return String.Empty;
            }
        }

        public string getParentFolder(CivilEventype _event)
        {
            switch (_event)
            {
                case CivilEventype.Commemoration:
                    return "Commemoration";
                case CivilEventype.Justice:
                    return "Justice";
                case CivilEventype.Political:
                    return "Political";
                case CivilEventype.Security:
                    return "Security";
                case CivilEventype.Socioeconomic:
                    return "Socioeconomic";
                case CivilEventype.Unknown:
                    return "Unknown";
                default:
                    return String.Empty;
            }
        }

        /// <summary>
        /// Gets  parent folder's name for Firearm seized
        /// </summary>
        /// <param name="_event"></param>
        /// <returns></returns>
        public string getParentFolder()
        {
            return "Firearm Seized";
        }
        /// <summary>
        /// Gets  parent style info for Firearm seized
        /// </summary>
        /// <param name="_event"></param>
        /// <returns></returns>
        public string getStyle()
        {
            return @"
	            <Style id='sh_FirearmSeized'>
		            <IconStyle>
			            <color>ff00ffff</color>
			            <scale>1.18182</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/shaded_dot.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sn_FirearmSeized'>
		            <IconStyle>
			            <color>ff00ffff</color>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/shaded_dot.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <StyleMap id='m_FirearmSeized'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_FirearmSeized</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_FirearmSeized</styleUrl>
		            </Pair>
	            </StyleMap>";
        }

        public string getStyle(Eventype _event)
        {
            switch (_event)
            {
                case Eventype.Assault:
                    return @"<Style id='s_assault1'>
					<IconStyle>
						<color>ffff0000</color>
						<scale>0.8</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/shaded_dot.png</href>
						</Icon>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
				<Style id='s_assault2'>
					<IconStyle>
						<color>ffff0000</color>
						<scale>0.945455</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/shaded_dot.png</href>
						</Icon>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
                <StyleMap id='m_Assault'>
					<Pair>
						<key>normal</key>
						<styleUrl>#s_assault1</styleUrl>
					</Pair>
					<Pair>
						<key>highlight</key>
						<styleUrl>#s_assault2</styleUrl>
					</Pair>
				</StyleMap>
				";

                case Eventype.AttemptRape:
                    return @"<Style id='s_attemptRape1'>
					<IconStyle>
						<color>ff00ff55</color>
						<scale>0.8</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/woman.png</href>
						</Icon>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
				<Style id='s_attemptRape2'>
					<IconStyle>
						<color>ff00ff55</color>
						<scale>0.945455</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/woman.png</href>
						</Icon>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
				<StyleMap id='m_AttemptRape'>
					<Pair>
						<key>normal</key>
						<styleUrl>#s_attemptRape1</styleUrl>
					</Pair>
					<Pair>
						<key>highlight</key>
						<styleUrl>#s_attemptRape2</styleUrl>
					</Pair>
				</StyleMap>";

                case Eventype.BankRelated:
                    return @"<Style id='s_BankRelated1'>
					<IconStyle>
						<color>ff00aaff</color>
						<scale>0.8</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/dollar.png</href>
						</Icon>
						<hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
				<Style id='s_BankRelated2'>
					<IconStyle>
						<color>ff00aaff</color>
						<scale>0.945455</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/dollar.png</href>
						</Icon>
						<hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
                <StyleMap id='m_BankRelated'>
					<Pair>
						<key>normal</key>
						<styleUrl>#s_BankRelated1</styleUrl>
					</Pair>
					<Pair>
						<key>highlight</key>
						<styleUrl>#s_BankRelated2</styleUrl>
					</Pair>
				</StyleMap>";

                case Eventype.FirearmIncidents:
                    return @"<Style id='s_FirearmIncidents2'>
					<IconStyle>
						<color>ff0000ff</color>
						<scale>0.945455</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/shaded_dot.png</href>
						</Icon>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
				<Style id='s_FirearmIncidents1'>
					<IconStyle>
						<color>ff0000ff</color>
						<scale>0.8</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/shaded_dot.png</href>
						</Icon>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
				<StyleMap id='m_FirearmIncidents'>
					<Pair>
						<key>normal</key>
						<styleUrl>#s_FirearmIncidents1</styleUrl>
					</Pair>
					<Pair>
						<key>highlight</key>
						<styleUrl>#s_FirearmIncidents2</styleUrl>
					</Pair>
				</StyleMap>";

                case Eventype.FirearmSeized:
                    return @"
	            <Style id='sh_FirearmSeized'>
		            <IconStyle>
			            <color>ff00ffff</color>
			            <scale>1.18182</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/shaded_dot.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sn_FirearmSeized'>
		            <IconStyle>
			            <color>ff00ffff</color>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/shaded_dot.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
                <StyleMap id='m_FirearmSeized'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_FirearmSeized</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_FirearmSeized</styleUrl>
		            </Pair>
	            </StyleMap>";

                case Eventype.HNPKilled:
                    return
                        @"<Style id='s_HNPKilled2'>
					<IconStyle>
						<color>ff0000ff</color>
						<scale>0.945455</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/police.png</href>
						</Icon>
						<hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
				<Style id='s_HNPKilled1'>
					<IconStyle>
						<color>ff0000ff</color>
						<scale>0.8</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/police.png</href>
						</Icon>
						<hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
				<StyleMap id='m_HNPKilled'>
					<Pair>
						<key>normal</key>
						<styleUrl>#s_HNPKilled1</styleUrl>
					</Pair>
					<Pair>
						<key>highlight</key>
						<styleUrl>#s_HNPKilled2</styleUrl>
					</Pair>
				</StyleMap>";

                case Eventype.HNPWounded:
                    return @"
				<Style id='s_HNPWounded2'>
                    <IconStyle>
						<color>ffff0000</color>
						<scale>0.945455</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/police.png</href>
						</Icon>
						<hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
				<Style id='s_HNPWounded'>
					<IconStyle>
						<color>ffff0000</color>
						<scale>0.8</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/police.png</href>
						</Icon>
						<hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
                <StyleMap id='m_HNPWounded'>
					<Pair>
						<key>normal</key>
						<styleUrl>#s_HNPWounded</styleUrl>
					</Pair>
					<Pair>
						<key>highlight</key>
						<styleUrl>#s_HNPWounded2</styleUrl>
					</Pair>
				</StyleMap>";

                case Eventype.Homicide:
                    return @"
				<Style id='s_homicide1'>
					<IconStyle>
						<color>ff0000ff</color>
						<scale>0.945455</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/shaded_dot.png</href>
						</Icon>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
				<Style id='s_homicide2'>
					<IconStyle>
						<color>ff0000ff</color>
						<scale>0.8</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/shaded_dot.png</href>
						</Icon>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
				<StyleMap id='m_Homicide'>
					<Pair>
						<key>normal</key>
						<styleUrl>#s_homicide2</styleUrl>
					</Pair>
					<Pair>
						<key>highlight</key>
						<styleUrl>#s_homicide1</styleUrl>
					</Pair>
				</StyleMap>";

                case Eventype.Kidnapping:
                    return @"<Style id='s_Kidnapping1'>
					<IconStyle>
						<color>ff0000ff</color>
						<scale>0.8</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/caution.png</href>
						</Icon>
						<hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
				<Style id='s_Kidnapping2'>
					<IconStyle>
						<color>ff0000ff</color>
						<scale>0.945455</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/caution.png</href>
						</Icon>
						<hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
				<StyleMap id='m_Kidnapping'>
					<Pair>
						<key>normal</key>
						<styleUrl>#s_Kidnapping1</styleUrl>
					</Pair>
					<Pair>
						<key>highlight</key>
						<styleUrl>#s_Kidnapping2</styleUrl>
					</Pair>
				</StyleMap>";

                case Eventype.MotorcycleMurder:
                    return @"<Style id='s_MotorcycleMurder2'>
					<IconStyle>
						<color>ff0000ff</color>
						<scale>0.945455</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/motorcycling.png</href>
						</Icon>
						<hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
				<Style id='s_MotorcycleMurder1'>
					<IconStyle>
						<color>ff0000ff</color>
						<scale>0.8</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/motorcycling.png</href>
						</Icon>
						<hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
                <StyleMap id='m_MotorcycleMurder'>
					<Pair>
						<key>normal</key>
						<styleUrl>#s_MotorcycleMurder1</styleUrl>
					</Pair>
					<Pair>
						<key>highlight</key>
						<styleUrl>#s_MotorcycleMurder2</styleUrl>
					</Pair>
				</StyleMap>";

                case Eventype.MotorcycleNonMurder:
                    return @"
				<Style id='s_MotorcycleNonMurder2'>
					<IconStyle>
						<color>ffff0000</color>
						<scale>0.945455</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/motorcycling.png</href>
						</Icon>
						<hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
				<Style id='s_MotorcycleNonMurder1'>
					<IconStyle>
						<color>ffff0000</color>
						<scale>0.8</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/motorcycling.png</href>
						</Icon>
						<hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
                <StyleMap id='m_MotorcycleNonMurder'>
					<Pair>
						<key>normal</key>
						<styleUrl>#s_MotorcycleNonMurder1</styleUrl>
					</Pair>
					<Pair>
						<key>highlight</key>
						<styleUrl>#s_MotorcycleNonMurder2</styleUrl>
					</Pair>
				</StyleMap>";

                case Eventype.Narcotics:
                    return @"
				<Style id='s_Narcotics'>
					<IconStyle>
						<color>ff00ff55</color>
						<scale>1.2</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/open-diamond.png</href>
						</Icon>
						<hotSpot x='0.5' y='0.5' xunits='fraction' yunits='fraction'/>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
				<Style id='s_Narcotics2'>
					<IconStyle>
						<color>ff00ff55</color>
						<scale>1.3</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/open-diamond.png</href>
						</Icon>
						<hotSpot x='0.5' y='0.5' xunits='fraction' yunits='fraction'/>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
                <StyleMap id='m_Narcotics'>
					<Pair>
						<key>normal</key>
						<styleUrl>#s_Narcotics</styleUrl>
					</Pair>
					<Pair>
						<key>highlight</key>
						<styleUrl>#s_Narcotics2</styleUrl>
					</Pair>
				</StyleMap>";

                case Eventype.RapeDay:
                    return @"
				<Style id='s_RapeDay1'>
					<IconStyle>
						<color>ff0000ff</color>
						<scale>0.8</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/woman.png</href>
						</Icon>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
				<Style id='s_RapeDay2'>
					<IconStyle>
						<color>ff0000ff</color>
						<scale>0.945455</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/woman.png</href>
						</Icon>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
                <StyleMap id='m_RapeDay'>
					<Pair>
						<key>normal</key>
						<styleUrl>#s_RapeDay1</styleUrl>
					</Pair>
					<Pair>
						<key>highlight</key>
						<styleUrl>#s_RapeDay2</styleUrl>
					</Pair>
				</StyleMap>";

                case Eventype.RapeNight:
                    return @"<Style id='s_RapeNight1'>
					<IconStyle>
						<color>ffff0000</color>
						<scale>0.8</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/woman.png</href>
						</Icon>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
				<Style id='s_RapeNight2'>
					<IconStyle>
						<color>ffff0000</color>
						<scale>0.945455</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/woman.png</href>
						</Icon>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
				<StyleMap id='m_RapeNight'>
					<Pair>
						<key>normal</key>
						<styleUrl>#s_RapeNight1</styleUrl>
					</Pair>
					<Pair>
						<key>highlight</key>
						<styleUrl>#s_RapeNight2</styleUrl>
					</Pair>
				</StyleMap>";

                case Eventype.RapeUnknown:
                    return @"
				<Style id='s_RapeUnknown1'>
					<IconStyle>
						<scale>0.945455</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/woman.png</href>
						</Icon>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
				<Style id='s_RapeUnknown2'>
					<IconStyle>
						<scale>0.8</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/woman.png</href>
						</Icon>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
                <StyleMap id='m_RapeUnknown'>
					<Pair>
						<key>normal</key>
						<styleUrl>#s_RapeUnknown2</styleUrl>
					</Pair>
					<Pair>
						<key>highlight</key>
						<styleUrl>#s_RapeUnknown1</styleUrl>
					</Pair>
				</StyleMap>";

                case Eventype.Robbery:
                    return @"
				<Style id='s_Robbery1'>
					<IconStyle>
						<color>ff00ff55</color>
						<scale>0.8</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/shaded_dot.png</href>
						</Icon>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
				<Style id='s_Robbery2'>
					<IconStyle>
						<color>ff00ff55</color>
						<scale>0.945455</scale>
						<Icon>
							<href>http://maps.google.com/mapfiles/kml/shapes/shaded_dot.png</href>
						</Icon>
					</IconStyle>
					<LabelStyle>
						<color>00ffffff</color>
					</LabelStyle>
				</Style>
                <StyleMap id='m_Robbery'>
					<Pair>
						<key>normal</key>
						<styleUrl>#s_Robbery1</styleUrl>
					</Pair>
					<Pair>
						<key>highlight</key>
						<styleUrl>#s_Robbery2</styleUrl>
					</Pair>
				</StyleMap>";

                default:
                    return String.Empty;
            }
        }

        public string getStyle(CivilEventype _event)
        {
            switch (_event)
            {
                case CivilEventype.Commemoration:
                    return @"
	                        <Style id='sh_violentCommemoration'>
		                        <IconStyle>
			                        <color>ff0000ff</color>
			                        <scale>1.18182</scale>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/paddle/red-stars.png</href>
			                        </Icon>
			                        <hotSpot x='32' y='1' xunits='pixels' yunits='pixels'/>
		                        </IconStyle>
		                        <LabelStyle>
			                        <color>00ffffff</color>
		                        </LabelStyle>
		                        <ListStyle>
			                        <ItemIcon>
				                        <href>http://maps.google.com/mapfiles/kml/paddle/red-stars-lv.png</href>
			                        </ItemIcon>
		                        </ListStyle>
	                        </Style>
	                        <Style id='sn_violentCommemoration'>
		                        <IconStyle>
			                        <color>ff0000ff</color>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/paddle/red-stars.png</href>
			                        </Icon>
			                        <hotSpot x='32' y='1' xunits='pixels' yunits='pixels'/>
		                        </IconStyle>
		                        <LabelStyle>
			                        <color>00ffffff</color>
		                        </LabelStyle>
		                        <ListStyle>
			                        <ItemIcon>
				                        <href>http://maps.google.com/mapfiles/kml/paddle/red-stars-lv.png</href>
			                        </ItemIcon>
		                        </ListStyle>
	                        </Style>
	                        <StyleMap id='m_ViolentCommemoration'>
		                        <Pair>
			                        <key>normal</key>
			                        <styleUrl>#sn_violentCommemoration</styleUrl>
		                        </Pair>
		                        <Pair>
			                        <key>highlight</key>
			                        <styleUrl>#sh_violentCommemoration</styleUrl>
		                        </Pair>
	                        </StyleMap>
	                        <Style id='sh_commemoration'>
		                        <IconStyle>
			                        <color>ff00ffff</color>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/paddle/ylw-stars.png</href>
			                        </Icon>
			                        <hotSpot x='32' y='1' xunits='pixels' yunits='pixels'/>
		                        </IconStyle>
		                        <LabelStyle>
			                        <color>00ffffff</color>
		                        </LabelStyle>
		                        <ListStyle>
			                        <ItemIcon>
				                        <href>http://maps.google.com/mapfiles/kml/paddle/ylw-stars-lv.png</href>
			                        </ItemIcon>
		                        </ListStyle>
	                        </Style>
	                        <Style id='sn_commemoration'>
		                        <IconStyle>
			                        <color>ff00ffff</color>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/paddle/ylw-stars.png</href>
			                        </Icon>
			                        <hotSpot x='32' y='1' xunits='pixels' yunits='pixels'/>
		                        </IconStyle>
		                        <LabelStyle>
			                        <color>00ffffff</color>
		                        </LabelStyle>
		                        <ListStyle>
			                        <ItemIcon>
				                        <href>http://maps.google.com/mapfiles/kml/paddle/ylw-stars-lv.png</href>
			                        </ItemIcon>
		                        </ListStyle>
	                        </Style>
	                        <StyleMap id='m_Commemoration'>
		                        <Pair>
			                        <key>normal</key>
			                        <styleUrl>#sn_commemoration</styleUrl>
		                        </Pair>
		                        <Pair>
			                        <key>highlight</key>
			                        <styleUrl>#sh_commemoration</styleUrl>
		                        </Pair>
	                        </StyleMap>";

                case CivilEventype.Justice:
                    return @"
	                        <Style id='sh_ViolentJustice'>
		                        <IconStyle>
			                        <color>ff0000ff</color>
			                        <scale>1.18182</scale>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png</href>
			                        </Icon>
			                        <hotSpot x='20' y='2' xunits='pixels' yunits='pixels'/>
		                        </IconStyle>
		                        <LabelStyle>
			                        <color>00ffffff</color>
		                        </LabelStyle>
	                        </Style>
	                        <Style id='sn_ViolentJustice'>
		                        <IconStyle>
			                        <color>ff0000ff</color>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png</href>
			                        </Icon>
			                        <hotSpot x='20' y='2' xunits='pixels' yunits='pixels'/>
		                        </IconStyle>
		                        <LabelStyle>
			                        <color>00ffffff</color>
		                        </LabelStyle>
	                        </Style>
                            <StyleMap id='m_ViolentJustice'>
		                        <Pair>
			                        <key>normal</key>
			                        <styleUrl>#sn_ViolentJustice</styleUrl>
		                        </Pair>
		                        <Pair>
			                        <key>highlight</key>
			                        <styleUrl>#sh_ViolentJustice</styleUrl>
		                        </Pair>
	                        </StyleMap>
                            <Style id='sh_justice'>
		                        <IconStyle>
			                        <color>ff00ffff</color>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png</href>
			                        </Icon>
			                        <hotSpot x='20' y='2' xunits='pixels' yunits='pixels'/>
		                        </IconStyle>
		                        <LabelStyle>
			                        <color>00ffffff</color>
		                        </LabelStyle>
	                        </Style>
	                        <Style id='sn_justice'>
		                        <IconStyle>
			                        <color>ff00ffff</color>
			                        <scale>1.18182</scale>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png</href>
			                        </Icon>
			                        <hotSpot x='20' y='2' xunits='pixels' yunits='pixels'/>
		                        </IconStyle>
		                        <LabelStyle>
			                        <color>00ffffff</color>
		                        </LabelStyle>
	                        </Style>
	                        <StyleMap id='m_Justice'>
		                        <Pair>
			                        <key>normal</key>
			                        <styleUrl>#sn_justice</styleUrl>
		                        </Pair>
		                        <Pair>
			                        <key>highlight</key>
			                        <styleUrl>#sh_justice</styleUrl>
		                        </Pair>
	                        </StyleMap>";

                case CivilEventype.Political:
                    return @"
	                        <Style id='sh_violentpolitical'>
		                        <IconStyle>
			                        <color>ff0000ff</color>
			                        <scale>1.86667</scale>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/shapes/open-diamond.png</href>
			                        </Icon>
		                        </IconStyle>
		                        <LabelStyle>
			                        <color>00ffffff</color>
		                        </LabelStyle>
		                        <ListStyle>
		                        </ListStyle>
	                        </Style><Style id='sn_violentpolitical'>
		                        <IconStyle>
			                        <color>ff0000ff</color>
			                        <scale>1.6</scale>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/shapes/open-diamond.png</href>
			                        </Icon>
		                        </IconStyle>
		                        <LabelStyle>
			                        <color>00ffffff</color>
		                        </LabelStyle>
		                        <ListStyle>
		                        </ListStyle>
	                        </Style>
	                        <StyleMap id='m_ViolentPolitical'>
		                        <Pair>
			                        <key>normal</key>
			                        <styleUrl>#sn_violentpolitical</styleUrl>
		                        </Pair>
		                        <Pair>
			                        <key>highlight</key>
			                        <styleUrl>#sh_violentpolitical</styleUrl>
		                        </Pair>
	                        </StyleMap>
	                        <Style id='sn_political'>
		                        <IconStyle>
			                        <color>ff00ffff</color>
			                        <scale>1.6</scale>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/shapes/open-diamond.png</href>
			                        </Icon>
		                        </IconStyle>
		                        <LabelStyle>
			                        <color>00ffffff</color>
		                        </LabelStyle>
		                        <ListStyle>
		                        </ListStyle>
	                        </Style>
	                        <Style id='sh_spolitical'>
		                        <IconStyle>
			                        <color>ff00ffff</color>
			                        <scale>1.86667</scale>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/shapes/open-diamond.png</href>
			                        </Icon>
		                        </IconStyle>
		                        <LabelStyle>
			                        <color>00ffffff</color>
		                        </LabelStyle>
		                        <ListStyle>
		                        </ListStyle>
	                        </Style>
	                        <StyleMap id='m_Political'>
		                        <Pair>
			                        <key>normal</key>
			                        <styleUrl>#sn_political</styleUrl>
		                        </Pair>
		                        <Pair>
			                        <key>highlight</key>
			                        <styleUrl>#sh_spolitical</styleUrl>
		                        </Pair>
	                        </StyleMap>";

                case CivilEventype.Security:
                    return @"
	                        <Style id='sn_ViolentSecurity'>
		                        <IconStyle>
			                        <color>ff0000ff</color>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/shapes/police.png</href>
			                        </Icon>
			                        <hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
		                        </IconStyle>
		                        <LabelStyle>
			                        <color>00ffffff</color>
		                        </LabelStyle>
	                        </Style>
	                        <Style id='sh_ViolentSecurity'>
		                        <IconStyle>
			                        <color>ff0000ff</color>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/shapes/police.png</href>
			                        </Icon>
			                        <hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
		                        </IconStyle>
		                        <LabelStyle>
			                        <color>00ffffff</color>
		                        </LabelStyle>
	                        </Style>
	                        <StyleMap id='m_ViolentSecurity'>
		                        <Pair>
			                        <key>normal</key>
			                        <styleUrl>#sn_ViolentSecurity</styleUrl>
		                        </Pair>
		                        <Pair>
			                        <key>highlight</key>
			                        <styleUrl>#sh_ViolentSecurity</styleUrl>
		                        </Pair>
	                        </StyleMap>
	                        <Style id='sn_Security'>
		                        <IconStyle>
			                        <color>ff00ffff</color>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/shapes/police.png</href>
			                        </Icon>
			                        <hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
		                        </IconStyle>
		                        <LabelStyle>
			                        <color>00ffffff</color>
		                        </LabelStyle>
	                        </Style>
	                        <Style id='sh_Security'>
		                        <IconStyle>
			                        <color>ff00ffff</color>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/shapes/police.png</href>
			                        </Icon>
			                        <hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
		                        </IconStyle>
		                        <LabelStyle>
			                        <color>00ffffff</color>
		                        </LabelStyle>
	                        </Style>
	                        <StyleMap id='m_Security'>
		                        <Pair>
			                        <key>normal</key>
			                        <styleUrl>#sn_Security</styleUrl>
		                        </Pair>
		                        <Pair>
			                        <key>highlight</key>
			                        <styleUrl>#sh_Security</styleUrl>
		                        </Pair>
	                        </StyleMap>";

                case CivilEventype.Socioeconomic:
                    return @"
	                        <Style id='sh_violentsoc'>
		                        <IconStyle>
			                        <color>ff0000ff</color>
			                        <scale>1.18182</scale>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/shapes/dollar.png</href>
			                        </Icon>
			                        <hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
		                        </IconStyle>
		                        <LabelStyle>
			                        <color>00ffffff</color>
		                        </LabelStyle>
	                        </Style>
	                        <Style id='sn_violentsoc'>
		                        <IconStyle>
			                        <color>ff0000ff</color>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/shapes/dollar.png</href>
			                        </Icon>
			                        <hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
		                        </IconStyle>
		                        <LabelStyle>
			                        <color>00ffffff</color>
		                        </LabelStyle>
	                        </Style>
	                        <StyleMap id='m_ViolentSocioeconomic'>
		                        <Pair>
			                        <key>normal</key>
			                        <styleUrl>#sn_violentsoc</styleUrl>
		                        </Pair>
		                        <Pair>
			                        <key>highlight</key>
			                        <styleUrl>#sh_violentsoc</styleUrl>
		                        </Pair>
	                        </StyleMap>
	                        <Style id='sh_dollar'>
		                        <IconStyle>
			                        <color>ff00ffff</color>
			                        <scale>1.18182</scale>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/shapes/dollar.png</href>
			                        </Icon>
			                        <hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
		                        </IconStyle>
		                        <LabelStyle>
			                        <color>00ffffff</color>
		                        </LabelStyle>
	                        </Style>
	                        <Style id='sn_dollar'>
		                        <IconStyle>
			                        <color>ff00ffff</color>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/shapes/dollar.png</href>
			                        </Icon>
			                        <hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
		                        </IconStyle>
		                        <LabelStyle>
			                        <color>00ffffff</color>
		                        </LabelStyle>
	                        </Style>
	                        <StyleMap id='m_Socioeconomic'>
		                        <Pair>
			                        <key>normal</key>
			                        <styleUrl>#sn_dollar</styleUrl>
		                        </Pair>
		                        <Pair>
			                        <key>highlight</key>
			                        <styleUrl>#sh_dollar</styleUrl>
		                        </Pair>
	                        </StyleMap>";

                case CivilEventype.Unknown:
                    return @"
	                        <Style id='sn_ViolentUnknown'>
		                        <IconStyle>
			                        <color>ff0000ff</color>
			                        <scale>0.8</scale>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/shapes/info_circle.png</href>
			                        </Icon>
			                        <hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
		                        </IconStyle>
		                        <LabelStyle>
			                        <color>00ffffff</color>
		                        </LabelStyle>
	                        </Style>
	                        <Style id='sh_ViolentUnknown'>
		                        <IconStyle>
			                        <color>ff0000ff</color>
			                        <scale>0.8</scale>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/shapes/info_circle.png</href>
			                        </Icon>
			                        <hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
		                        </IconStyle>
		                        <LabelStyle>
			                        <color>00ffffff</color>
		                        </LabelStyle>
	                        </Style>
	                        <StyleMap id='m_ViolentUnknown'>
		                        <Pair>
			                        <key>normal</key>
			                        <styleUrl>#sn_ViolentUnknown</styleUrl>
		                        </Pair>
		                        <Pair>
			                        <key>highlight</key>
			                        <styleUrl>#sh_ViolentUnknown</styleUrl>
		                        </Pair>
	                        </StyleMap>
	                        <Style id='sh_Unknown'>
		                        <IconStyle>
			                        <color>ff00ffff</color>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/shapes/info_circle.png</href>
			                        </Icon>
			                        <hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
		                        </IconStyle>
		                        <LabelStyle>
			                        <color>00ffffff</color>
		                        </LabelStyle>
	                        </Style>
	                        <Style id='sn_Unknown'>
		                        <IconStyle>
			                        <color>ff00ffff</color>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/shapes/info_circle.png</href>
			                        </Icon>
			                        <hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
		                        </IconStyle>
		                        <LabelStyle>
			                        <color>00ffffff</color>
		                        </LabelStyle>
	                        </Style>
                            <StyleMap id='m_Unknown'>
		                        <Pair>
			                        <key>normal</key>
			                        <styleUrl>#sn_Unknown</styleUrl>
		                        </Pair>
		                        <Pair>
			                        <key>highlight</key>
			                        <styleUrl>#sh_Unknown</styleUrl>
		                        </Pair>
	                        </StyleMap>";

                default:
                    return String.Empty;
            }
        }

        public string getStyle(string style)
        {
            return @"
	           	    <Style id='sn_RedMotorcycle'>
		            <IconStyle>
			            <color>cc0000ff</color>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/motorcycling.png</href>
			            </Icon>
			            <hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sh_RedMotorcycle'>
		            <IconStyle>
			            <color>cc0000ff</color>
			            <scale>1.16667</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/motorcycling.png</href>
			            </Icon>
			            <hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
				<StyleMap id='m_RedMotorcycle'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_RedMotorcycle</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_RedMotorcycle</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_RedSquare'>
		            <IconStyle>
			            <color>ff0000ff</color>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/square.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sh_RedSquare'>
		            <IconStyle>
			            <color>ff0000ff</color>
			            <scale>1.16667</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/square.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style> 
	            <StyleMap id='m_RedSquare'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_RedSquare</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_RedSquare</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_BlueTriangle'>
		            <IconStyle>
			            <color>ffff5500</color>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/triangle.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sh_BlueTriangle'>
		            <IconStyle>
			            <color>ffff5500</color>
			            <scale>1.16667</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/triangle.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <StyleMap id='m_BlueTriangle'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_BlueTriangle</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_BlueTriangle</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_RedTriangle'>
		            <IconStyle>
			            <color>ff0000ff</color>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/triangle.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sh_RedTriangle'>
		            <IconStyle>
			            <color>ff0000ff</color>
			            <scale>1.16667</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/triangle.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <StyleMap id='m_RedTriangle'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_RedTriangle</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_RedTriangle</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_RedPushpin'>
		            <IconStyle>
			            <color>ff0000ff</color>
			            <scale>1.1</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/pushpin/red-pushpin.png</href>
			            </Icon>
			            <hotSpot x='20' y='2' xunits='pixels' yunits='pixels'/>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style> 
	            <Style id='sh_RedPushpin'>
		            <IconStyle>
			            <color>ff0000ff</color>
			            <scale>1.3</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/pushpin/red-pushpin.png</href>
			            </Icon>
			            <hotSpot x='20' y='2' xunits='pixels' yunits='pixels'/>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <StyleMap id='m_RedPushpin'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_RedPushpin</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_RedPushpin</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_BluePin'>
		            <IconStyle>
			            <color>ffff5500</color>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/paddle/wht-diamond.png</href>
			            </Icon>
			            <hotSpot x='32' y='1' xunits='pixels' yunits='pixels'/>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
			            <ItemIcon>
				            <href>http://maps.google.com/mapfiles/kml/paddle/wht-diamond-lv.png</href>
			            </ItemIcon>
		            </ListStyle>
	            </Style>
	            <Style id='sh_BluePin'>
		            <IconStyle>
			            <color>ffff5500</color>
			            <scale>1.16667</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/paddle/wht-diamond.png</href>
			            </Icon>
			            <hotSpot x='32' y='1' xunits='pixels' yunits='pixels'/>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
			            <ItemIcon>
				            <href>http://maps.google.com/mapfiles/kml/paddle/wht-diamond-lv.png</href>
			            </ItemIcon>
		            </ListStyle>
	            </Style>     
	            <StyleMap id='m_BluePin'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_BluePin</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_BluePin</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_RedCaution'>
		            <IconStyle>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/caution.png</href>
			            </Icon>
			            <hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sh_RedCaution'>
		            <IconStyle>
			            <scale>1.16667</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/caution.png</href>
			            </Icon>
			            <hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <StyleMap id='m_RedCaution'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_RedCaution</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_RedCaution</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_BluePushpin'>
		            <IconStyle>
			            <color>ffff5555</color>
			            <scale>1.1</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/pushpin/blue-pushpin.png</href>
			            </Icon>
			            <hotSpot x='20' y='2' xunits='pixels' yunits='pixels'/>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sh_BluePushpin'>
		            <IconStyle>
			            <color>ffff5555</color>
			            <scale>1.3</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/pushpin/blue-pushpin.png</href>
			            </Icon>
			            <hotSpot x='20' y='2' xunits='pixels' yunits='pixels'/>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <StyleMap id='m_BluePushpin'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_BluePushpin</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_BluePushpin</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_BluedSquare'>
		            <IconStyle>
			            <color>ffff5500</color>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/square.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sh_BluedSquare'>
		            <IconStyle>
			            <color>ffff5500</color>
			            <scale>1.16667</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/square.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>	    
	            <StyleMap id='m_BlueSquare'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_BluedSquare</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_BluedSquare</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_YellowDollar'>
		            <IconStyle>
			            <color>ff00ffff</color>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/dollar.png</href>
			            </Icon>
			            <hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sh_YellowDollar'>
		            <IconStyle>
			            <color>ff00ffff</color>
			            <scale>1.16667</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/dollar.png</href>
			            </Icon>
			            <hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style> 
	            <StyleMap id='m_YellowDollar'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_YellowDollar</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_YellowDollar</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_YellowWoman'>
		            <IconStyle>
			            <color>ff00ffff</color>
			            <scale>1.2</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/woman.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sh_YellowWoman'>
		            <IconStyle>
			            <color>ff00ffff</color>
			            <scale>1.4</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/woman.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <StyleMap id='m_YellowWoman'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_YellowWoman</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_YellowWoman</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_YellowPushpin'>
		            <IconStyle>
			            <scale>1.1</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png</href>
			            </Icon>
			            <hotSpot x='20' y='2' xunits='pixels' yunits='pixels'/>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sh_YellowPushpin'>
		            <IconStyle>
			            <scale>1.3</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png</href>
			            </Icon>
			            <hotSpot x='20' y='2' xunits='pixels' yunits='pixels'/>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <StyleMap id='m_YellowPushpin'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_YellowPushpin</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_YellowPushpin</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_RedPin'>
		            <IconStyle>
			            <color>ff0000ff</color>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/paddle/wht-diamond.png</href>
			            </Icon>
			            <hotSpot x='32' y='1' xunits='pixels' yunits='pixels'/>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
			            <ItemIcon>
				            <href>http://maps.google.com/mapfiles/kml/paddle/wht-diamond-lv.png</href>
			            </ItemIcon>
		            </ListStyle>
	            </Style>
	            <Style id='sh_RedPin'>
		            <IconStyle>
			            <color>ff0000ff</color>
			            <scale>1.16667</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/paddle/wht-diamond.png</href>
			            </Icon>
			            <hotSpot x='32' y='1' xunits='pixels' yunits='pixels'/>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
			            <ItemIcon>
				            <href>http://maps.google.com/mapfiles/kml/paddle/wht-diamond-lv.png</href>
			            </ItemIcon>
		            </ListStyle>
	            </Style>
	            <StyleMap id='m_RedPin'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_RedPin</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_RedPin</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_BlueDot'>
		            <IconStyle>
			            <color>ffff0000</color>
			            <scale>1.2</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/shaded_dot.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sh_BlueDot'>
		            <IconStyle>
			            <color>ffff0000</color>
			            <scale>1.4</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/shaded_dot.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <StyleMap id='m_BlueDot'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_BlueDot</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_BlueDot</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_YellowMan'>
		            <IconStyle>
			            <color>ff00ffff</color>
			            <scale>1.16667</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/man.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sh_YellowMan'>
		            <IconStyle>
			            <color>ff00ffff</color>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/man.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <StyleMap id='m_YellowMan'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_YellowMan</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_YellowMan</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sh_BlueMotorcycle'>
		            <IconStyle>
			            <color>ccff382a</color>
			            <scale>1.16667</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/motorcycling.png</href>
			            </Icon>
			            <hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sn_BlueMotorcycle'>
		            <IconStyle>
			            <color>ccff382a</color>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/motorcycling.png</href>
			            </Icon>
			            <hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
				<StyleMap id='m_BlueMotorcycle'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_BlueMotorcycle</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_BlueMotorcycle</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_RedWoman'>
		            <IconStyle>
			            <color>ff0000ff</color>
			            <scale>1.2</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/woman.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sh_RedWoman'>
		            <IconStyle>
			            <color>ff0000ff</color>
			            <scale>1.4</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/woman.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <StyleMap id='m_RedWoman'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_RedWoman</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_RedWoman</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_BlueWoman'>
		            <IconStyle>
			            <color>ffff5500</color>
			            <scale>1.2</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/woman.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sh_BlueWoman'>
		            <IconStyle>
			            <color>ffff5500</color>
			            <scale>1.4</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/woman.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <StyleMap id='m_BlueWoman'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_BlueWoman</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_BlueWoman</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_YellowTriangle'>
		            <IconStyle>
			            <color>ff00ffff</color>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/triangle.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sh_YellowTriangle'>
		            <IconStyle>
			            <color>ff00ffff</color>
			            <scale>1.16667</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/triangle.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <StyleMap id='m_YellowTriangle'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_YellowTriangle</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_YellowTriangle</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_YellowDot'>
		            <IconStyle>
			            <color>ff00ffff</color>
			            <scale>1.2</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/shaded_dot.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sh_YellowDot'>
		            <IconStyle>
			            <color>ff00ffff</color>
			            <scale>1.4</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/shaded_dot.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <StyleMap id='m_YellowDot'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_YellowDot</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_YellowDot</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_RedDollar'>
		            <IconStyle>
			            <color>ff0000ff</color>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/dollar.png</href>
			            </Icon>
			            <hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sh_RedDollar'>
		            <IconStyle>
			            <color>ff0000ff</color>
			            <scale>1.16667</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/dollar.png</href>
			            </Icon>
			            <hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <StyleMap id='m_RedDollar'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_RedDollar</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_RedDollar</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_BlueMan'>
		            <IconStyle>
			            <color>ffff5500</color>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/man.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sh_BlueMan'>
		            <IconStyle>
			            <color>ffff5500</color>
			            <scale>1.16667</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/man.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <StyleMap id='m_BlueMan'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_BlueMan</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_BlueMan</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_GreenDot'>
		            <IconStyle>
			            <color>ff00aa00</color>
			            <scale>1.2</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/shaded_dot.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sh_GreenDot'>
		            <IconStyle>
			            <color>ff00aa00</color>
			            <scale>1.4</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/shaded_dot.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <StyleMap id='m_GreenDot'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_GreenDot</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_GreenDot</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_GreenPushpin'>
		            <IconStyle>
			            <color>ff00aa00</color>
			            <scale>1.1</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/pushpin/grn-pushpin.png</href>
			            </Icon>
			            <hotSpot x='20' y='2' xunits='pixels' yunits='pixels'/>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sh_GreenPushpin'>
		            <IconStyle>
			            <color>ff00aa00</color>
			            <scale>1.3</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/pushpin/grn-pushpin.png</href>
			            </Icon>
			            <hotSpot x='20' y='2' xunits='pixels' yunits='pixels'/>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <StyleMap id='m_GreenPushpin'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_GreenPushpin</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_GreenPushpin</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_RedDot'>
		            <IconStyle>
			            <color>ff0000ff</color>
			            <scale>1.2</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/shaded_dot.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sh_RedDot'>
		            <IconStyle>
			            <color>ff0000ff</color>
			            <scale>1.4</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/shaded_dot.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <StyleMap id='m_RedDot'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_RedDot</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_RedDot</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_YellowPin'>
		            <IconStyle>
			            <color>ff00ffff</color>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/paddle/wht-diamond.png</href>
			            </Icon>
			            <hotSpot x='32' y='1' xunits='pixels' yunits='pixels'/>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
			            <ItemIcon>
				            <href>http://maps.google.com/mapfiles/kml/paddle/wht-diamond-lv.png</href>
			            </ItemIcon>
		            </ListStyle>
	            </Style>
	            <Style id='sh_YellowPin'>
		            <IconStyle>
			            <color>ff00ffff</color>
			            <scale>1.16667</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/paddle/wht-diamond.png</href>
			            </Icon>
			            <hotSpot x='32' y='1' xunits='pixels' yunits='pixels'/>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
			            <ItemIcon>
				            <href>http://maps.google.com/mapfiles/kml/paddle/wht-diamond-lv.png</href>
			            </ItemIcon>
		            </ListStyle>
	            </Style>
				<StyleMap id='m_YellowPin'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_YellowPin</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_YellowPin</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_YellowSquare'>
		            <IconStyle>
			            <color>ff00ffff</color>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/square.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sh_YellowSquare'>
		            <IconStyle>
			            <color>ff00ffff</color>
			            <scale>1.16667</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/square.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
				<StyleMap id='m_YellowSquare'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_YellowSquare</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_YellowSquare</styleUrl>
		            </Pair>
	            </StyleMap>
	            <Style id='sn_RedMan'>
		            <IconStyle>
			            <color>ff0000ff</color>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/man.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <Style id='sh_RedMan'>
		            <IconStyle>
			            <color>ff0000ff</color>
			            <scale>1.16667</scale>
			            <Icon>
				            <href>http://maps.google.com/mapfiles/kml/shapes/man.png</href>
			            </Icon>
		            </IconStyle>
		            <LabelStyle>
			            <color>00ffffff</color>
		            </LabelStyle>
		            <ListStyle>
		            </ListStyle>
	            </Style>
	            <StyleMap id='m_RedMan'>
		            <Pair>
			            <key>normal</key>
			            <styleUrl>#sn_RedMan</styleUrl>
		            </Pair>
		            <Pair>
			            <key>highlight</key>
			            <styleUrl>#sh_RedMan</styleUrl>
		            </Pair>
	            </StyleMap>";
        }
    }
}

