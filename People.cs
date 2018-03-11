using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.IO;
using System.Xml.Serialization;

namespace Testing_File___Serialisation
{
    [Serializable()]
    public class People : ISerializable
    {
        [NonSerialized]
        public Guid id;
        [XmlAttribute]
        public string first_name;
        public string last_name;
        public string email;
        public string gender;
        public string ip_address;

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("first_name", this.first_name);
            info.AddValue("last_name", this.last_name);
            info.AddValue("email", this.email);
            info.AddValue("gender", this.gender);
            info.AddValue("ip_address", this.ip_address);
        }

        public People()
        {

        }

        public People(SerializationInfo info, StreamingContext ctxt)
        {
            //this.id = info.GetValue("id", typeof(Guid)).ToString();
            this.first_name = info.GetValue("first_name", typeof(string)).ToString();
            this.last_name = info.GetValue("last_name", typeof(string)).ToString();
            this.email = info.GetValue("email", typeof(string)).ToString();
            this.gender = info.GetValue("gender", typeof(string)).ToString();
            this.ip_address = info.GetValue("ip_address", typeof(string)).ToString();
                    
        }

        //Save Instance to file:
        public void Persist(string filename)
        {
            using (var stream = new FileStream(filename, FileMode.Create))
            {
                //Overwrite existing file:
                XmlSerializer XML = new XmlSerializer(typeof(People));
                XML.Serialize(stream, this);
            }
        }

        //Load from file:
        public static People LoadFromFile(string filename)
        {
            using (var stream = new FileStream(filename, FileMode.Open))
            {
                //Overwrite existing file:
                XmlSerializer XML = new XmlSerializer(typeof(People));
                return (People)XML.Deserialize(stream);
            }
        }
    }
}
