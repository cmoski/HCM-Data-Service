using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace HCM401kData
{
    [XmlRoot()]
    public class ChartColorsSet
    {

        [XmlElement()]
        public string HEXUpColor
        {
            get { return ConvertColorToHexString(System.Windows.Media.Color.FromArgb(UpColor.A, UpColor.R, UpColor.G, UpColor.B)); }
            set
            {
                Color setVal = Colors.Green;
                System.Windows.Media.Color cVal = ConvertColorFromHexString(value);
                setVal = Color.FromArgb(cVal.A, cVal.R, cVal.G, cVal.B);
                UpColor = setVal;
            }

        }
        [XmlIgnore()]
        public Color UpColor { get; set; }
        [XmlElement()]
        public string HEXDownColor
        {
            get { return ConvertColorToHexString(System.Windows.Media.Color.FromArgb(DownColor.A, DownColor.R, DownColor.G, DownColor.B)); }
            set
            {
                Color setVal = Colors.Green;
                System.Windows.Media.Color cVal = ConvertColorFromHexString(value);
                setVal = Color.FromArgb(cVal.A, cVal.R, cVal.G, cVal.B);
                DownColor = setVal;
            }

        }
        [XmlIgnore()]
        public Color DownColor { get; set; }
        [XmlElement()]
        public string HEXVolumeColor
        {
            get { return ConvertColorToHexString(System.Windows.Media.Color.FromArgb(VolumeColor.A, VolumeColor.R, VolumeColor.G, VolumeColor.B)); }
            set
            {
                Color setVal = Colors.Green;
                System.Windows.Media.Color cVal = ConvertColorFromHexString(value);
                setVal = Color.FromArgb(cVal.A, cVal.R, cVal.G, cVal.B);
                VolumeColor = setVal;
            }

        }
        [XmlIgnore()]
        public Color VolumeColor { get; set; }
        [XmlElement()]
        public string HEXTextsColor
        {
            get { return ConvertColorToHexString(System.Windows.Media.Color.FromArgb(TextsColor.A, TextsColor.R, TextsColor.G, TextsColor.B)); }
            set
            {
                Color setVal = Colors.Green;
                System.Windows.Media.Color cVal = ConvertColorFromHexString(value);
                setVal = Color.FromArgb(cVal.A, cVal.R, cVal.G, cVal.B);
                TextsColor = setVal;
            }

        }
        [XmlIgnore()]
        public Color TextsColor { get; set; }
        [XmlElement()]
        public string HEXPanelTopColor
        {
            get { return ConvertColorToHexString(System.Windows.Media.Color.FromArgb(PanelTopColor.A, PanelTopColor.R, PanelTopColor.G, PanelTopColor.B)); }
            set
            {
                Color setVal = Colors.Green;
                System.Windows.Media.Color cVal = ConvertColorFromHexString(value);
                setVal = Color.FromArgb(cVal.A, cVal.R, cVal.G, cVal.B);
                PanelTopColor = setVal;
            }

        }
        [XmlIgnore()]
        public Color PanelTopColor { get; set; }
        [XmlElement()]
        public string HEXPanelBottomColor
        {
            get { return ConvertColorToHexString(System.Windows.Media.Color.FromArgb(PanelBottomColor.A, PanelBottomColor.R, PanelBottomColor.G, PanelBottomColor.B)); }
            set
            {
                Color setVal = Colors.Green;
                System.Windows.Media.Color cVal = ConvertColorFromHexString(value);
                setVal = Color.FromArgb(cVal.A, cVal.R, cVal.G, cVal.B);
                PanelBottomColor = setVal;
            }

        }
        [XmlIgnore()]
        public Color PanelBottomColor { get; set; }
        [XmlElement()]
        public string HEXPanelGridColor
        {
            get { return ConvertColorToHexString(System.Windows.Media.Color.FromArgb(PanelGridColor.A, PanelGridColor.R, PanelGridColor.G, PanelGridColor.B)); }
            set
            {
                Color setVal = Colors.Green;
                System.Windows.Media.Color cVal = ConvertColorFromHexString(value);
                setVal = Color.FromArgb(cVal.A, cVal.R, cVal.G, cVal.B);
                PanelGridColor = setVal;
            }

        }
        [XmlIgnore()]
        public Color PanelGridColor { get; set; }
        [XmlElement()]
        public string HEXCrosshairColor
        {
            get { return ConvertColorToHexString(System.Windows.Media.Color.FromArgb(CrosshairColor.A, CrosshairColor.R, CrosshairColor.G, CrosshairColor.B)); }
            set
            {
                Color setVal = Colors.Green;
                System.Windows.Media.Color cVal = ConvertColorFromHexString(value);
                setVal = Color.FromArgb(cVal.A, cVal.R, cVal.G, cVal.B);
                CrosshairColor = setVal;
            }

        }
        [XmlIgnore()]
        public Color CrosshairColor { get; set; }
        [XmlElement()]
        public string HEXYAxesColor
        {
            get { return ConvertColorToHexString(System.Windows.Media.Color.FromArgb(YAxesColor.A, YAxesColor.R, YAxesColor.G, YAxesColor.B)); }
            set
            {
                Color setVal = Colors.Green;
                System.Windows.Media.Color cVal = ConvertColorFromHexString(value);
                setVal = Color.FromArgb(cVal.A, cVal.R, cVal.G, cVal.B);
                YAxesColor = setVal;
            }

        }
        [XmlIgnore()]
        public Color YAxesColor { get; set; }
        [XmlElement()]
        public string HEXCalendarColor
        {
            get { return ConvertColorToHexString(System.Windows.Media.Color.FromArgb(CalendarColor.A, CalendarColor.R, CalendarColor.G, CalendarColor.B)); }
            set
            {
                Color setVal = Colors.Green;
                System.Windows.Media.Color cVal = ConvertColorFromHexString(value);
                setVal = Color.FromArgb(cVal.A, cVal.R, cVal.G, cVal.B);
                CalendarColor = setVal;
            }

        }
        [XmlIgnore()]
        public Color CalendarColor { get; set; }

        [XmlElement()]
        public string HEXClosingPriceColor
        {
            get { return ConvertColorToHexString(System.Windows.Media.Color.FromArgb(ClosingPriceColor.A, ClosingPriceColor.R, ClosingPriceColor.G, ClosingPriceColor.B)); }
            set
            {
                Color setVal = Colors.Green;
                System.Windows.Media.Color cVal = ConvertColorFromHexString(value);
                setVal = Color.FromArgb(cVal.A, cVal.R, cVal.G, cVal.B);
                ClosingPriceColor = setVal;
            }

        }
        [XmlIgnore()]
        public Color ClosingPriceColor { get; set; }


        private string ConvertColorToHexString(Color aColor)
        {
            String retStr = String.Empty;

            retStr = aColor.A.ToString("X2") +
                     aColor.R.ToString("X2") +
                     aColor.G.ToString("X2") +
                     aColor.B.ToString("X2");
            return retStr;
        }

        private Color ConvertColorFromHexString(string val)
        {
            val.ToLower();
            Color c = Color.FromArgb(0, 0, 0, 0);

            byte a = System.Convert.ToByte(val.Substring(0, 2), 16);
            byte r = System.Convert.ToByte(val.Substring(2, 2), 16);
            byte g = System.Convert.ToByte(val.Substring(4, 2), 16);
            byte b = System.Convert.ToByte(val.Substring(6, 2), 16);
            c = Color.FromArgb(a, r, g, b);
            return c;
        }

    }
}
