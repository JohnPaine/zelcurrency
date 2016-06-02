//#region References

//using System;
//using System.IO;
//using System.Text;
//using System.Web;
//using System.Xml;
//using System.Xml.Schema;
//using System.Xml.Serialization;
//using Currency.Caching;

//#endregion

//namespace Currency.Configuration
//{
//    public static class ConfigHelper
//    {
//        private static XmlReaderSettings XmlReaderSettings
//        {
//            get
//            {
//                return new XmlReaderSettings
//                {
//                    CheckCharacters = false,
//                    CloseInput = true,
//                    ConformanceLevel = ConformanceLevel.Document,
//                    DtdProcessing = DtdProcessing.Ignore,
//                    IgnoreComments = true,
//                    IgnoreProcessingInstructions = false,
//                    IgnoreWhitespace = true,
//                    ValidationFlags = XmlSchemaValidationFlags.AllowXmlAttributes,
//                    ValidationType = ValidationType.None
//                };
//            }
//        }

//        private static XmlWriterSettings XmlWriterSettings
//        {
//            get
//            {
//                return new XmlWriterSettings
//                {
//                    CheckCharacters = false,
//                    CloseOutput = true,
//                    ConformanceLevel = ConformanceLevel.Document,
//                    Encoding = Encoding.UTF8,
//                    Indent = true,
//                    IndentChars = "\t",
//                    NamespaceHandling = NamespaceHandling.OmitDuplicates,
//                    NewLineChars = "\r\n",
//                    NewLineHandling = NewLineHandling.Replace,
//                    NewLineOnAttributes = false,
//                    OmitXmlDeclaration = false
//                };
//            }
//        }

//        public static T Read<T>(bool cached = true) where T : class
//        {
//            return ReadConfigFromFile<T>(GetFilePath(typeof (T)), cached);
//        }

//        private static T ReadConfigFromFile<T>(string filename, bool cached = true) where T : class
//        {
//            return cached
//                ? CacheHelper.Get(filename, ReadConfigFromFileInternal<T>)
//                : ReadConfigFromFileInternal<T>(filename);
//        }

//        private static T ReadConfigFromFileInternal<T>(string filename) where T : class
//        {
//            using (var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
//            {
//                return ReadConfigFromStream<T>(fileStream);
//            }
//        }

//        public static bool Write<T>(T config, bool cache = true) where T : class
//        {
//            return WriteConfigToFile(config, GetFilePath(typeof (T)), cache);
//        }

//        private static bool WriteConfigToFile<T>(T config, string filename, bool cache = true) where T : class
//        {
//            if (cache)
//            {
//                CacheHelper.Remove(filename);
//            }

//            if (config == null)
//            {
//                return false;
//            }

//            var changedValue = true;

//            using (var fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
//            {
//                try
//                {
//                    WriteConfigToStream(config, fileStream);
//                }
//                catch (Exception)
//                {
//                    changedValue = false;
//                }
//            }

//            return changedValue;
//        }

//        private static T ReadConfigFromStream<T>(Stream stream) where T : class
//        {
//            using (var reader = XmlReader.Create(stream, XmlReaderSettings))
//            {
//                var xmlSerializer = new XmlSerializer(typeof (T));
//                return (T) xmlSerializer.Deserialize(reader);
//            }
//        }

//        private static void WriteConfigToStream<T>(T config, Stream stream) where T : class
//        {
//            using (var writer = XmlWriter.Create(stream, XmlWriterSettings))
//            {
//                var xmlSerializer = new XmlSerializer(typeof (T));
//                xmlSerializer.Serialize(writer, config);
//            }
//        }

//        private static string GetFilePath(Type type)
//        {
//            return HttpContext.Current.Server.MapPath(string.Format("~/{0}.config", type.Name));
//        }
//    }
//}