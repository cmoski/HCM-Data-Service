using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;

[DataContract(Name = "XMLSerialized")]
public class XMLSerialized
{
    public string XmlSerialize<TSource>()
    {
        string retStr = string.Empty;
        try
        {
            XmlSerializer serXml = new XmlSerializer(typeof(TSource));
            StringWriter strWriter = new StringWriter();
            serXml.Serialize(strWriter, this);
            retStr = strWriter.ToString();
            strWriter.Close();
        }
        catch { }

        return retStr;
    }

    public static TSource XmlDeSerialize<TSource>(string value)
    {
        object ret = null;
        if (value != string.Empty)
            try
            {
                XmlSerializer serXml = new XmlSerializer(typeof(TSource));
                StringReader strReader = new StringReader(value);
                ret = serXml.Deserialize(strReader);
                strReader.Close();
            }
            catch { }
        return (TSource)ret;
    }
}

