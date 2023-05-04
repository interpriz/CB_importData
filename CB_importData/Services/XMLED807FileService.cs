using CB_importData.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
//using System.Text.Encoding.CodePages.dll;

namespace CB_importData.Services
{
    class XMLED807FileService : IFileService<ED807>
    {
        public List<ED807> Open(string filename)
        {
            List<ED807> records = new List<ED807>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ED807));

            // десериализуем объект
            // восстановление массива из файла
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                ED807? newRecords = xmlSerializer.Deserialize(fs) as ED807;

                if (newRecords != null)
                {
                    records.Add(newRecords);
                }
            }

            return records;
        }

        public void Save(string filename, List<ED807> records)
        {
            // передаем в конструктор тип класса
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ED807));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, records[0]);

                Console.WriteLine("Object has been serialized");
            }
        }

        public void Validation(string filename)
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(null, "DataFiles/20230428_ED807_full.xsd");//   //C:/JOB/ЦБ C# тестовое/UFEBS_v2023_4_1/XMLSchemas/ed/cbr_ed807_v2023.4.0.xsd

            XDocument document = XDocument.Load(filename);

            try
            {
                document.Validate(schemas, null);
            }
            catch (XmlSchemaValidationException ex)
            {
                throw;
            }

        }
    }
}
