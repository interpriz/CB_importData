using System.Xml.Serialization;

namespace CB_importData.Models
{
    public class PartInfo
    {
        public int Id { get; set; }

        [XmlAttribute("PartNo")]
        public int PartNo { get; set; }

        [XmlAttribute("PartQuantity")]
        public int PartQuantity { get; set; }

        [XmlAttribute("PartAggregateID")]
        public string PartAggregateID { get; set; }
    }
}
