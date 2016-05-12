using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Xml.Serialization;
using System.Runtime.Serialization;


[XmlRoot()]
[DataContract(Name = "WCFBarData")]
public class WCFBarData : XMLSerialized
{
    [DataMember(Name = "ID")]
    [XmlAttribute()]
    public string ID { get; set; }
    [DataMember(Name = "Symbol")]
    [XmlAttribute()]
    public string Symbol { get; set; }
    [DataMember(Name = "Data")]
    [XmlElement()]
    public List<WCFBar> Data { get; set; }
}

[XmlRoot()]
[DataContract(Name = "WCFBar")]
public class WCFBar
{
    [DataMember(Name = "Open")]
    [XmlAttribute()]
    public double Open { get; set; }
    [DataMember(Name = "High")]
    [XmlAttribute()]
    public double High { get; set; }
    [DataMember(Name = "Low")]
    [XmlAttribute()]
    public double Low { get; set; }
    [DataMember(Name = "Close")]
    [XmlAttribute()]
    public double Close { get; set; }
    [DataMember(Name = "Volume")]
    [XmlAttribute()]
    public double Volume { get; set; }
    [DataMember(Name = "TimeStamp")]
    [XmlIgnore()]
    public DateTime TimeStamp { get; set; }
    [XmlAttribute()]
    public string TimeStampString
    {
        get
        {
            return TimeStamp.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
        }
        set
        {
            DateTime tstamp = DateTime.MinValue;
            DateTime.TryParseExact(value, "M/d/yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out tstamp);
            TimeStamp = tstamp;
        }
    }
}
