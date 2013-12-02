using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StartupSelector.Helpers
{
    public static class Serializer
    {
        [Serializable]
        public class SerializationException : Exception
        {
            public SerializationException()
            {
            }

            public SerializationException(string message) : base(message)
            {
            }

            public SerializationException(string message, Exception inner) : base(message, inner)
            {
            }

            protected SerializationException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }

        public static T DeserializeXml<T>(string xml) where T : class
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                using (TextReader reader = new StringReader(xml))
                {
                    var result = (T)serializer.Deserialize(reader);
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new SerializationException(string.Format("Falied to deserialize '{0}'", typeof(T).Name), e);
            }
        }

        public static string SerializeXml<T>(T obj) where T : class
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                var textWriter = new StringWriter();
                xmlSerializer.Serialize(textWriter, obj);
                return textWriter.ToString();
            }
            catch (Exception e)
            {
                throw new SerializationException(string.Format("Falied to serialize '{0}'", typeof(T).Name), e);
            }
        }
    }
}
