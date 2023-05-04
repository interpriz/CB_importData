using System.Xml.Serialization;

namespace CB_importData.Models
{
    public class AccRstrList
    {
        public int Id { get; set; }

        [XmlAttribute("AccRstr")]
        public string AccRstr { get; set; }

        [XmlAttribute("AccRstrDate")]
        public string AccRstrDate { get; set; }

        [XmlAttribute("SuccessorBIC")]
        public int SuccessorBIC { get; set; }
    }
}
