using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using CB_importData.Models;

namespace CB_importData.Services
{
    internal class XMLUsersFileService : IFileService<User>
    {
        public List<User> Open(string filename)
        {
            List<User> users = new List<User>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(User[]));

            // десериализуем объект
            // восстановление массива из файла
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                User[]? newUsers = xmlSerializer.Deserialize(fs) as User[];

                if (newUsers != null)
                {
                    foreach (User user in newUsers)
                    {
                        Console.WriteLine($"Name: {user.Name} --- Age: {user.Age}");
                    }
                    users.AddRange(newUsers);
                }
            }

            return users;
        }

        public void Save(string filename, List<User> usersList)
        {
            // передаем в конструктор тип класса Person
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(User[]));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, usersList.ToArray());

                Console.WriteLine("Object has been serialized");
            }
        }

        public void Validation(string filename)
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(null, "DataFiles/test_data.xsd"); //"DataFiles/test_data.xsd"

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
