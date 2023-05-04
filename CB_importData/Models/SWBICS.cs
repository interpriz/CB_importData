using System.Xml.Serialization;

namespace CB_importData.Models
{
    public class SWBICS
    {
        public int Id { get; set; }

        [XmlAttribute("SWBICS")]
        public string swbics { get; set; }

        [XmlAttribute("DefaultSWBIC")]
        public string DefaultSWBIC { get; set; }
        
    }
}
