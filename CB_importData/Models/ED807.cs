using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CB_importData.Models
{
    public class ED807
    {

        public int Id { get; set; }

        [XmlAttribute("EDNo")]
        public int EDNo { get; set; }

        [XmlAttribute("EDDate")]
        public string EDDate { get; set; }

        [XmlAttribute("EDAuthor")]
        public Int64 EDAuthor { get; set; }

        [XmlAttribute("EDReceiver")]
        public Int64 EDReceiver { get; set; }

        [XmlAttribute("CreationReason")]
        public string CreationReason { get; set; }

        [XmlAttribute("CreationDateTime")]
        public string CreationDateTime { get; set; }

        [XmlAttribute("InfoTypeCode")]
        public string InfoTypeCode { get; set; }

        [XmlAttribute("BusinessDay")]
        public string BusinessDay { get; set; }

        [XmlAttribute("DirectoryVersion")]
        public int DirectoryVersion { get; set; }

        [XmlElement("PartInfo")]
        public List<PartInfo> partInfo { get; set; }

        [XmlElement("InitialED")]
        public InitialED initialED { get; set; }

        [XmlElement("BICDirectoryEntry")]
        public List<BICDirectoryEntry> bICDirectoryEntry { get; set; }

    }
}
