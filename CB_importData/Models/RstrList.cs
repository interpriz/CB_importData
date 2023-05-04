using System.Xml.Serialization;

namespace CB_importData.Models
{
    public class RstrList
    {
        public int Id { get; set; }

        [XmlAttribute("Rstr")]
        public string Rstr { get; set; }

        [XmlAttribute("RstrDate")]
        public string RstrDate { get; set; }
}
}
