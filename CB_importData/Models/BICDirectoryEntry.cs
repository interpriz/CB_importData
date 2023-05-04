using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CB_importData.Models
{


    public class BICDirectoryEntry
    {
        public int Id { get; set; }

        public ED807 ED807 { get; set; }

        [XmlAttribute("BIC")]
        public int BIC { get; set;}

        [XmlAttribute("ChangeType")]
        public string ChangeType { get; set;}

        [XmlElement("ParticipantInfo")]
        public ParticipantInfo participantInfo { get; set; }

        [XmlElement("SWBICS")]
        public List<SWBICS> SWBICS { get; set; }

        [XmlElement("Accounts")]
        public List<Accounts> accounts { get; set; }

    }
}
