using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CB_importData.Models
{
    public class ParticipantInfo
    {
        public int Id { get; set; }

        [XmlAttribute("NameP")]
        public string NameP { get; set; }

        [XmlAttribute("EnglName")]
        public string EnglName { get; set; }

        [XmlAttribute("RegN")]
        public string RegN { get; set; }

        [XmlAttribute("CntrCd")]
        public string CntrCd { get; set; }

        [XmlAttribute("Rgn")]
        public string Rgn { get; set; }

        [XmlAttribute("Ind")]
        public string Ind { get; set; }

        [XmlAttribute("Tnp")]
        public string Tnp { get; set; }

        [XmlAttribute("Nnp")]
        public string Nnp { get; set; }

        [XmlAttribute("Adr")]
        public string Adr { get; set; }

        [XmlAttribute("PrntBIC")]
        public int PrntBIC { get; set; }

        [XmlAttribute("DateIn")]
        public string DateIn { get; set;}

        [XmlAttribute("DateOut")]
        public string DateOut { get; set; }

        [XmlAttribute("PtType")]
        public string PtType { get; set; }

        [XmlAttribute("Srvcs")]
        public string Srvcs { get; set; }

        [XmlAttribute("XchType")]
        public string XchType { get; set; }

        [XmlAttribute("UID")]
        public Int64 UID { get; set; }

        [XmlAttribute("ParticipantStatus")]
        public string ParticipantStatus { get; set; }

        [XmlElement("RstrList")]
        public List<RstrList> rstrList { get; set; }

    }
}
