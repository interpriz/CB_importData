using System;
using System.Xml.Serialization;

namespace CB_importData.Models
{
    public class InitialED
    {
        public int Id { get; set; }

        [XmlAttribute("EDNo")]
        public int EDNo { get; set; }

        [XmlAttribute("EDDate")]
        public string EDDate { get; set; }

        [XmlAttribute("EDAuthor")]
        public Int64 EDAuthor { get; set; }
    }
}
