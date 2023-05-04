using System.Collections.Generic;
using System.Xml.Serialization;

namespace CB_importData.Models
{
    public class Accounts
    {
        public int Id { get; set; }
        public BICDirectoryEntry bICDirectoryEntry { get; set; }

        [XmlAttribute("Account")]
        public string Account { get; set; }

        [XmlAttribute("RegulationAccountType")]
        public string RegulationAccountType { get; set; }

        [XmlAttribute("CK")]
        public string CK { get; set; }

        [XmlAttribute("AccountCBRBIC")]
        public int AccountCBRBIC { get; set; }

        [XmlAttribute("DateIn")]
        public string DateIn { get; set; }

        [XmlAttribute("DateOut")]
        public string DateOut { get; set; }

        [XmlAttribute("AccountStatus")]
        public string AccountStatus { get; set; }

        [XmlElement("AccRstrList")]
        public List<AccRstrList> accRstrList { get; set; }


    }
}
